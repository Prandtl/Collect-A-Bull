using MvvmCross.Plugins.Messenger;

namespace Collect_A_Bull.Core.Services.Location
{
	class LocationMessage : MvxMessage
	{
		public LocationMessage(double lat, double lon, object sender) : base(sender)
		{
			Lat = lat;
			Lon = lon;
		}

		public double Lat { get; private set; }
		public double Lon { get; private set; }
	}
}