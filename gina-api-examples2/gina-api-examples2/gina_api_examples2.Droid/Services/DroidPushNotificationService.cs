using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;


[assembly: Permission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]

// Gives the app permission to register and receive messages.
[assembly: UsesPermission(Name = "com.google.android.c2dm.permission.RECEIVE")]

// This permission is necessary only for Android 4.0.3 and below.
[assembly: UsesPermission(Name = "android.permission.GET_ACCOUNTS")]

// Need to access the internet for GCM
[assembly: UsesPermission(Name = "android.permission.INTERNET")]

// Needed to keep the processor from sleeping when a message arrives
[assembly: UsesPermission(Name = "android.permission.WAKE_LOCK")]



namespace gina_api_examples2.Droid.Services
{
    public class DroidPushNotificationService : Core.Services.IPushNotificationService
    {
        // service for processing push notifications 
        [Service]
        public class PNIntentService : IntentService
        {
            static Android.OS.PowerManager.WakeLock sWakeLock;
            static object LOCK = new object();

            public static void RunIntentInService(Context context, Intent intent)
            {
                lock (LOCK)
                {
                    if (sWakeLock == null)
                    {
                        // This is called from BroadcastReceiver, there is no init.
                        var pm = Android.OS.PowerManager.FromContext(context);
                        sWakeLock = pm.NewWakeLock(Android.OS.WakeLockFlags.Partial, "My WakeLock Tag");
                    }
                }

                sWakeLock.Acquire();
                intent.SetClass(context, typeof(PNIntentService));
                context.StartService(intent);
            }

            protected override void OnHandleIntent(Intent intent)
            {
                try
                {
                    Context context = this.ApplicationContext;
                    string action = intent.Action;

                    string registrationId = intent.GetStringExtra("registration_id");
                    string error = intent.GetStringExtra("error");
                    string unregistration = intent.GetStringExtra("unregistered");

                    if (action.Equals("com.google.android.c2dm.intent.REGISTRATION"))
                    {
                        // HandleRegistration(context, intent);
                    }
                    else if (action.Equals("com.google.android.c2dm.intent.RECEIVE"))
                    {
                        // HandleMessage(context, intent);
                    }
                }
                finally
                {
                    lock (LOCK)
                    {
                        //Sanity check for null as this is a public method
                        if (sWakeLock != null)
                            sWakeLock.Release();
                    }
                }
            }
        }


        // broadcast receiver
        [BroadcastReceiver(Permission = "com.google.android.c2dm.permission.SEND")]
        [IntentFilter(new string[] { "com.google.android.c2dm.intent.RECEIVE" }, Categories = new string[] { "@PACKAGE_NAME@" })]
        [IntentFilter(new string[] { "com.google.android.c2dm.intent.REGISTRATION" }, Categories = new string[] { "@PACKAGE_NAME@" })]
        [IntentFilter(new string[] { "com.google.android.gcm.intent.RETRY" }, Categories = new string[] { "@PACKAGE_NAME@" })]
        private class GCMBroadcastReceiver : BroadcastReceiver
        {
            const string TAG = "PushHandlerBroadcastReceiver";
            public override void OnReceive(Context context, Intent intent)
            {
                PNIntentService.RunIntentInService(context, intent);
                SetResult(Result.Ok, null, null);
            }
        }



        // main class
        public void StartService()
        {
            string senders = "922250740088";
            Intent intent = new Intent("com.google.android.c2dm.intent.REGISTER");

            intent.SetPackage("com.google.android.gsf");
            intent.PutExtra("app", PendingIntent.GetBroadcast(Application.Context, 0, new Intent(), 0));
            intent.PutExtra("sender", senders);
            Application.Context.StartService(intent);
        }

        public void StopService()
        {
            Intent intent = new Intent("com.google.android.c2dm.intent.UNREGISTER");

            intent.PutExtra("app", PendingIntent.GetBroadcast(Application.Context, 0, new Intent(), 0));
            Application.Context.StartService(intent);
        }
    }
}