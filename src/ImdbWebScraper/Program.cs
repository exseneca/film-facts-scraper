using System;
using System.Net.Http;
using Newtonsoft.Json;
using HtmlAgilityPack;


namespace ImdbWebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            // api key
            string apiKey = //insert api key;
            Console.WriteLine("Please enter a film to search for: ");
            string searchInput = Console.ReadLine();
            HttpClient client = new HttpClient();
            // post request to api
            var searchOutput = HelperFunctions.SearchTitle(searchInput, apiKey, client);
            // to json
            dynamic obj = JsonConvert.DeserializeObject(searchOutput);
            var SearchResults = obj.Search;
            int resultCounter = 1;
            foreach(var result in SearchResults)
            {
                Console.WriteLine(resultCounter + ". " + result.Title);
                resultCounter++;
            }
            bool HasValidInput = false;
            int ChosenNumber = 0;
            while(!HasValidInput)
            {
                Console.WriteLine("Which Result Would you like to go for?");
                string IntendedResult = Console.ReadLine();
                if(HelperFunctions.IsDigitsOnly(IntendedResult))
                {
                    ChosenNumber = Convert.ToInt16(IntendedResult);
                    if(ChosenNumber >= 1 && ChosenNumber <= resultCounter)
                    {
                        HasValidInput = true;
                    }
                    else {
                        Console.WriteLine("Invalid Number Given, Please give a number between 1 and " + resultCounter.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input Given, Please give a number between one and " + resultCounter.ToString());
                }

            }

            var ChosenResult = SearchResults[ChosenNumber - 1];
            string ChosenTitle = ChosenResult.Title;
            string ChosenimdbID = ChosenResult.imdbID;

            Console.WriteLine("You have chosen " + ChosenTitle);
            Console.WriteLine("The ID is " + ChosenimdbID);
            var ChosenFilm = new IMDBFilm(ChosenTitle, ChosenimdbID);

            Console.WriteLine("Film is " + ChosenFilm.ImdbId + "  " + ChosenFilm.Title);



            // we now have the films ID we can build the trivia url
            string triviaUrl = "https://www.imdb.com/title/" + ChosenFilm.ImdbId + "/trivia";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(triviaUrl);
            var TriviaList = doc.DocumentNode.SelectNodes("//div[@class='sodatext']");
            foreach(var trivia in TriviaList)
            {
                Console.WriteLine(trivia.InnerText);
            }
        }

    }
}
