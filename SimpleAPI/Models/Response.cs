using System;
namespace SimpleAPI.Models
{
	public class Response
	{
		public Response(string message)
		{
			this.message = message;
		}

		public string message { get; set; }

	}
}

