@ECHO OFF

candle Product.wxs -out installer.wixobj
light installer.wixobj -ext WixUIExtension -ext WixUtilExtension.dll -out Properties2CSharp.msi
insignia -im Properties2CSharp.msi