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
    public class CatController : ApiController
    {
        //post a cat
        public IHttpActionResult Post(CatCreate cat)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCatServices();

            if (!service.CreateCat(cat))
                return InternalServerError();

            return Ok();

        }

        //get all cats!
        public IHttpActionResult GetAll()
        {
            CatServices catService = CreateCatServices();
            var cat = catService.GetAllCats();
            return Ok(cat);
        }

        //edit cat
        public IHttpActionResult Put(CatEdit cat)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCatServices();
            if (!service.UpdateCat(cat))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int catId)
        {
            var service = CreateCatServices();

            if (!service.DeleteCat(catId))
                return InternalServerError();

            return Ok();
        }
        //cat service
        private CatServices CreateCatServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            
            var catServices = new CatServices(userId);

            return catServices;
        }
    }
}
