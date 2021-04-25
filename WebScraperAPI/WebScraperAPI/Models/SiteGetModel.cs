using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScraperAPI.Models
{
    public class SiteGetModel
    {
        public string Url { get; set; }
        public SiteGetModel()
        {
            Console.WriteLine("ended up here");
        }
        public SiteGetModel (string url)
        {
            Url = url;
        }
    }
}
