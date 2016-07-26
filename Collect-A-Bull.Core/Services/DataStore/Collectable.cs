using System;
using SQLite.Net.Attributes;

namespace Collect_A_Bull.Core.Services.DataStore
{
	class Collectable
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		public string Caption { get; set; }
		public string Note { get; set; }

		public bool LocationKnown { get; set; }
		public double Lat { get; set; }
		public double Lon { get; set; }

		public DateTime CapturedAtUtc { get; set; }
		public string ImagePath { get; set; }
	}
}
