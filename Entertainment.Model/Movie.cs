using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Text;

namespace Entertainment.Model
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public override string ToString()
        {
            return $"{Title}, {ReleaseDate.ToShortDateString()}";
        }

        public static List<Movie> GetAllMoviesFromApi(){

            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44392/api/movies"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(jsonString);
            return movies;
        }

        public static void AddMovieToDbViaApi(Movie movie)
        {
            var client = new RestClient("https://localhost:44392/api/movies");
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(new { movie.Title, movie.ReleaseDate}); // uses JsonSerializer
            client.Execute(request);
        }

        public static void DeleteMovieFromDbViaApi(Movie movie)
        {
            var client = new RestClient("https://localhost:44392/api/movies/" + movie.MovieId);
            var request = new RestRequest(Method.DELETE);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

    }
}
