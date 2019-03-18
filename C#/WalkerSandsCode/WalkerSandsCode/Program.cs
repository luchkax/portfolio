using System;
using System.IO;
using System.Net;
using System.Linq;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Globalization;



// SQL CHALLENGE:
// 
/*
 * 
 [1] SELECT t1.ReportId, COALESCE(t2.DeptName, 'Corporate') as 'Depratment Name', t1.ReportSizeInBytes
    FROM Reports t1 
    LEFT JOIN Department t2 on t1.DeptCode = t2.DeptCode
    WHERE NOT EXISTS (SELECT * FROM ReportLog as t3
                        WHERE t1.ReportId = t3.ReportId )
 *                                               
 *                                             
 * 
  [2] SELECT TOP 3 COUNT(t3.ReportTime), t1.ReportId, COALESCE(t2.DeptName, 'Corporate') as 'Department Name', t2.DeptCode, t3.ReportTime, count(t3.ReportId) as "NoOfTimesRun" 
    FROM Reports t1 
    LEFT JOIN Department t2 on t1.DeptCode = t2.DeptCode
    LEFT JOIN ReportLog t3 on t1.ReportId = t3.ReportId
    WHERE t3.ReportTime >= DATEADD(DAY, -1, GETDATE())
    GROUP BY  t1.ReportId, t2.DeptName, t3.ReportTime, t2.DeptCode
    ORDER BY  count(t3.ReportId) DESC

*/

namespace WeatherChannel
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string url = "http://api.openweathermap.org/data/2.5/group?id=4887398,4684888,5809844,5419384,5128581,5780993,5506956,5391959,4930956,4180439&appid=30b3db4152f8ddd4bd894e9ea5be2246&units=imperial";
            string req = releaseApi(url);
            dynamic jsn = JObject.Parse(req);
            List<CitiesWeatherDetails> cwd1 = new List<CitiesWeatherDetails>();
            foreach (var i in jsn.list)
            {
                WeatherDetails wd = new WeatherDetails
                {
                    Longitude = i.coord.lon,
                    Latitude = i.coord.lat,
                    MinTemp = i.main.temp_min,
                    MaxTemp = i.main.temp_max
                };


                CitiesWeatherDetails cwd = new CitiesWeatherDetails
                {
                    Id = i.id,
                    Name = i.name,
                    WeatherDetails = wd
                };

                cwd1.Add(cwd);

            }
            Weather w = new Weather
            {
                Count = jsn.cnt,
                CitiesWeatherDetails = cwd1
            };
            w.CitiesWeatherDetails = w.CitiesWeatherDetails.OrderByDescending(o => o.WeatherDetails.MaxTemp).ToList();
            var result = new JavaScriptSerializer().Serialize(w);
            Console.WriteLine(result);
            JObject fin = JObject.Parse(result);

        }

        public JObject Retreive (JObject obj)
        {
            return obj;
        }

        public static string  releaseApi(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }
    }

    public partial class Weather
    {
        public long Count { get; set; }

        public List<CitiesWeatherDetails> CitiesWeatherDetails { get; set; }
    }

    public partial class CitiesWeatherDetails
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public WeatherDetails WeatherDetails { get; set; }

    }

    public partial class WeatherDetails
    {
        [JsonProperty("temp_min")]
        public string MinTemp { get; set; }

        [JsonProperty("temp_max")]
        public string MaxTemp { get; set; }

        [JsonProperty("lon")]
        public string Longitude { get; set; }

        [JsonProperty("lat")]
        public string Latitude { get; set; }
    }
}