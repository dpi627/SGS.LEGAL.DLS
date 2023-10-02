@echo off
:: Code Page 改為英文
chcp 850
:: 要安裝(複製)的專案名稱(目錄名稱)
set "projectName=SGS.LEGAL.DLS"
:: 執行檔名稱(通常等於專案名稱)
set "fileName=%projectName%"
:: 複製來源
set "sourceDir=\\twfs007\SGSSHARE\OAD\Brian\_Publish"
:: 安裝目標
set "targetDir=C:\SGSLIMS"
:: 完整複製來源路徑
set "sourcePath=%sourceDir%\%projectName%"
:: 完整安裝目標路徑
set "targetPath=%targetDir%\%projectName%"
:: 完整安裝目標檔案路徑，捷徑指向使用
set "targetFile=%targetPath%\%fileName%.exe"
:: 產生捷徑的路徑
set "shortcutPath=%userprofile%\Desktop\%fileName%"
set "logDir=%targetDir%\Log\%projectName%"
set "logFile=%logDir%\%DATE:~3,4%%DATE:~8,2%%DATE:~11,2%.log"

REM 建立 log 檔案所在的目錄
if not exist "%logDir%" (
    mkdir "%logDir%"
    echo Log directory %logDir% created
)

robocopy %sourcePath% %targetPath% /mir /tee /r:1 /w:0 /log+:%logFile%

if not exist "%shortcutPath%" (
    mklink "%shortcutPath%" "%targetFile%"
    echo Shortcut %fileName% created on Desktop
)

echo Press any key to exit...
pause > nul