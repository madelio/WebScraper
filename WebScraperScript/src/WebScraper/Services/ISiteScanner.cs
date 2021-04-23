using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraperScript.WebScraper.Services
{
    public interface ISiteScanner
    {
        public void SaveHtmlToFile(string url, string outputFilename);
        public void SaveHtmlToFile(string[] urls);
    }
}
