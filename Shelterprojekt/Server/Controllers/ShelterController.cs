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
using Shelterprojekt.Server;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using MongoDB.Bson;

namespace Shelterprojekt.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShelterController : ControllerBase
    {
        string url = "shelter_data.json";

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
                dynamic jsonObj = JsonConvert.DeserializeObject(json);
                List<shelterInfo> items = new();
                foreach (var obj in jsonObj)
                {
                    shelterInfo shelter_1 = new shelterInfo(
                                                        $"{obj["properties"]["navn"]}",
                                                        $"{obj["properties"]["cvr_navn"]}",
                                                        $"{obj["properties"]["handicap"]}",
                                                        $"{obj["properties"]["antal_pl"]}",
                                                        $"{obj["properties"]["postnr"]}",
                                                        $"{obj["properties"]["vejnavn"]}",
                                                        $"{obj["properties"]["kontakt_ved"]}"
                                                        );
                    items.Add(shelter_1);
                    
                }   
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
