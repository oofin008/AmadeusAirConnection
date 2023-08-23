using System.Net;

namespace AmadeusAirConnection.API.Utils
{
	public record SuccessResult
	{
		public int Status { get; set; }
		public object Data { get; set; }
	}

	public record ErrorResult
	{
		public int Status { get; set; }
		public string Message { get; set; }
	}

	public class CustomActionResult
	{
		public static SuccessResult Success(object? data)
		{
			return new SuccessResult
			{
				Status = (int)HttpStatusCode.OK,
				Data = data,
			};
		}

		public static ErrorResult Error(int status, string message)
		{
			return new ErrorResult
			{
				Status = (int)status,
				Message = message,
			};
		}
	}
}

