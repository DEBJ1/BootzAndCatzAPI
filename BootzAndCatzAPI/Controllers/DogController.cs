﻿using BootzAndCatz.Models;
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
        public class DogController : ApiController
        {
            //post the dog 
            public IHttpActionResult Post(DogCreate dog)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDogServices();

            if (!service.CreateDog(dog))
                return InternalServerError();

            return Ok($"{dog.Name} has been posted to Bootz & Catz!");

            }

            //get all cats that are dogs
            public IHttpActionResult GetAll()
            {
            DogServices dogService = CreateDogServices();
                var dog = dogService.GetAllDogs();
                return Ok(dog);
            }

            //get dogs by breed
          /*  public IHttpActionResult GetBreed(string breed)
            {
                DogServices dogServices = CreateDogServices();

                var dog = dogServices.GetDogsByBreed(breed);
                if (dog is null)
                    return Ok($"Sorry! Looks like there are currently no {breed}'s in our database.");

                return Ok(dog);
          */  //}

            //edit dog
            public IHttpActionResult Put(DogEdit dog)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateDogServices();
                if (!service.UpdateDog(dog))
                    return InternalServerError();

                return Ok("The nature of this dog has been altered!");
            }

            public IHttpActionResult Delete(int dogId)
            {
                var service = CreateDogServices();

                if (!service.DeleteDog(dogId))
                    return InternalServerError();

                return Ok($"Dog {dogId} has been removed from Bootz & Catz.");
            }
            //dog service for the love of god 
            private DogServices CreateDogServices()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());

                var dogServices = new DogServices(userId);

                return dogServices;
            }
        }
    }

