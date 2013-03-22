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
    public class CompanyDomain : BusinessDomainBase<Company>
    {
        public CompanyDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new CompanyRepository();
        }

        public override void Add(Company entity)
        {
            DBRepository.Insert(entity, ActionState);
            CompanyRepository companyRepository = new CompanyRepository();

            companyRepository.InsertCompanyBehaviours(entity, ActionState);
            
           
        }

        public override void Delete(Company entity)
        {
            DBRepository.Delete(entity, ActionState);
        }

        public override void Update(Company entity)
        {
            DBRepository.Update(entity, ActionState);
            CompanyRepository companyRepository = new CompanyRepository();
            companyRepository.DeleteCompanyBehaviours(entity, ActionState);
            companyRepository.InsertCompanyBehaviours(entity, ActionState);
        }

        public override List<Company> FindAll()
        {
            return DBRepository.FindAll(ActionState);
        }

        public override Company FindByID(int entityID)
        {
            return DBRepository.FindByID(entityID, ActionState);
        }

        public override bool IsExist(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
