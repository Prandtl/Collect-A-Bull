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

		public Collectable Latest => _repository.AllCollectables().FirstOrDefault();

		public void Add(Collectable newCollectable)
		{
			_repository.Add(newCollectable);
		}

		private readonly IRepository _repository;

	}
}