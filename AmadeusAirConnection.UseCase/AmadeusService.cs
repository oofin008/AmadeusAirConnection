using System;
using AmadeusAirConnection.Domain.Interfaces;
using AmadeusAirConnection.UseCase.Models;

namespace AmadeusAirConnection.UseCase
{
	internal class AmadeusService: IAmadeusService
	{
        private readonly IItinerary _itinerary;
		public AmadeusService(IItinerary itinerary)
		{
            _itinerary = itinerary;
		}

        public void AddRoute(List<AirlineRoute> routes)
        {
            routes.ForEach(route =>
            {
                _itinerary.AddRoute(route.From, route.To, route.Cost);
            });
        }

        public int GetCheapestItinerary(char source, char destination)
        {
           return _itinerary.GetCheapestItinerary(source, destination);
        }

        public int GetCost(List<char> itinerary)
        {
            return _itinerary.GetCost(itinerary);
        }
    }
}

