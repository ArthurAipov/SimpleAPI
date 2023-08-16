using System;
namespace SimpleAPI.Models
{
	public class Status
	{
		public Status(int id, string name)
		{
			this.id = id;
			this.name = name;
		}

		public int id { get; set; }
		public string name { get; set; }

	}
}

