using Newtonsoft.Json;

namespace AmadeusAirConnection.API.Models
{
	public class GetCostResponse
	{
		[JsonProperty("itinerary")]
		public string? Itinerary { get; set; }

		[JsonProperty("cost")]
		public int Cost { get; set; }
	}
}

