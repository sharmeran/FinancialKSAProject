using FSP.Common.Constants.Connections;
using FSP.DataAccess.Constants.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.DataAccess.Constants.Connections
{
    public static class ConnectionsMetaRepositoryConstants
    {
        public const string ID = CommonConstants.PreParameter + ConnectionsMetaConstants.ID;
        public const string ZakatMainID = CommonConstants.PreParameter + ConnectionsMetaConstants.ZakatMainID;
        public const string InitialConnectionNumber = CommonConstants.PreParameter + ConnectionsMetaConstants.InitialConnectionNumber;
        public const string RestrictedConnesctionNumber = CommonConstants.PreParameter + ConnectionsMetaConstants.RestrictedConnesctionNumber;
        public const string UnRestrictedConnectionNumber = CommonConstants.PreParameter + ConnectionsMetaConstants.UnRestrictedConnectionNumber;
        public const string ExtraConnectionNumber = CommonConstants.PreParameter + ConnectionsMetaConstants.ExtraConnectionNumber;
        public const string AppreciationConnectionNumber = CommonConstants.PreParameter + ConnectionsMetaConstants.AppreciationConnectionNumber;
        public const string FinalConnectionNumber = CommonConstants.PreParameter + ConnectionsMetaConstants.FinalConnectionNumber;
        public const string UnderStudyingNumber = CommonConstants.PreParameter + ConnectionsMetaConstants.UnderStudyingNumber;


        public const string SP_DeleteByZakatMainID = "ConnectionsMetaDeleteByZakatMainID";
        public const string SP_FindBYZakatMainID = "ConnectionsMetaFindByZakatMainID";
        public const string SP_Insert = "ConnectionsMetaInsert";
    }
}
