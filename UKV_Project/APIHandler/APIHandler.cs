using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DDRProject.Models;

namespace DDRProject.APIHandler
{
    public class APIHandler
    {
        
        public static async Task<string> GetDataFromAPI(string data_url)
        {
            string json_data = null;
            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync(data_url);
                if (response.IsSuccessStatusCode)
                {
                    var jRaw = await response.Content.ReadAsAsync<JRaw>();
                    json_data = jRaw.ToString();
                }
            }
            catch (Exception e)
            {
                var st = e.Message;
            }
            return json_data;
        }

        public static async Task<List<FinancialSummary>> GetDataFromJSON(string path)
        {
            string json_string = await GetDataFromAPI(path);
            var listFin = JsonConvert.DeserializeObject<List<FinancialSummary>>(json_string);
            return listFin;
        }
    }
}
