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
    public class GroupDomain : BusinessDomainBase<Group>
    {
        public GroupDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new GroupRepository();
        }

        public override void Add(Group entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(Group entity)
        {
            DBRepository.Delete(entity, ActionState);
        }

        public override void Update(Group entity)
        {
            DBRepository.Update(entity, ActionState);
        }

        public override List<Group> FindAll()
        {
            return DBRepository.FindAll(ActionState);
        }

        public override Group FindByID(int entityID)
        {
            return DBRepository.FindByID(entityID, ActionState);
        }

        public override bool IsExist(Group entity)
        {
            throw new NotImplementedException();
        }
    }

}
