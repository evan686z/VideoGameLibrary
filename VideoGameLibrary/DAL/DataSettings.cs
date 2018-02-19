using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoGameLibrary.DAL
{
    public class DataSettings
    {
        public string dataFilePath = HttpContext.Current.Server.MapPath("~/App_Data/VideoGameData.xml");
    }
}