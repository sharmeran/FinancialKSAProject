using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Entites.Administration;
using FSP.Common.Enums;
using FSP.DataAccess.SQLImlementation.Administration;
using FSP.Domain.BaseClasses;

namespace FSP.Domain.Domains.Administration
{
   public class UserDomain : BusinessDomainBase<User>
   {
       public UserDomain(int userID, LanguagesEnum language)
           : base(userID, language)
       {
           DBRepository = new UserRepository();
       }
        public override void Add(User entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(User entity)
        {
            DBRepository.Delete(entity, ActionState);
        }

        public override void Update(User entity)
        {
            DBRepository.Update(entity, ActionState);
        }

        public override List<User> FindAll()
        {
            return DBRepository.FindAll(ActionState);
        }

        public override User FindByID(int entityID)
        {
            return DBRepository.FindByID(entityID, ActionState);
        }

        public override bool IsExist(User entity)
        {
            throw new NotImplementedException();
        }
        public User CheckUserLogin(string username, string password)
        {
            UserRepository userRepository = new UserRepository();
            return userRepository.CheckUserLogin(username, password, ActionState);
        }
    }
}
