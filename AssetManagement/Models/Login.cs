using AssetManagement._Helpers;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Android.Net;

namespace AssetManagement.Models
{
    class Login
    {
        private string PlantId { get; set; }
        private string UserId { get; set; }
        private string Password { get; set; }
        private int DeviceId { get; set; }

        public Login(string plantId, string userId, string password, int deviceId)
        {
            PlantId = plantId;
            UserId = userId;
            Password = password;
            DeviceId = deviceId;
        }

        public async Task<HttpResponseMessage> LoggedIn()
        {
            HttpClient client = new HttpClient(new AndroidClientHandler());
            var uri = new Uri(string.Format(clsStatic.url + "/AMS_API/Login/UserLogin"));

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await Helper.PostData(uri, this);

            return response;
        }
    }
}