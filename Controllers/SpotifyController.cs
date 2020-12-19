using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinerTrabajoFInal.Models.DTO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace MinerTrabajoFInal.Controllers
{
    public class SpotifyController : Controller
    {
        private readonly ILogger<SpotifyController> _logger;
        private const string URL_API_SPOTIFY = "https://api.spotify.com/v1/me";
        private const string ACCESS_TOKEN = "BQCJDiP__MoICkjmWkcY2FbRpcoMgkAyk-IdJZCrJmqcTzScA2zZ929nQragdZDvm-e24TOaMg32DhJy1N0M3unftDGMiRf1DLH1e8Gtu_YQPlPtikVBefkihov0wX5d2ih7GMfpYJCqcf_hXqtYSn4IZoRgtf7U0IVussdXF1Yjg3FhtRrKNvzI_T3Upp114bSB29Hmmyql3nue36I";

        public SpotifyController(ILogger<SpotifyController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.BaseAddress = new Uri(URL_API_SPOTIFY);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ACCESS_TOKEN);
            var streamTask = httpClient.GetStreamAsync("users/nightwolfstin");
            var me = await JsonSerializer.DeserializeAsync<UserSpotify>(await streamTask);
            return View(me);
        }


    }
} 