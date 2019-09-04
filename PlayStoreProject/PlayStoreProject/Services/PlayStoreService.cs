using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using PlayStoreProject.Models;

namespace PlayStoreProject.Services
{
	public class PlayStoreService
	{
		private readonly RequestService _requestService;
		public PlayStoreService()
		{
			_requestService = new RequestService();
		}
		public List<PlayStoreDto> Get()
		{
		return _requestService.SendGetRequest<List<PlayStoreDto>>("topFree",null, ApplicationConstants.SERVER_URL, null);
		}
	}
}