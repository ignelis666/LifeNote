package mono.com.wdullaer.materialdatetimepicker.date;


public class MonthView_OnDayClickListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.wdullaer.materialdatetimepicker.date.MonthView.OnDayClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDayClick:(Lcom/wdullaer/materialdatetimepicker/date/MonthView;Lcom/wdullaer/materialdatetimepicker/date/MonthAdapter$CalendarDay;)V:GetOnDayClick_Lcom_wdullaer_materialdatetimepicker_date_MonthView_Lcom_wdullaer_materialdatetimepicker_date_MonthAdapter_CalendarDay_Handler:Com.Wdullaer.Materialdatetimepicker.Date.AbstractMonthView/IOnDayClickListenerInvoker, Xamarin.Bindings.MaterialDateTimePicker\n" +
			"";
		mono.android.Runtime.register ("Com.Wdullaer.Materialdatetimepicker.Date.AbstractMonthView+IOnDayClickListenerImplementor, Xamarin.Bindings.MaterialDateTimePicker", MonthView_OnDayClickListenerImplementor.class, __md_methods);
	}


	public MonthView_OnDayClickListenerImplementor ()
	{
		super ();
		if (getClass () == MonthView_OnDayClickListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Wdullaer.Materialdatetimepicker.Date.AbstractMonthView+IOnDayClickListenerImplementor, Xamarin.Bindings.MaterialDateTimePicker", "", this, new java.lang.Object[] {  });
	}


	public void onDayClick (com.wdullaer.materialdatetimepicker.date.MonthView p0, com.wdullaer.materialdatetimepicker.date.MonthAdapter.CalendarDay p1)
	{
		n_onDayClick (p0, p1);
	}

	private native void n_onDayClick (com.wdullaer.materialdatetimepicker.date.MonthView p0, com.wdullaer.materialdatetimepicker.date.MonthAdapter.CalendarDay p1);

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
