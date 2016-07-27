using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;

namespace Collect_A_Bull.Core.Services.Location
{
	public class LocationService : ILocationService
	{
		public LocationService(IMvxLocationWatcher watcher, IMvxMessenger messenger)
		{
			_watcher = watcher;
			_watcher.Start(new MvxLocationOptions(), OnSuccess, OnError);
			_lockObject = new object();
			_messenger = messenger;
		}
		public bool TryGetlatestLocation(out double lat, out double lon)
		{
			lock (_lockObject)
			{
				if (_latestLocation == null)
				{
					lat = 0;
					lon = 0;
					return false;
				}
				lat = _latestLocation.Coordinates.Latitude;
				lon = _latestLocation.Coordinates.Longitude;
				return true;
			}
		}

		private void OnSuccess(MvxGeoLocation location)
		{
			lock (_lockObject)
			{
				_latestLocation = location;
			}
			var coordinates = location.Coordinates;
			var message = new LocationMessage(coordinates.Latitude, coordinates.Longitude, this);
			_messenger.Publish(message);
		}

		private static void OnError(MvxLocationError error)
		{
			Mvx.Warning("Error (code: {0}) in location service: {1}", error.Code, error.ToString());
		}

		private MvxGeoLocation _latestLocation;
		private readonly object _lockObject;

		private readonly IMvxLocationWatcher _watcher;
		private readonly IMvxMessenger _messenger;
		
	}
}