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
   public class AppreciationConnectionsRepository : RepositoryBaseClass<AppreciationConnections>
    {

        public void DeleteByConnectionMetaID(int connectionMetaID, ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(AppreciationConnectionsRepositoryConstants.SP_DeleteByConnectionMetaID);
                database.AddInParameter(cmd, AppreciationConnectionsRepositoryConstants.ConnectionMetaID, DbType.Int32, connectionMetaID);


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

        public override void Delete(AppreciationConnections entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override void Insert(AppreciationConnections entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(AppreciationConnectionsRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, AppreciationConnectionsRepositoryConstants.ConnectionMetaID, DbType.Int32, entity.ConnectionMetaID);
                database.AddInParameter(cmd, AppreciationConnectionsRepositoryConstants.Year, DbType.Int32, entity.Year);
                

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

       

        public override void Update(AppreciationConnections entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override List<AppreciationConnections> FindAll(Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public List<AppreciationConnections> FindByConnectionMetaID(int connectionMetaID, Common.ActionState actionState)
        {
            List<AppreciationConnections> appreciationConnectionsList;
            AppreciationConnections appreciationConnectionsEntity;
            DbCommand cmd;

            appreciationConnectionsList = new List<AppreciationConnections>();
            appreciationConnectionsEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(AppreciationConnectionsRepositoryConstants.SP_FindBYConnectionMetaID);
                database.AddInParameter(cmd, AppreciationConnectionsRepositoryConstants.ConnectionMetaID, DbType.Int32, connectionMetaID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        appreciationConnectionsEntity = AppreciationConnectionsHelper(reader);
                        if (appreciationConnectionsEntity != null)
                        {
                            appreciationConnectionsList.Add(appreciationConnectionsEntity);
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
            return appreciationConnectionsList;
        }

        public override AppreciationConnections FindByID(int entityID, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(AppreciationConnections entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private AppreciationConnections AppreciationConnectionsHelper(SqlDataReader reader)
        {
            AppreciationConnections appreciationConnections = new AppreciationConnections();
            appreciationConnections.ConnectionMetaID = Convert.ToInt32(reader[AppreciationConnectionsConstants.ConnectionsMetaID]);
            appreciationConnections.ID = Convert.ToInt32(reader[AppreciationConnectionsConstants.ID]);
            appreciationConnections.Year = Convert.ToInt32(reader[AppreciationConnectionsConstants.Year]);
            return appreciationConnections;
        }
    }
}
