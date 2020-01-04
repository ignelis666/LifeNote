package crc646c44863df9b5e222;


public class LifeNoteCard
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer,
		com.wdullaer.materialdatetimepicker.date.DatePickerDialog.OnDateSetListener,
		com.wdullaer.materialdatetimepicker.time.TimePickerDialog.OnTimeSetListener,
		com.google.firebase.storage.OnProgressListener,
		com.google.android.gms.tasks.OnSuccessListener,
		com.google.android.gms.tasks.OnFailureListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onActivityResult:(IILandroid/content/Intent;)V:GetOnActivityResult_IILandroid_content_Intent_Handler\n" +
			"n_onDateSet:(Lcom/wdullaer/materialdatetimepicker/date/DatePickerDialog;III)V:GetOnDateSet_Lcom_wdullaer_materialdatetimepicker_date_DatePickerDialog_IIIHandler:Com.Wdullaer.Materialdatetimepicker.Date.DatePickerDialog/IOnDateSetListenerInvoker, Xamarin.Bindings.MaterialDateTimePicker\n" +
			"n_onTimeSet:(Lcom/wdullaer/materialdatetimepicker/time/RadialPickerLayout;III)V:GetOnTimeSet_Lcom_wdullaer_materialdatetimepicker_time_RadialPickerLayout_IIIHandler:Com.Wdullaer.Materialdatetimepicker.Time.TimePickerDialog/IOnTimeSetListenerInvoker, Xamarin.Bindings.MaterialDateTimePicker\n" +
			"n_onProgress:(Ljava/lang/Object;)V:Getsnapshot_Ljava_lang_Object_Handler:Firebase.Storage.IOnProgressListenerInvoker, Xamarin.Firebase.Storage\n" +
			"n_onSuccess:(Ljava/lang/Object;)V:GetOnSuccess_Ljava_lang_Object_Handler:Android.Gms.Tasks.IOnSuccessListenerInvoker, Xamarin.GooglePlayServices.Tasks\n" +
			"n_onFailure:(Ljava/lang/Exception;)V:GetOnFailure_Ljava_lang_Exception_Handler:Android.Gms.Tasks.IOnFailureListenerInvoker, Xamarin.GooglePlayServices.Tasks\n" +
			"";
		mono.android.Runtime.register ("LifeNoteApp.LifeNoteCard, LifeNoteApp", LifeNoteCard.class, __md_methods);
	}


	public LifeNoteCard ()
	{
		super ();
		if (getClass () == LifeNoteCard.class)
			mono.android.TypeManager.Activate ("LifeNoteApp.LifeNoteCard, LifeNoteApp", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onActivityResult (int p0, int p1, android.content.Intent p2)
	{
		n_onActivityResult (p0, p1, p2);
	}

	private native void n_onActivityResult (int p0, int p1, android.content.Intent p2);


	public void onDateSet (com.wdullaer.materialdatetimepicker.date.DatePickerDialog p0, int p1, int p2, int p3)
	{
		n_onDateSet (p0, p1, p2, p3);
	}

	private native void n_onDateSet (com.wdullaer.materialdatetimepicker.date.DatePickerDialog p0, int p1, int p2, int p3);


	public void onTimeSet (com.wdullaer.materialdatetimepicker.time.RadialPickerLayout p0, int p1, int p2, int p3)
	{
		n_onTimeSet (p0, p1, p2, p3);
	}

	private native void n_onTimeSet (com.wdullaer.materialdatetimepicker.time.RadialPickerLayout p0, int p1, int p2, int p3);


	public void onProgress (java.lang.Object p0)
	{
		n_onProgress (p0);
	}

	private native void n_onProgress (java.lang.Object p0);


	public void onSuccess (java.lang.Object p0)
	{
		n_onSuccess (p0);
	}

	private native void n_onSuccess (java.lang.Object p0);


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
