using System.Net;
using Microsoft.AspNetCore.Mvc;
using AmadeusAirConnection.UseCase.Models;
using AmadeusAirConnection.UseCase;
using AmadeusAirConnection.API.Utils;
using AmadeusAirConnection.API.Models;
using AmadeusAirConnection.Domain.Entities;
using Microsoft.Extensions.Hosting;

namespace AmadeusAirConnection.Controllers;

[ApiController]
[Route("itinerary")]
public class ItineraryController : ControllerBase
{
    private readonly IAmadeusService _amadeusService;
    private static readonly List<AirlineRoute> RouteInfos = new List<AirlineRoute>
    {
        new AirlineRoute { From = 'A', To = 'B', Cost = 60},
        new AirlineRoute { From = 'A', To = 'C', Cost = 150},
        new AirlineRoute { From = 'B', To = 'C', Cost = 50},
        new AirlineRoute { From = 'B', To = 'E', Cost = 80},
        new AirlineRoute { From = 'C', To = 'B', Cost = 220},
        new AirlineRoute { From = 'C', To = 'G', Cost = 350},
        new AirlineRoute { From = 'D', To = 'I', Cost = 120},
        new AirlineRoute { From = 'E', To = 'A', Cost = 70},
        new AirlineRoute { From = 'E', To = 'C', Cost = 85},
        new AirlineRoute { From = 'F', To = 'A', Cost = 230},
        new AirlineRoute { From = 'F', To = 'G', Cost = 110},
        new AirlineRoute { From = 'G', To = 'F', Cost = 90},
        new AirlineRoute { From = 'G', To = 'H', Cost = 75},
        new AirlineRoute { From = 'H', To = 'I', Cost = 35},
        new AirlineRoute { From = 'I', To = 'C', Cost = 90},
        new AirlineRoute { From = 'I', To = 'D', Cost = 30},
    };

    public ItineraryController(IAmadeusService amadeusService)
    {
        _amadeusService = amadeusService;
        _amadeusService.AddRoute(RouteInfos);
    }

    [HttpGet]
    [Route("{itinerary}")]
    public IActionResult GetCostByItinerary(string itinerary)
    {
        try
        {
            List<char> fromTo = new List<char>(itinerary.Replace("-", ""));
            int cost = _amadeusService.GetCost(fromTo);
            if (cost >= 0)
            {
                var result = new GetCostResponse
                {
                    Itinerary = itinerary,
                    Cost = cost,
                };
                return Ok(result);
            }
            else
            {
                return NotFound(CustomActionResult.Error(404, "No Such Itinerary"));
            }
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPost]
    [Route("getcheapest")]
    public IActionResult GetCheapestItinerary([FromBody] GetCheapestInput body)
    {
        try
        {
            var cheapestCost = _amadeusService.GetCheapestItinerary(body.From, body.To);
            if (cheapestCost >= 0)
            {
                var result = new GetCostResponse
                {
                    Itinerary = body.From + " " + body.To,
                    Cost = cheapestCost,
                };
                return Ok(CustomActionResult.Success(result));
            }
            else
            {
                return NotFound(CustomActionResult.Error(404, "No Such Itinerary"));
            }
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
}
