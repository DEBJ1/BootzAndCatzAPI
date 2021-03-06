using BootzAndCatz.Data;
using BootzAndCatz.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BootzAndCatz.Services
{
    public class ShelterServices
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        private readonly Guid _userId;

        public ShelterServices(Guid userId)
        {
            _userId = userId;
        }

        //Shelter Create
        public bool CreateShelter(ShelterCreate model)
        {
            var entity =
                new Shelter()
                {
                    //ShelterId = _shelterId,
                    ShelterOwnerId = _userId,
                    ShelterName = model.ShelterName,
                    ZipCode = model.ZipCode,
                    Description = model.Description,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shelters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //get all the shelters
        public IEnumerable<ShelterListItem> GetAllShelters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Shelters
                    //.Where(e => e.ShelterOwnerId == _userId)
                    .Select(
                        e =>
                        new ShelterListItem
                        {
                            ShelterId = e.ShelterId,
                            ShelterName = e.ShelterName
                        }
                        );
                return query.ToArray();
            }
        }

        //get shelter by id
        
        public Shelter GetById(int id)
        {
            var shelter = _context.Shelters

                .FirstOrDefault(i => i.ShelterId == id);

                return shelter;
        }

        public bool DeleteShelter(int id)
        {
            Shelter shelter = GetById(id);

            if (shelter == null)
                return false;

            _context.Shelters.Remove(shelter);

            return _context.SaveChanges() == 1;
        }

        //update shelter
        public bool UpdateShelter(ShelterEdit model)
        {
            Shelter oldShelter = GetById(model.ShelterId);

            if (oldShelter != null)
            {
                oldShelter.ShelterName = model.ShelterName;
                oldShelter.ZipCode = model.ZipCode;
                oldShelter.Description = model.Description;
                oldShelter.PhoneNumber = model.PhoneNumber;
                oldShelter.Address = model.Address;

                return _context.SaveChanges() == 1;
            }
           else
                return false;
            
        }

       
    }
}

