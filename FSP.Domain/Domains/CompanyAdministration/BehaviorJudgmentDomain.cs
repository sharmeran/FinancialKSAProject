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
    public class BehaviorJudgmentDomain : BusinessDomainBase<BehaviorJudgment>
    {
        public BehaviorJudgmentDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new BehaviorJudgmentRepository();
        }

        public override void Add(BehaviorJudgment entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(BehaviorJudgment entity)
        {
            DBRepository.Delete(entity, ActionState);
        }

        public override void Update(BehaviorJudgment entity)
        {
            DBRepository.Update(entity, ActionState);
        }

        public override List<BehaviorJudgment> FindAll()
        {
            return DBRepository.FindAll(ActionState);
        }

        public override BehaviorJudgment FindByID(int entityID)
        {
            return DBRepository.FindByID(entityID, ActionState);
        }

        public override bool IsExist(BehaviorJudgment entity)
        {
            throw new NotImplementedException();
        }
    }
}
