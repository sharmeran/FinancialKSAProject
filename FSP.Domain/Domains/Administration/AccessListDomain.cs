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
    public class AccessListDomain : BusinessDomainBase<AccessList>
    {
        public AccessListDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new AccessListRepository();
        }

        public override void Add(AccessList entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(AccessList entity)
        {
            DBRepository.Delete(entity, ActionState);
        }

        public override void Update(AccessList entity)
        {
            DBRepository.Update(entity, ActionState);
        }

        public override List<AccessList> FindAll()
        {
            return DBRepository.FindAll(ActionState);
        }

        public override AccessList FindByID(int entityID)
        {
           return DBRepository.FindByID(entityID, ActionState);
        }

        public override bool IsExist(AccessList entity)
        {
            throw new NotImplementedException();
        }
    }
}
