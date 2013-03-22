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
    public class ZakatSubCollectionDomain : BusinessDomainBase<ZakatSubCollection>
    {

        public ZakatSubCollectionDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new ZakatSubCollectionRepository();
        }

        public override void Add(ZakatSubCollection entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(ZakatSubCollection entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(ZakatSubCollection entity)
        {
            throw new NotImplementedException();
        }

        public override List<ZakatSubCollection> FindAll()
        {
            throw new NotImplementedException();
        }

        public override ZakatSubCollection FindByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(ZakatSubCollection entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteByZakatMetaID(int zakatMetaID)
        {
            ZakatSubCollectionRepository zakatSubCollectionRepository = new ZakatSubCollectionRepository();
            zakatSubCollectionRepository.DeleteByZakatMetaID(zakatMetaID, ActionState);
        }

        public List<ZakatSubCollection> FindByZakatMetaID(int zakatMetaID)
        {
            ZakatSubCollectionRepository zakatSubCollectionRepository = new ZakatSubCollectionRepository();
            return zakatSubCollectionRepository.FindByZakatMetaID(zakatMetaID, ActionState);
        }
    }
}
