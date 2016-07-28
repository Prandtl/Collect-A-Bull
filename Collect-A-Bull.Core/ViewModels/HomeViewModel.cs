using System.Windows.Input;
using Collect_A_Bull.Core.Services.Collections;
using Collect_A_Bull.Core.Services.DataStore;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace Collect_A_Bull.Core.ViewModels
{
	public class HomeViewModel
		: MvxViewModel
	{
		public HomeViewModel(ICollectionService collectionService, IMvxMessenger messenger)
		{
			_collectionService = collectionService;
			_messenger = messenger;

			_token = _messenger.SubscribeOnMainThread<RepositoryChangedMessage>(OnRepoChanged);

			RefreshLatest();
		}

		public Collectable Latest
		{
			get { return _latest; }
			set { SetProperty(ref _latest, value); }
		}
		public ICommand AddNewCommand
		{
			get
			{
				_addNewCommand = _addNewCommand ?? new MvxCommand(AddNewCollectable);
				return _addNewCommand;
			}
		}

		public ICommand ShowListCommand
		{
			get
			{
				_showListCommand = _showListCommand ?? new MvxCommand(ShowCollectedList);
				return _showListCommand;
			}
		}

		private void AddNewCollectable()
		{
			ShowViewModel<AddViewModel>();
			RefreshLatest();
		}

		private void ShowCollectedList()
		{
			ShowViewModel<ListViewModel>();
		}

		private void RefreshLatest()
		{
			Latest = _collectionService.GetLatest();
		}

		private void OnRepoChanged(RepositoryChangedMessage msg)
		{
			RefreshLatest();
		}

		private Collectable _latest;
		private MvxCommand _addNewCommand;
		private MvxCommand _showListCommand;

		private ICollectionService _collectionService;
		private IMvxMessenger _messenger;
		private MvxSubscriptionToken _token;
	}
}
