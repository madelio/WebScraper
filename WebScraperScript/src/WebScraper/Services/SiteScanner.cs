using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text;

namespace WebScraperScript.WebScraper.Services
{
    public class SiteScanner : ISiteScanner
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseSavedHtmlFolder;
        private StreamWriter _outputFile;

        public SiteScanner(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseSavedHtmlFolder = _configuration["BaseSavedHtmlFolder"];
        }
        public SiteScanner()
        {
        }

        public string GetRawHtml(string url)
        {
            var scraper = new HtmlWeb();
            var page = scraper.Load(url);
            var nodes = page.DocumentNode.Descendants();

            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"Results for url: {url}");
            foreach (var currNode in nodes)
            {
                var headline = currNode.InnerHtml;
                sb.AppendLine(headline);
            }
            return sb.ToString();
        }

        public string GetRawHtml(string[] urls)
        {
            var sb = new System.Text.StringBuilder();
            foreach (var url in urls)
            {
                sb.AppendLine(GetRawHtml(url));
            }
            return sb.ToString();
        }

        public void SaveHtmlToFile(string url, string outputFilename) {
            var scraper = new HtmlWeb();
            var page = scraper.Load(url);
            var nodes = page.DocumentNode.Descendants();

            if (_outputFile == null)
            {
                _outputFile = new StreamWriter(_baseSavedHtmlFolder + outputFilename + ".html");
            }
            _outputFile.WriteLine($"Results for url: {url}");
            foreach (var currNode in nodes)
            {
                var headline = currNode.InnerHtml;
                _outputFile.WriteLine(headline);
            }
        }

        public void SaveHtmlToFile(string[] urls, string outputFileName) {
            foreach (var url in urls)
            {
                SaveHtmlToFile(url, outputFileName);
            }
        }
    }
}
