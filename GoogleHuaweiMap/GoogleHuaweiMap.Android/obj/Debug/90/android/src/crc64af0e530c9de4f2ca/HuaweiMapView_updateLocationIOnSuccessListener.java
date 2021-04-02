package crc64af0e530c9de4f2ca;


public class HuaweiMapView_updateLocationIOnSuccessListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.huawei.hmf.tasks.OnSuccessListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSuccess:(Ljava/lang/Object;)V:GetOnSuccess_Ljava_lang_Object_Handler:Com.Huawei.Hmf.Tasks.IOnSuccessListenerInvoker, XTask-1.3.3.300\n" +
			"";
		mono.android.Runtime.register ("GoogleHuaweiMap.Droid.HuaweiMapView+updateLocationIOnSuccessListener, GoogleHuaweiMap.Android", HuaweiMapView_updateLocationIOnSuccessListener.class, __md_methods);
	}


	public HuaweiMapView_updateLocationIOnSuccessListener ()
	{
		super ();
		if (getClass () == HuaweiMapView_updateLocationIOnSuccessListener.class)
			mono.android.TypeManager.Activate ("GoogleHuaweiMap.Droid.HuaweiMapView+updateLocationIOnSuccessListener, GoogleHuaweiMap.Android", "", this, new java.lang.Object[] {  });
	}

	public HuaweiMapView_updateLocationIOnSuccessListener (crc64af0e530c9de4f2ca.HuaweiMapView p0)
	{
		super ();
		if (getClass () == HuaweiMapView_updateLocationIOnSuccessListener.class)
			mono.android.TypeManager.Activate ("GoogleHuaweiMap.Droid.HuaweiMapView+updateLocationIOnSuccessListener, GoogleHuaweiMap.Android", "GoogleHuaweiMap.Droid.HuaweiMapView, GoogleHuaweiMap.Android", this, new java.lang.Object[] { p0 });
	}


	public void onSuccess (java.lang.Object p0)
	{
		n_onSuccess (p0);
	}

	private native void n_onSuccess (java.lang.Object p0);

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
