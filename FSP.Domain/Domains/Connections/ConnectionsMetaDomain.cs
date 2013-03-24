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
            AppreciationConnectionsRepository appreciationConnectionsRepository = new AppreciationConnectionsRepository();
            ExtraConnectionsRepository extraConnectionsRepository = new ExtraConnectionsRepository();
            FinalConnectionsRepository finalConnectionsRepository = new FinalConnectionsRepository();
            InitialConnectionsRepository initialConnectionsRepository = new InitialConnectionsRepository();
            RestrictedConnectionsRepository restrictedConnectionsRepository = new RestrictedConnectionsRepository();
            UnderStudyingConnectionsRepository underStudyingConnectionsRepository = new UnderStudyingConnectionsRepository();
            UnRestrictedConnectionsRepository unRestrictedConnectionsRepository = new UnRestrictedConnectionsRepository();
            

            foreach(AppreciationConnections appreciationConnections in entity.AppreciationConnectionsList) 
            {
                appreciationConnectionsRepository.Insert(appreciationConnections, ActionState);
            }

            foreach (ExtraConnections extraConnections in entity.ExtraConnectionsList)
            {
                extraConnectionsRepository.Insert(extraConnections, ActionState);
            }

            foreach (FinalConnections finalConnections in entity.FinalConnectionsList)
            {
                finalConnectionsRepository.Insert(finalConnections, ActionState);
            }

            foreach (InitialConnections initialConnections in entity.InitialConnectionsList)
            {
                initialConnectionsRepository.Insert(initialConnections, ActionState);
            }

            foreach (RestrictedConnections restrictedConnections in entity.RestrictedConnectionsList)
            {
                restrictedConnectionsRepository.Insert(restrictedConnections, ActionState);
            }

            foreach (UnderStudyingConnections underStudyingConnections in entity.UnderStudyingConnectionsList)
            {
                underStudyingConnectionsRepository.Insert(underStudyingConnections, ActionState);
            }

            foreach (UnRestrictedConnections unRestrictedConnections in entity.UnRestrictedConnectionsList)
            {
                unRestrictedConnectionsRepository.Insert(unRestrictedConnections, ActionState);
            }

        }

        public override void Delete(ConnectionsMeta entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteByZakatMainID(ConnectionsMeta entity)
        {
            ConnectionsMetaRepository connectionsMetaRepository = new ConnectionsMetaRepository();
            connectionsMetaRepository.DeleteByZakatMainID(entity.ZakatMainID, ActionState);

            AppreciationConnectionsRepository appreciationConnectionsRepository = new AppreciationConnectionsRepository();
            appreciationConnectionsRepository.DeleteByConnectionMetaID(entity.ID, ActionState);

            ExtraConnectionsRepository extraConnectionsRepository = new ExtraConnectionsRepository();
            extraConnectionsRepository.DeleteByConnectionMetaID(entity.ID, ActionState);

            FinalConnectionsRepository finalConnectionsRepository = new FinalConnectionsRepository();
            finalConnectionsRepository.DeleteByConnectionMetaID(entity.ID, ActionState);

            InitialConnectionsRepository initialConnectionsRepository = new InitialConnectionsRepository();
            initialConnectionsRepository.DeleteByConnectionMetaID(entity.ID, ActionState);

            RestrictedConnectionsRepository restrictedConnectionsRepository = new RestrictedConnectionsRepository();
            restrictedConnectionsRepository.DeleteByConnectionMetaID(entity.ID, ActionState);

            UnderStudyingConnectionsRepository underStudyingConnectionsRepository = new UnderStudyingConnectionsRepository();
            underStudyingConnectionsRepository.DeleteByConnectionMetaID(entity.ID, ActionState);

            UnRestrictedConnectionsRepository unRestrictedConnectionsRepository = new UnRestrictedConnectionsRepository();
            unRestrictedConnectionsRepository.DeleteByConnectionMetaID(entity.ID, ActionState);


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
