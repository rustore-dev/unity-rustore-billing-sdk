package com.plugins.billingexample;

import android.app.Activity;
import android.widget.Toast;

public class AndroidUtils
{
	public void showToast(final Activity activity, String message)
	{
		activity.runOnUiThread(new Runnable() {
			@Override
			public void run() {
				Toast.makeText(activity, message, Toast.LENGTH_LONG).show();
			}
		});
	}
}
