using FSP.Common.Constants.Connections;
using FSP.DataAccess.Constants.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.DataAccess.Constants.Connections
{
    public static class UnRestrictedConnectionsRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + UnRestrictedConnectionsConstants.ID;
        public const string ConnectionsMetaID = CommonConstants.PreParameter + UnRestrictedConnectionsConstants.ConnectionsMetaID;
        public const string Year = CommonConstants.PreParameter + UnRestrictedConnectionsConstants.Year;

        public const string SP_Insert = "UnRestrictedConnectionsInsert";
        public const string SP_FindBYConnectionMetaID = "UnRestrictedConnectionsFindByConnectionsMetaID";
        public const string SP_DeleteByConnectionMetaID = "UnRestrictedConnectionsDeleteByConnectionsMetaID";
    }
}
