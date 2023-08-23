using System;
using AmadeusAirConnection.UseCase;

namespace AmadeusAirConnection.API
{
	public static class Singleton
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddUseCaseLayer();
			return services;
		}
	}
}
