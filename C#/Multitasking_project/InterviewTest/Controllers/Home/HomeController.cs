using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using InterviewTest.Models;

namespace InterviewTest.Controllers.Home
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BannerTrackingReport()
        {
            //I tried to connect both to my local and remote DBs but no success unfortunately. Btw the task is pretty simple.
            // After the query execution I would bind it to webgrid and display on client side. 
            // Probably the issue is with my machine, I am using mac + docker...
            try
            {
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.AppSettings["ConnectionString"]))
                {
                    con.Open();
                    string sqlCmd = "SELECT t1.Name, t1.Link, t1.Image, t2.CreateDate, SUM(t2.ImpressionCount) " +
                    	"AS \"Impression Count\", SUM(t2.ClickCount) as \"Click Count\" " +
                    	"FROM Banner AS t1 JOIN BannerTracking as t2 " +
                    	"ON t1.BannerId = t2.BannerId \nWHERE (t2.CreateDate >= '2015/11/18' AND t2.CreateDate <= '2015/11/24')" +
                    	"\nGROUP BY t1.Name, t1.Link, t1.Image, t2.CreateDate, t2.ClickCount";
                    //SqlCommand sqlCommand = new SqlCommand(sqlCmd);
                    SqlCommand sqlCommand = new SqlCommand("Select * From Banner");
                    string cmd = sqlCommand.ToString();
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                       }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();

            return View();
        }

        public ActionResult HotelsWebService()
        {
            try
            {
                // http GET request with auth credentials is not described and specified properly. I decided to use SOAP.

                int hotelID = 105304;
                string url = @"http://ws-design.idevdesign.net/hotels.asmx";
                    HttpWebRequest request = CreateSOAPWebRequest(url);
                    XmlDocument SOAPReqBody = new XmlDocument();
                    SOAPReqBody.LoadXml($@"<?xml version=""1.0"" encoding=""utf-8""?>
                        <soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
                          <soap12:Header>
                            <HotelCredentials xmlns=""http://ws.design.americaneagle.com"">
                              <username>aeTraining</username>
                              <password>ZZZ</password>
                            </HotelCredentials>
                          </soap12:Header>
                          <soap12:Body>
                            <GetHotel xmlns=""http://ws.design.americaneagle.com"">
                              <hotelId>{hotelID}</hotelId>
                            </GetHotel>
                          </soap12:Body>
                        </soap12:Envelope>");

                    using (Stream stream = request.GetRequestStream())
                    {
                        SOAPReqBody.Save(stream);
                    }
                    //Geting response from request  
                    using (WebResponse Serviceres = request.GetResponse())
                    {
                        using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                        {
                            //reading stream  
                            var ServiceResult = rd.ReadToEnd();
                            XmlDocument data = new XmlDocument();
                            data.LoadXml(ServiceResult);
                            XmlNode newNode = data.DocumentElement;
                            string jsonText = JsonConvert.SerializeXmlNode(newNode);
                            JObject jobject = JObject.Parse(jsonText);
                            ViewData["DisplayData"] = jobject;  
                            Console.WriteLine(jsonText);
                            
                        }
                    }

                }
                catch (WebException ex)
                {
                    var response = (HttpWebResponse)ex.Response;
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Console.WriteLine(false);
                    }
                    throw;
                }
            return View();
        }
        //Helper method for creating SOAP Reqeusts
        public HttpWebRequest CreateSOAPWebRequest(string url)
        {
            //Making Web Request  
            HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(url);
            //Content_type  
            Req.ContentType = "text/xml;charset=\"utf-8\"";
            Req.Accept = "text/xml";
            //HTTP method  
            Req.Method = "POST";
            //return HttpWebRequest  
            return Req;
        }

        [HttpGet]
        public ActionResult CustomValidator(string ex)
        {
            Console.WriteLine("HERE!");
            if (ex != null) ViewData["Err"] = ex;
            else ViewData["Err"] = " ";
            return View();
        }

        [HttpPost]
        public ActionResult CustomValidatorPost(FormD form)
        {
            string ex = "";
            if (form.drpState == null && form.txtRegion == null)
            {
                ex = "Error. All fields should be filled out.";
                return RedirectToAction("CustomValidator", "Home", new { ex });
            }
            ex = "Validated!";
            Console.WriteLine(form);
            return RedirectToAction("CustomValidator", "Home", new { ex });
        }

        public ActionResult HelperSql()
        {
            return View();
        }
    }
}