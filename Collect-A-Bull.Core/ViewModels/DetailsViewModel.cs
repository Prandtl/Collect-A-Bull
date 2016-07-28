using System.Windows.Input;
using Collect_A_Bull.Core.Services.Collections;
using Collect_A_Bull.Core.Services.DataStore;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace Collect_A_Bull.Core.ViewModels
{
	class DetailsViewModel : MvxViewModel
	{
		public DetailsViewModel(ICollectionService collectionService)
		{
			_collectionService = collectionService;
		}
		
		public class Nav
		{
			public int Id { get; set; }
		}

		public void Init(Nav navigation)
		{
			Item = _collectionService.Get(navigation.Id);
		}

		public Collectable Item
		{
			get { return _item;}
			set { SetProperty(ref _item, value); }
		}

		public ICommand DeleteCommand
		{
			get
			{
				_deleteCommand = _deleteCommand ?? new MvxCommand(DeleteItem);
				return _deleteCommand;
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

		private void DeleteItem()
		{
			_collectionService.Delete(Item);
			Close(this);
		}

		private void GoBack()
		{
			Close(this);
		}

		private Collectable _item;
		private MvxCommand _deleteCommand;
		private MvxCommand _goBackCommand;

		private readonly ICollectionService _collectionService;
	}
}
