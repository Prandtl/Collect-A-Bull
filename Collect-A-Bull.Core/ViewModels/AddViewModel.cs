using Collect_A_Bull.Core.Services.Collections;
using Collect_A_Bull.Core.Services.Location;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace Collect_A_Bull.Core.ViewModels
{
	class AddViewModel:MvxViewModel
	{
		public AddViewModel(ICollectionService collectionService, ILocationService locationService, IMvxMessenger messenger)
		{
			_collectionService = collectionService;
			_locationService = locationService;
			_messenger = messenger;
			_messenger.SubscribeOnMainThread(OnLocation)
		}

		public string Caption
		{
			get { return _caption; }
			set { SetProperty(ref _caption, value); }
		}

		public string Note
		{
			get { return _note; }
			set { SetProperty(ref _note, value); }
		}

		private string _caption;
		private string _note;

		private readonly ICollectionService _collectionService;
		private readonly ILocationService _locationService;
		private readonly IMvxMessenger _messenger;
	}
}
