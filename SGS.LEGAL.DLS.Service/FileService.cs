using SGS.LEGAL.DLS.Entity;
using SGS.LIB.Common;
using System.Diagnostics;

namespace SGS.LEGAL.DLS.Service
{
    public class FileService : BaseService
    {
        /// <summary>
        /// 暫存檔完整路徑
        /// </summary>
        private string _tempFullPath;
        /// <summary>
        /// 暫存路徑，預設為專案中資料夾 temp
        /// </summary>
        private string _tempPath;
        /// <summary>
        /// 備份路徑
        /// </summary>
        private string _backupPath;
        /// <summary>
        /// 發布路徑
        /// </summary>
        private string _publishPath;
        /// <summary>
        /// 遠端路徑 (下載用)
        /// </summary>
        private string _remoteFullPath;

        /// <summary>
        /// 備份檔案名稱
        /// 預設等同暫存檔案名稱
        /// </summary>
        public string BackupFileName
        {
            get { return Path.GetFileName(this._tempFullPath); }
            set { }
        }
        /// <summary>
        /// 發布檔案名稱
        /// 暫存檔案名稱去除時間戳記
        /// </summary>
        public string PublishFileName
        {
            get
            {
                string fileName = Path.GetFileNameWithoutExtension(this._tempFullPath);
                string extension = Path.GetExtension(this._tempFullPath);
                return $"{fileName[..^15]}{extension}"; // 等同於 fileName.Substring(0, fileName.Length - 15)
            }
            set { }
        }

        public string BackupFullPath => Path.Combine(_backupPath, BackupFileName);
        public string PublishFullPath => Path.Combine(_publishPath, PublishFileName);
        public string TempFullPath => Path.Combine(_tempPath, Path.GetFileName(this._remoteFullPath));

        private Impersonator? imp = default;

        /// <summary>
        /// 如需要特殊權限，可另行帶入指定AD帳號密碼
        /// 指定AD帳號密碼非必填，但缺一不可
        /// </summary>
        /// <param name="user">系統使用者</param>
        /// <param name="impUserId">指定AD帳號</param>
        /// <param name="impUserPwd">指定AD帳號密碼</param>
        public FileService(SYS_USER? user, string? impUserId = null, string? impUserPwd = null) : base(user)
        {
            if (impUserId != null && impUserPwd != null)
            {
                imp = new Impersonator(impUserId, impUserPwd);
            }
        }
        /// <summary>
        /// 可帶入特殊權限AD帳號
        /// </summary>
        /// <param name="user">系統使用者</param>
        /// <param name="impersonator">AD身分轉換類別</param>
        public FileService(SYS_USER? user, Impersonator? impersonator) : base(user)
        {
            if (impersonator != null)
            {
                imp = impersonator;
            }
        }

        /// <summary>
        /// 設定暫存檔完整路徑
        /// </summary>
        /// <param name="tempFullPath">暫存檔路徑，含副檔名</param>
        public FileService SetTempFullPath(string tempFullPath)
        {
            _tempFullPath = tempFullPath;
            
            return this;
        }

        /// <summary>
        /// 設定暫存路徑(資料夾)，檢查路徑如不存在自動建立
        /// </summary>
        public FileService SetTempPath(string tempPath)
        {
            CreateDirectory(tempPath);
            _tempPath = tempPath;
            return this;
        }

        /// <summary>
        /// 設定備份路徑(資料夾)，檢查路徑如不存在自動建立
        /// </summary>
        public FileService SetBackupPath(string backupPath)
        {
            CreateDirectory(backupPath);
            _backupPath = backupPath;
            return this;
        }

        /// <summary>
        /// 設定發布路徑(資料夾)，檢查路徑如不存在自動建立
        /// </summary>
        public FileService SetPublishPath(string publishPath)
        {
            CreateDirectory(publishPath);
            _publishPath = publishPath;
            return this;
        }

        /// <summary>
        /// 設定遠端路徑(資料夾)，下載用
        /// </summary>
        public FileService SetRemoteFullPath(string remoteFullPath)
        {
            _remoteFullPath = remoteFullPath;
            return this;
        }

        /// <summary>
        /// 檢查並建立資料夾，不存在會自動建立
        /// 包含身分轉換判斷，如已設定會自動轉換
        /// </summary>
        /// <param name="path">要(檢查並)建立的路徑</param>
        private void CreateDirectory(string path)
        {
            if (imp != default)
                imp.Run(() => { Directory.CreateDirectory(path); });
            else
                Directory.CreateDirectory(path);
        }

        /// <summary>
        /// 備份檔案
        /// </summary>
        private void Backup()
        {
            File.Copy(_tempFullPath, BackupFullPath, true);
        }

        /// <summary>
        /// 發布檔案
        /// </summary>
        /// <param name="IsBackup">是否進行備份</param>
        /// <param name="IsRemoveTemp">是否刪除暫存檔</param>
        private FileService doPublish(bool IsBackup = true, bool IsRemoveTemp = true)
        {
            File.Copy(_tempFullPath, PublishFullPath, true);

            if (IsBackup)
                Backup();

            if (IsRemoveTemp)
                File.Delete(_tempFullPath);

            return this;
        }
        /// <summary>
        /// 切換AD帳號發布檔案，權限不夠的時候使用
        /// </summary>
        /// <param name="IsBackup">是否進行備份</param>
        /// <param name="IsRemoveTemp">是否刪除暫存檔</param>
        public FileService Publish(bool IsBackup = true, bool IsRemoveTemp = true)
        {
            if (imp != default)
                imp.Run(() => { doPublish(IsBackup, IsRemoveTemp); });
            else
                doPublish(IsBackup, IsRemoveTemp);
            return this;
        }

        /// <summary>
        /// 執行下載
        /// </summary>
        private FileService doDownload()
        {
            File.Copy(_remoteFullPath, this.TempFullPath, true);
            return this;
        }

        /// <summary>
        /// 下載檔案供檢視
        /// </summary>
        public FileService Download()
        {
            if (imp != default)
                imp.Run(() => { doDownload(); });
            else
                doDownload();
            return this;
        }

        /// <summary>
        /// 將來源檔案複製到下載資料夾
        /// </summary>
        /// <param name="SourceFullPath">來源檔案完整路徑</param>
        /// <returns>下載資料夾路徑</returns>
        public string CopyFileToDownload(string SourceFullPath)
        {
            // 目標下載資料夾路徑
            string downloadFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
            // 確保目標資料夾存在，如果不存在則建立它
            Directory.CreateDirectory(downloadFolderPath);
            // 組合目標檔案的完整路徑
            string targetFullPath = Path.Combine(downloadFolderPath, Path.GetFileName(SourceFullPath));
            // 複製檔案
            File.Copy(SourceFullPath, targetFullPath, true);

            return targetFullPath;
        }
    }
}
