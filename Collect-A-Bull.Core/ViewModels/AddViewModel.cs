using MvvmCross.Core.ViewModels;

namespace Collect_A_Bull.Core.ViewModels
{
	class AddViewModel:MvxViewModel
	{
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
	}
}
