using System;
using System.Collections.Generic;
using SDS.Core.DomainService;
using SDS.Core.Entity;

namespace SDS.Infrastructure.data.Repositories
{
    public class AvatarTypeRepo : IAvatarTypeRepository
    {

        
        //private static List<AvatarType> _avatarTypeLst = new List<AvatarType>();
         //public static int id = 1;


        public AvatarType Create(AvatarType avatarType)
        {
            avatarType.AvatarTypeId = DBinitializer.GetNextId();
            var list = DBinitializer.GetAvatarTypes();
            list.Add(avatarType);
            return avatarType;
        }

        public AvatarType Delete(int id)
        {
            //var avatarFound = this.GetAvatarById(id);
            //if (avatarFound != null)
            //{

            //    _avatarTypeLst.Remove(avatarFound);
            //    return avatarFound;
            //}
            //return null;

            AvatarType at = GetAvatarTypes().Find(x => x.AvatarTypeId == id);
            GetAvatarTypes().Remove(at);
            if (at != null)
            {

                return at;
            }
            return null;
        }

        private List<AvatarType> GetAvatarTypes()
        {
            var avatarTypeLst = DBinitializer.GetNextId();
            return DBinitializer.avatarTypeLst;    //<<<<<<<<This is WRONG!!! + ID
        }

        public AvatarType GetAvatarById(int Id)
        {
            var avatarTypeLst = DBinitializer.GetAvatarTypes();
            var avatarType = avatarTypeLst.Find(x => x.AvatarTypeId == Id);

            return avatarType;
        }

        public IEnumerable<AvatarType> ReadAllAvatars()
        {
            return DBinitializer.GetAvatarTypes();
        }

        public AvatarType Update(AvatarType avatarUpdate)
        {
            var avatarFromDB = GetAvatarById(avatarUpdate.AvatarTypeId);
            if (avatarFromDB != null)
            {
                avatarFromDB.AvatarTypeName = avatarUpdate.AvatarTypeName;
                

                return avatarFromDB;
            }

            return null;
        }
    }     
    
}
