using System;
using AmadeusAirConnection.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace AmadeusAirConnection.UseCase
{
	public static class Singleton
	{
		public static IServiceCollection AddUseCaseLayer(this IServiceCollection services)
		{
			services.AddDomainLayer();
			services.AddSingleton<IAmadeusService, AmadeusService>();
			return services;
		}
	}
}

