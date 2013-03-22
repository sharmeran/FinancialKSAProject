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
    public class SubsidiaryCompanyDomain : BusinessDomainBase<SubsidiaryCompany>
    {
        public SubsidiaryCompanyDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new SubsidiaryCompanyRepository();
        }

        public override void Add(SubsidiaryCompany entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(SubsidiaryCompany entity)
        {
            DBRepository.Delete(entity, ActionState);
        }

        public override void Update(SubsidiaryCompany entity)
        {
            DBRepository.Update(entity, ActionState);
        }

        public override List<SubsidiaryCompany> FindAll()
        {
            return DBRepository.FindAll(ActionState);
        }

        public override SubsidiaryCompany FindByID(int entityID)
        {
            return DBRepository.FindByID(entityID, ActionState);
        }

        public List<SubsidiaryCompany> FindByCompanyID(int companyID)
        {
            SubsidiaryCompanyRepository subsidiaryCompanyRepository = new SubsidiaryCompanyRepository();
            return subsidiaryCompanyRepository.FindByCompanyID(companyID, ActionState);
        }

        public override bool IsExist(SubsidiaryCompany entity)
        {
            throw new NotImplementedException();
        }
    }
}
