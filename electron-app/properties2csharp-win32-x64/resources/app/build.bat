@ECHO OFF
@REM set variables
set pth=./
set app_name=Properties2CSharp
set win_icon=icon.ico
set mac_icon=icon.icns

@REM delete installer file
cd wixInstaller
del Properties2CSharp.msi

cd ..
@REM build the apps
@REM echo building mac
@REM call electron-packager %pth% %app_name% --out=dist/osx --platform=darwin --arch=x64 --icon=%mac_icon%
@REM echo building win32
@REM call electron-packager %pth% %app_name% --platform=win32 --arch=ia32 --icon=%win_icon%
@REM echo bulding win64
call electron-packager %pth% %app_name% --platform=win32 --arch=x64 --icon=%win_icon%