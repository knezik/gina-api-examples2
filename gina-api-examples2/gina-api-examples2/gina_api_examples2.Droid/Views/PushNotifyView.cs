using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.OS;

using Cirrious.MvvmCross.Droid.Views;


namespace gina_api_examples2.Droid.Views
{
    [Activity(Label = "Push notify example", NoHistory = true)]
    public class PushNotifyView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Test_PushNotify);
        }
    }
}