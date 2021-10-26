using Microsoft.AspNetCore.Mvc;
using Shelterprojekt.Server.Services;
using Shelterprojekt.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelterprojekt.Server.Controllers
{
    public class Shelter2Controller : Controller
    {

        ShelterService service = new ShelterService();

        [HttpGet]
        [Route("api/shelter/index")]
        public async Task<IEnumerable<Shelter>> Index()
        {
            return await service.GetSheltersAsync();
        }



    }
}
