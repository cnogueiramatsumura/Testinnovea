using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testinnovea.Services
{
    public class ServiceBase<T> where T : class
    {
        public string NewsApiKey { get; set; }
        public ILogger _log { get; set; }
        public IConfiguration _config { get; set; }

        public ServiceBase(IConfiguration config, ILogger<T> log)
        {
            _config = config;
            _log = log;
            NewsApiKey = _config.GetValue<string>("NewsApiKey");            
        }
    }
}
