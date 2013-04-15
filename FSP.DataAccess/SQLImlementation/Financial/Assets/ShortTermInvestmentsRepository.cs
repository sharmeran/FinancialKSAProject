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
    public class ShortTermInvestmentsRepository : RepositoryBaseClass<ShortTermInvestments>
    {
        public override void Delete(ShortTermInvestments entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(ShortTermInvestmentsRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, ShortTermInvestmentsRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(ShortTermInvestments entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(ShortTermInvestmentsRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, ShortTermInvestmentsRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, ShortTermInvestmentsRepositoryConstants.MoneyMarketFundIslamic, DbType.Decimal, entity.MoneyMarketFundIslamic);
                database.AddInParameter(cmd, ShortTermInvestmentsRepositoryConstants.MoneyMarketFundConventional, DbType.Decimal, entity.MoneyMarketFundConventional);
                database.AddInParameter(cmd, ShortTermInvestmentsRepositoryConstants.ConventionalBonds, DbType.Decimal, entity.ConventionalBonds);
                database.AddInParameter(cmd, ShortTermInvestmentsRepositoryConstants.Sukuk, DbType.Decimal, entity.Sukuk);

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

        public override void Update(ShortTermInvestments entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(ShortTermInvestmentsRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, ShortTermInvestmentsRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, ShortTermInvestmentsRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, ShortTermInvestmentsRepositoryConstants.MoneyMarketFundIslamic, DbType.Decimal, entity.MoneyMarketFundIslamic);
                database.AddInParameter(cmd, ShortTermInvestmentsRepositoryConstants.MoneyMarketFundConventional, DbType.Decimal, entity.MoneyMarketFundConventional);
                database.AddInParameter(cmd, ShortTermInvestmentsRepositoryConstants.ConventionalBonds, DbType.Decimal, entity.ConventionalBonds);
                database.AddInParameter(cmd, ShortTermInvestmentsRepositoryConstants.Sukuk, DbType.Decimal, entity.Sukuk);

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
                cmd = database.GetStoredProcCommand(ShortTermInvestmentsRepositoryConstants.SP_DeleteBYAssetsID);
                database.AddInParameter(cmd, ShortTermInvestmentsRepositoryConstants.AssetsID, DbType.Int32, assetsID);


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

        public List<ShortTermInvestments> FindByAssetsID(int assetsID, Common.ActionState actionState)
        {
            List<ShortTermInvestments> list;
            ShortTermInvestments entity;
            DbCommand cmd;

            list = new List<ShortTermInvestments>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(ShortTermInvestmentsRepositoryConstants.SP_FindBYAssetsID);
                database.AddInParameter(cmd, ShortTermInvestmentsRepositoryConstants.AssetsID, DbType.Int32, assetsID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = ShortTermInvestmentsHelper(reader);
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

        public override List<ShortTermInvestments> FindAll(Common.ActionState actionState)
        {
            List<ShortTermInvestments> list;
            ShortTermInvestments entity;
            DbCommand cmd;

            list = new List<ShortTermInvestments>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(ShortTermInvestmentsRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = ShortTermInvestmentsHelper(reader);
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

        public override ShortTermInvestments FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            ShortTermInvestments entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(ShortTermInvestmentsRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, ShortTermInvestmentsRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = ShortTermInvestmentsHelper(reader);
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

        public override bool IsExist(ShortTermInvestments entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private ShortTermInvestments ShortTermInvestmentsHelper(SqlDataReader reader)
        {
            ShortTermInvestments entity = new ShortTermInvestments();
            entity.ID = Convert.ToInt32(reader[ShortTermInvestmentsConstants.ID]);
            entity.AssetsID = Convert.ToInt32(reader[ShortTermInvestmentsConstants.AssetsID]);
            AssetRepository assetRepository = new AssetRepository();
            entity.Asset = assetRepository.FindByID(Convert.ToInt32(reader[ShortTermInvestmentsConstants.AssetsID]), new Common.ActionState());
            entity.MoneyMarketFundIslamic = (float)Convert.ToDouble(reader[ShortTermInvestmentsConstants.MoneyMarketFundIslamic]);
            entity.MoneyMarketFundConventional = (float)Convert.ToDouble(reader[ShortTermInvestmentsConstants.MoneyMarketFundConventional]);
            entity.ConventionalBonds = (float)Convert.ToDouble(reader[ShortTermInvestmentsConstants.ConventionalBonds]);
            entity.Sukuk = (float)Convert.ToDouble(reader[ShortTermInvestmentsConstants.Sukuk]);
            return entity;
        }
    }
}
