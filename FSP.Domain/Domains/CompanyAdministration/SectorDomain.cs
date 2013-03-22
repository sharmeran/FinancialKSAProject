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
    public class SectorDomain : BusinessDomainBase<Sector>
    {
        public SectorDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new SectorRepository();
        }


        public override void Add(Sector entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(Sector entity)
        {
            DBRepository.Delete(entity, ActionState);
        }

        public override void Update(Sector entity)
        {
            DBRepository.Update(entity, ActionState);
        }

        public override List<Sector> FindAll()
        {
            return DBRepository.FindAll(ActionState);
        }

        public override Sector FindByID(int entityID)
        {
           return DBRepository.FindByID(entityID, ActionState);
        }

        public override bool IsExist(Sector entity)
        {
            throw new NotImplementedException();
        }
    }
}
