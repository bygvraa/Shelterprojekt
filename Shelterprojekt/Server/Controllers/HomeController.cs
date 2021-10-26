using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public List<ShoppingItem> LoadJson()
        {
            using (StreamReader r = new StreamReader(url))
            {
                string json = r.ReadToEnd();
                List<ShoppingItem> items = JsonConvert.DeserializeObject<List<ShoppingItem>>(json);
                return items;
            }
        }

        [HttpGet]
        public IEnumerable<ShoppingItem> Get()
        {
            return LoadJson();
        }

    }
}
