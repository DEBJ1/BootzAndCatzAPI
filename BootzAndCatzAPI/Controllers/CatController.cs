﻿using BootzAndCatz.Data;
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
       /// <summary>
       /// 
       /// </summary>
       /// <param name="cat"></param>
       /// <returns></returns>
        public IHttpActionResult Post(CatCreate cat)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCatServices();

            if (!service.CreateCat(cat))
                return InternalServerError();

            return Ok($"{cat.Name} has been posted to Bootz & Catz! ฅ^•ﻌ•^ฅ");

        }

        //get all cats!
        /// <summary>
        /// Returns all cats from database
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
            CatServices catService = CreateCatServices();
            var cat = catService.GetAllCats();
            return Ok(cat);
        }

        //get cats by breed
        //[Route("get-cats-by-breed")]
        /// <summary>
        /// Returns cats by specific breed
        /// </summary>
        /// <param name="breed"></param>
        /// <returns></returns>
        public IHttpActionResult GetBreed(string breed)
        {
            CatServices catServices = CreateCatServices();

            var cat = catServices.GetCatsByBreed(breed);
            if (cat is null)
                return Ok($"Sorry! Looks like there are currently no {breed} cats in our database. 乁( ⁰͡ Ĺ̯ ⁰͡ ) ㄏ");

            return Ok(cat);
        }
        //get cat by id
        public IHttpActionResult GetById(int id)
        {
           CatServices catService = CreateCatServices();

            var cat = catService.GetCatById(id);
            if (cat is null)
                return Ok($"Sorry! Looks like there are currently no cats with the provided ID in our database. ᕙ(⇀‸↼‶)ᕗ");


            return Ok(cat);
        }
        //edit cat
        /// <summary>
        /// Allows user to edit information of cat
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public IHttpActionResult Put(int id, [FromBody]CatEdit cat)
        {
            GetById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCatServices();
            if (!service.UpdateCat(cat))
                return InternalServerError();

            return Ok("Cat has been updated! (◕‿◕✿)");
        }

        /// <summary>
        /// Removes cat from database
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int catId)
        {
            //GetById(catId);

            var service = CreateCatServices();

            if (!service.DeleteCat(catId))
                return InternalServerError();

            return Ok($"Cat {catId} has been removed from Bootz & Catz. (づ￣ ³￣)づ Bye Bye cat.");
        }
        //cat service
        private CatServices CreateCatServices()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());

            //new ShelterServices(userId);

            var catServices = new CatServices(userId);

            return catServices;
        }

        private ShelterServices GetOwnerGuid()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            var shelterServices = new ShelterServices(userId);

            return shelterServices;
        }
    }
}
