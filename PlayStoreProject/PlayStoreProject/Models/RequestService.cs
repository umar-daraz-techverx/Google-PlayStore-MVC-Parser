using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using PlayStoreProject.Utils;

namespace PlayStoreProject.Models
{
	public class RequestService
	{
		public T SendGetRequest<T>(string methodName, Dictionary<string, string> parameters, string apiUrl, List<KeyValuePair<string, string>> keyValueParameters = null)
		{
			var response = HttpWebRequestHelper.SendGetRequest(String.Format("{0}{1}", apiUrl, methodName),
				parameters, keyValueParameters);

			if (response == null)
			{
				throw new Exception("Unable to get resposne");
			}
			return JsonConvert.DeserializeObject<T>(HttpWebRequestHelper.GetHttpWebResponseData(response));
		}
	}
}
