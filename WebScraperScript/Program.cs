using System;
using WebScraperScript.WebScraper.Services;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebScraperScript
{
    class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .AddEnvironmentVariables()
             .AddCommandLine(args)
             .Build();

            Console.WriteLine("Start Scraping!");
            var scanner = new SiteScanner(configuration);
            //scanner.SaveHtmlToFile("https://www.york.ac.uk/teaching/cws/wws/webpage1.html", "tryThisOne");
            string[] urls = { "https://www.york.ac.uk/teaching/cws/wws/webpage1.html", "https://stackoverflow.com/questions/574911/difference-between-windows-and-console-application" };
            // scanner.SaveHtmlToFile(urls, "moreThanOne");
            var result = scanner.GetRawHtml(urls);
            Console.WriteLine(result);
            Console.WriteLine("End Scraping!");
        }
    }
}
