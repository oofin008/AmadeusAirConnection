using System;
using AmadeusAirConnection.Domain.Interfaces;
using AmadeusAirConnection.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace AmadeusAirConnection.Domain
{
	public static class Singleton
	{
		public static IServiceCollection AddDomainLayer(this IServiceCollection services)
		{
			services.AddSingleton<IItinerary, Itinerary>();
			return services;
		}
	}
}

