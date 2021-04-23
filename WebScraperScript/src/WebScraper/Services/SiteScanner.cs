using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebScraperScript.WebScraper.Services
{
    public class SiteScanner : ISiteScanner
    {
        private readonly string baseSavedHtmlFolder = "C:/Users/madel/Desktop/Projects/WebScraperChallenge/WebScraperScript/src/WebScraper/SavedHtmlPages/";
        public void SaveHtmlToFile(string url, string outputFilename) {
            var scraper = new HtmlWeb();
            var page = scraper.Load(url);
            var nodes = page.DocumentNode.Descendants();

            using StreamWriter file = new StreamWriter(baseSavedHtmlFolder + outputFilename + ".html");

            foreach (var currNode in nodes)
            {
                var headline = currNode.InnerHtml;
                file.WriteLine(headline);
            }
        }

        public void SaveHtmlToFile(string[] urls) { 

        }
    }
}
