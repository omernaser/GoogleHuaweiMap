package crc64af0e530c9de4f2ca;


public class HuaweiMapView
	extends android.widget.LinearLayout
	implements
		mono.android.IGCUserPeer,
		com.huawei.hms.maps.OnMapReadyCallback,
		com.huawei.hms.maps.HuaweiMap.OnCameraMoveStartedListener,
		com.huawei.hms.maps.HuaweiMap.OnCameraMoveListener,
		com.huawei.hms.maps.HuaweiMap.OnCameraIdleListener,
		com.huawei.hms.maps.HuaweiMap.OnMyLocationButtonClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAttachedToWindow:()V:GetOnAttachedToWindowHandler\n" +
			"n_onMapReady:(Lcom/huawei/hms/maps/HuaweiMap;)V:GetOnMapReady_Lcom_huawei_hms_maps_HuaweiMap_Handler:Com.Huawei.Hms.Maps.IOnMapReadyCallbackInvoker, XHmsMaps-4.0.1.300\n" +
			"n_onCameraMoveStarted:(I)V:GetOnCameraMoveStarted_IHandler:Com.Huawei.Hms.Maps.HuaweiMap/IOnCameraMoveStartedListenerInvoker, XHmsMaps-4.0.1.300\n" +
			"n_onCameraMove:()V:GetOnCameraMoveHandler:Com.Huawei.Hms.Maps.HuaweiMap/IOnCameraMoveListenerInvoker, XHmsMaps-4.0.1.300\n" +
			"n_onCameraIdle:()V:GetOnCameraIdleHandler:Com.Huawei.Hms.Maps.HuaweiMap/IOnCameraIdleListenerInvoker, XHmsMaps-4.0.1.300\n" +
			"n_onMyLocationButtonClick:()Z:GetOnMyLocationButtonClickHandler:Com.Huawei.Hms.Maps.HuaweiMap/IOnMyLocationButtonClickListenerInvoker, XHmsMaps-4.0.1.300\n" +
			"";
		mono.android.Runtime.register ("GoogleHuaweiMap.Droid.HuaweiMapView, GoogleHuaweiMap.Android", HuaweiMapView.class, __md_methods);
	}


	public HuaweiMapView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == HuaweiMapView.class)
			mono.android.TypeManager.Activate ("GoogleHuaweiMap.Droid.HuaweiMapView, GoogleHuaweiMap.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public HuaweiMapView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == HuaweiMapView.class)
			mono.android.TypeManager.Activate ("GoogleHuaweiMap.Droid.HuaweiMapView, GoogleHuaweiMap.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public HuaweiMapView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == HuaweiMapView.class)
			mono.android.TypeManager.Activate ("GoogleHuaweiMap.Droid.HuaweiMapView, GoogleHuaweiMap.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public HuaweiMapView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == HuaweiMapView.class)
			mono.android.TypeManager.Activate ("GoogleHuaweiMap.Droid.HuaweiMapView, GoogleHuaweiMap.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onAttachedToWindow ()
	{
		n_onAttachedToWindow ();
	}

	private native void n_onAttachedToWindow ();


	public void onMapReady (com.huawei.hms.maps.HuaweiMap p0)
	{
		n_onMapReady (p0);
	}

	private native void n_onMapReady (com.huawei.hms.maps.HuaweiMap p0);


	public void onCameraMoveStarted (int p0)
	{
		n_onCameraMoveStarted (p0);
	}

	private native void n_onCameraMoveStarted (int p0);


	public void onCameraMove ()
	{
		n_onCameraMove ();
	}

	private native void n_onCameraMove ();


	public void onCameraIdle ()
	{
		n_onCameraIdle ();
	}

	private native void n_onCameraIdle ();


	public boolean onMyLocationButtonClick ()
	{
		return n_onMyLocationButtonClick ();
	}

	private native boolean n_onMyLocationButtonClick ();

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
