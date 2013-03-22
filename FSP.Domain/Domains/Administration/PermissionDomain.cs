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
    public class PermissionDomain : BusinessDomainBase<Permission>
    {
        public PermissionDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new PermissionRepository();
        }
        public override void Add(Permission entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(Permission entity)
        {
            DBRepository.Delete(entity, ActionState);
        }

        public override void Update(Permission entity)
        {
            DBRepository.Update(entity, ActionState);
        }

        public override List<Permission> FindAll()
        {
            return DBRepository.FindAll(ActionState);
        }

        public override Permission FindByID(int entityID)
        {
            return DBRepository.FindByID(entityID, ActionState);
        }

        public override bool IsExist(Permission entity)
        {
            throw new NotImplementedException();
        }
    }
}
