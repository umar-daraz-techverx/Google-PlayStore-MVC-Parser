using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PlayStoreProject.Utils
{
	public static class HttpWebRequestHelper
	{
		private static string FormContentType = "application/x-www-form-urlencoded";
		private static string XMLContentType = "text/xml";
		private static string POST = "POST";
		private static string GET = "GET";
		private static string FormatPostParameters(List<KeyValuePair<string, string>> ArrayParameters)
		{
			var sb = new StringBuilder();
			if (ArrayParameters != null)
			{
				foreach (KeyValuePair<string, string> key in ArrayParameters)
				{
					sb.Append(HttpUtility.UrlEncode(key.Key) + "[]=" + HttpUtility.UrlEncode(key.Value) + "&");
				}
			}

			if (sb.Length > 0)
				sb.Length = sb.Length - 1;

			return sb.ToString();
		}
		private static string FormatPostParameters(Dictionary<string, string> parameters)
		{
			var sb = new StringBuilder();
			if (parameters != null)
			{
				foreach (string key in parameters.Keys)
				{
					sb.Append(HttpUtility.UrlEncode(key) + "=" + HttpUtility.UrlEncode(parameters[key]) + "&");
				}
			}

			if (sb.Length > 0)
				sb.Length = sb.Length - 1;

			return sb.ToString();
		}
		public static HttpWebResponse SendGetRequest(string url, Dictionary<string, string> parameters, List<KeyValuePair<string, string>> ArrayParameter = null)
		{
			if (parameters != null)
			{
				url += "?" + FormatPostParameters(parameters);
			}

			if (ArrayParameter != null)
			{
				if (parameters == null) { url += "?"; } else { url += "&"; }
				url += FormatPostParameters(ArrayParameter);
			}
			var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.ContentType = FormContentType;
			httpWebRequest.Timeout = (60 * 1000) * 10;
			httpWebRequest.Method = GET;




			Task<WebResponse> responseTask = Task.Factory.FromAsync<WebResponse>(httpWebRequest.BeginGetResponse,
				httpWebRequest.EndGetResponse, null);

			return (HttpWebResponse)responseTask.Result;
		}
		public static string GetHttpWebResponseData(HttpWebResponse response)
		{
			string data = string.Empty;
			if (response != null)
			{
				using (var incomingStreamReader = new StreamReader(response.GetResponseStream()))
				{
					data = incomingStreamReader.ReadToEnd();
					incomingStreamReader.Close();
					response.GetResponseStream().Close();
				}
			}
			return data;
		}

	}
}