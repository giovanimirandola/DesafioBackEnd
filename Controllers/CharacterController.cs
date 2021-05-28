using DesafioPaschoalottoBackEnd.Models;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.IO;
using System.Text;
using System.Web.Http;

namespace DesafioPaschoalottoBackEnd.Controllers
{
    public class CharacterController : ApiController
    {
        [HttpGet]
        public int GetCharacters()
        {
            string url = "http://gateway.marvel.com//v1/public/characters?ts=1&apikey=473da253b3977826288936c4a61c0991&hash=8be15a064f1557728066139e0619aaf6";

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Root root = new JsonDeserializer().Deserialize<Root>(response);

                StreamWriter txt = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "personagensmarvel.txt", true, Encoding.ASCII);

                writeTXT(txt, root);
                txt.Close();

                return 1;
            }
            else
                return 0;
        }

        private void writeTXT(StreamWriter txt, Root data)
        {
            int aux = 0;

            foreach (Result result in data.data.results)
            {
                if (aux == 0)
                    txt.WriteLine("ID: " + result.id);
                else
                    txt.WriteLine("\nID: " + result.id);

                txt.WriteLine("Name: " + result.name);
                txt.WriteLine("Description: " + result.description);
                txt.WriteLine("Comics:");
                foreach (Item comics in result.comics.items)
                {
                    txt.WriteLine("\t- " + comics.name);
                }

                txt.WriteLine("Series:");
                foreach (Item comics in result.series.items)
                {
                    txt.WriteLine("\t- " + comics.name);
                }

                txt.WriteLine("Stories:");
                foreach (Item comics in result.stories.items)
                {
                    txt.WriteLine("\t- " + comics.name);
                }

                txt.WriteLine("Events:");
                foreach (Item comics in result.events.items)
                {
                    txt.WriteLine("\t- " + comics.name);
                }

                aux++;
            }
        }
    }
}
