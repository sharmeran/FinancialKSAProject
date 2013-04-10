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
    public class CurrentReceivablesRepository : RepositoryBaseClass<CurrentReceivables>
    {
        public override void Delete(CurrentReceivables entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CurrentReceivablesRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, CurrentReceivablesRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(CurrentReceivables entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CurrentReceivablesRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, CurrentReceivablesRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, CurrentReceivablesRepositoryConstants.Inventories, DbType.Decimal, entity.Inventories);
                database.AddInParameter(cmd, CurrentReceivablesRepositoryConstants.AdvancedPaymentsToSuppliers, DbType.Decimal, entity.AdvancedPaymentsToSuppliers);
                database.AddInParameter(cmd, CurrentReceivablesRepositoryConstants.OtherCurrentAssets, DbType.Decimal, entity.OtherCurrentAssets);
                database.AddInParameter(cmd, CurrentReceivablesRepositoryConstants.OtherCurrentAssetsNonIslamic, DbType.Decimal, entity.OtherCurrentAssetsNonIslamic);

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

        public override void Update(CurrentReceivables entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CurrentReceivablesRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, CurrentReceivablesRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, CurrentReceivablesRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, CurrentReceivablesRepositoryConstants.Inventories, DbType.Decimal, entity.Inventories);
                database.AddInParameter(cmd, CurrentReceivablesRepositoryConstants.AdvancedPaymentsToSuppliers, DbType.Decimal, entity.AdvancedPaymentsToSuppliers);
                database.AddInParameter(cmd, CurrentReceivablesRepositoryConstants.OtherCurrentAssets, DbType.Decimal, entity.OtherCurrentAssets);
                database.AddInParameter(cmd, CurrentReceivablesRepositoryConstants.OtherCurrentAssetsNonIslamic, DbType.Decimal, entity.OtherCurrentAssetsNonIslamic);

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

        public override List<CurrentReceivables> FindAll(Common.ActionState actionState)
        {
            List<CurrentReceivables> list;
            CurrentReceivables entity;
            DbCommand cmd;

            list = new List<CurrentReceivables>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(CurrentReceivablesRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = CurrentReceivablesHelper(reader);
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

        public override CurrentReceivables FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            CurrentReceivables entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(CurrentReceivablesRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, CurrentReceivablesRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = CurrentReceivablesHelper(reader);
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

        public override bool IsExist(CurrentReceivables entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private CurrentReceivables CurrentReceivablesHelper(SqlDataReader reader)
        {
            CurrentReceivables entity = new CurrentReceivables();
            entity.ID = Convert.ToInt32(reader[CurrentReceivablesConstants.ID]);
            entity.AssetsID = Convert.ToInt32(reader[CurrentReceivablesConstants.AssetsID]);
            AssetRepository assetRepository = new AssetRepository();
            entity.Asset = assetRepository.FindByID(Convert.ToInt32(reader[CurrentReceivablesConstants.AssetsID]), new Common.ActionState());
            entity.Inventories = (float)Convert.ToDouble(reader[CurrentReceivablesConstants.Inventories]);
            entity.AdvancedPaymentsToSuppliers = (float)Convert.ToDouble(reader[CurrentReceivablesConstants.AdvancedPaymentsToSuppliers]);
            entity.OtherCurrentAssets = (float)Convert.ToDouble(reader[CurrentReceivablesConstants.OtherCurrentAssets]);
            entity.OtherCurrentAssetsNonIslamic = (float)Convert.ToDouble(reader[CurrentReceivablesConstants.OtherCurrentAssetsNonIslamic]);
            return entity;
        }
    }
}
