using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebScraperScript.src.WebScraper.Models;

namespace WebScraperScript.WebScraper.Services
{
    public class SiteScanner : ISiteScanner
    {
 
        public SiteScanner()
        {
        }

        public SiteData GetSiteData(string url)
        {
            var scraper = new HtmlWeb();
            var page = scraper.Load(url);
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

        public List<SiteData> GetSiteData(string[] urls)
        {
            var allSiteData = new List<SiteData>();
            foreach (var url in urls)
            {
                allSiteData.Add(GetSiteData(url));
            }

            return allSiteData;
        }

        public void SaveHtmlToFile(string url, string outputFilename) {
            var siteData = GetSiteData(url);
            var outputFile = new StreamWriter(outputFilename);
            outputFile.WriteLine($"Results for url: {siteData.Url}");
            outputFile.WriteLine(siteData.RawHtmlContent);
        }

        /// <summary>
        ///  /
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="outputFilename"></param>
        public void SaveHtmlToFile(string[] urls, string outputFilename) {
            var allSiteData = GetSiteData(urls);
            var outputFile = new StreamWriter(outputFilename);
            foreach (var siteData in allSiteData)
            {
                outputFile.WriteLine($"Results for url: {siteData.Url}");
                outputFile.WriteLine(siteData.RawHtmlContent);
            }
        }
    }
}
