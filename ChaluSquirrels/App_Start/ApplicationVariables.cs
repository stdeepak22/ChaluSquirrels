using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ChaluSquirrels
{
    public class ApplicationVariables
    {

        public static ChaluSquirrelsSection Config { get; set; }

        public static List<string> HeaderKeywords { get; set; }

        public static List<string> HeaderMenus { get; set; }




        public static void LoadAll()
        {
            Config = ConfigurationManager.GetSection("ChaluSquirrels") as ChaluSquirrelsSection;
            //HeaderBigImage = ConfigurationManager.AppSettings["Header:BigImage"];

            //HeaderKeywords = ConfigurationManager.AppSettings["Header:Keywords"]
            //                .Split(',', ';')
            //                .Where(c => c.Length > 0)
            //                .Select(c => c.Trim())
            //                .ToList();
            //HeaderMenus = ConfigurationManager.AppSettings["Header:Menus"]
            //                .Split(',', ';')
            //                .Where(c => c.Length > 0)
            //                .Select(c => c.Trim())
            //                .ToList();
            
        }
    }
}