using System;
using AmadeusAirConnection.Domain.Interfaces;

namespace AmadeusAirConnection.Domain.Entities
{
	public class Itinerary: IItinerary
	{
		// using Adjacency list (dict in dict) to represent directed graph of airport.
		private Dictionary<char, Dictionary<char, int>> routes;

		public Itinerary()
		{
			routes = new Dictionary<char, Dictionary<char, int>>();
		}

		public void AddRoute(char fromAirport, char toAirport, int cost)
		{
			if(!routes.ContainsKey(fromAirport))
			{
				routes[fromAirport] = new Dictionary<char, int>();
			}
			routes[fromAirport][toAirport] = cost;
		}

        // Objective 1: find total cost of given itinerary
        public int GetCost(List<char> itinerary)
		{
			int totalCost = 0;
			for(int i = 0; i < itinerary.Count - 1; i++)
			{
				char fromAirport = itinerary[i];
				char toAirport = itinerary[i + 1];
				if(routes.ContainsKey(fromAirport) && routes[fromAirport].ContainsKey(toAirport))
				{
					totalCost += routes[fromAirport][toAirport];
				}
				else
				{
					return -1; // Invalid itinerary input
				}
			}
			return totalCost;
		}

        public List<string> GetPossibleItineraries(char source, char destination, bool noSameLeg, int maxCost, int maxLegs)
        {
            throw new NotImplementedException();
        }

        // Objective 3: find cheapest of given itinerary
        public int GetCheapestItinerary(char source, char destination)
        {
            // using Dijkstra’s algorithm
            Dictionary<char, int> distances = new Dictionary<char, int>();
            HashSet<char> visited = new HashSet<char>();
            PriorityQueue<char> minHeap = new PriorityQueue<char>((a, b) => distances[a] - distances[b]);

            foreach (var airport in routes.Keys)
            {
                distances[airport] = airport == source ? 0 : int.MaxValue;
                minHeap.Enqueue(airport);
            }

            while (minHeap.Count > 0)
            {
                char current = minHeap.Dequeue();
                visited.Add(current);

                foreach (var neighbor in routes[current])
                {
                    if (!visited.Contains(neighbor.Key))
                    {
                        int newDistance = distances[current] + neighbor.Value;
                        if (newDistance < distances[neighbor.Key])
                        {
                            distances[neighbor.Key] = newDistance;
                            minHeap.UpdatePriority(neighbor.Key);
                        }
                    }
                }
            }

            return distances[destination];
        }
    }
}

