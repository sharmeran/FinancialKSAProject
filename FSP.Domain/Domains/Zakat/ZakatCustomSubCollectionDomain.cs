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
    public class ZakatCustomSubCollectionDomain : BusinessDomainBase<ZakatCustomSubCollection>
    {
        public ZakatCustomSubCollectionDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new ZakatCustomSubCollectionRepository();
        }

        public override void Add(ZakatCustomSubCollection entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(ZakatCustomSubCollection entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(ZakatCustomSubCollection entity)
        {
            throw new NotImplementedException();
        }

        public override List<ZakatCustomSubCollection> FindAll()
        {
            throw new NotImplementedException();
        }

        public override ZakatCustomSubCollection FindByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(ZakatCustomSubCollection entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteByZakatMetaID(int zakatMetaID)
        {
            ZakatCustomSubCollectionRepository zakatCustomSubCollectionRepository = new ZakatCustomSubCollectionRepository();
            zakatCustomSubCollectionRepository.DeleteByZakatMetaID(zakatMetaID, ActionState);
        }

        public List<ZakatCustomSubCollection> FindByZakatMetaID(int zakatMetaID)
        {
            ZakatCustomSubCollectionRepository zakatCustomSubCollectionRepository = new ZakatCustomSubCollectionRepository();
            return zakatCustomSubCollectionRepository.FindByZakatMetaID(zakatMetaID, ActionState);
        }
    }
}
