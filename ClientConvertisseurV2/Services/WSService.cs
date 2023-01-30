using ClientConvertisseurV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Services
{
    public class WSService : IService
    {
        System.Net.Http.HttpClient client;

        private static int PORT = 7022;

        public async Task<List<Devise>> GetDevisesAsync(string nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<Devise>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Construct a webService
        /// </summary>        
        /// <param name="nameURI">Name of URI for this service</param>
        public WSService(String nameUri)
        {
            client = new System.Net.Http.HttpClient();
            client.BaseAddress = new Uri("https://localhost:" + PORT + "/api/" + nameUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }

    public interface IService
    {
    }
}
