using System;
namespace AmadeusAirConnection.Domain.Interfaces
{
	public interface IItinerary
	{
		void AddRoute(char fromAirport, char toAirport, int cost);
		int GetCost(List<char> itinerary);
		int GetCheapestItinerary(char source, char destination);
		List<string> GetPossibleItineraries(char source, char destination, bool noSameLeg, int maxCost, int maxLegs);
	}
}

