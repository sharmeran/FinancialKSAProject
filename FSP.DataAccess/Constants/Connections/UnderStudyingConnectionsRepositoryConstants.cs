using FSP.Common.Constants.Connections;
using FSP.DataAccess.Constants.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.DataAccess.Constants.Connections
{
   public static class UnderStudyingConnectionsRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + UnderStudyingConnectionsConstants.ID;
       public const string ConnectionsMetaID = CommonConstants.PreParameter + UnderStudyingConnectionsConstants.ConnectionsMetaID;
       public const string Year = CommonConstants.PreParameter + UnderStudyingConnectionsConstants.Year;

       public const string SP_Insert = "UnderStudyingConnectionsInsert";
       public const string SP_FindBYConnectionMetaID = "UnderStudyingConnectionsFindByConnectionsMetaID";
       public const string SP_DeleteByConnectionMetaID = "UnderStudyingConnectionsDeleteConnectionsMetaID";
    }
}
