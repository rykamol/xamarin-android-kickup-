using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AssetManagement._Helpers;
using AssetManagement.Models;

namespace AssetManagement.Activities
{
    [Activity(Label = "Asset Management", Theme = "@style/AppTheme", MainLauncher = false, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SitesActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_site);

            var imgcipl = FindViewById<ImageView>(Resource.Id.imgcipl);
            var imgegmcl = FindViewById<ImageView>(Resource.Id.imgegmcl);
            var imgegmcl2 = FindViewById<ImageView>(Resource.Id.imgegmcl2);
            var imgpgcl = FindViewById<ImageView>(Resource.Id.imgpgcl);
            var imggtl = FindViewById<ImageView>(Resource.Id.imggtl);
            var imgethopia = FindViewById<ImageView>(Resource.Id.imgethopia);
            var imgjordan = FindViewById<ImageView>(Resource.Id.imgjordan);
            var imgVBH = FindViewById<ImageView>(Resource.Id.imgVBH);

            var txtcipl = FindViewById<TextView>(Resource.Id.txtcipl);
            var txtegmcl = FindViewById<TextView>(Resource.Id.txtegmcl);
            var txtegmcl2 = FindViewById<TextView>(Resource.Id.txtegmcl2);
            var txtpgcl = FindViewById<TextView>(Resource.Id.txtpgcl);
            var txtgtl = FindViewById<TextView>(Resource.Id.txtgtl);
            var txtethopia = FindViewById<TextView>(Resource.Id.txtethopia);
            var txtjordan = FindViewById<TextView>(Resource.Id.txtjordan);
            var txtvbh = FindViewById<TextView>(Resource.Id.txtvbh);
            var txtvxl = FindViewById<TextView>(Resource.Id.txtvxl);

            txtcipl.Gravity = GravityFlags.CenterHorizontal;
            txtegmcl.Gravity = GravityFlags.CenterHorizontal;
            txtegmcl2.Gravity = GravityFlags.CenterHorizontal;
            txtpgcl.Gravity = GravityFlags.CenterHorizontal;
            txtgtl.Gravity = GravityFlags.CenterHorizontal;
            txtethopia.Gravity = GravityFlags.CenterHorizontal;
            txtjordan.Gravity = GravityFlags.CenterHorizontal;
            txtvbh.Gravity = GravityFlags.CenterHorizontal;
            txtvxl.Gravity = GravityFlags.CenterHorizontal;


            imgcipl.Click += delegate
            {
                GoForLogin("PLN-2014-3");
            };

            imgegmcl.Click += delegate
            {
                GoForLogin("PLN-2014-4");
            };

            imgegmcl2.Click += delegate
            {
                GoForLogin("PLN-2014-5");
            };

            imgpgcl.Click += delegate
            {
                GoForLogin("PLN-2014-6");
            };

            imggtl.Click += delegate
            {
                GoForLogin("PLN-2015-1");
            };

            imgethopia.Click += delegate
            {
                GoForLogin("PLN-2016-2");
            };

            imgjordan.Click += delegate
            {
                GoForLogin("PLN-2017-2");
            };

            imgVBH.Click += delegate
            {
                GoForLogin("PLN-2017-2");
            };

            //#region temp
            //imgcipl.Click += delegate
            //{
            //    GoForLogin("EPBD-CIPL");
            //};

            //imgegmcl.Click += delegate
            //{
            //    GoForLogin("EPBD-EGMCL");
            //};

            //imgegmcl2.Click += delegate
            //{
            //    GoForLogin("EPBD-EG2");
            //};

            //imgpgcl.Click += delegate
            //{
            //    GoForLogin("EPBD-PGCL");
            //};

            //imggtl.Click += delegate
            //{
            //    GoForLogin("EPBD-GTL1");
            //};

            //imgethopia.Click += delegate
            //{
            //    GoForLogin("EPICET");
            //};

            //imgjordan.Click += delegate
            //{
            //    GoForLogin("EPICJOD");
            //};

            //imgVBH.Click += delegate
            //{
            //    GoForLogin("EPICVN-BH");
            //};



            //#endregion
        }

        private void GoForLogin(string plantId)
        {
            if (!string.IsNullOrEmpty(plantId))
            {
                Intent i = new Intent(this, typeof(LoginActivity));
                StartActivity(i);
                //OverridePendingTransition(Resource.Animation.right_to_left, Resource.Animation.abc_fade_out);
                SingletonSession.Instance().setPlantID(plantId);
            }
            else
            {
                Helper.ShowToastMessage(this, Color.DarkRed, "Plant Is Empty..!!!", ToastLength.Short);
            }
        }

        public override void OnBackPressed()
        {
            try
            {
                Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(new ContextThemeWrapper(this, Resource.Style.AlertDialogCustom));
                alert.SetTitle("");
                alert.SetMessage("Are you sure you want to Exit?");

                alert.SetPositiveButton("YES", (senderAlert, args) =>
                {
                    Finish();
                });
                alert.SetNegativeButton("NO", (senderAlert, args) =>
                {

                });

                Dialog dialog = alert.Create();
                dialog.SetCanceledOnTouchOutside(false);
                dialog.Show();
            }
            catch (System.Exception ex)
            {
                Helper.ShowToastMessage(this, Color.DarkRed, ex.Message, ToastLength.Short);
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}