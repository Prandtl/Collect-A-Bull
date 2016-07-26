using System.Collections.Generic;

namespace Collect_A_Bull.Core.Services.DataStore
{
	public interface IRepository
	{
		List<Collectable> AllCollectables();
		void Add(Collectable item);
		void Delete(Collectable item);
		void Update(Collectable item);
	}
}
