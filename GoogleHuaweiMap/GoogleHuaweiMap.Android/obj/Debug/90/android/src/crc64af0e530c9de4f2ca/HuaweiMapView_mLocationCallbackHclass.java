package crc64af0e530c9de4f2ca;


public class HuaweiMapView_mLocationCallbackHclass
	extends com.huawei.hms.location.LocationCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLocationResult:(Lcom/huawei/hms/location/LocationResult;)V:GetOnLocationResult_Lcom_huawei_hms_location_LocationResult_Handler\n" +
			"n_onLocationAvailability:(Lcom/huawei/hms/location/LocationAvailability;)V:GetOnLocationAvailability_Lcom_huawei_hms_location_LocationAvailability_Handler\n" +
			"";
		mono.android.Runtime.register ("GoogleHuaweiMap.Droid.HuaweiMapView+mLocationCallbackHclass, GoogleHuaweiMap.Android", HuaweiMapView_mLocationCallbackHclass.class, __md_methods);
	}


	public HuaweiMapView_mLocationCallbackHclass ()
	{
		super ();
		if (getClass () == HuaweiMapView_mLocationCallbackHclass.class)
			mono.android.TypeManager.Activate ("GoogleHuaweiMap.Droid.HuaweiMapView+mLocationCallbackHclass, GoogleHuaweiMap.Android", "", this, new java.lang.Object[] {  });
	}

	public HuaweiMapView_mLocationCallbackHclass (crc64af0e530c9de4f2ca.HuaweiMapView p0)
	{
		super ();
		if (getClass () == HuaweiMapView_mLocationCallbackHclass.class)
			mono.android.TypeManager.Activate ("GoogleHuaweiMap.Droid.HuaweiMapView+mLocationCallbackHclass, GoogleHuaweiMap.Android", "GoogleHuaweiMap.Droid.HuaweiMapView, GoogleHuaweiMap.Android", this, new java.lang.Object[] { p0 });
	}


	public void onLocationResult (com.huawei.hms.location.LocationResult p0)
	{
		n_onLocationResult (p0);
	}

	private native void n_onLocationResult (com.huawei.hms.location.LocationResult p0);


	public void onLocationAvailability (com.huawei.hms.location.LocationAvailability p0)
	{
		n_onLocationAvailability (p0);
	}

	private native void n_onLocationAvailability (com.huawei.hms.location.LocationAvailability p0);

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
