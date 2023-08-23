using System;
using System.Collections.Generic;

namespace TestCode;
class AmadeusAirline
{
    private Dictionary<char, Dictionary<char, int>> routes;

    public AmadeusAirline()
    {
        routes = new Dictionary<char, Dictionary<char, int>>();
    }

    public void AddRoute(char fromAirport, char toAirport, int cost)
    {
        if (!routes.ContainsKey(fromAirport))
        {
            routes[fromAirport] = new Dictionary<char, int>();
        }
        routes[fromAirport][toAirport] = cost;
    }

    public int GetCost(List<char> itinerary)
    {
        int totalCost = 0;
        for (int i = 0; i < itinerary.Count - 1; i++)
        {
            char fromAirport = itinerary[i];
            char toAirport = itinerary[i + 1];
            if (routes.ContainsKey(fromAirport) && routes[fromAirport].ContainsKey(toAirport))
            {
                totalCost += routes[fromAirport][toAirport];
            }
            else
            {
                return -1; // Invalid itinerary
            }
        }
        return totalCost;
    }

    public List<char>? GetCheapestItinerary(char source, char destination)
    {
        List<List<char>> allItineraries = GetAllItineraries(source, int.MaxValue, int.MaxValue, true);
        List<char>? cheapestItinerary = null;
        int minCost = int.MaxValue;

        foreach (List<char> itinerary in allItineraries)
        {
            if (itinerary.Last() == destination)
            {
                int cost = GetCost(itinerary);
                if (cost < minCost)
                {
                    minCost = cost;
                    cheapestItinerary = itinerary;
                }
            }
        }

        return cheapestItinerary;
    }

    public List<List<char>> GetAllItineraries(char startAirport, int maxLegs, int maxCost, bool noRepeatedLegs)
    {
        List<List<char>> result = new List<List<char>>();
        GetAllItinerariesRecursive(new List<char> { startAirport }, result, maxLegs, maxCost, noRepeatedLegs);
        return result;
    }

    private void GetAllItinerariesRecursive(List<char> currentItinerary, List<List<char>> result, int maxLegs, int maxCost, bool noRepeatedLegs)
    {
        char lastAirport = currentItinerary.Last();
        if (currentItinerary.Count > maxLegs + 1 || GetCost(currentItinerary) > maxCost)
        {
            return;
        }

        foreach (char nextAirport in routes[lastAirport].Keys)
        {
            if (noRepeatedLegs && currentItinerary.Contains(nextAirport))
            {
                continue;
            }

            List<char> newItinerary = new List<char>(currentItinerary);
            newItinerary.Add(nextAirport);

            if (nextAirport == currentItinerary[0] && newItinerary.Count > 2)
            {
                continue; // Avoid cyclic itineraries
            }

            if (newItinerary.Count <= maxLegs + 1 && GetCost(newItinerary) <= maxCost)
            {
                result.Add(newItinerary);
            }

            GetAllItinerariesRecursive(newItinerary, result, maxLegs, maxCost, noRepeatedLegs);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        AmadeusAirline amadeusAirline = new AmadeusAirline();

        // Add routes and costs
        amadeusAirline.AddRoute('A', 'B', 60);
        amadeusAirline.AddRoute('A', 'C', 130);
        amadeusAirline.AddRoute('B', 'C', 50);

        //Console.Write("Enter itinerary (dash-separated airport codes): ");
        //string? itineraryString = Console.ReadLine();
        //if(itineraryString is null)
        //{
        //    return;
        //}
        //List<char> itinerary = new List<char>(itineraryString.Replace("-", ""));

        //int cost = amadeusAirline.GetCost(itinerary);
        //if (cost != -1)
        //{
        //    Console.WriteLine($"The cost of the itinerary is {cost} Amadollars.");
        //}
        //else
        //{
        //    Console.WriteLine("Invalid itinerary.");
        //}

        Console.Write("Enter From-To to find cheapest itinerary: ");
        string? fromToString = Console.ReadLine();
        if(fromToString is null)
        {
            return;
        }
        List<char> fromTo = new List<char>(fromToString.Replace("-", ""));
        List<char> cheapestCode = amadeusAirline.GetCheapestItinerary(fromTo[0], fromTo[1]);
        int cheapestCost = amadeusAirline.GetCost(cheapestCode);
        if (cheapestCost != -1)
        {
            Console.WriteLine($"The cost of the itinerary is {cheapestCode} Amadollars.");
        }
        else
        {
            Console.WriteLine("Invalid itinerary.");
        }
    }
}
