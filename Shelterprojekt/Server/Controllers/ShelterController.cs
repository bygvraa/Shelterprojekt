using Microsoft.AspNetCore.Mvc;
using Shelterprojekt.Server.Services;
using Shelterprojekt.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelterprojekt.Server.Controllers
{
    public class ShelterController : Controller
    {

        ShelterService service = new ShelterService();


        [HttpGet]
        [Route("api/shelter/index")]
        public async Task<IEnumerable<Shelter>> Index()
        {
            return await service.GetShelters();
        }

        [HttpGet]
        [Route("api/shelter/details/{id}")]
        public async Task<Shelter> Details(string id)
        {
            return await service.GetShelterById(id);
        }

        [HttpPost]
        [Route("api/shelter/create")]
        public async Task Create([FromBody] Shelter shelter)
        {
            await service.CreateShelter(shelter);
        }

        [HttpPut]
        [Route("api/shelter/edit")]
        public async Task Edit([FromBody] Shelter shelter)
        {
            await service.UpdateShelter(shelter);
        }

        [HttpDelete]
        [Route("api/shelter/delete/{id}")]
        public async Task Delete(string id)
        {
            await service.DeleteShelter(id);
        }

    }
}
