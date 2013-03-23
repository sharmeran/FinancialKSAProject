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
    public class ConnectionsMetaDomain : BusinessDomainBase<ConnectionsMeta>
    {
        public ConnectionsMetaDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new ConnectionsMetaRepository();
        }

        public override void Add(ConnectionsMeta entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(ConnectionsMeta entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteByConnectionsMeta(int connectionsMetaID)
        {
            AppreciationConnectionsRepository appreciationConnectionsRepository = new AppreciationConnectionsRepository();
            appreciationConnectionsRepository.DeleteByConnectionMetaID(connectionsMetaID, ActionState);

            ExtraConnectionsRepository extraConnectionsRepository = new ExtraConnectionsRepository();
            extraConnectionsRepository.DeleteByConnectionMetaID(connectionsMetaID, ActionState);

            FinalConnectionsRepository finalConnectionsRepository = new FinalConnectionsRepository();
            finalConnectionsRepository.DeleteByConnectionMetaID(connectionsMetaID, ActionState);

            InitialConnectionsRepository initialConnectionsRepository = new InitialConnectionsRepository();
            initialConnectionsRepository.DeleteByConnectionMetaID(connectionsMetaID, ActionState);

            RestrictedConnectionsRepository restrictedConnectionsRepository = new RestrictedConnectionsRepository();
            restrictedConnectionsRepository.DeleteByConnectionMetaID(connectionsMetaID, ActionState);

            UnderStudyingConnectionsRepository underStudyingConnectionsRepository = new UnderStudyingConnectionsRepository();
            underStudyingConnectionsRepository.DeleteByConnectionMetaID(connectionsMetaID, ActionState);

            UnRestrictedConnectionsRepository unRestrictedConnectionsRepository = new UnRestrictedConnectionsRepository();
            unRestrictedConnectionsRepository.DeleteByConnectionMetaID(connectionsMetaID, ActionState);


        }

        public override void Update(ConnectionsMeta entity)
        {
            throw new NotImplementedException();
        }

        public override List<ConnectionsMeta> FindAll()
        {
            throw new NotImplementedException();
        }

        public override ConnectionsMeta FindByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(ConnectionsMeta entity)
        {
            throw new NotImplementedException();
        }

        public List<ConnectionsMeta> FindByConnectionsMetaID(int connectionsMeta)
        {
            ConnectionsMetaRepository connectionsMetaRepository = new ConnectionsMetaRepository();
            return connectionsMetaRepository.FindByZakatMainID(connectionsMeta, ActionState);
        }
    }
}
