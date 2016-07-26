using System.Collections.Generic;
using Collect_A_Bull.Core.Services.DataStore;

namespace Collect_A_Bull.Core.Services.Collections
{
	public interface ICollectionService
	{
		List<Collectable> GetAll();
		Collectable Latest { get; }
	}
}
