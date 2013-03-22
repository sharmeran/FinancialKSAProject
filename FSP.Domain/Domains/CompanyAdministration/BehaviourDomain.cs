using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Entites.CompanyAdministration;
using FSP.Common.Enums;
using FSP.DataAccess.SQLImlementation.CompanyAdministration;
using FSP.Domain.BaseClasses;

namespace FSP.Domain.Domains.CompanyAdministration
{
    public class BehaviourDomain : BusinessDomainBase<Behaviour>
    {
        public BehaviourDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new BehaviourRepository();
        }

        public override void Add(Behaviour entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(Behaviour entity)
        {
            DBRepository.Delete(entity, ActionState);
        }

        public override void Update(Behaviour entity)
        {
            DBRepository.Update(entity, ActionState);
        }

        public override List<Behaviour> FindAll()
        {
            return DBRepository.FindAll(ActionState);
        }

        public override Behaviour FindByID(int entityID)
        {
            return DBRepository.FindByID(entityID, ActionState);
        }

        public override bool IsExist(Behaviour entity)
        {
            throw new NotImplementedException();
        }
    }
}
