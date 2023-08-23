using Moq;
using System.Net;
using AmadeusAirConnection.UseCase;
using AmadeusAirConnection.API.Models;
using AmadeusAirConnection.Controllers;

namespace AmadeusAirConnection.Tests
{
	public class ItineraryControllerTest
	{
		[Fact]
		public async void GetCost_OnSuccess_ReturnCost()
		{
			// Arrange
			var mockAmadeusService = new Mock<IAmadeusService>();
			mockAmadeusService.Setup(service => service.GetCost(new List<char>())).Returns(100);
			var controller = new ItineraryController(mockAmadeusService.Object);

			// Act
			var result = controller.GetCostByItinerary("A-B-C");

			// Assert

		}
	}
}

