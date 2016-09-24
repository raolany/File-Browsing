using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Routing;
using FileBrowsingWebSystem.Models;

namespace FileBrowsingWebSystem.Controllers
{
    public class DirectoryController : ApiController
    {
        public DirectoryModel Get()
        {
            return new DirectoryModel("server");
        }

        public DirectoryModel Get([FromUri]string path)
        {
            return new DirectoryModel(path);
        }

        [Route("api/directory/getfiles")]
        public FileModel GetFiles([FromUri]string path)
        {
            return new FileModel(path);
        }
    }
}
