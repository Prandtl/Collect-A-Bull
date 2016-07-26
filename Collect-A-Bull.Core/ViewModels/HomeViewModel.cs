using Collect_A_Bull.Core.Services.DataStore;
using MvvmCross.Core.ViewModels;

namespace Collect_A_Bull.Core.ViewModels
{
	public class HomeViewModel
		: MvxViewModel
	{
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
			throw new System.NotImplementedException();
		}

		private void ShowCollectedList()
		{
			throw new System.NotImplementedException();
		}

		private Collectable _latest;
		private MvxCommand _addNewCommand;
		private MvxCommand _showListCommand;
	}
}
