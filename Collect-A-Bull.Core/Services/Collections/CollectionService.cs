using System.Collections.Generic;
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

		private readonly IRepository _repository;

	}
}