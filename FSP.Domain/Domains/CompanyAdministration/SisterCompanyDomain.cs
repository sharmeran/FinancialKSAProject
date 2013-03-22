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
  public  class SisterCompanyDomain : BusinessDomainBase<SisterCompany>
    {
        public SisterCompanyDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new SisterCompanyRepository();
        }

        public override void Add(SisterCompany entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(SisterCompany entity)
        {
            DBRepository.Delete(entity, ActionState);
        }

        public override void Update(SisterCompany entity)
        {
            DBRepository.Update(entity, ActionState);
        }

        public override List<SisterCompany> FindAll()
        {
            return DBRepository.FindAll(ActionState);
        }

        public override SisterCompany FindByID(int entityID)
        {
            return DBRepository.FindByID(entityID, ActionState);
        }

        public List<SisterCompany> FindByCompanyID(int companyID)
        {
            SisterCompanyRepository sisterCompanyRepository = new SisterCompanyRepository();
            return sisterCompanyRepository.FindByCompanyID(companyID, ActionState);
        }

        

        public override bool IsExist(SisterCompany entity)
        {
            throw new NotImplementedException();
        }
    }
}
