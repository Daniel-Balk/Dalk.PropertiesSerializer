@ECHO OFF
del Properties2CSharp.msi
del rep.exe
call cs.bat
del Properties2CSharp.wixpdb
del FileList.wxs
call scanDir.bat
call build.bat
echo Build finished
del Properties2CSharp.wixpdb
del installer.wixobj
pause