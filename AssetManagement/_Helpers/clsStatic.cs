using Android.Views;
using Android.Widget;
using AssetManagement.Models;
using System;

namespace AssetManagement._Helpers
{
    public static class clsStatic
    {
        public static ProgressBar Progress;
        public static string url = "http://data.epicdesigners.com/AMS_Interface";
        public enum SubContractTransaction
        {
            CLN_INIT, CLN_RCV, CLN_DISPATCH_INT, CLN_ACOMPLISH
        }
        public static void ShowProgress()
        {
            try
            {
                if (Progress != null)
                    Progress.Visibility = ViewStates.Visible;
            }
            catch (Exception ex)
            {

            }

        }
        public static void HideProgress()
        {
            try
            {
                if (Progress != null)
                    Progress.Visibility = ViewStates.Gone;
            }
            catch (Exception ex)
            {

            }
        }
        public static string Titlebar()
        {
            string title = "";
            try
            {
                DateTime datetime = DateTime.Now;

                var hour = datetime.Hour;


                if (hour >= 18)
                {
                    title = "Good Night" + "," + SingletonSession.Instance().getUsername().ToUpper();

                }
                else if (hour >= 12)
                {
                    title = "Good Afternoon" + "," + SingletonSession.Instance().getUsername().ToUpper();
                }
                else
                {
                    title = "Good Morning" + "," + SingletonSession.Instance().getUsername().ToUpper();
                }


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return title;
        }
        public static string GetNumData(string strNumber)
        {
            double d;
            System.Globalization.NumberFormatInfo n = new System.Globalization.NumberFormatInfo();
            if (strNumber.Trim() == "")
            { return "0"; }
            else if (System.Double.TryParse(strNumber, System.Globalization.NumberStyles.Float, n, out d) == true)
            {
                return strNumber;
            }
            else
            {
                return "0";
            }
        }
    }
}