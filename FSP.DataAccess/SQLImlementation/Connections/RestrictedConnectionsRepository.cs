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
    public class RestrictedConnectionsRepository : RepositoryBaseClass<RestrictedConnections>
    {

        public void DeleteByConnectionMetaID(int connectionMetaID, ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(RestrictedConnectionsRepositoryConstants.SP_DeleteByConnectionMetaID);
                database.AddInParameter(cmd, RestrictedConnectionsRepositoryConstants.ConnectionsMetaID, DbType.Int32, connectionMetaID);


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

        public override void Delete(RestrictedConnections entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override void Insert(RestrictedConnections entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(RestrictedConnectionsRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, RestrictedConnectionsRepositoryConstants.ConnectionsMetaID, DbType.Int32, entity.ConnectionMetaID);
                database.AddInParameter(cmd, RestrictedConnectionsRepositoryConstants.Year, DbType.Int32, entity.Year);


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

        public override void Update(RestrictedConnections entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override List<RestrictedConnections> FindAll(Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public List<RestrictedConnections> FindByConnectionMetaID(int connectionMetaID, Common.ActionState actionState)
        {
            List<RestrictedConnections> restrictedConnectionsList;
            RestrictedConnections restrictedConnectionsEntity;
            DbCommand cmd;

            restrictedConnectionsList = new List<RestrictedConnections>();
            restrictedConnectionsEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(RestrictedConnectionsRepositoryConstants.SP_FindBYConnectionMetaID);
                database.AddInParameter(cmd, RestrictedConnectionsRepositoryConstants.ConnectionsMetaID, DbType.Int32, connectionMetaID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        restrictedConnectionsEntity = RestrictedConnectionsHelper(reader);
                        if (restrictedConnectionsEntity != null)
                        {
                            restrictedConnectionsList.Add(restrictedConnectionsEntity);
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
            return restrictedConnectionsList;
        }

        public override RestrictedConnections FindByID(int entityID, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(RestrictedConnections entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private RestrictedConnections RestrictedConnectionsHelper(SqlDataReader reader)
        {
            RestrictedConnections restrictedConnections= new RestrictedConnections();
            restrictedConnections.ConnectionMetaID=Convert.ToInt32(reader[RestrictedConnectionsConstants.ConnectionsMetaID]);
            restrictedConnections.ID=Convert.ToInt32(reader[RestrictedConnectionsConstants.ID]);
            restrictedConnections.Year=Convert.ToInt32(reader[RestrictedConnectionsConstants.Year]);
            return restrictedConnections;
        }
   
    }
}
