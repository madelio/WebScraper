
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebScraperScript.WebScraper.Services;

namespace WebScraperScript
{
    class Program
    {
        public static async Task Main(string[] args)
        {

            Console.WriteLine("Start Scraping!");
     
            var baseFolder = "../../../WebScraper/SavedHtmlPages/";
            await new SiteScanner().SaveHtmlToFile("http://zenhabits.com/", baseFolder + "zenhabits.html");
            await new SiteScanner().SaveHtmlToFile("https://www.york.ac.uk/teaching/cws/wws/webpage1.html", baseFolder + "york.html");
            await new SiteScanner().SaveHtmlToFile("https://www.google.com/", baseFolder + "google.html");

            Console.WriteLine("End Scraping!");
        }
    }
}