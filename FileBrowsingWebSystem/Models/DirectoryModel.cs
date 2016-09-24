using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace FileBrowsingWebSystem.Models
{
    public class DirectoryModel
    {
        public string Path { get; set; }
        public List<string> PathList { get; set; }
        public List<string> Dirs { get; set; }
        public List<string> Files { get; set; }

        public DirectoryModel(string path)
        {
            Dirs = new List<string>();
            Files = new List<string>();
            PathList = path.Equals("server") ? new List<string>() : new List<string>(path.Split('/'));
            Init(path);
        }

        public void Init(string path)
        {
            Path = path;

            //all hds
            if (Path.Equals("server"))
            {
                var drvrs = Directory.GetLogicalDrives();
                Dirs = new List<string>(drvrs);
                return;
            }

            //files and dirs on hd
            DirectoryInfo dir = new DirectoryInfo(Path);
            foreach (var catalog in dir.GetDirectories())
            {
                Dirs.Add(catalog.Name);
            }
            foreach (var file in dir.GetFiles())
            {
                Files.Add(file.Name);
            }
        }

    }
}