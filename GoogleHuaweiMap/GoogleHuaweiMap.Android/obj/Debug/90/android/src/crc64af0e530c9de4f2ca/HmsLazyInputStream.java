package crc64af0e530c9de4f2ca;


public class HmsLazyInputStream
	extends com.huawei.agconnect.config.LazyInputStream
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_get:(Landroid/content/Context;)Ljava/io/InputStream;:GetGet_Landroid_content_Context_Handler\n" +
			"";
		mono.android.Runtime.register ("GoogleHuaweiMap.Droid.HmsLazyInputStream, GoogleHuaweiMap.Android", HmsLazyInputStream.class, __md_methods);
	}


	public HmsLazyInputStream (android.content.Context p0)
	{
		super (p0);
		if (getClass () == HmsLazyInputStream.class)
			mono.android.TypeManager.Activate ("GoogleHuaweiMap.Droid.HmsLazyInputStream, GoogleHuaweiMap.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public java.io.InputStream get (android.content.Context p0)
	{
		return n_get (p0);
	}

	private native java.io.InputStream n_get (android.content.Context p0);

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
