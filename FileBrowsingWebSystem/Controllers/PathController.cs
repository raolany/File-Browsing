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
using FileBrowsingWebSystem.Models;

namespace FileBrowsingWebSystem.Controllers
{
    public class PathController : ApiController
    {
        //string rootpath = HostingEnvironment.MapPath("/");

        public DirectoryModel Get()
        {
            return new DirectoryModel("/");
        }

        public DirectoryModel Get([FromUri]string path)
        {
            return new DirectoryModel(path);
        }

        /*// POST: api/Path
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Path/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Path/5
        public void Delete(int id)
        {
        }*/
    }
}
