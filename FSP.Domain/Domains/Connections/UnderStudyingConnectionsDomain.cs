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
    public class UnderStudyingConnectionsDomain : BusinessDomainBase<UnderStudyingConnections>
    {
        public UnderStudyingConnectionsDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new UnderStudyingConnectionsRepository();
        }

        public override void Add(UnderStudyingConnections entity)
        {
            DBRepository.Insert(entity, ActionState);
        }

        public override void Delete(UnderStudyingConnections entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(UnderStudyingConnections entity)
        {
            throw new NotImplementedException();
        }

        public override List<UnderStudyingConnections> FindAll()
        {
            throw new NotImplementedException();
        }

        public override UnderStudyingConnections FindByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(UnderStudyingConnections entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteByConnectionMetaID(int connectionMetaID)
        {
            UnderStudyingConnectionsRepository underStudyingConnectionsRepository = new UnderStudyingConnectionsRepository();
            underStudyingConnectionsRepository.DeleteByConnectionMetaID(connectionMetaID, ActionState);
        }

        public  List<UnderStudyingConnections> FindByConnectionMetaID(int connectionMetaID)
        {
            UnderStudyingConnectionsRepository underStudyingConnectionsRepository = new UnderStudyingConnectionsRepository();
            return underStudyingConnectionsRepository.FindByConnectionMetaID(connectionMetaID, ActionState);
        }

    }
}
