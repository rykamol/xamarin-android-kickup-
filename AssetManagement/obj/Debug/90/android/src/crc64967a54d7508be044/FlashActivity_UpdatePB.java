package crc64967a54d7508be044;


public class FlashActivity_UpdatePB
	extends android.os.AsyncTask
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_doInBackground:([Ljava/lang/Object;)Ljava/lang/Object;:GetDoInBackground_arrayLjava_lang_Object_Handler\n" +
			"n_onProgressUpdate:([Ljava/lang/Object;)V:GetOnProgressUpdate_arrayLjava_lang_Object_Handler\n" +
			"n_onPostExecute:(Ljava/lang/Object;)V:GetOnPostExecute_Ljava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("AssetManagement.Activities.FlashActivity+UpdatePB, AssetManagement", FlashActivity_UpdatePB.class, __md_methods);
	}


	public FlashActivity_UpdatePB ()
	{
		super ();
		if (getClass () == FlashActivity_UpdatePB.class)
			mono.android.TypeManager.Activate ("AssetManagement.Activities.FlashActivity+UpdatePB, AssetManagement", "", this, new java.lang.Object[] {  });
	}

	public FlashActivity_UpdatePB (android.app.Activity p0)
	{
		super ();
		if (getClass () == FlashActivity_UpdatePB.class)
			mono.android.TypeManager.Activate ("AssetManagement.Activities.FlashActivity+UpdatePB, AssetManagement", "Android.App.Activity, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public java.lang.Object doInBackground (java.lang.Object[] p0)
	{
		return n_doInBackground (p0);
	}

	private native java.lang.Object n_doInBackground (java.lang.Object[] p0);


	public void onProgressUpdate (java.lang.Object[] p0)
	{
		n_onProgressUpdate (p0);
	}

	private native void n_onProgressUpdate (java.lang.Object[] p0);


	public void onPostExecute (java.lang.Object p0)
	{
		n_onPostExecute (p0);
	}

	private native void n_onPostExecute (java.lang.Object p0);

	private java.util.ArrayList refList;
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
