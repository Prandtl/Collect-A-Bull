using System.Collections.Generic;
using System.Linq;
using MvvmCross.Plugins.Messenger;
using MvvmCross.Plugins.Sqlite;
using SQLite.Net;

namespace Collect_A_Bull.Core.Services.DataStore
{
	public class Repository : IRepository
	{
		public Repository(IMvxSqliteConnectionFactory factory, IMvxMessenger messenger)
		{
			_connection = factory.GetConnection("collectables.sql");
			_connection.CreateTable<Collectable>();

			_messenger = messenger;
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
			_messenger.Publish(new RepositoryChangedMessage(this, "insert"));
		}

		public void Delete(Collectable item)
		{
			_connection.Delete(item);
			_messenger.Publish(new RepositoryChangedMessage(this, "delete"));
		}

		public void Update(Collectable item)
		{
			_connection.Update(item);
			_messenger.Publish(new RepositoryChangedMessage(this, "update"));
		}

		private readonly SQLiteConnection _connection;
		private IMvxMessenger _messenger;
	}
}