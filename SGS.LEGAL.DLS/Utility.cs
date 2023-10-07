using Aspose.Pdf;
using Microsoft.VisualBasic.ApplicationServices;
using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Printing;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Interop;

namespace SGS.LEGAL.DLS
{
    internal class Utility
    {
        /// <summary>
        /// 在 Panel 內實體化表單 Form T
        /// </summary>
        /// <typeparam name="T">表單類別 Form Type</typeparam>
        /// <param name="panel">指定 Panel</param>
        public static void ShowForm<T>(ref Panel panel) where T : Form, new()
        {
            #region 檢查主面板是否存在控制項，或未儲存設定表單
            if (panel.Controls.Count > 0)
            {
                if (IsUnsaveSettings(ref panel))
                {
                    MessageBox.Show("設定已變更，請先儲存", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    panel.Controls["frmSettings"].Show();
                    return;
                }
                panel.Controls.Clear();
            }
            #endregion

            // 生成指定型別的表單物件
            T form = new()
            {
                // 設定表單屬性
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Size = new Size(680, 550),
                Dock = DockStyle.Fill
            };
            // 將表單加入到主面板中
            panel.Controls.Add(form);
            // 顯示表單
            form.Show();
        }

        /// <summary>
        /// 判斷是否存在 "未儲存之設定表單"
        /// </summary>
        /// <param name="panel"></param>
        /// <returns></returns>
        public static bool IsUnsaveSettings(ref Panel panel, string formName = "frmSetting")
        {
            //if (panel.Controls.ContainsKey(formName))
            //    return panel.Controls[formName] is frmSetting frm && frm.IsModify;

            return false;
        }

        /// <summary>
        /// 判斷檔案是否已存在 Grid
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool IsExists(ref DataGridView grid, string file)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow || row.Index < 0)
                    continue;
                //Debug.WriteLine(row.GetType());
                if (row.Cells["FilePath"].Value.ToString() == file)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 取得目錄路徑
        /// </summary>
        /// <returns></returns>
        public static string GetFolderPath(string description = "選擇資料夾")
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = description;
                folderDialog.SelectedPath = @"";

                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    return folderDialog.SelectedPath;
                }
                return "";
            }
        }

        /// <summary>
        /// 取得檔案路徑
        /// </summary>
        /// <returns></returns>
        public static string GetFilePath(string description = "選擇檔案")
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.Title = description;
            openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            return openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileName : "";
        }

        /// <summary>
        /// 取得目前登入 LDAP 使用者資料
        /// </summary>
        /// <returns></returns>
        public static UserPrincipal? GetCurrentAdUser()
        {
            try
            {
                // 取得目前執行程式的使用者身分識別
                WindowsIdentity currentIdentity = WindowsIdentity.GetCurrent();
                // 使用使用者身分識別來建立使用者主體物件
                UserPrincipal currentUser = new UserPrincipal(new PrincipalContext(ContextType.Domain))
                {
                    SamAccountName = currentIdentity.Name.Split('\\')[1] // 取得使用者名稱
                };
                // 使用使用者主體物件來進行查詢
                PrincipalSearcher searcher = new PrincipalSearcher(currentUser);
                UserPrincipal user = (UserPrincipal)searcher.FindOne();
                return user;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 傳入集合，制定欄位名稱，將其中路徑之 pdf 檔案合併
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="colName">欄位名稱，預設 FilePath</param>
        /// <returns></returns>
        public static Document MergePDF(DataGridViewRowCollection rows, string colName = "FilePath")
        {
            // 合併後的 pdf
            Document pdfMerge = new();
            // 單一檔案路徑
            string? file = string.Empty;
            foreach (DataGridViewRow row in rows)
            {
                // 非資料列跳過
                if (row.IsNewRow || row.Index < 0)
                    continue;
                // 取得單一檔案路徑
                file = row.Cells[colName].Value.ToString();
                // 建立單一 pdf
                using Document pdf = new(file);
                // 合併 pdf
                pdfMerge.Pages.Add(pdf.Pages);
            }
            return pdfMerge;
        }
        /// <summary>
        /// 傳入檔案路徑，將之合併
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public static Document MergePDF(string[] files)
        {
            Document pdfMerge = new();
            foreach (string file in files)
            {
                using Document pdf = new(file);
                pdfMerge.Pages.Add(pdf.Pages);
            }
            return pdfMerge;
        }

        /// <summary>
        /// 設定 ComboBox，選項來源為參數檔
        /// </summary>
        /// <param name="ccb">控制項</param>
        /// <param name="parameterClass">指定參數檔類別</param>
        public static void SetComboBox(
            ref ComboBox ccb,
            string parameterClass,
            bool addDefultOption = false,
            string defaultOptionText = "請選擇...",
            string defaultOptionValue = ""
            )
        {
            using SysParamService svc = new(null);
            var list = svc.Get(parameterClass);
            if (addDefultOption)
                list?.Insert(0, new SYS_PARAM() { P_TXT = defaultOptionText, P_VAL = defaultOptionValue });

            ccb.DataSource = list;
            ccb.DisplayMember = "P_TXT";
            ccb.ValueMember = "P_VAL";
        }

        public static void WaitUntilJobsDone(string printerName)
        {
            PrintQueue printQueue = new(new PrintServer(), printerName);
            bool allCompleted = false;

            while (!allCompleted)
            {
                PrintJobInfoCollection jobs = printQueue.GetPrintJobInfoCollection();
                allCompleted = true;

                foreach (PrintSystemJobInfo job in jobs)
                {
                    if (job.JobStatus != PrintJobStatus.Completed)
                    {
                        allCompleted = false;
                        break;
                    }
                }

                if (!allCompleted)
                    Thread.Sleep(500);
            }
            //return allCompleted;
        }

        /// <summary>
        /// 顯示簡易警告訊息
        /// </summary>
        public static bool ShowMsg(string msg, string title = "系統訊息", MessageBoxIcon icon = MessageBoxIcon.Warning, bool vaildResult = false)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, icon);
            return vaildResult; //通常都是失敗才顯示警告，預設回傳 false
        }

        /// <summary>
        /// 嚴正文字輸入，並回傳結果
        /// 未填寫顯示警告
        /// </summary>
        /// <param name="txt">TextBox</param>
        /// <param name="rePattern">Regular Expression 字串</param>
        /// <param name="title">訊息抬頭</param>
        /// <param name="icon">訊息圖示</param>
        /// <returns>驗證結果，通過 true，失敗 false</returns>
        public static bool IsVaild(ref TextBox txt, string rePattern = "", string title = "系統訊息", MessageBoxIcon icon = MessageBoxIcon.Warning)
        {
            // 有填寫，且未指定正規表示式，直接通過
            if (!string.IsNullOrEmpty(txt.Text.Trim()) && string.IsNullOrEmpty(rePattern))
                return true;

            // 未填寫，顯示警告
            if (string.IsNullOrEmpty(txt.Text.Trim()))
            {
                MessageBox.Show($"請填寫 {txt.PlaceholderText}", title, MessageBoxButtons.OK, icon);
                txt.Focus();
                return false;
            }
            
            // 有填寫，且指定正規表示式，但不符合，顯示警告
            if (!string.IsNullOrEmpty(rePattern) && !Regex.IsMatch(txt.Text.Trim(), rePattern))
            {
                MessageBox.Show($"{txt.PlaceholderText} 格式錯誤", title, MessageBoxButtons.OK, icon);
                txt.Focus();
                return false;
            }

            return true;
        }


    }
}