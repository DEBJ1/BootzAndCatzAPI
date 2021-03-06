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

            return Ok($"{dog.Name} has been posted to Bootz & Catz! ▼・ᴥ・▼");

            }

            //get all cats that are dogs
            public IHttpActionResult GetAll()
            {
            DogServices dogService = CreateDogServices();
                var dog = dogService.GetAllDogs();
                return Ok(dog);
            }

            //get dogs by breed
           public IHttpActionResult GetBreed(string breed)
            {
                DogServices dogServices = CreateDogServices();

                var dog = dogServices.GetDogsByBreed(breed);
                if (dog is null)
                    return Ok($"Sorry! Looks like there are currently no {breed}'s in our database.");

                return Ok(dog);
          }

            //edit dog
            public IHttpActionResult Put(int id,[FromBody]DogEdit dog)
            {
                 GetById(id);

                 if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateDogServices();
                if (!service.UpdateDog(dog))
                    return InternalServerError();

                return Ok("The nature of this dog has been altered!  (ﾉ◕ヮ◕)ﾉ*:・ﾟ✧ ");
            }

        public IHttpActionResult GetById(int id)
        {
            DogServices dogService = CreateDogServices();

            var dog = dogService.GetDogById(id);
            if (dog is null)
                return Ok($" Dude, there is no dog with that provided ID in our database.");


            return Ok(dog);
        }
        public IHttpActionResult Delete(int dogId)
            {
                var service = CreateDogServices();

                if (!service.DeleteDog(dogId))
                    return InternalServerError();

<<<<<<< HEAD
                return Ok($"Dog {dogId} has been removed from Bootz & Catz. (☞ﾟ∀ﾟ)☞");
=======
                return Ok($"Dog {dogId} has been removed from Bootz & Catz. Forever.");
>>>>>>> ab4db3fbdd8c87dde1f1165354820fb2da31507b
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

