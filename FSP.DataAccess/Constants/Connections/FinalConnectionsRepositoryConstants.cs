using FSP.Common.Constants.Connections;
using FSP.DataAccess.Constants.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.DataAccess.Constants.Connections
{
   public static class FinalConnectionsRepositoryConstants
    {
       public const string ID = CommonConstants.PreParameter + FinalConnectionsConstants.ID;
       public const string ConnectionsMetaID = CommonConstants.PreParameter + FinalConnectionsConstants.ConnectionsMetaID;
       public const string Year = CommonConstants.PreParameter + FinalConnectionsConstants.Year;

       public const string SP_Insert = "FinalConnectionsInsert";
       public const string SP_FindBYConnectionMetaID = "FinalConnectionsFindByConnectionsMetaID";
       public const string SP_DeleteByConnectionMetaID = "FinalConnectionsDeleteByConnectionsMetaID";
    }
}
