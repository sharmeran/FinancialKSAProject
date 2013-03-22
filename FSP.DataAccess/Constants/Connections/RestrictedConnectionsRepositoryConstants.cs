using FSP.Common.Constants.Connections;
using FSP.DataAccess.Constants.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.DataAccess.Constants.Connections
{
    public static class RestrictedConnectionsRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + RestrictedConnectionsConstants.ID;
        public const string ConnectionsMetaID = CommonConstants.PreParameter + RestrictedConnectionsConstants.ConnectionsMetaID;
        public const string Year = CommonConstants.PreParameter + RestrictedConnectionsConstants.Year;

        public const string SP_Insert = "RestrictedConnectionsInsert";
        public const string SP_FindBYConnectionMetaID = "RestrictedConnectionsFindByConnectionsMetaID";
        public const string SP_DeleteByConnectionMetaID = "RestrictedConnectionsDeleteByConnectionsMetaID";
    }
}
