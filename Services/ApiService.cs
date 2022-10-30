using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Testinnovea.Models.Api;
using Testinnovea.Services.Interfaces;

namespace Testinnovea.Services
{
    public class ApiService : ServiceBase<ApiService>, IAPIService
    {
        private string urlAcesso = "https://newsapi.org/v2/everything?q=bitcoin";
        public ApiService(IConfiguration config, ILogger<ApiService> log) : base(config, log)
        {
        }

        public Root GetAll()
        {
            var root = new Root();
            try
            {
                using (HttpClient httpclient = new HttpClient())
                {
                    httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(NewsApiKey);
                    httpclient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("TestInovea","1.0"));
                    var response = httpclient.GetAsync(urlAcesso).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        root = JsonSerializer.Deserialize<Root>(result);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
            }
            return root;
        }
    }
}
