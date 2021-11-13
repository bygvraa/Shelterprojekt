using Microsoft.AspNetCore.Mvc;
using Shelterprojekt.Server.Services;
using Shelterprojekt.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ShelterLocalController : ControllerBase
    {
        string url = "data/shelter_data.json";

        private readonly ILogger<ShelterLocalController> logger;

        public ShelterLocalController(ILogger<ShelterLocalController> logger)
        {
            this.logger = logger;
        }

        public List<ShelterLocal> LoadJson()
        {
            using (StreamReader r = new StreamReader(url))
            {
                string json = r.ReadToEnd();
                dynamic jsonObj = JsonConvert.DeserializeObject(json);
                List<ShelterLocal> items = new();
                foreach (var obj in jsonObj)
                {
                    ShelterLocal shelter_1 = new ShelterLocal(
                                                        $"{obj["properties"]["navn"]}",
                                                        $"{obj["properties"]["cvr_navn"]}",
                                                        //Convert.ToInt32//
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
        public IEnumerable<ShelterLocal> Get()
        {
            return LoadJson();
        }

    }
}
