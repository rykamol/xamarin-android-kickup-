
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace AssetManagement.Activities
{
    [Activity(Label = "Assets", MainLauncher = true, Theme = "@style/MyTheme.Splash", NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class FlashActivity : Activity
    {
        int count = 0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_splash);
            new UpdatePB(this).Execute();
        }

        public class UpdatePB : AsyncTask<int, int, string>
        {
            Activity mcontext;
            ProgressBar mpb;
            Dialog dialog;
            public UpdatePB(Activity context)
            {
                mcontext = context;
                LayoutInflater layoutInflater = LayoutInflater.From(mcontext);
                View progressDialogBox = layoutInflater.Inflate(Resource.Layout.flashLayout, null);
                AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(mcontext);
                alertDialogBuilder.SetView(progressDialogBox);
                var progressBar1 = progressDialogBox.FindViewById<ProgressBar>(Resource.Id.ProgressBar01);
                var txtviewmessage = progressDialogBox.FindViewById<TextView>(Resource.Id.txtmessage);
                txtviewmessage.Text = "Please wait Loading app...";
                dialog = alertDialogBuilder.Create();
                this.dialog.SetCanceledOnTouchOutside(false);
                this.dialog.SetCancelable(false);
                dialog.Show();

            }
            protected override string RunInBackground(params int[] @params)
            {
                // TODO Auto-generated method stub
                //for (int i = 1; i <= 4; i++)
                //{
                try
                {
                    System.Threading.Thread.Sleep(5000);
                }
                catch (InterruptedException e)
                {
                    // TODO Auto-generated catch block
                    // Android.Util.Log.Error("lv", e.Message);
                }
                //mpb.IncrementProgressBy(25);
                //PublishProgress(i * 25);

                //}
                return "EPICAPP";
            }
            protected override void OnProgressUpdate(params int[] values)
            {
                Android.Util.Log.Error("lv==", values[0] + "");
            }
            protected override void OnPostExecute(string result)
            {
                mcontext.Title = result;
                dialog.Hide();
                dialog.Dismiss();

                var intent = new Intent(mcontext, typeof(SitesActivity));
                mcontext.StartActivity(intent);
            }
        }
    }
}