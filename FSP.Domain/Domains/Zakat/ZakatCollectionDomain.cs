using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Entites.Zakat;
using FSP.Common.Enums;
using FSP.DataAccess.SQLImlementation.Zakat;
using FSP.Domain.BaseClasses;

namespace FSP.Domain.Domains.Zakat
{
    class ZakatCollectionDomain : BusinessDomainBase<ZakatCollection>
    {
        public ZakatCollectionDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new ZakatCollectionRepository();
        }

        public override void Add(ZakatCollection entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(ZakatCollection entity)
        {
            throw new NotImplementedException();
        }

        public override List<ZakatCollection> FindAll()
        {
            throw new NotImplementedException();
        }

        public override void Update(ZakatCollection entity)
        {
            throw new NotImplementedException();
        }

        public override ZakatCollection FindByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(ZakatCollection entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteByZakatMetaID(int zakatMetaID)
        {
            ZakatCollectionRepository zakatCollectionRepository = new ZakatCollectionRepository();
            zakatCollectionRepository.DeleteByZakatMetaID(zakatMetaID, ActionState);
        }

        public List<ZakatCollection> FindByZakatMetaID(int zakatMetaID)
        {
            ZakatCollectionRepository zakatCollectionRepository = new ZakatCollectionRepository();
            return zakatCollectionRepository.FindByZakatMetaID(zakatMetaID, ActionState);
        }
    }
}
