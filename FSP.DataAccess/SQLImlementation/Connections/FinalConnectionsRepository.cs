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
    public class FinalConnectionsRepository : RepositoryBaseClass<FinalConnections>
    {

        public void DeleteByConnectionMetaID(int connectionMetaID, ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(FinalConnectionsRepositoryConstants.SP_DeleteByConnectionMetaID);
                database.AddInParameter(cmd, FinalConnectionsRepositoryConstants.ConnectionsMetaID, DbType.Int32, connectionMetaID);


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

        public override void Delete(FinalConnections entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override void Insert(FinalConnections entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(FinalConnectionsRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, FinalConnectionsRepositoryConstants.ConnectionsMetaID, DbType.Int32, entity.ConnectionMetaID);
                database.AddInParameter(cmd, FinalConnectionsRepositoryConstants.Year, DbType.Int32, entity.Year);


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

        public override void Update(FinalConnections entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override List<FinalConnections> FindAll(Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public List<FinalConnections> FindByConnectionMetaID(int connectionMetaID, Common.ActionState actionState)
        {
            List<FinalConnections> finalConnectionsList;
            FinalConnections finalConnectionsEntity;
            DbCommand cmd;

            finalConnectionsList = new List<FinalConnections>();
            finalConnectionsEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(FinalConnectionsRepositoryConstants.SP_FindBYConnectionMetaID);
                database.AddInParameter(cmd, FinalConnectionsRepositoryConstants.ConnectionsMetaID, DbType.Int32, connectionMetaID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        finalConnectionsEntity = FinalConnectionsHelper(reader);
                        if (finalConnectionsEntity != null)
                        {
                            finalConnectionsList.Add(finalConnectionsEntity);
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
            return finalConnectionsList;
        }

        public override FinalConnections FindByID(int entityID, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(FinalConnections entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private FinalConnections FinalConnectionsHelper(SqlDataReader reader)
        {
            FinalConnections finalConnections = new FinalConnections();
            finalConnections.ConnectionMetaID = Convert.ToInt32(reader[FinalConnectionsConstants.ConnectionsMetaID]);
            finalConnections.ID = Convert.ToInt32(reader[FinalConnectionsConstants.ID]);
            finalConnections.Year = Convert.ToInt32(reader[FinalConnectionsConstants.Year]);
            return finalConnections;
        }
    }
}
