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
    public class UnRestrictedConnectionsDomain : BusinessDomainBase<UnRestrictedConnections>
    {
        public UnRestrictedConnectionsDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new UnRestrictedConnectionsRepository();
        }

        public override void Add(UnRestrictedConnections entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(UnRestrictedConnections entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(UnRestrictedConnections entity)
        {
            throw new NotImplementedException();
        }

        public override List<UnRestrictedConnections> FindAll()
        {
            throw new NotImplementedException();
        }

        public override UnRestrictedConnections FindByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(UnRestrictedConnections entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteByConnectionMetaID(int connectionMetaID)
        {
            UnRestrictedConnectionsRepository unRestrictedConnectionsRepository = new UnRestrictedConnectionsRepository();
            unRestrictedConnectionsRepository.DeleteByConnectionMetaID(connectionMetaID, ActionState);
        }

        public  List<UnRestrictedConnections> FindByConnectionMetaID(int connectionMetaID)
        {
            UnRestrictedConnectionsRepository unRestrictedConnectionsRepository = new UnRestrictedConnectionsRepository();
            return unRestrictedConnectionsRepository.FindByConnectionMetaID(connectionMetaID, ActionState);
        }
    }
}
