﻿using BootzAndCatz.Data;
using BootzAndCatz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootzAndCatz.Services
{
    public class DogServices
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        private readonly Guid _userId;

        public DogServices(Guid userId)
        {
            _userId = userId;
        }

        //create dogggggggs 4days 
        public bool CreateDog(DogCreate model)
        {
            var entity =
                new Dog()
                {
                    
                    IsChipped = model.IsChipped,
                    EnergyLevel = model.EnergyLevel,
                    Size = model.Size,
                    Name = model.Name,
                    Breed = model.Breed,
                    Age = model.Age,
                    AboutMe = model.AboutMe,
                    ShelterId = model.ShelterId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Dogs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //get all dogs
        public IEnumerable<DogListItem> GetAllDogs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Dogs
                    //.Where(e => e.DogId. == _dogId)
                    .Select(
                        e =>
                        new DogListItem
                        {
                            DogId = e.DogId,
                            Name = e.Name
                        }
                        );
                return query.ToArray();
            }
        }

        //update dog
        public bool UpdateDog(DogEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Dogs
                    .Single(e => e.DogId == model.DogId);
                entity.IsChipped = model.IsChipped;
                entity.EnergyLevel = model.EnergyLevel;
                entity.Size = model.Size;
                entity.Name = model.Name;
                entity.Breed = model.Breed;
                entity.Age = model.Age;
                entity.AboutMe = model.AboutMe;


                return ctx.SaveChanges() == 1;
            }
        }

        //get by id
        public Dog GetDogById(int id)
        {
            var dog = _context.Dogs
                .FirstOrDefault(i => i.DogId == id);

            return dog;
        }

        //Bye dog, youre getting deleted 
        public bool DeleteDog(int dogId)
        {
            Dog dog = GetDogById(dogId);

            if (dog == null)
                return false;

            _context.Dogs.Remove(dog);

            return _context.SaveChanges() == 1;


            //using (var ctx = new ApplicationDbContext())
            //{
            //    var entity =
            //        ctx
            //        .Dogs
            //        .SingleOrDefault(e => e.DogId == dogId && e.Shelter.ShelterOwnerId == _userId);

            //    ctx.Dogs.Remove(entity);

            //    return ctx.SaveChanges() == 1;
            //}
        }
    }
}

