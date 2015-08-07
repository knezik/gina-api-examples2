using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace gina_api_examples2.Droid.Views
{
	[Activity(Label = "Api examples")]
	public class FirstView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.FirstView);
		}
	}
}