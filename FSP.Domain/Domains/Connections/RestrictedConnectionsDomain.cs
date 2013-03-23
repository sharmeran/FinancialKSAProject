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
    public class RestrictedConnectionsDomain : BusinessDomainBase<RestrictedConnections>
    {
        public RestrictedConnectionsDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new RestrictedConnectionsRepository();
        }

        public override void Add(RestrictedConnections entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(RestrictedConnections entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(RestrictedConnections entity)
        {
            throw new NotImplementedException();
        }

        public override List<RestrictedConnections> FindAll()
        {
            throw new NotImplementedException();
        }

        public override RestrictedConnections FindByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(RestrictedConnections entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteByConnectionMetaID(int connectionMetaID)
        {
            RestrictedConnectionsRepository restrictedConnectionsRepository = new RestrictedConnectionsRepository();
            restrictedConnectionsRepository.DeleteByConnectionMetaID(connectionMetaID, ActionState);
        }

        public  List<RestrictedConnections> FindByConnectionMetaID(int connectionMetaID)
        {
            RestrictedConnectionsRepository restrictedConnectionsRepository = new RestrictedConnectionsRepository();
            return restrictedConnectionsRepository.FindByConnectionMetaID(connectionMetaID, ActionState);
        }

    }
}
