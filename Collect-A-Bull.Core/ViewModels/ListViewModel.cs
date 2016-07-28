using System.Collections.Generic;
using System.Windows.Input;
using Collect_A_Bull.Core.Services.Collections;
using Collect_A_Bull.Core.Services.DataStore;
using MvvmCross.Core.ViewModels;

namespace Collect_A_Bull.Core.ViewModels
{
	public class ListViewModel : MvxViewModel
	{
		public ListViewModel(ICollectionService collectionService)
		{
			_collectionService = collectionService;
			Collectables = _collectionService.GetAll();
		}

		public List<Collectable> Collectables
		{
			get { return _collectables; }
			set { SetProperty(ref _collectables, value); }
		}

		public ICommand ShowDetailsCommand
		{
			get
			{
				return new MvxCommand<Collectable>(item => ShowViewModel<DetailsViewModel>(new DetailsViewModel.Nav() { Id = item.Id }));
			}
		}

		public ICommand GoBackCommand
		{
			get
			{
				_goBackCommand = _goBackCommand ?? new MvxCommand(GoBack);
				return _goBackCommand;
			}
		}

		private void GoBack()
		{
			Close(this);
		}

		private List<Collectable> _collectables;
		private MvxCommand _goBackCommand;

		private readonly ICollectionService _collectionService;
	}
}