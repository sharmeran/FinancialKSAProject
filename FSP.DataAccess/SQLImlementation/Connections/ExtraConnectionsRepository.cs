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
    public class ExtraConnectionsRepository : RepositoryBaseClass<ExtraConnections>
    {

        public void DeleteByConnectionMetaID(int connectionMetaID, ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(ExtraConnectionsRepositoryConstants.SP_DeleteByConnectionMetaID);
                database.AddInParameter(cmd, ExtraConnectionsRepositoryConstants.ConnectionsMetaID, DbType.Int32, connectionMetaID);


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

        public override void Delete(ExtraConnections entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override void Insert(ExtraConnections entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(ExtraConnectionsRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, ExtraConnectionsRepositoryConstants.ConnectionsMetaID, DbType.Int32, entity.ConnectionMetaID);
                database.AddInParameter(cmd, ExtraConnectionsRepositoryConstants.Year, DbType.Int32, entity.Year);


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

        public override void Update(ExtraConnections entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override List<ExtraConnections> FindAll(Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }


        public List<ExtraConnections> FindByConnectionMetaID(int connectionMetaID, Common.ActionState actionState)
        {
            List<ExtraConnections> extraConnectionsList;
            ExtraConnections extraConnectionsEntity;
            DbCommand cmd;

            extraConnectionsList = new List<ExtraConnections>();
            extraConnectionsEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(ExtraConnectionsRepositoryConstants.SP_FindBYConnectionMetaID);
                database.AddInParameter(cmd, ExtraConnectionsRepositoryConstants.ConnectionsMetaID, DbType.Int32, connectionMetaID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        extraConnectionsEntity = ExtraConnectionsHelper(reader);
                        if (extraConnectionsEntity != null)
                        {
                            extraConnectionsList.Add(extraConnectionsEntity);
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
            return extraConnectionsList;
        }

        public override ExtraConnections FindByID(int entityID, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(ExtraConnections entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private ExtraConnections ExtraConnectionsHelper(SqlDataReader reader)
        {
            ExtraConnections extraConnections = new ExtraConnections();
            extraConnections.ConnectionMetaID = Convert.ToInt32(reader[ExtraConnectionsConstants.ConnectionsMetaID]);
            extraConnections.ID = Convert.ToInt32(reader[ExtraConnectionsConstants.ID]);
            extraConnections.Year = Convert.ToInt32(reader[ExtraConnectionsConstants.Year]);
            return extraConnections;
        }
    }
}
