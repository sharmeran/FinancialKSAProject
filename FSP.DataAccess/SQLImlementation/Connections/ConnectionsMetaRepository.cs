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
   public class ConnectionsMetaRepository : RepositoryBaseClass<ConnectionsMeta>
    {

       public void DeleteByZakatMainID(int zakatMainID, ActionState actionState)
       {
           int spResult;
           DbCommand cmd;

           try
           {
               cmd = database.GetStoredProcCommand(ConnectionsMetaRepositoryConstants.SP_DeleteByZakatMainID);
               database.AddInParameter(cmd, ConnectionsMetaRepositoryConstants.ZakatMainID, DbType.Int32, zakatMainID);


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

       public override void Delete(ConnectionsMeta entity, Common.ActionState actionState)
       {
           throw new NotImplementedException();
       }

       public override void Insert(ConnectionsMeta entity, Common.ActionState actionState)
       {
           int spResult;
           DbCommand cmd;

           try
           {
               cmd = database.GetStoredProcCommand(ConnectionsMetaRepositoryConstants.SP_Insert);
               database.AddInParameter(cmd, ConnectionsMetaRepositoryConstants.ZakatMainID, DbType.Int32, entity.ZakatMainID);
               database.AddInParameter(cmd, ConnectionsMetaRepositoryConstants.AppreciationConnectionNumber, DbType.Int32, entity.AppreciationConnectionNumber);
               database.AddInParameter(cmd, ConnectionsMetaRepositoryConstants.ExtraConnectionNumber, DbType.Int32, entity.ExtraConnectionNumber);
               database.AddInParameter(cmd, ConnectionsMetaRepositoryConstants.FinalConnectionNumber, DbType.Int32, entity.FinalConnectionNumber);
               database.AddInParameter(cmd, ConnectionsMetaRepositoryConstants.InitialConnectionNumber, DbType.Int32, entity.InitialConnectionNumber);
               database.AddInParameter(cmd, ConnectionsMetaRepositoryConstants.RestrictedConnesctionNumber, DbType.Int32, entity.RestrictedConnesctionNumber);
               database.AddInParameter(cmd, ConnectionsMetaRepositoryConstants.UnderStudyingNumber, DbType.Int32, entity.UnderStudyingNumber);
               database.AddInParameter(cmd, ConnectionsMetaRepositoryConstants.UnRestrictedConnectionNumber, DbType.Int32, entity.UnRestrictedConnectionNumber);


               spResult = Convert.ToInt32(database.ExecuteScalar(cmd));
               if (spResult > 0)
               {
                   entity.ID = spResult;
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

       public override void Update(ConnectionsMeta entity, Common.ActionState actionState)
       {
           throw new NotImplementedException();
       }

       public override List<ConnectionsMeta> FindAll(Common.ActionState actionState)
       {
           throw new NotImplementedException();
       }

       public List<ConnectionsMeta> FindByZakatMainID(int zakatMainID, Common.ActionState actionState)
       {
           List<ConnectionsMeta> connectionsMetaList;
           ConnectionsMeta connectionsMeta;
           DbCommand cmd;

           connectionsMetaList = new List<ConnectionsMeta>();
           connectionsMeta = null;

           try
           {
               cmd = database.GetStoredProcCommand(ConnectionsMetaRepositoryConstants.SP_FindBYZakatMainID);
               database.AddInParameter(cmd, ConnectionsMetaRepositoryConstants.ZakatMainID, DbType.Int32, zakatMainID);
               using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
               {
                   while (reader.Read())
                   {
                       connectionsMeta = ConnectionsMetaHelper(reader);
                       if (connectionsMeta != null)
                       {
                           connectionsMetaList.Add(connectionsMeta);
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
           return connectionsMetaList;
       }


       public override ConnectionsMeta FindByID(int entityID, Common.ActionState actionState)
       {
           throw new NotImplementedException();
       }

       public override bool IsExist(ConnectionsMeta entity, Common.ActionState actionState)
       {
           throw new NotImplementedException();
       }

       private ConnectionsMeta ConnectionsMetaHelper(SqlDataReader reader)
       {
           ConnectionsMeta connectionsMeta = new ConnectionsMeta();
           connectionsMeta.ZakatMainID = Convert.ToInt32(reader[ConnectionsMetaConstants.ZakatMainID]);
           connectionsMeta.AppreciationConnectionNumber = Convert.ToInt32(reader[ConnectionsMetaConstants.AppreciationConnectionNumber]);
           AppreciationConnectionsRepository appreciationConnectionsRepository = new AppreciationConnectionsRepository();
           connectionsMeta.AppreciationConnectionsList = appreciationConnectionsRepository.FindByConnectionMetaID(connectionsMeta.ZakatMainID, new ActionState());
           connectionsMeta.ExtraConnectionNumber = Convert.ToInt32(reader[ConnectionsMetaConstants.ExtraConnectionNumber]);
           ExtraConnectionsRepository extraConnectionsRepository = new ExtraConnectionsRepository();
           connectionsMeta.ExtraConnectionsList = extraConnectionsRepository.FindByConnectionMetaID(connectionsMeta.ZakatMainID, new ActionState());
           connectionsMeta.FinalConnectionNumber = Convert.ToInt32(reader[ConnectionsMetaConstants.FinalConnectionNumber]);
           FinalConnectionsRepository finalConnectionsRepository = new FinalConnectionsRepository();
           connectionsMeta.FinalConnectionsList = finalConnectionsRepository.FindByConnectionMetaID(connectionsMeta.ZakatMainID, new ActionState());
           connectionsMeta.ID = Convert.ToInt32(reader[ConnectionsMetaConstants.ID]);
           connectionsMeta.InitialConnectionNumber = Convert.ToInt32(reader[ConnectionsMetaConstants.InitialConnectionNumber]);
           InitialConnectionsRepository initialConnectionsRepository = new InitialConnectionsRepository();
           connectionsMeta.InitialConnectionsList = initialConnectionsRepository.FindByConnectionMetaID(connectionsMeta.ZakatMainID, new ActionState());
           connectionsMeta.RestrictedConnesctionNumber = Convert.ToInt32(reader[ConnectionsMetaConstants.RestrictedConnesctionNumber]);
           RestrictedConnectionsRepository restrictedConnectionsRepository = new RestrictedConnectionsRepository();
           connectionsMeta.RestrictedConnectionsList = restrictedConnectionsRepository.FindByConnectionMetaID(connectionsMeta.ZakatMainID, new ActionState());
           connectionsMeta.UnderStudyingNumber = Convert.ToInt32(reader[ConnectionsMetaConstants.UnderStudyingNumber]);
           UnderStudyingConnectionsRepository underStudyingConnectionsRepository = new UnderStudyingConnectionsRepository();
           connectionsMeta.UnderStudyingConnectionsList = underStudyingConnectionsRepository.FindByConnectionMetaID(connectionsMeta.ZakatMainID, new ActionState());
           connectionsMeta.UnRestrictedConnectionNumber = Convert.ToInt32(reader[ConnectionsMetaConstants.UnRestrictedConnectionNumber]);
           UnRestrictedConnectionsRepository unRestrictedConnectionsRepository = new UnRestrictedConnectionsRepository();
           connectionsMeta.UnRestrictedConnectionsList = unRestrictedConnectionsRepository.FindByConnectionMetaID(connectionsMeta.ZakatMainID, new ActionState());
           return connectionsMeta;
       }
    }
}
