using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Airport
{
	public class AirportViewModel
	{
		public List<AirportModel> airports = new List<AirportModel>();

		public AirportViewModel ()
		{
			string url = "http://airports.pidgets.com/v1/airports?country=Canada&format=json";

			HttpWebResponse wrResp = null; 
			HttpWebRequest wrReq = (HttpWebRequest)WebRequest.Create(url);
			wrReq.Method = "GET";
			wrReq.ContentType = "text/xml";
			Encoding encoding = Encoding.GetEncoding("utf-8");
			string responseMessage = "";

			try
			{
				// Execute on the url
				wrResp = (HttpWebResponse)GetResponse(wrReq);

				// Interpret the response
				Stream sr1 = wrResp.GetResponseStream();
				StreamReader srResponse = new StreamReader(sr1, encoding);
				responseMessage = srResponse.ReadToEnd();
				int start = responseMessage.IndexOf(@"[{");
				responseMessage = responseMessage.Substring(start);
				airports = JsonConvert.DeserializeObject<List<AirportModel>> (responseMessage);

				foreach(var item in airports)
				{
					item.location = item.lat + ", " + item.lon;
				}
			}
			catch (WebException ex)
			{
				responseMessage = ex.ToString();
			}
		}

		public WebResponse GetResponse(WebRequest request){
			ManualResetEvent evt = new ManualResetEvent (false);
			WebResponse response = null;
			request.BeginGetResponse ((IAsyncResult ar) => {
				response = request.EndGetResponse(ar);
				evt.Set();
			}, null);
			evt.WaitOne ();
			return response as WebResponse;
		}

		public Stream GetRequestStream(WebRequest request){
			ManualResetEvent evt = new ManualResetEvent (false);
			Stream requestStream = null;
			request.BeginGetRequestStream ((IAsyncResult ar) => {
				requestStream = request.EndGetRequestStream(ar);
				evt.Set();
			}, null);
			evt.WaitOne ();
			return requestStream;
		}
	}
}

