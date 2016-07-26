using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using MvvmCross.Plugins.Messenger;

namespace Collect_A_Bull.Core.Services.Location
{
	class LocationService : ILocationService
	{
		public LocationService(IMvxLocationWatcher watcher, IMvxMessenger messenger)
		{
			_watcher = watcher;
			_watcher.Start(new MvxLocationOptions(), OnSuccess,OnError );

			_messenger = messenger;
		}

		private void OnSuccess(MvxGeoLocation location)
		{
			var coordinates = location.Coordinates;
			var message = new LocationMessage(coordinates.Latitude,coordinates.Longitude,this);
			_messenger.Publish(message);
		}

		private void OnError(MvxLocationError error)
		{
			Mvx.Warning("Error (code: {0}) in location service: {1}",error.Code ,error.ToString());
		}

		private readonly IMvxLocationWatcher _watcher;
		private readonly IMvxMessenger _messenger;
	}
}