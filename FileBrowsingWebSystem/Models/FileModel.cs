using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace FileBrowsingWebSystem.Models
{
    public class FileModel
    {
        public int FilesLess10 { get; set; }
        public int FilesOthers { get; set; }
        public int FilesMore100 { get; set; }
        private int _MB = 1024*1024;

        public FileModel(string path)
        {
            Init(path);
        }

        public void Init(string path)
        {
            //count all files on all hds
            if (path.Equals("server"))
            {
                foreach (var drive in Directory.GetLogicalDrives())
                {
                    CountOfFiles(drive);
                }
            }
            else //count files in path
            {
                CountOfFiles(path);
            }
        }

        private void CountOfFiles(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            var files = dir.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if (file.Length < 10 * _MB)
                    FilesLess10++;
                else if (file.Length > 100 * _MB)
                    FilesMore100++;
                else
                    FilesOthers++;
            }
        }
    }
}