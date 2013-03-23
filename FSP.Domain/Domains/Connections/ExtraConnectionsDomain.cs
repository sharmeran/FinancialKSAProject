using FSP.Common.Entites.Connections;
using FSP.Common.Enums;
using FSP.DataAccess.SQLImlementation.Connections;
using FSP.Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.Domain.Domains.Connections
{
    public class ExtraConnectionsDomain : BusinessDomainBase<ExtraConnections>
    {
        public ExtraConnectionsDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new ExtraConnectionsRepository();
        }

        public override void Add(ExtraConnections entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(ExtraConnections entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(ExtraConnections entity)
        {
            throw new NotImplementedException();
        }

        public override List<ExtraConnections> FindAll()
        {
            throw new NotImplementedException();
        }

        public override ExtraConnections FindByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(ExtraConnections entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteByConnectionMetaID(int connectionMetaID)
        {
            ExtraConnectionsRepository extraConnectionsRepository = new ExtraConnectionsRepository();
            extraConnectionsRepository.DeleteByConnectionMetaID(connectionMetaID, ActionState);
        }

        public  List<ExtraConnections> FindByConnectionMetaID(int connectionMetaID)
        {
            ExtraConnectionsRepository extraConnectionsRepository = new ExtraConnectionsRepository();
            return extraConnectionsRepository.FindByConnectionMetaID(connectionMetaID, ActionState);
        }

    }
}
