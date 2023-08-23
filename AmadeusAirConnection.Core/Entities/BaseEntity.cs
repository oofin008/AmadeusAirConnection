using System;
namespace AmadeusAirConnection.Domain.Entities
{
	abstract public class BaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public BaseEntity(string name)
		{
			Name = name;
		}
	}
}

