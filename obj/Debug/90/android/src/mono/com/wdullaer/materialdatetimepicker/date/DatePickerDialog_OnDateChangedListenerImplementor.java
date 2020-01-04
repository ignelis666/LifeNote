package mono.com.wdullaer.materialdatetimepicker.date;


public class DatePickerDialog_OnDateChangedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.wdullaer.materialdatetimepicker.date.DatePickerDialog.OnDateChangedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDateChanged:()V:GetOnDateChangedHandler:Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog/IOnDateChangedListenerInvoker, Xamarin.Bindings.MaterialDateTimePicker\n" +
			"";
		mono.android.Runtime.register ("Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog+IOnDateChangedListenerImplementor, Xamarin.Bindings.MaterialDateTimePicker", DatePickerDialog_OnDateChangedListenerImplementor.class, __md_methods);
	}


	public DatePickerDialog_OnDateChangedListenerImplementor ()
	{
		super ();
		if (getClass () == DatePickerDialog_OnDateChangedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog+IOnDateChangedListenerImplementor, Xamarin.Bindings.MaterialDateTimePicker", "", this, new java.lang.Object[] {  });
	}


	public void onDateChanged ()
	{
		n_onDateChanged ();
	}

	private native void n_onDateChanged ();

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
