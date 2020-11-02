using Android.Content;
using Android.Graphics;
using Android.Widget;
using AssetManagement.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement._Helpers
{
    static class Helper
    {
        private static Android.Media.MediaPlayer mPlayer;
        public static void ShowToastMessage(Context context, Color color, string message, ToastLength shorOrLong)
        {
            try
            {
                Toast t = Toast.MakeText(context, message, shorOrLong);
                Color c = color;
                ColorMatrixColorFilter CM = new ColorMatrixColorFilter(new float[]
                    {
                                0,0,0,0,c.R,
                                0,0,0,0,c.G,
                                0,0,0,0,c.B,
                                0,0,0,1,0
                    });
                t.View.Background.SetColorFilter(CM);
                t.Show();

            }
            catch (Exception ex)
            {

            }
        }
        public static void PlayMusic(Context context, in int successOrFail)
        {
            mPlayer = Android.Media.MediaPlayer.Create(context, successOrFail);
            mPlayer.SeekTo(1);
            mPlayer.Start();
        }
        public static async Task<HttpResponseMessage> PostData(Uri uri, object data)
        {
            try
            {
                HttpClient myClient = new HttpClient();
                string jsonData = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await myClient.PostAsync(uri, content);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static async Task<HttpResponseMessage> GetData(Uri uri)
        {
            try
            {
                HttpClient myClient = new HttpClient();
                HttpResponseMessage response = await myClient.GetAsync(uri);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static async Task<HttpResponseMessage> LoadSite()
        {
            try
            {
                HttpClient myClient = new HttpClient();
                var uri = new Uri(string.Format(clsStatic.url + "/Login/GetDataofUserSite?userID=" + SingletonSession.Instance().getUsername() + "&PlantId=" + SingletonSession.Instance().getPlantID() + ""));
                HttpResponseMessage response = await myClient.GetAsync(uri);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}