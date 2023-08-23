using AmadeusAirConnection.UseCase.Models;

namespace AmadeusAirConnection.UseCase;
public interface IAmadeusService
{
    void AddRoute(List<AirlineRoute> routes);
    int GetCost(List<char> itinerary);
    int GetCheapestItinerary(char source, char destination);
}
