package mono.com.wdullaer.materialdatetimepicker.date;


public class DatePickerDialog_OnDateSetListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.wdullaer.materialdatetimepicker.date.DatePickerDialog.OnDateSetListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDateSet:(Lcom/wdullaer/materialdatetimepicker/date/DatePickerDialog;III)V:GetOnDateSet_Lcom_wdullaer_materialdatetimepicker_date_DatePickerDialog_IIIHandler:Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog/IOnDateSetListenerInvoker, Xamarin.Bindings.MaterialDateTimePicker\n" +
			"";
		mono.android.Runtime.register ("Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog+IOnDateSetListenerImplementor, Xamarin.Bindings.MaterialDateTimePicker", DatePickerDialog_OnDateSetListenerImplementor.class, __md_methods);
	}


	public DatePickerDialog_OnDateSetListenerImplementor ()
	{
		super ();
		if (getClass () == DatePickerDialog_OnDateSetListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog+IOnDateSetListenerImplementor, Xamarin.Bindings.MaterialDateTimePicker", "", this, new java.lang.Object[] {  });
	}


	public void onDateSet (com.wdullaer.materialdatetimepicker.date.DatePickerDialog p0, int p1, int p2, int p3)
	{
		n_onDateSet (p0, p1, p2, p3);
	}

	private native void n_onDateSet (com.wdullaer.materialdatetimepicker.date.DatePickerDialog p0, int p1, int p2, int p3);

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
