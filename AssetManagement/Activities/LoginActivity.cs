using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using AssetManagement._Helpers;
using AssetManagement.Models;
using Plugin.Connectivity;
using System;
using System.Net.Http;

namespace AssetManagement.Activities
{
    [Activity(Label = "", Theme = "@style/MyTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class LoginActivity : Activity
    {
        EditText txtusername;
        EditText txtPassword;
        Button btnsign;
        string url = "";
        ProgressBar progressBar;
        string IMEINumber = "";
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.activity_login);
                ImageView btnepicflash = FindViewById<ImageView>(Resource.Id.imgepicflash);

                progressBar = FindViewById<ProgressBar>(Resource.Id.Progress);

                url = clsStatic.url;

                clsStatic.Progress = FindViewById<ProgressBar>(Resource.Id.Progress);

                btnsign = FindViewById<Button>(Resource.Id.btnLogInID);
                txtusername = FindViewById<EditText>(Resource.Id.editTextUserName);
                txtPassword = FindViewById<EditText>(Resource.Id.editTextPassword);
                btnsign.Click += Btnsign_Click;

                //Android.Telephony.TelephonyManager mTelephonyMgr;
                //mTelephonyMgr = (Android.Telephony.TelephonyManager)GetSystemService(TelephonyService);
                //IMEINumber = mTelephonyMgr.Imei;
            }
            catch (System.Exception ex)
            {
                Helper.ShowToastMessage(this, Color.DarkRed, ex.Message, ToastLength.Short);
            }
        }

        private async void Btnsign_Click(object sender, EventArgs e)
        {
            Dialog dialog = null;
            try
            {
                if (txtusername.Text != "" && txtPassword.Text != "")
                {
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        #region Loading Dialog
                        LayoutInflater layoutInflater = LayoutInflater.From(this);
                        View progressDialogBox = layoutInflater.Inflate(Resource.Layout.flashLayout, null);
                        AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(this);
                        alertDialogBuilder.SetView(progressDialogBox);
                        var progressBar1 = progressDialogBox.FindViewById<ProgressBar>(Resource.Id.ProgressBar01);
                        var txtviewmessage = progressDialogBox.FindViewById<TextView>(Resource.Id.txtmessage);
                        txtviewmessage.Text = "Please wait Loading...";
                        dialog = alertDialogBuilder.Create();
                        dialog.SetCanceledOnTouchOutside(false);
                        dialog.SetCancelable(false);
                        dialog.Show();
                        #endregion

                        var login = new Login(SingletonSession.Instance().getPlantID(), txtusername.Text, txtPassword.Text, 123);
                        HttpResponseMessage response = await login.LoggedIn();

                        if (response.ReasonPhrase == "OK")
                        {
                            var result = await response.Content.ReadAsStringAsync();
                            if (result.Contains("Success"))
                            {
                                SingletonSession.Instance().setUsername(txtusername.Text.ToString());
                                StartActivity(typeof(CategoryActivity));
                                //OverridePendingTransition(Resource.Animation.right_to_left,Resource.Animation.abc_fade_out);
                                dialog.Hide();
                                dialog.Dismiss();
                                Helper.ShowToastMessage(this, Color.DarkGreen, "Login Successful...", ToastLength.Short);
                            }
                            else
                            {
                                dialog.Hide();
                                dialog.Dismiss();
                                txtusername.Text = string.Empty;
                                txtPassword.Text = string.Empty;
                                SingletonSession.Instance().setUsername("");
                                throw new AndroidRuntimeException("User ID or Password Wrong...");
                            }
                        }
                        else
                        {
                            dialog.Hide();
                            dialog.Dismiss();
                            throw new AndroidRuntimeException("Internal server Error...");
                        }
                    }
                    else
                    {
                        throw new AndroidRuntimeException("Check your internet connection and try again..");
                    }
                }
                else
                {
                    throw new AndroidRuntimeException("Enter your User Id or Password .....");
                }
            }
            catch (AndroidRuntimeException ex)
            {
                Helper.ShowToastMessage(this, Color.DarkRed, ex.Message, ToastLength.Short);
            }
        }

        public override void OnBackPressed()
        {
            try
            {
                var intent = new Intent(this, typeof(SitesActivity));
                intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.ClearTask | ActivityFlags.NewTask);

                StartActivity(intent);
                SingletonSession.Instance().setPlantID("");
                Finish();
            }
            catch (System.Exception ex)
            {
                Helper.ShowToastMessage(this, Color.DarkRed, ex.Message, ToastLength.Short);
            }
        }

        public void isNetworkAvailable()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                // your logic...  
            }
            else
            {
                Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(new ContextThemeWrapper(this, Resource.Style.AlertDialogCustom));

                alert.SetTitle("Error!");
                alert.SetMessage("Check your internet connection and try again.");

                alert.SetPositiveButton("Try Again", (senderAlert, args) =>
                {

                    isNetworkAvailable();


                });
                alert.SetNegativeButton("Cancel", (senderAlert, args) =>
                {
                    //Finish();
                });

                Dialog dialog = alert.Create();
                dialog.Show();
            }
        }
    }
}