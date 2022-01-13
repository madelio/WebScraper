
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using WebScraperScript.WebScraper.Services;

namespace WebScraperScript
{
    class Program
    {
        public static async Task Main(string[] args)
        {

            Console.WriteLine("Start Scraping!");
     
            var baseFolder = "C:/Users/Madel/Projects/WebScraper/WebScraperScript/";

            var mangas = new MangaProcessor().GetMangaListFromFile("C:/Users/madel/Projects/WebScraper/ManwhaList-20211201.txt", baseFolder + "rejected.txt");
  
            using (StreamWriter streamWriter = new StreamWriter(baseFolder + "updated.txt"))
            {
                var updatedWorks = 0;
                /** print ON TEXT **/

                //foreach (var manga in mangas)
                //{
                //    Console.WriteLine($"Checking if updated - {manga.Title}...");
                //    manga.LatestChapter = await new SiteScanner().GetLatestChapterTitle(manga.Url);
                //    var latestChUpperCase = manga.LatestChapter.Trim().Replace(" ", "").Replace(".", "").Replace("new", "").ToUpper();
                //    var currentChUpperCase = manga.CurrentChapter.Trim().Replace(" ", "").Replace(".", "").ToUpper();

                //    manga.IsUpdated = !latestChUpperCase.Equals(currentChUpperCase, StringComparison.OrdinalIgnoreCase);
                //    if (manga.IsUpdated)
                //    {
                //        updatedWorks = updatedWorks + 1;
                //        streamWriter.WriteLine(updatedWorks + ". " + manga.Title);
                //        streamWriter.WriteLine("Latest Chapter: " + manga.LatestChapter);
                //        streamWriter.WriteLine("Current Chapter: " + manga.CurrentChapter);
                //        streamWriter.WriteLine($"UPDATED! Read now here: {manga.Url}");
                //        streamWriter.WriteLine();

                //    }
                //}

                /** print JSON **/
                foreach (var manga in mangas)
                {
                    updatedWorks = updatedWorks + 1;
                    Console.WriteLine($"Checking if updated - {manga.Title}...");
                    var mangaInfo  = await new SiteScanner().GetMangaInfo(manga.Url);

                    manga.Id = updatedWorks;
                    manga.LatestChapter = mangaInfo.LatestChapter;
                    manga.ImageUrl = mangaInfo.Image;

                    var latestChUpperCase = manga.LatestChapter.Trim().Replace(" ", "").Replace(".", "").Replace("new", "").ToUpper();
                    var currentChUpperCase = manga.CurrentChapter.Trim().Replace(" ", "").Replace(".", "").ToUpper();

                    manga.IsUpdated = !latestChUpperCase.Equals(currentChUpperCase, StringComparison.OrdinalIgnoreCase);
                }

                var jsonMangaList = JsonSerializer.Serialize(mangas);
                streamWriter.WriteLine(jsonMangaList);

            }


            //await new SiteScanner().SaveHtmlToFile("https://www.mangago.me/read-manga/tamen_di_gushi/", baseFolder + "tamen_di_gushi.html");
            //await new SiteScanner().SaveHtmlToFile("https://www.york.ac.uk/teaching/cws/wws/webpage1.html", baseFolder + "york.html");
            //await new SiteScanner().SaveHtmlToFile("https://www.google.com/", baseFolder + "google.html");

            Console.WriteLine("End Scraping!");
        }
    }
}