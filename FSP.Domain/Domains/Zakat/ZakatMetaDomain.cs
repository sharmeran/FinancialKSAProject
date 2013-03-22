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
    public class ZakatMetaDomain : BusinessDomainBase<ZakatMeta>
    {
        public ZakatMetaDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new ZakatMetaRepository();
        }

        public override void Add(ZakatMeta entity)
        {
            DBRepository.Insert(entity, ActionState);
            ZakatCollectionDomain zakatCollectionDomain = new ZakatCollectionDomain(1, LanguagesEnum.Arabic);
            for (int i = 0; i < entity.ZakatCollectionList.Count; i++)
            {
                entity.ZakatCollectionList[i].ZakatMetaID = entity.ID;
                zakatCollectionDomain.Add(entity.ZakatCollectionList[i]);
            }

            ZakatCustomCollectionDomain zakatCustomCollectionDomain = new ZakatCustomCollectionDomain(1, LanguagesEnum.Arabic);
            for (int j = 0; j < entity.ZakatCustomCollectionList.Count; j++)
            {
                entity.ZakatCustomCollectionList[j].ZakatMetaID = entity.ID;
                zakatCustomCollectionDomain.Add(entity.ZakatCustomCollectionList[j]);
            }

            ZakatCustomSubCollectionDomain zakatCustomSubCollectionDomain = new ZakatCustomSubCollectionDomain(1, LanguagesEnum.Arabic);
            for (int k = 0; k < entity.ZakatCustomSubCollectionList.Count; k++)
            {
                entity.ZakatCustomSubCollectionList[k].ZakatMetaID = entity.ID;
                zakatCustomSubCollectionDomain.Add(entity.ZakatCustomSubCollectionList[k]);
            }

            ZakatSubCollectionDomain zakatSubCollectionDomain = new ZakatSubCollectionDomain(1, LanguagesEnum.Arabic);
            for (int m = 0; m < entity.ZakatSubCollectionList.Count; m++)
            {
                entity.ZakatSubCollectionList[m].ZakatMetaID = entity.ID;
                zakatSubCollectionDomain.Add(entity.ZakatSubCollectionList[m]);
            }
        }

        public void DeleteByZakatMainID(ZakatMeta entity)
        {
            ZakatMetaRepository zakatMetaRepository = new ZakatMetaRepository();
            zakatMetaRepository.DeleteByZakatMainID(entity.ZakatMainID, ActionState);
            ZakatCollectionDomain zakatCollectionDomain = new ZakatCollectionDomain(1, LanguagesEnum.Arabic);
            zakatCollectionDomain.DeleteByZakatMetaID(entity.ID);
            ZakatCustomCollectionDomain zakatCustomCollectionDomain = new ZakatCustomCollectionDomain(1, LanguagesEnum.Arabic);
            zakatCustomCollectionDomain.DeleteByZakatMetaID(entity.ID);
            ZakatCustomSubCollectionDomain zakatCustomSubCollectionDomain = new ZakatCustomSubCollectionDomain(1, LanguagesEnum.Arabic);
            zakatCustomSubCollectionDomain.DeleteByZakatMetaID(entity.ID);
            ZakatSubCollectionDomain zakatSubCollectionDomain = new ZakatSubCollectionDomain(1, LanguagesEnum.Arabic);
            zakatSubCollectionDomain.DeleteByZakatMetaID(entity.ID);
        }

        public override void Delete(ZakatMeta entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(ZakatMeta entity)
        {
            throw new NotImplementedException();
        }

        public override List<ZakatMeta> FindAll()
        {
            throw new NotImplementedException();
        }

        public override ZakatMeta FindByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(ZakatMeta entity)
        {
            throw new NotImplementedException();
        }

        public List<ZakatMeta> FindByZakatMainID(int zakatMainID)
        {
            ZakatMetaRepository zakatMetaRepository = new ZakatMetaRepository();
            return zakatMetaRepository.FindByZakatMainID(zakatMainID, ActionState);
        }
    }
}
