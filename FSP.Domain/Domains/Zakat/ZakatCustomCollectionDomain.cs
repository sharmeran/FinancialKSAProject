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
    public class ZakatCustomCollectionDomain : BusinessDomainBase<ZakatCustomCollection>
    {
        public ZakatCustomCollectionDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new ZakatCustomCollectionRepository();
        }
        public override void Add(ZakatCustomCollection entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(ZakatCustomCollection entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(ZakatCustomCollection entity)
        {
            throw new NotImplementedException();
        }

        public override List<ZakatCustomCollection> FindAll()
        {
            throw new NotImplementedException();
        }

        public override ZakatCustomCollection FindByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(ZakatCustomCollection entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteByZakatMetaID(int zakatMetaID)
        {
            ZakatCustomCollectionRepository zakatCustomCollectionRepository = new ZakatCustomCollectionRepository();
            zakatCustomCollectionRepository.DeleteByZakatMetaID(zakatMetaID, ActionState);
        }

        public List<ZakatCustomCollection> FindByZakatMetaID(int zakatMetaID)
        {
            ZakatCustomCollectionRepository zakatCustomCollectionRepository = new ZakatCustomCollectionRepository();
            return zakatCustomCollectionRepository.FindByZakatMetaID(zakatMetaID, ActionState);
        }
    }
}
