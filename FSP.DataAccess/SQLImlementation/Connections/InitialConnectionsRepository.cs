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
   public class InitialConnectionsRepository : RepositoryBaseClass<InitialConnections>
    {

       public void DeleteByConnectionMetaID(int connectionMetaID, ActionState actionState)
       {
           int spResult;
           DbCommand cmd;

           try
           {
               cmd = database.GetStoredProcCommand(InitialConnectionsRepositoryConstants.SP_DeleteByConnectionMetaID);
               database.AddInParameter(cmd, InitialConnectionsRepositoryConstants.ConnectionsMetaID, DbType.Int32, connectionMetaID);


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

       public override void Delete(InitialConnections entity, Common.ActionState actionState)
       {
           throw new NotImplementedException();
       }

       public override void Insert(InitialConnections entity, Common.ActionState actionState)
       {
           int spResult;
           DbCommand cmd;

           try
           {
               cmd = database.GetStoredProcCommand(InitialConnectionsRepositoryConstants.SP_Insert);
               database.AddInParameter(cmd, InitialConnectionsRepositoryConstants.ConnectionsMetaID, DbType.Int32, entity.ConnectionMetaID);
               database.AddInParameter(cmd, InitialConnectionsRepositoryConstants.Year, DbType.Int32, entity.Year);


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

       public override void Update(InitialConnections entity, Common.ActionState actionState)
       {
           throw new NotImplementedException();
       }

       public override List<InitialConnections> FindAll(Common.ActionState actionState)
       {
           throw new NotImplementedException();
       }

       public List<InitialConnections> FindByConnectionMetaID(int connectionMetaID, Common.ActionState actionState)
       {
           List<InitialConnections> initialConnectionsList;
           InitialConnections initialConnectionsEntity;
           DbCommand cmd;

           initialConnectionsList = new List<InitialConnections>();
           initialConnectionsEntity = null;

           try
           {
               cmd = database.GetStoredProcCommand(InitialConnectionsRepositoryConstants.SP_FindBYConnectionMetaID);
               database.AddInParameter(cmd, InitialConnectionsRepositoryConstants.ConnectionsMetaID, DbType.Int32, connectionMetaID);
               using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
               {
                   while (reader.Read())
                   {
                       initialConnectionsEntity = InitialConnectionsHelper(reader);
                       if (initialConnectionsEntity != null)
                       {
                           initialConnectionsList.Add(initialConnectionsEntity);
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
           return initialConnectionsList;
       }

       public override InitialConnections FindByID(int entityID, Common.ActionState actionState)
       {
           throw new NotImplementedException();
       }

       public override bool IsExist(InitialConnections entity, Common.ActionState actionState)
       {
           throw new NotImplementedException();
       }

       private InitialConnections InitialConnectionsHelper(SqlDataReader reader)
       {
           InitialConnections initialConnections = new InitialConnections();
           initialConnections.ConnectionMetaID = Convert.ToInt32(reader[InitialConnectionsConstants.ConnectionsMetaID]);
           initialConnections.ID = Convert.ToInt32(reader[InitialConnectionsConstants.ID]);
           initialConnections.Year = Convert.ToInt32(reader[InitialConnectionsConstants.Year]);
           return initialConnections;
       }
    }
}
