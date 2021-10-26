using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shelterprojekt.Client.Shared;

using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Shelterprojekt.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShelterController : ControllerBase
    {
        string url = "shelter_minus.json";

        private readonly ILogger<ShelterController> logger;

        public ShelterController(ILogger<ShelterController> logger)
        {
            this.logger = logger;
        }

        public List<shelterInfo> LoadJson()
        {
            using (StreamReader r = new StreamReader(url))
            {
                string json = r.ReadToEnd();
                List<shelterInfo> items = JsonConvert.DeserializeObject<List<shelterInfo>>(json);
                return items;
            }
        }

        [HttpGet]
        public IEnumerable<shelterInfo> Get()
        {
            return LoadJson();
        }

    }
}
