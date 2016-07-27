using System;
using System.IO;
using System.Windows.Input;
using Collect_A_Bull.Core.Services.Collections;
using Collect_A_Bull.Core.Services.DataStore;
using Collect_A_Bull.Core.Services.Location;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.File;
using MvvmCross.Plugins.Messenger;
using MvvmCross.Plugins.PictureChooser;

namespace Collect_A_Bull.Core.ViewModels
{
	class AddViewModel : MvxViewModel
	{
		public AddViewModel(ICollectionService collectionService,
							ILocationService locationService,
							IMvxMessenger messenger,
							IMvxPictureChooserTask pictureChooserTask,
							IMvxFileStore fileStore)
		{
			_collectionService = collectionService;
			_locationService = locationService;
			_messenger = messenger;
			_pictureChooserTask = pictureChooserTask;
			_token = _messenger.SubscribeOnMainThread<LocationMessage>(OnLocation);
			_fileStore = fileStore;
			GetInitialLocation();
			UseLocation = true;
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

		public bool LocationKnown
		{
			get { return _locationKnown; }
			set { SetProperty(ref _locationKnown, value); }
		}

		public bool UseLocation
		{
			get { return _useLocation; }
			set { SetProperty(ref _useLocation, value); }
		}

		public double Latitude
		{
			get { return _latitude; }
			set { SetProperty(ref _latitude, value); }
		}

		public double Longitude
		{
			get { return _longitude; }
			set { SetProperty(ref _longitude, value); }
		}

		public DateTime CapturedAtUtc
		{
			get { return _capturedAtUtc; }
			set { SetProperty(ref _capturedAtUtc, value); }
		}

		public string ImagePath
		{
			get { return _imagePath; }
			set { SetProperty(ref _imagePath, value); }
		}

		public byte[] PictureBytes
		{
			get { return _pictureBytes; }
			set { SetProperty(ref _pictureBytes, value); }
		}

		public ICommand SaveCommand
		{
			get
			{
				_saveCommand = _saveCommand ?? new MvxCommand(SaveCollectable);
				return _saveCommand;
			}
		}

		public ICommand AttachPictureCommand
		{
			get
			{
				_attachPictureCommand = _attachPictureCommand ?? new MvxCommand(AttachPicture);
				return _attachPictureCommand;
			}
		}

		private void GetInitialLocation()
		{
			double lat, lon;
			if (!_locationService.TryGetlatestLocation(out lat, out lon)) return;
			_locationKnown = true;
			Latitude = lat;
			Longitude = lon;
		}

		private void OnLocation(LocationMessage location)
		{
			LocationKnown = true;
			Latitude = location.Lat;
			Longitude = location.Lon;
		}

		private void SaveCollectable()
		{
			if (!Validate())
				return;
			if (PictureBytes != null)
			{
				ImagePath = GenerateImagePath();
				_fileStore.WriteFile(ImagePath, PictureBytes);
			}
			if (!UseLocation)
			{
				LocationKnown = false;
				Latitude = 0;
				Longitude = 0;
			}
			var newCollectable = new Collectable()
			{
				Caption = Caption,
				Note = Note,
				CapturedAtUtc = DateTime.UtcNow,
				LocationKnown = LocationKnown,
				Lat = Latitude,
				Lon = Longitude,
				ImagePath = ImagePath
			};
			_collectionService.Add(newCollectable);
			Close(this);
		}

		private void AttachPicture()
		{
			_pictureChooserTask.ChoosePictureFromLibrary(400, 90, OnPicture, (() => { }));
		}

		private void OnPicture(Stream stream)
		{
			var ms = new MemoryStream();
			stream.CopyTo(ms);
			PictureBytes = ms.ToArray();
		}

		private string GenerateImagePath()
		{
			var id = Guid.NewGuid().ToString("N");
			var name = $"img{id}.jpg";
			_imageFolderPath = "images";
			_fileStore.EnsureFolderExists(_imageFolderPath);
			var path = _fileStore.PathCombine(_fileStore.NativePath(_imageFolderPath), name);
			return path;
		}

		private bool Validate()
		{
			return !string.IsNullOrWhiteSpace(Caption);
		}

		private string _caption;
		private string _note;
		private bool _locationKnown;
		private bool _useLocation;
		private double _latitude;
		private double _longitude;
		private DateTime _capturedAtUtc;
		private string _imagePath;
		private MvxCommand _saveCommand;
		private MvxCommand _attachPictureCommand;
		private byte[] _pictureBytes;

		private readonly ICollectionService _collectionService;
		private readonly ILocationService _locationService;
		private readonly IMvxMessenger _messenger;
		private MvxSubscriptionToken _token;
		private IMvxPictureChooserTask _pictureChooserTask;
		private IMvxFileStore _fileStore;
		private string _imageFolderPath;
	}
}
