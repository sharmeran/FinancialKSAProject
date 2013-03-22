using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Connections;
using FSP.DataAccess.Constants.Common;

namespace FSP.DataAccess.Constants.Connections
{
   public static class AppreciationConnectionsRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + AppreciationConnectionsConstants.ID;
       public const string ConnectionMetaID = CommonConstants.PreParameter + AppreciationConnectionsConstants.ConnectionsMetaID;
       public const string Year = CommonConstants.PreParameter + AppreciationConnectionsConstants.Year;

       public const string SP_Insert = "AppreciationConnectionsInsert";
       public const string SP_FindBYConnectionMetaID = "AppreciationConnectionsFindByConnectionsMetaID";
       public const string SP_DeleteByConnectionMetaID = "AppreciationConnectionsDeleteByConnectionsMetaID";

    }
}
