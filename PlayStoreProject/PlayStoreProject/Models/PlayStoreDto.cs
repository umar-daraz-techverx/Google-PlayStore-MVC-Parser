using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PlayStoreProject.Models
{
	public class PlayStoreDto
	{
		
			[JsonProperty("url")]
			public Uri Url { get; set; }

			[JsonProperty("appId")]
			public string AppId { get; set; }

			[JsonProperty("title")]
			public string Title { get; set; }

			[JsonProperty("summary")]
			public string Summary { get; set; }

			[JsonProperty("developer")]
			public string Developer { get; set; }

			[JsonProperty("developerId")]
			public string DeveloperId { get; set; }

			[JsonProperty("icon")]
			public string Icon { get; set; }

			[JsonProperty("score")]
			public double Score { get; set; }

			[JsonProperty("scoreText")]
			public string ScoreText { get; set; }

			[JsonProperty("priceText")]
			public string PriceText { get; set; }

			[JsonProperty("free")]
			public bool Free { get; set; }
		}
	
}