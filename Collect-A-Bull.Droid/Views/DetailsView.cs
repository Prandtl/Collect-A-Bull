using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace Collect_A_Bull.Droid.Views
{
    [Activity(Label = "Details")]
    public class DetailsView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.DetailsView);
        }
    }
}
