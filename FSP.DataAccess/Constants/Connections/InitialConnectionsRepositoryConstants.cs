using FSP.Common.Constants.Connections;
using FSP.DataAccess.Constants.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.DataAccess.Constants.Connections
{
  public static  class InitialConnectionsRepositoryConstants
    {
      public const string ID = CommonConstants.PreParameter + InitialConnectionsConstants.ID;
      public const string ConnectionsMetaID = CommonConstants.PreParameter + InitialConnectionsConstants.ConnectionsMetaID;
      public const string Year = CommonConstants.PreParameter + InitialConnectionsConstants.Year;

      public const string SP_Insert = "InitialConnectionInsert";
      public const string SP_FindBYConnectionMetaID = "InitialConnectionFindByConnectionsMetaID";
      public const string SP_DeleteByConnectionMetaID = "InitialConnectionDeleteByConnectionsMetaID";
    }
}
