using System;

namespace ImdbWebScraper
{
    public class IMDBFilm
    {
        public IMDBFilm(string title, string imdbId)
        {
            Title = title;
            ImdbId = imdbId;
        }
        public string Title {get; set;}

        public string ImdbId {get; set;}
    }
}