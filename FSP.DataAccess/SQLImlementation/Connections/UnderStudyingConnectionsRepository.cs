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
   public class UnderStudyingConnectionsRepository : RepositoryBaseClass<UnderStudyingConnections>
    {
       public void DeleteByConnectionMetaID(int connectionMetaID, ActionState actionState)
       {
           int spResult;
           DbCommand cmd;

           try
           {
               cmd = database.GetStoredProcCommand(UnderStudyingConnectionsRepositoryConstants.SP_DeleteByConnectionMetaID);
               database.AddInParameter(cmd, UnderStudyingConnectionsRepositoryConstants.ConnectionsMetaID, DbType.Int32, connectionMetaID);


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

       public override void Delete(UnderStudyingConnections entity, Common.ActionState actionState)
       {
           throw new NotImplementedException();
       }

       public override void Insert(UnderStudyingConnections entity, Common.ActionState actionState)
       {
           int spResult;
           DbCommand cmd;

           try
           {
               cmd = database.GetStoredProcCommand(UnderStudyingConnectionsRepositoryConstants.SP_Insert);
               database.AddInParameter(cmd, UnderStudyingConnectionsRepositoryConstants.ConnectionsMetaID, DbType.Int32, entity.ConnectionMetaID);
               database.AddInParameter(cmd, UnderStudyingConnectionsRepositoryConstants.Year, DbType.Int32, entity.Year);


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

       public override void Update(UnderStudyingConnections entity, Common.ActionState actionState)
       {
           throw new NotImplementedException();
       }

       public override List<UnderStudyingConnections> FindAll(Common.ActionState actionState)
       {
           throw new NotImplementedException();
       }


       public List<UnderStudyingConnections> FindByConnectionMetaID(int connectionMetaID, Common.ActionState actionState)
       {
           List<UnderStudyingConnections> underStudyingConnectionsList;
           UnderStudyingConnections underStudyingConnectionsEntity;
           DbCommand cmd;

           underStudyingConnectionsList = new List<UnderStudyingConnections>();
           underStudyingConnectionsEntity = null;

           try
           {
               cmd = database.GetStoredProcCommand(UnderStudyingConnectionsRepositoryConstants.SP_FindBYConnectionMetaID);
               database.AddInParameter(cmd, UnderStudyingConnectionsRepositoryConstants.ConnectionsMetaID, DbType.Int32, connectionMetaID);
               using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
               {
                   while (reader.Read())
                   {
                       underStudyingConnectionsEntity = UnderStudyingConnectionsHelper(reader);
                       if (underStudyingConnectionsEntity != null)
                       {
                           underStudyingConnectionsList.Add(underStudyingConnectionsEntity);
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
           return underStudyingConnectionsList;
       }

       public override UnderStudyingConnections FindByID(int entityID, Common.ActionState actionState)
       {
           throw new NotImplementedException();
       }

       public override bool IsExist(UnderStudyingConnections entity, Common.ActionState actionState)
       {
           throw new NotImplementedException();
       }

       private UnderStudyingConnections UnderStudyingConnectionsHelper(SqlDataReader reader)
       {
           UnderStudyingConnections underStudyingConnections = new UnderStudyingConnections();
           underStudyingConnections.ConnectionMetaID = Convert.ToInt32(reader[UnderStudyingConnectionsConstants.ConnectionsMetaID]);
           underStudyingConnections.ID = Convert.ToInt32(reader[UnderStudyingConnectionsConstants.ID]);
           underStudyingConnections.Year = Convert.ToInt32(reader[UnderStudyingConnectionsConstants.Year]);
           return underStudyingConnections;
       }
    }
}
