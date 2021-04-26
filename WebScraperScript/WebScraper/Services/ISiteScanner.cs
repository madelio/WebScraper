using System.Threading.Tasks;
using WebScraperScript.WebScraper.Models;

namespace WebScraperScript.WebScraper.Services
{
    public interface ISiteScanner
    {
        public Task<SiteData> GetSiteData(string url);
        public Task SaveHtmlToFile(string url, string outputFilename);
    }
}
