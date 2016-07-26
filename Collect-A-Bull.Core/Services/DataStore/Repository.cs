using System.Collections.Generic;
using System.Linq;
using MvvmCross.Plugins.Sqlite;
using SQLite.Net;

namespace Collect_A_Bull.Core.Services.DataStore
{
	public class Repository : IRepository
	{
		public Repository(IMvxSqliteConnectionFactory factory)
		{
			_connection = factory.GetConnection("collectables.sql");
			_connection.CreateTable<Collectable>();
		}

		public List<Collectable> AllCollectables()
		{
			return _connection.Table<Collectable>()
					.OrderByDescending(c => c.CapturedAtUtc)
					.ToList();
		}

		public void Add(Collectable item)
		{
			_connection.Insert(item);
		}

		public void Delete(Collectable item)
		{
			_connection.Delete(item);
		}

		public void Update(Collectable item)
		{
			_connection.Update(item);
		}

		private readonly SQLiteConnection _connection;
	}
}