using FSP.Common.Constants.Connections;
using FSP.DataAccess.Constants.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.DataAccess.Constants.Connections
{
    public static class ExtraConnectionsRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + ExtraConnectionsConstants.ID;
        public const string ConnectionsMetaID = CommonConstants.PreParameter + ExtraConnectionsConstants.ConnectionsMetaID;
        public const string Year = CommonConstants.PreParameter + ExtraConnectionsConstants.Year;

        public const string SP_Insert = "ExtraConnectionsInsert";
        public const string SP_FindBYConnectionMetaID = "ExtraConnectionsFindByConnectionsMetaID";
        public const string SP_DeleteByConnectionMetaID = "ExtraConnectionsDeleteByConnectionsMetaID";
    }
}
