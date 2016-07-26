using MvvmCross.Plugins.Messenger;

namespace Collect_A_Bull.Core.Services.DataStore
{
	public class RepositoryChangedMessage:MvxMessage
	{
		public RepositoryChangedMessage(object sender,string method) : base(sender)
		{
			Method = method;
		}

		public string Method { get; set; }
	}
}