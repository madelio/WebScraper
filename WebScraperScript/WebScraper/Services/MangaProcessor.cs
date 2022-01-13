using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using WebScraperScript.WebScraper.Models;

namespace WebScraperScript.WebScraper.Services
{
    public class MangaProcessor
    {
        public List<Manga> GetMangaListFromFile(string mangaFile, string rejectedFileName)
        {
            var rejectedWorks = new StreamWriter(rejectedFileName);
            var validManga = new List<Manga>();

            var lines = File.ReadAllLines(mangaFile);
            foreach(var line in lines)
            {
                var urlMatch = Regex.Match(line, @"https:\/\/www.mangago.me\/read-manga\/[a-zA-Z0-9_.-]+\/");

                if (urlMatch.Success)
                {
                    string[] delimitedLine = line.Split("-", 3);
        
                    validManga.Add(new Manga()
                    {
                        Title = delimitedLine[0].Trim(),
                        CurrentChapter = delimitedLine[1].Trim(),
                        Url = urlMatch.Value,
                        SourceSite = MangaSite.Mangago
                    });
                } else
                {
                    rejectedWorks.WriteLine(line);
                }
            }
            return validManga;
        }

    }
}
