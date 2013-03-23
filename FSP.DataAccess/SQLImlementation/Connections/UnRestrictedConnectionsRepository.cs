using FSP.Common;
using FSP.Common.Constants.Connections;
using FSP.Common.Entites.Connections;
using FSP.Common.Enums;
using FSP.DataAccess.BaseClasses;
using FSP.DataAccess.Constants.Common;
using FSP.DataAccess.Constants.Connections;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSP.DataAccess.SQLImlementation.Connections
{
    public class UnRestrictedConnectionsRepository : RepositoryBaseClass<UnRestrictedConnections>
    {

        public void DeleteByConnectionMetaID(int connectionMetaID, ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(UnRestrictedConnectionsRepositoryConstants.SP_DeleteByConnectionMetaID);
                database.AddInParameter(cmd, UnRestrictedConnectionsRepositoryConstants.ConnectionsMetaID, DbType.Int32, connectionMetaID);


                spResult = database.ExecuteNonQuery(cmd);
                if (spResult > 0)
                {
                    actionState.SetSuccess();
                }
                else
                {
                    actionState.SetFail(ActionStatusEnum.CannotDelete, LocalizationConstants.Err_CannotDelete);
                }

            }
            catch (Exception ex)
            {
                actionState.SetFail(ActionStatusEnum.CannotDelete, ex.Message);
            }
            finally
            {
                cmd = null;
            }
        }

        public override void Delete(UnRestrictedConnections entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override void Insert(UnRestrictedConnections entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(UnRestrictedConnectionsRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, UnRestrictedConnectionsRepositoryConstants.ConnectionsMetaID, DbType.Int32, entity.ConnectionMetaID);
                database.AddInParameter(cmd, UnRestrictedConnectionsRepositoryConstants.Year, DbType.Int32, entity.Year);


                spResult = Convert.ToInt32(database.ExecuteScalar(cmd));
                if (spResult > 0)
                {
                    actionState.SetSuccess();
                    entity.ID = spResult;
                }
                else
                {
                    actionState.SetFail(ActionStatusEnum.CannotInsert, LocalizationConstants.Err_CannotInsert);
                }

            }
            catch (Exception ex)
            {
                actionState.SetFail(ActionStatusEnum.CannotInsert, ex.Message);
            }
            finally
            {
                cmd = null;
            }
        }

        public override void Update(UnRestrictedConnections entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override List<UnRestrictedConnections> FindAll(Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public List<UnRestrictedConnections> FindByConnectionMetaID(int connectionMetaID, Common.ActionState actionState)
        {
            List<UnRestrictedConnections> unRestrictedConnectionsList;
            UnRestrictedConnections unRestrictedConnectionsEntity;
            DbCommand cmd;

            unRestrictedConnectionsList = new List<UnRestrictedConnections>();
            unRestrictedConnectionsEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(UnRestrictedConnectionsRepositoryConstants.SP_FindBYConnectionMetaID);
                database.AddInParameter(cmd, UnRestrictedConnectionsRepositoryConstants.ConnectionsMetaID, DbType.Int32, connectionMetaID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        unRestrictedConnectionsEntity = UnRestrictedConnectionsHelper(reader);
                        if (unRestrictedConnectionsEntity != null)
                        {
                            unRestrictedConnectionsList.Add(unRestrictedConnectionsEntity);
                        }
                    }
                    actionState.SetSuccess();
                }
            }
            catch (Exception ex)
            {
                actionState.SetFail(ActionStatusEnum.Exception, ex.Message);
            }
            finally
            {
                cmd = null;
            }
            return unRestrictedConnectionsList;
        }


        public override UnRestrictedConnections FindByID(int entityID, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(UnRestrictedConnections entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private UnRestrictedConnections UnRestrictedConnectionsHelper(SqlDataReader reader)
        {
            UnRestrictedConnections unRestrictedConnections = new UnRestrictedConnections();
            unRestrictedConnections.ConnectionMetaID = Convert.ToInt32(reader[UnRestrictedConnectionsConstants.ConnectionsMetaID]);
            unRestrictedConnections.ID = Convert.ToInt32(reader[UnRestrictedConnectionsConstants.ID]);
            unRestrictedConnections.Year = Convert.ToInt32(reader[UnRestrictedConnectionsConstants.Year]);
            return unRestrictedConnections;
        }
    }
}
