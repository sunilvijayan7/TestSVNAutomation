using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace TestSVNAutomate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter SVN URL : ");
            string svnPath = Console.ReadLine();

            Console.Write("SVN Username : ");
            string username = Console.ReadLine();
            Console.Write("SVN Password : ");
            string pwd = Console.ReadLine();

            Console.Write("Local path to pull code from SVN : ");
            string path = Console.ReadLine();

            Console.Write(@" Installation path of SVN[Default:C:\Program Files\TortoiseSVN\bin] : ");
            string installPath = Console.ReadLine();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (String.IsNullOrEmpty(installPath))
            {
                installPath = @"C:\Program Files\TortoiseSVN\bin";
            }
            DownloadSVNCode(path, svnPath, username, pwd,installPath);
            Console.ReadLine();
        }
        private static void DownloadSVNCode(string phyPath, string svnUrl, string uname, string pwd,string svnInstallPath)
        {
            string arguments = " checkout " + svnUrl + " " + phyPath + "  --username " + uname + " --password " + pwd;
            ProcessStartInfo info = new ProcessStartInfo("svn.exe", arguments);
            info.WorkingDirectory = svnInstallPath;
            info.WindowStyle = ProcessWindowStyle.Normal;
            Process.Start(info);
            Console.WriteLine("Download Started");
        }

    }
}
