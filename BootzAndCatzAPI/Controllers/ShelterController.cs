using BootzAndCatz.Data;
using BootzAndCatz.Models;
using BootzAndCatz.Services;
using Microsoft.AspNet.Identity;
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
        ApplicationDbContext _context = new ApplicationDbContext();

        //post new shelter
        public IHttpActionResult Post(ShelterCreate shelter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShelterServices();

            if (!service.CreateShelter(shelter))
                return InternalServerError();

            return Ok($"Wonderful, {shelter.ShelterName} has been added to Bootz & Catz!");
        }

        //get all shelters
        public IHttpActionResult GetAll()
        {
            ShelterServices shelterService = CreateShelterServices();
            var shelter = shelterService.GetAllShelters();

            return Ok(shelter);
        }

        //get shelter by id
        public IHttpActionResult Get (int id)
        {
            ShelterServices shelterService = CreateShelterServices();

            var shelter = shelterService.GetById(id);

            return Ok(shelter);
        }

        //edit shelter
        public IHttpActionResult Put(ShelterEdit oldShelter)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShelterServices();

            if (!service.UpdateShelter(oldShelter))
                return InternalServerError();
            return Ok($"Shelter {oldShelter.ShelterName} has been updated!");
               
            //return Ok("Shelter information has been updated!");
        }

        public IHttpActionResult Delete(int shelterId)
        {
            var service = CreateShelterServices();

            if (!service.DeleteShelter(shelterId))
                return InternalServerError();
          

            return Ok($"Shelter {shelterId} has been removed from Bootz & Catz");
        }


        //shelter service
        private ShelterServices CreateShelterServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            var shelterServices = new ShelterServices(userId);

            return shelterServices;
        }

    }
}
