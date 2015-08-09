package md5d2dfef184c24c5e6792f8e534ce0cde5;


public class DroidPushNotificationService_PNIntentService
	extends mono.android.app.IntentService
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onHandleIntent:(Landroid/content/Intent;)V:GetOnHandleIntent_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("gina_api_examples2.Droid.Services.DroidPushNotificationService/PNIntentService, gina_api_examples2.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DroidPushNotificationService_PNIntentService.class, __md_methods);
	}


	public DroidPushNotificationService_PNIntentService (java.lang.String p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == DroidPushNotificationService_PNIntentService.class)
			mono.android.TypeManager.Activate ("gina_api_examples2.Droid.Services.DroidPushNotificationService/PNIntentService, gina_api_examples2.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0 });
	}


	public DroidPushNotificationService_PNIntentService () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DroidPushNotificationService_PNIntentService.class)
			mono.android.TypeManager.Activate ("gina_api_examples2.Droid.Services.DroidPushNotificationService/PNIntentService, gina_api_examples2.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onHandleIntent (android.content.Intent p0)
	{
		n_onHandleIntent (p0);
	}

	private native void n_onHandleIntent (android.content.Intent p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
