using System;
using System.IO;

class Program{
    static void Main(string[] args)
    {
        var p = "FileList.wxs";
        File.WriteAllText(p, File.ReadAllText(p)
            .Replace("SourceDir", "..\\properties2csharp-win32-x64")
            .Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "")
            .Replace("\n<Wix xmlns=\"http://schemas.microsoft.com/wix/2006/wi\">", "<Include>")
            .Replace("\r\n<Wix xmlns=\"http://schemas.microsoft.com/wix/2006/wi\">", "<Include>")
            .Replace("</Wix>", "</Include>")
            );
    }
} 