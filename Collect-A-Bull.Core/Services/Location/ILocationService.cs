namespace Collect_A_Bull.Core.Services.Location
{
	public interface ILocationService
	{
		bool TryGetlatestLocation(out double lat, out double lon);
	}
}