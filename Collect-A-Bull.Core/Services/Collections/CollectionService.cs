using System.Collections.Generic;
using System.Linq;
using Collect_A_Bull.Core.Services.DataStore;

namespace Collect_A_Bull.Core.Services.Collections
{
	public class CollectionService : ICollectionService
	{
		public CollectionService(IRepository repository)
		{
			_repository = repository;
		}

		public List<Collectable> GetAll()
		{
			return _repository.AllCollectables();
		}

		public Collectable GetLatest()
		{
			return GetAll()
				.OrderByDescending(x => x.CapturedAtUtc)
				.FirstOrDefault();
		}

		public Collectable Get(int id)
		{
			return GetAll().FirstOrDefault(c => c.Id == id);
		}

		public void Add(Collectable newCollectable)
		{
			_repository.Add(newCollectable);
		}

		public void Update(Collectable item)
		{
			_repository.Update(item);
		}

		public void Delete(Collectable item)
		{
			_repository.Delete(item);
		}

		private readonly IRepository _repository;

	}
}