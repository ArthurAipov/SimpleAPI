using System;
using SimpleAPI.Models;

namespace SimpleAPI.ModelSettings
{
	public class StatusSettings
	{
		public static List<Status> statuses = new List<Status>()
		{
			new Status(1, "no the way"),
			new Status(2, "canceled"),
			new Status(3, "ready")
		};
	}
}

