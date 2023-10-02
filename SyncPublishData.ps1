# 專案若透過 ClieckOnce 直接部署到主機太慢，ClickOnce 也不會回報進度
# 改用以下指令同步，在使用 ClickOnce 部署後，將發布資料同步到遠端主機
# 使用終端機執行 .\SyncPublishData.ps1

# 使用英文 (避免輸出訊息與沒有對齊，要看中文就註解此行)
chcp 850

# 取得專案目錄
# Split-Path 切割路徑，參數 Leaf 可取回最後一個元素(即目錄名稱)
# $PSScriptRoot 取得當下目錄完整路徑
$prj = Split-Path -Path $PSScriptRoot -Leaf
# 來源路徑，預設專案部署路徑
$src = "$prj\bin\publish\"
# 目標路徑，通常是 FileServer，方便分享給 BU
$dst = "\\twfs007\SGSSHARE\OAD\Brian\_Publish\$prj\"
# 記錄檔
$log = "robocopy.log"
# 使用 robocopy 複製
# /E：複製包含子目錄的所有檔案和資料夾
# /XO：僅複製新增或更新的檔案，忽略目標目錄中已經存在且更新時間相同的檔案
# /TEE：輸出訊息到主控台與log
robocopy $src $dst /E /XO /TEE /LOG:$log
# 複製完畢顯示路徑 (必要時可複製)
Write-Output "$dst`n"