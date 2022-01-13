using HtmlAgilityPack;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using WebScraperScript.WebScraper.Models;
using System.Text.RegularExpressions;

namespace WebScraperScript.WebScraper.Services
{
    public class SiteScanner : ISiteScanner
    {
        public async Task<SiteData> GetSiteData(string url)
        {
            var page = await new HtmlWeb().LoadFromWebAsync(url);
            var nodes = page.DocumentNode?.Descendants();

            var sb = new StringBuilder();
            foreach (var currNode in nodes)
            {
                sb.AppendLine(currNode.InnerHtml);
            }

            return new SiteData()
            {
                Url = url,
                RawHtmlContent = sb.ToString()
            };
        }

        public async Task<MangaSiteResponse> GetMangaInfo(string mangagoUrl)
        {
            var page = await new HtmlWeb().LoadFromWebAsync(mangagoUrl);
            var titleNode = page.DocumentNode.SelectSingleNode("//table[contains(@id, 'chapter_table')]/tbody/tr/td");
            var title = titleNode?.InnerText.Replace("\n","").Replace("\t","");

            var imageNode  = page.DocumentNode.SelectSingleNode("//div[contains(@class, 'cover')]/img");
            var imageUrl = imageNode.GetAttributeValue("src", null);

            return new MangaSiteResponse()
            {
                LatestChapter = title,
                Image = imageUrl
            };
        }

        public async Task SaveHtmlToFile(string url, string outputFilename) {
            var siteData = await GetSiteData(url);
            new StreamWriter(outputFilename).WriteLine(siteData?.RawHtmlContent);
        }
    }
}
