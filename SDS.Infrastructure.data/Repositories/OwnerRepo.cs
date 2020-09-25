using System;
using System.Collections.Generic;
using SDS.Core.DomainService;
using SDS.Core.Entity;

namespace SDS.Infrastructure.data.Repositories
{
    public class OwnerRepo : IOwnerRepository
    {
        
        private static List<Owner> _ownerLst = new List<Owner>();
        static int id = 1;

        public Owner Create(Owner owner)
        {
            owner.OwnerId = id++;
            _ownerLst.Add(owner);
            return owner;
        }

        public Owner Delete(int id)
        {
            var avatarFound = this.GetOwnerById(id);
            if (avatarFound != null)
            {
                _ownerLst.Remove(avatarFound);
                return avatarFound;
            }
            return null;
        }

        public Owner GetOwnerById(int Id)
        {
            foreach (var owner in _ownerLst)
            {
                if (owner.OwnerId == id)
                {
                    return owner;
                }
            }
            return null;
        }
       public IEnumerable<Owner> ReadAllOwners()
        {
            return _ownerLst;
        }

        public Owner Update(Owner ownerUpdate)
        {
            var avatarFromDB = this.GetOwnerById(ownerUpdate.OwnerId);
            if (avatarFromDB != null)
            {
                avatarFromDB.FirstName = ownerUpdate.FirstName;
                avatarFromDB.LastName = ownerUpdate.LastName;
                avatarFromDB.Address = ownerUpdate.Address;
                avatarFromDB.Email = ownerUpdate.Email;
               

                return avatarFromDB;
            }

            return null;
        
    }
    };
   
}
