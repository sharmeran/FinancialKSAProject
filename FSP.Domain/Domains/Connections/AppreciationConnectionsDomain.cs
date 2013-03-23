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
    public class AppreciationConnectionsDomain : BusinessDomainBase<AppreciationConnections>
    {
        public AppreciationConnectionsDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new AppreciationConnectionsRepository();
        }

        public override void Add(AppreciationConnections entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        
        public override void Delete(AppreciationConnections entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(AppreciationConnections entity)
        {
            throw new NotImplementedException();
        }

        public override List<AppreciationConnections> FindAll()
        {
            throw new NotImplementedException();
        }

        public override AppreciationConnections FindByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(AppreciationConnections entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteByConnectionMetaID(int connectionMetaID)
        {
            AppreciationConnectionsRepository appreciationConnectionsRepository = new AppreciationConnectionsRepository();
            appreciationConnectionsRepository.DeleteByConnectionMetaID(connectionMetaID, ActionState);
        }

        public  List<AppreciationConnections> FindByConnectionMetaID(int connectionMetaID)
        {
            AppreciationConnectionsRepository appreciationConnectionsRepository = new AppreciationConnectionsRepository();
           return  appreciationConnectionsRepository.FindByConnectionMetaID(connectionMetaID, ActionState);
        }
    }
}
