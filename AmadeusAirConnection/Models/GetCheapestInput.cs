using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AmadeusAirConnection.API.Models
{
	[DataContract]
	public class GetCheapestInput
	{
		[DataMember(Name = "from")]
		[Required(ErrorMessage = "from airport is required")]
		public char From { get; set; }

		[DataMember(Name = "to")]
		[Required(ErrorMessage = "to airport is required")]
		public char To { get; set; }
	}
}

