package mono.com.wdullaer.materialdatetimepicker.time;


public class RadialPickerLayout_OnValueSelectedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.wdullaer.materialdatetimepicker.time.RadialPickerLayout.OnValueSelectedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_advancePicker:(I)V:GetAdvancePicker_IHandler:Com.Wdullaer.Materialdatetimepicker.Time.RadialPickerLayout/IOnValueSelectedListenerInvoker, Xamarin.Bindings.MaterialDateTimePicker\n" +
			"n_enablePicker:()V:GetEnablePickerHandler:Com.Wdullaer.Materialdatetimepicker.Time.RadialPickerLayout/IOnValueSelectedListenerInvoker, Xamarin.Bindings.MaterialDateTimePicker\n" +
			"n_onValueSelected:(Lcom/wdullaer/materialdatetimepicker/time/Timepoint;)V:GetOnValueSelected_Lcom_wdullaer_materialdatetimepicker_time_Timepoint_Handler:Com.Wdullaer.Materialdatetimepicker.Time.RadialPickerLayout/IOnValueSelectedListenerInvoker, Xamarin.Bindings.MaterialDateTimePicker\n" +
			"";
		mono.android.Runtime.register ("Com.Wdullaer.Materialdatetimepicker.Time.RadialPickerLayout+IOnValueSelectedListenerImplementor, Xamarin.Bindings.MaterialDateTimePicker", RadialPickerLayout_OnValueSelectedListenerImplementor.class, __md_methods);
	}


	public RadialPickerLayout_OnValueSelectedListenerImplementor ()
	{
		super ();
		if (getClass () == RadialPickerLayout_OnValueSelectedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Wdullaer.Materialdatetimepicker.Time.RadialPickerLayout+IOnValueSelectedListenerImplementor, Xamarin.Bindings.MaterialDateTimePicker", "", this, new java.lang.Object[] {  });
	}


	public void advancePicker (int p0)
	{
		n_advancePicker (p0);
	}

	private native void n_advancePicker (int p0);


	public void enablePicker ()
	{
		n_enablePicker ();
	}

	private native void n_enablePicker ();


	public void onValueSelected (com.wdullaer.materialdatetimepicker.time.Timepoint p0)
	{
		n_onValueSelected (p0);
	}

	private native void n_onValueSelected (com.wdullaer.materialdatetimepicker.time.Timepoint p0);

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
