using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

namespace Entertainment.Model
{
    public class Actor
    {
        public int ActorId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Image ProfilePicture { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        


        public override string ToString()
        {
            return $"{FullName}, {DateOfBirth.ToShortDateString()}";
        }

        public static List<Actor> GetAllActorsFromAPI()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44392/api/actors"));
            WebReq.Method = "GET";
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }
            List<Actor> actors = JsonConvert.DeserializeObject<List<Actor>>(jsonString);
            return actors;
        }
        public static void AddActorToDbViaApi(Actor actor)
        {
            var client = new RestClient("https://localhost:44392/api/actors");
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(new { actor.FirstName, actor.LastName, actor.DateOfBirth, actor.ProfilePicture }); // uses JsonSerializer
            client.Execute(request);
        }

        public static void DeleteActorFromDbViaApi(Actor actor)
        {
            var client = new RestClient("https://localhost:44392/api/actors/" + actor.ActorId);
            var request = new RestRequest(Method.DELETE);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }


    }
}