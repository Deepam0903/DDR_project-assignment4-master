using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DDRProject.Models;
using Newtonsoft.Json;
using System.Net.Http;
using DDRProject.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DDRProject.Controllers
{
    public class HomeController : Controller
    {

        string BASE_URL = "https://developer.nps.gov/api/v1/";
        HttpClient httpClient;
        List<FinancialSummary> lstModels = null;

        ApplicationDbContext context = null;

        public HomeController(ApplicationDbContext context)
        {
            httpClient = new HttpClient();
            this.context = context;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void PopulateData()
        {
            string api_path = @"https://data.austintexas.gov/api/id/kyp9-ynfw.json?$query=select%20*%2C%20%3Aid%20limit%20300";
            var task = Task.Run(async () => await APIHandler.APIHandler.GetDataFromJSON(api_path));
            lstModels = task.Result;

        }

        /*
            Calls the IEX reference API to get the list of symbols.
            Returns a list of the companies whose information is available. 
        */
        public List<Datum> GetData()
        {
            string IEXTrading_API_PATH = BASE_URL + "events?api_key=dCgbntSNVGwM7mzqC4hGhL6EGtp1pmYJDmhyuGnj";
            string datumList = "";
            RootObject datums = null;

            // Connect to the IEXTrading API and retrieve information
            httpClient.BaseAddress = new Uri(IEXTrading_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();

            // Read the Json objects in the API response
            if (response.IsSuccessStatusCode)
            {
                datumList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            // Parse the Json strings as C# objects
            if (!datumList.Equals(""))
            {
                datums = JsonConvert.DeserializeObject<RootObject>(datumList);
                //datums = datums.GetRange(0, 50);
            }

            return datums.data;
        }

        public List<Datum2> GetData2()
        {
            string IEXTrading_API_PATH = BASE_URL + "campgrounds?api_key=dCgbntSNVGwM7mzqC4hGhL6EGtp1pmYJDmhyuGnj";
            string datum2List = "";
            RootObject2 datums2 = null;

            // Connect to the IEXTrading API and retrieve information
            httpClient.BaseAddress = new Uri(IEXTrading_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();

            // Read the Json objects in the API response
            if (response.IsSuccessStatusCode)
            {
                datum2List = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            // Parse the Json strings as C# objects
            if (!datum2List.Equals(""))
            {
                datums2 = JsonConvert.DeserializeObject<RootObject2>(datum2List);
                //datums = datums.GetRange(0, 50);
            }

            return datums2.data;
        }

        public IActionResult Index()
        {
            // Get the data from the List using GetSymbols method
            //List<Datum> datums = GetData();
            // Send the data to the Index view
            //return View(datums);
            return View();
        }
        public IActionResult Index1()
        {
            if (lstModels == null || lstModels.Count == 0)
                PopulateData();
            Dictionary<string, double> dictModel = new Dictionary<string, double>();
            lstModels.GroupBy(x => x.Proposition).ToList().ForEach(item => {
                double sum = 0;
                foreach (var x in item)
                {
                    sum += x.Allocated;
                }
                sum /= 10000000;
                dictModel.Add(item.Key, sum);
            });
           
            return View(dictModel);
        }
        public IActionResult About()
        {
            return View();
        }

       public IActionResult Contact()
        {
            // List<Datum> datums = GetData();
            //return View(datums);
            //string api_path = @"https://data.austintexas.gov/api/id/kyp9-ynfw.json?$query=select%20*%2C%20%3Aid%20limit%20300";
            //var task = Task.Run(async () => await APIHandler.APIHandler.GetDataFromJSON(api_path));
            //var result = task.Result;
            if (lstModels == null || lstModels.Count == 0)
                PopulateData();
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE BondSummary");

            foreach (var item in lstModels)
            {
                try
                {
                    context.FinancialSummaries.Add(item);
                    context.SaveChanges();
                }
                catch (Exception e)
                {

                    var msg = e.Message;
                }
            }


            // lstModels = result;
            return View(lstModels);
        }
        
        public IActionResult Visit()
        {
            // List<Datum2> datums2 = GetData2();
            //return View(datums2);
            return View();
        }

       /* public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult More()
        {
            return View();
        }*/
    }
}