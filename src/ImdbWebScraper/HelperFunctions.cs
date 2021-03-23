using System;
using System.Net.Http;
namespace ImdbWebScraper
{
  
    public class HelperFunctions
    {
        public static string StripATags(string input)
        {
            // strip the opening tags 
            while(input.IndexOf("<a") > -1)
            {
                int startOpenIndex = input.IndexOf("<a");
                int endOpenIndex = input.IndexOf(">");
                input = input.Remove(startOpenIndex, endOpenIndex - startOpenIndex + 1);
                int startCloseIndex = input.IndexOf("</");
                int endCloseIndex = input.IndexOf(">");
                input = input.Remove(startCloseIndex, endCloseIndex - startCloseIndex + 1);

            }
            return input;
        }

        public static string SearchTitle(string searchString, string apiKey, HttpClient client)
        {   
            var url = "http://www.omdbapi.com/?apikey=" + apiKey + "&s=" +  searchString;
            var response = client.GetStringAsync(url);
            return response.Result;
        }

        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                return false;
            }

            return true;
        }
    }
    
}

