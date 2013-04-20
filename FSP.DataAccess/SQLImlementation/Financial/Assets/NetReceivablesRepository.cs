using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial;
using FSP.Common.Entites.Financial;
using FSP.Common.Constants.Financial.Assets;
using FSP.Common.Entites.Financial.Assets;
using FSP.Common.Enums;
using FSP.Common;
using FSP.DataAccess.BaseClasses;
using FSP.DataAccess.Constants.Common;
using FSP.DataAccess.Constants.Financial;
using FSP.DataAccess.Constants.Financial.Assets;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FSP.DataAccess.SQLImlementation.Financial;
using FSP.DataAccess.SQLImlementation.Financial.Assets;

namespace FSP.DataAccess.SQLImlementation.Financial.Assets
{
    public class NetReceivablesRepository : RepositoryBaseClass<NetReceivables>
    {
        public override void Delete(NetReceivables entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(NetReceivablesRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, NetReceivablesRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(NetReceivables entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(NetReceivablesRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, NetReceivablesRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, NetReceivablesRepositoryConstants.AccountsReceivables, DbType.Decimal, entity.AccountsReceivables);
                database.AddInParameter(cmd, NetReceivablesRepositoryConstants.ProvisionForDoubtfulReceivables, DbType.Decimal, entity.ProvisionForDoubtfulReceivables);
                database.AddInParameter(cmd, NetReceivablesRepositoryConstants.OtherReceivables, DbType.Decimal, entity.OtherReceivables);

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

        public override void Update(NetReceivables entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(NetReceivablesRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, NetReceivablesRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, NetReceivablesRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, NetReceivablesRepositoryConstants.AccountsReceivables, DbType.Decimal, entity.AccountsReceivables);
                database.AddInParameter(cmd, NetReceivablesRepositoryConstants.ProvisionForDoubtfulReceivables, DbType.Decimal, entity.ProvisionForDoubtfulReceivables);
                database.AddInParameter(cmd, NetReceivablesRepositoryConstants.OtherReceivables, DbType.Decimal, entity.OtherReceivables);

                spResult = database.ExecuteNonQuery(cmd);
                if (spResult > 0)
                {
                    actionState.SetSuccess();
                }
                else
                {
                    actionState.SetFail(ActionStatusEnum.CannotUpdate, LocalizationConstants.Err_CannotUpdate);
                }

            }
            catch (Exception ex)
            {
                actionState.SetFail(ActionStatusEnum.CannotUpdate, ex.Message);
            }
            finally
            {
                cmd = null;
            }
        }

        public void DeleteByAssetsID(int assetsID, ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(NetReceivablesRepositoryConstants.SP_DeleteBYAssetsID);
                database.AddInParameter(cmd, NetReceivablesRepositoryConstants.AssetsID, DbType.Int32, assetsID);


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

        public List<NetReceivables> FindByAssetsID(int assetsID, Common.ActionState actionState)
        {
            List<NetReceivables> list;
            NetReceivables entity;
            DbCommand cmd;

            list = new List<NetReceivables>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(NetReceivablesRepositoryConstants.SP_FindBYAssetsID);
                database.AddInParameter(cmd, NetReceivablesRepositoryConstants.AssetsID, DbType.Int32, assetsID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = NetReceivablesHelper(reader);
                        if (entity != null)
                        {
                            list.Add(entity);
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
            return list;
        }

        public override List<NetReceivables> FindAll(Common.ActionState actionState)
        {
            List<NetReceivables> list;
            NetReceivables entity;
            DbCommand cmd;

            list = new List<NetReceivables>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(NetReceivablesRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = NetReceivablesHelper(reader);
                        if (entity != null)
                        {
                            list.Add(entity);
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
            return list;
        }

        public override NetReceivables FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            NetReceivables entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(NetReceivablesRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, NetReceivablesRepositoryConstants.ID, DbType.Int32, entityID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    if (!reader.HasRows)
                    {
                        actionState.SetFail(ActionStatusEnum.NotFound, LocalizationConstants.Err_CannotFound);
                    }
                    else
                    {
                        actionState.SetSuccess();
                        reader.Read();
                        entity = NetReceivablesHelper(reader);
                    }
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
            return entity;
        }

        public override bool IsExist(NetReceivables entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private NetReceivables NetReceivablesHelper(SqlDataReader reader)
        {
            NetReceivables entity = new NetReceivables();
            entity.ID = Convert.ToInt32(reader[NetReceivablesConstants.ID]);
            entity.AssetsID = Convert.ToInt32(reader[NetReceivablesConstants.AssetsID]);
            AssetRepository assetRepository = new AssetRepository();
            entity.Asset = assetRepository.FindByID(Convert.ToInt32(reader[NetReceivablesConstants.AssetsID]), new Common.ActionState());
            entity.AccountsReceivables = (float)Convert.ToDouble(reader[NetReceivablesConstants.AccountsReceivables]);
            entity.ProvisionForDoubtfulReceivables = (float)Convert.ToDouble(reader[NetReceivablesConstants.ProvisionForDoubtfulReceivables]);
            entity.OtherReceivables = (float)Convert.ToDouble(reader[NetReceivablesConstants.OtherReceivables]);
            return entity;
        }
    }
}
