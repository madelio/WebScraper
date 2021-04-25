using System.Collections.Generic;
using WebScraperScript.src.WebScraper.Models;

namespace WebScraperScript.WebScraper.Services
{
    /// <summary>
    ///  TODO: if output filename doesn't exist, just return the text
    ///  TODO: does the same streamwriter get reused if it's coming from the same object? imo it does
    /// </summary>
    public interface ISiteScanner
    {
        public void SaveHtmlToFile(string url, string outputFilename);
        public void SaveHtmlToFile(string[] urls, string outputFilename);
        public SiteData GetSiteData(string url);
        public List<SiteData> GetSiteData(string[] urls);
    }
}
