using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Entertainment.Model;
using Newtonsoft.Json;
using Entertainment.DataAccess;
using System.Data.SqlClient;

namespace Entertainment.Entertainment.ConsoleApp
{
    class Program : EntertainmentContext
    {
        static async System.Threading.Tasks.Task Main(string[] args) 
        {
            using (var db = new EntertainmentContext())
            {
                //Actor.AddActorToDbViaApi(new Actor { FirstName = "Mark", LastName = "Mcmorris", DateOfBirth = Convert.ToDateTime("04.11.1995") });
                Movie.AddMovieToDbViaApi(new Movie { Title = "Inception on snowboard", ReleaseDate = Convert.ToDateTime("04.10.2000") });
                //Actor actor1 = Actor.GetAllActorsFromAPI()[0];
                //Actor.DeleteActorFromDbViaApi(actorSomSlettes);

                Console.WriteLine("Movies:");
                foreach (Movie movie in Movie.GetAllMoviesFromApi())
                {
                    Console.WriteLine(movie.ToString());
                }
                Console.WriteLine("\nActors:");
                foreach (Actor actor in Actor.GetAllActorsFromAPI())
                {
                    Console.WriteLine(actor.ToString());
                }
            }
        }
    }
}


