using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net;

namespace InterviewTest.Controllers.Home
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            //Asker();
            GetHotel();
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";

            return View();
        }

        public void GetHotel()
        {
            try
            {
                string url = @"http://ws-design.idevdesign.net/hotels.asmx/GetHotel?105304";
                //WebRequest request = WebRequest.Create(url);

                //request.Credentials = GetCredential();
                //request.PreAuthenticate = true;

                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                var client = new WebClient { Credentials = new NetworkCredential("aeTraining", "ZZZ") };
                var response = client.DownloadString(url);
                Console.WriteLine(response);

            }
            catch (SystemException e)
            {
                Console.WriteLine(e);
            }
        }

        private CredentialCache GetCredential()
        {
            string url = @"http://ws-design.idevdesign.net/hotels.asmx/GetHotel?105304";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            CredentialCache credentialCache = new CredentialCache();
            credentialCache.Add(new System.Uri(url), "Basic", new NetworkCredential("aeTraining", "ZZZ"));
            return credentialCache;
        }

        public void Asker()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                {
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand("Select * From People");
                    string cmd = sqlCommand.ToString();
                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
    }
}
