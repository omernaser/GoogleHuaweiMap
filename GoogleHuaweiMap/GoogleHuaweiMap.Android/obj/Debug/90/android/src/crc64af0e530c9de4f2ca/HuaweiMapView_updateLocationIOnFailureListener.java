package crc64af0e530c9de4f2ca;


public class HuaweiMapView_updateLocationIOnFailureListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.huawei.hmf.tasks.OnFailureListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFailure:(Ljava/lang/Exception;)V:GetOnFailure_Ljava_lang_Exception_Handler:Com.Huawei.Hmf.Tasks.IOnFailureListenerInvoker, XTask-1.3.3.300\n" +
			"";
		mono.android.Runtime.register ("GoogleHuaweiMap.Droid.HuaweiMapView+updateLocationIOnFailureListener, GoogleHuaweiMap.Android", HuaweiMapView_updateLocationIOnFailureListener.class, __md_methods);
	}


	public HuaweiMapView_updateLocationIOnFailureListener ()
	{
		super ();
		if (getClass () == HuaweiMapView_updateLocationIOnFailureListener.class)
			mono.android.TypeManager.Activate ("GoogleHuaweiMap.Droid.HuaweiMapView+updateLocationIOnFailureListener, GoogleHuaweiMap.Android", "", this, new java.lang.Object[] {  });
	}

	public HuaweiMapView_updateLocationIOnFailureListener (crc64af0e530c9de4f2ca.HuaweiMapView p0)
	{
		super ();
		if (getClass () == HuaweiMapView_updateLocationIOnFailureListener.class)
			mono.android.TypeManager.Activate ("GoogleHuaweiMap.Droid.HuaweiMapView+updateLocationIOnFailureListener, GoogleHuaweiMap.Android", "GoogleHuaweiMap.Droid.HuaweiMapView, GoogleHuaweiMap.Android", this, new java.lang.Object[] { p0 });
	}


	public void onFailure (java.lang.Exception p0)
	{
		n_onFailure (p0);
	}

	private native void n_onFailure (java.lang.Exception p0);

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
