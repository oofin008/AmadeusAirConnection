using Moq;
using System.Net;
using AmadeusAirConnection.UseCase;
using AmadeusAirConnection.API.Models;
using AmadeusAirConnection.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AmadeusAirConnection.Tests
{
	public class ItineraryControllerTest
	{
		private readonly Mock<IAmadeusService> _mockService;
		private readonly ItineraryController _controller;

		public ItineraryControllerTest()
		{
			_mockService = new Mock<IAmadeusService>();
			_controller = new ItineraryController(_mockService.Object);
		}

		[Fact]
		public async void GetCost_OnSuccess_ReturnCost()
		{
			// Arrange
			_mockService.Setup(service => service.GetCost(new List<char>())).Returns(100);

			// Act
			var result = _controller.GetCostByItinerary("A-B-C");

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var response = Assert.IsType<GetCostResponse>(okResult.Value);
			Assert.Equal(100, response.Cost);
		}
	}
}

