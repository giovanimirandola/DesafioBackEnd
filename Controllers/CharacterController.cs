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
        public string GetCharacters()
        {
            string url = "http://gateway.marvel.com//v1/public/characters?ts=1&apikey=473da253b3977826288936c4a61c0991&hash=8be15a064f1557728066139e0619aaf6";

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                return "Ocorreu um erro na execução.";
            else
            {
                Root root = new JsonDeserializer().Deserialize<Root>(response);

                StreamWriter txt = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "personagensmarvel.txt", true, Encoding.ASCII);

                writeTXT(txt, root);
                txt.Close();

                return "Arquivo 'personagensmarvel.txt' criado com sucesso!";
            }
        }

        private void writeTXT(StreamWriter txt, Root data)
        {
            foreach (Result result in data.data.results)
            {
                txt.WriteLine("ID: " + result.id);
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
                txt.WriteLine("");
            }
        }
    }
}
