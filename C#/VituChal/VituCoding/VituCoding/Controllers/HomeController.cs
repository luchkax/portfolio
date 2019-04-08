using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VituCoding.Models;
using CsvHelper;
using System.IO;
using Newtonsoft.Json;


namespace VituCoding.Controllers
{

    // OVERVIEW
    public class HomeController : Controller
    {
        public IActionResult Index(string viewres, int viewresSum)
        {
            if (viewres != null && viewresSum > 0) { ViewBag.Result = viewres; ViewBag.Sum = viewresSum; }
            Transactions res = new Transactions();
            try
            {
                decimal BillSum = 0;
                decimal nonBillSum = 0;
                using(TextReader reader = new StreamReader("transactions.csv"))
                {
                    string[] allBills = { "LTF", "Mortgage", "Comcast", "Bright Horizons", "SMART", "T*SMART TUITION", "ITUNES", "APL*ITUNES.COM", "COWORKERS" };
                    List<Statement> filteredRes = new List<Statement>();
                    DateTime thirtydays = DateTime.Now.AddDays(-30);

                    var csvReader = new CsvReader(reader);
                    csvReader.Configuration.RegisterClassMap<HasIngoredPropertyMap>();

                    var unfilteredRes = csvReader.GetRecords<Statement>().ToList();
                    foreach(var x in unfilteredRes)
                    {
                        // 30 days check
                        if (thirtydays < x.PostingDate)
                        {
                            filteredRes.Add(x);

                            // Bill or non Bill 
                            // generating sum for both
                            foreach (var st in allBills)
                            {
                                if (x.Description.Contains(st))
                                {
                                    x.isBill = true;
                                    BillSum += decimal.Parse(x.Amount);
                                }
                                else nonBillSum += decimal.Parse(x.Amount);
                            }
                        }

                    }
                    Transactions ex = new Transactions
                    {
                        Statements = filteredRes
                    };

                    //Final filtered list of transaction objects 
                    res = ex;
                    var output = JsonConvert.SerializeObject(res.Statements);
                    object js = JsonConvert.DeserializeObject(output);

                    ViewBag.Transactions = res.Statements;
                    ViewBag.BillSum = (BillSum+(-BillSum))+(-BillSum);
                    ViewBag.nonBillSum = (nonBillSum+(-nonBillSum))+(-nonBillSum);


                    Console.WriteLine(res);
                }


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View();

        }
        [HttpGet("/getACII")]
        public IActionResult GetACII(string username)
        {
            string res = "";
            int sum = 0;

            if (username == null)
            {
                res = "Input string";
            }
            else
            {
                int[] asciiArray = username.Select(r => (int)r).ToArray();
                foreach (var i in asciiArray)
                {
                    res += i + " ";
                    sum += i;
                }
            }
            return RedirectToAction("Index", new { viewres = res, viewresSum = sum });

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
