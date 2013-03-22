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
    public class AppYearDomain : BusinessDomainBase<AppYear>
    {
        public AppYearDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new AppYearRepository();
        }

        public override void Add(AppYear entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(AppYear entity)
        {
            DBRepository.Delete(entity, ActionState);
        }

        public override void Update(AppYear entity)
        {
            DBRepository.Update(entity, ActionState);
        }

        public override List<AppYear> FindAll()
        {
            return DBRepository.FindAll(ActionState);
        }

        public override AppYear FindByID(int entityID)
        {
            return DBRepository.FindByID(entityID, ActionState);
        }

        public override bool IsExist(AppYear entity)
        {
            throw new NotImplementedException();
        }
    }
}
