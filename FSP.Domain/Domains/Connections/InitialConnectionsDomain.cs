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
    public class InitialConnectionsDomain : BusinessDomainBase<InitialConnections>
    {
        public InitialConnectionsDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new InitialConnectionsRepository();
        }

        public override void Add(InitialConnections entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(InitialConnections entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(InitialConnections entity)
        {
            throw new NotImplementedException();
        }

        public override List<InitialConnections> FindAll()
        {
            throw new NotImplementedException();
        }

        public override InitialConnections FindByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(InitialConnections entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteByConnectionMetaID(int connectionMetaID)
        {
            InitialConnectionsRepository initialConnectionsRepository = new InitialConnectionsRepository();
            initialConnectionsRepository.DeleteByConnectionMetaID(connectionMetaID, ActionState);
        }

        public  List<InitialConnections> FindByConnectionMetaID(int connectionMetaID)
        {
            InitialConnectionsRepository initialConnectionsRepository = new InitialConnectionsRepository();
            return initialConnectionsRepository.FindByConnectionMetaID(connectionMetaID, ActionState);
        }
    }
}
