using BootzAndCatz.Models;
using BootzAndCatz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BootzAndCatzAPI.Controllers
{
    [Authorize]
    public class ShelterController : ApiController
    {
        //post new shelter
        public IHttpActionResult Post(ShelterCreate shelter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShelterServices();

            if (!service.CreateShelter(shelter))
                return InternalServerError();

            return Ok();
        }

        //shelter service
        private ShelterServices CreateShelterServices()
        {
            var shelterId = new int();
            var shelterServices = new ShelterServices(shelterId);

            return shelterServices;
        }

    }
}
