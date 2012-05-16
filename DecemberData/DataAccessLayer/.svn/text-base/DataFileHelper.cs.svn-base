using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Configuration;

namespace DecemberData.DataAccessLayer
{
    internal class DataFileHelper
    {
        /// <summary>
        /// Path to the folder containing the data files
        /// </summary>
        internal static string FilePath
        {
            get
            {
                string setting = ConfigurationManager.AppSettings["DataFilePath"];

                if (setting == null)
                    throw new Exception(@"The following appSetting is required: <appSettings><add key='DataFilePath' value='C:\Projects\December\DecemberWeb\Data\' /></appSettings>");

                if (HttpContext.Current != null)
                {
                    //Web environment - run Map Path
                    setting = HttpContext.Current.Server.MapPath(setting);
                }

                return setting;
            }
        }

        /// <summary>
        /// Full Path to the xml data file, including the file name. 
        /// </summary>
        internal static string FullPath(string id)
        {
            return Path.Combine(FilePath, id + ".xml"); 
        }
    }
}
