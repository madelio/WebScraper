using HtmlAgilityPack;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebScraperScript.WebScraper.Models;

namespace WebScraperScript.WebScraper.Services
{
    public class SiteScanner : ISiteScanner
    {
        public async Task<SiteData> GetSiteData(string url)
        {
            var scraper = new HtmlWeb();
            var page = await scraper.LoadFromWebAsync(url);
            var nodes = page.DocumentNode.Descendants();

            var sb = new StringBuilder();
            foreach (var currNode in nodes)
            {
                var headline = currNode.InnerHtml;
                sb.AppendLine(headline);
            }

            return new SiteData()
            {
                Url = url,
                RawHtmlContent = sb.ToString()
            };
        }

        public async Task SaveHtmlToFile(string url, string outputFilename) {
            var siteData = await GetSiteData(url);
            new StreamWriter(outputFilename).WriteLine(siteData.RawHtmlContent);
        }
    }
}
