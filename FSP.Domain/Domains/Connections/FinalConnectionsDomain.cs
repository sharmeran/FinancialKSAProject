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
    public class FinalConnectionsDomain : BusinessDomainBase<FinalConnections>
    {
        public FinalConnectionsDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new FinalConnectionsRepository();
        }

        public override void Add(FinalConnections entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(FinalConnections entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(FinalConnections entity)
        {
            throw new NotImplementedException();
        }

        public override List<FinalConnections> FindAll()
        {
            throw new NotImplementedException();
        }

        public override FinalConnections FindByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(FinalConnections entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteByConnectionMetaID(int connectionMetaID)
        {
            FinalConnectionsRepository finalConnectionsRepository = new FinalConnectionsRepository();
            finalConnectionsRepository.DeleteByConnectionMetaID(connectionMetaID, ActionState);
        }

        public  List<FinalConnections> FindByConnectionMetaID(int connectionMetaID)
        {
            FinalConnectionsRepository finalConnectionsRepository = new FinalConnectionsRepository();
            return finalConnectionsRepository.FindByConnectionMetaID(connectionMetaID, ActionState);
        }
    }
}
