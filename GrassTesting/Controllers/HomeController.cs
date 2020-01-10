using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GrassTesting.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace GrassTesting.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _baseUri = "https://ts4.travian.ru/spieler.php?uid=";

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Cultivation()
        {
            await TravianLogin();
            //var players = new int[] { 4638 };

            //foreach (var player in players)
            //{
            //    var kk = await TravianPlayerGet(player);
            //}

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<string> TravianPlayerGet(int playerId)
        {
            var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"{_baseUri}/spieler.php?uid={playerId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }

            throw new InvalidOperationException(response.StatusCode.ToString());


        }

        private async Task<string> TravianLogin()
        {
            var client = new HttpClient();

            HttpResponseMessage responseGet = await client.GetAsync($"{_baseUri}/login.php");
            if (!responseGet.IsSuccessStatusCode) throw new InvalidOperationException("Login GET = " + responseGet.StatusCode.ToString());

            var content = await responseGet.Content.ReadAsStringAsync();
            string htmlStart = "<input type=\"hidden\" name=\"login\" value=\"";
            content = content.Substring(content.IndexOf(htmlStart) + htmlStart.Length);
            string travianSysLogin = content.Substring(0, content.IndexOf("\""));

            var loginModel = new TravianLoginModel
            {
                name = "jeer",
                password = "moneyfor",
                login = travianSysLogin
            };

            var dataString = JsonConvert.SerializeObject(loginModel);
            HttpResponseMessage response = await client.PostAsync($"{_baseUri}/login.php", new StringContent(dataString, Encoding.UTF8, "application/json"));
            if (!responseGet.IsSuccessStatusCode) throw new InvalidOperationException("Login POST = " + responseGet.StatusCode.ToString());
            content = await responseGet.Content.ReadAsStringAsync();

            return content;
        }
    }
}
