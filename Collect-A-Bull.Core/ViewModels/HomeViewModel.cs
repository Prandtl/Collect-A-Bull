using Collect_A_Bull.Core.Services.Collections;
using Collect_A_Bull.Core.Services.DataStore;
using MvvmCross.Core.ViewModels;

namespace Collect_A_Bull.Core.ViewModels
{
	public class HomeViewModel
		: MvxViewModel
	{
		public HomeViewModel(ICollectionService collectionService)
		{
			_collectionService = collectionService;
			Latest = _collectionService.Latest;
		}

		public Collectable Latest
		{
			get { return _latest; }
			set { SetProperty(ref _latest, value); }
		}
		public System.Windows.Input.ICommand AddNewCommand
		{
			get
			{
				_addNewCommand = _addNewCommand ?? new MvxCommand(AddNewCollectable);
				return _addNewCommand;
			}
		}

		public System.Windows.Input.ICommand ShowListCommand
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
		}

		private void ShowCollectedList()
		{
			ShowViewModel<ListViewModel>();
		}

		private Collectable _latest;
		private MvxCommand _addNewCommand;
		private MvxCommand _showListCommand;

		private ICollectionService _collectionService;
	}
}
