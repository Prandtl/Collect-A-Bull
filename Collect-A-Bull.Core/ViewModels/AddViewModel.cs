﻿using System;
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
			_messenger.SubscribeOnMainThread<LocationMessage>(OnLocation);
		}

		private void OnLocation(LocationMessage location)
		{
			throw new System.NotImplementedException();
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
			get { return _imagePath;}
			set { SetProperty(ref _imagePath, value); }
		}

		private string _caption;
		private string _note;
		private bool _locationKnown;
		private double _latitude;
		private double _longitude;
		private DateTime _capturedAtUtc;
		private string _imagePath;

		private readonly ICollectionService _collectionService;
		private readonly ILocationService _locationService;
		private readonly IMvxMessenger _messenger;
		
	}
}
