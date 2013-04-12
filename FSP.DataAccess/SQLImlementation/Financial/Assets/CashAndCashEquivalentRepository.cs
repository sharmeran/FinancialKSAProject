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
    public class CashAndCashEquivalentRepository : RepositoryBaseClass<CashAndCashEquivalent>
    {
        public override void Delete(CashAndCashEquivalent entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CashAndCashEquivalentRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(CashAndCashEquivalent entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CashAndCashEquivalentRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.Cash, DbType.Decimal, entity.Cash);
                database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.DueAmountFromRelatedParties, DbType.Decimal, entity.DueAmountFromRelatedParties);
                database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.CashEquivalentConventional, DbType.Decimal, entity.CashEquivalentConventional);
                database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.CashCollateral, DbType.Decimal, entity.CashCollateral);
                if (entity.TimeDepositIslamic.Day == date.Day && entity.TimeDepositIslamic.Month == date.Month && entity.TimeDepositIslamic.Year == date.Year)
                {
                    database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.TimeDepositIslamic, DbType.Date, null);
                }
                else
                {
                    database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.TimeDepositIslamic, DbType.Date, entity.TimeDepositIslamic);
                }
                if (entity.TimeDepositConventional.Day == date.Day && entity.TimeDepositConventional.Month == date.Month && entity.TimeDepositConventional.Year == date.Year)
                {
                    database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.TimeDepositConventional, DbType.Date, null);
                }
                else
                {
                    database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.TimeDepositConventional, DbType.Date, entity.TimeDepositConventional);
                }


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

        public override void Update(CashAndCashEquivalent entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CashAndCashEquivalentRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.Cash, DbType.Decimal, entity.Cash);
                database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.DueAmountFromRelatedParties, DbType.Decimal, entity.DueAmountFromRelatedParties);
                database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.CashEquivalentConventional, DbType.Decimal, entity.CashEquivalentConventional);
                database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.CashCollateral, DbType.Decimal, entity.CashCollateral);
                if (entity.TimeDepositIslamic.Day == date.Day && entity.TimeDepositIslamic.Month == date.Month && entity.TimeDepositIslamic.Year == date.Year)
                {
                    database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.TimeDepositIslamic, DbType.Date, null);
                }
                else
                {
                    database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.TimeDepositIslamic, DbType.Date, entity.TimeDepositIslamic);
                }
                if (entity.TimeDepositConventional.Day == date.Day && entity.TimeDepositConventional.Month == date.Month && entity.TimeDepositConventional.Year == date.Year)
                {
                    database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.TimeDepositConventional, DbType.Date, null);
                }
                else
                {
                    database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.TimeDepositConventional, DbType.Date, entity.TimeDepositConventional);
                }

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

        public List<CashAndCashEquivalent> FindByAssetsID(int assetsID, Common.ActionState actionState)
        {
            List<CashAndCashEquivalent> list;
            CashAndCashEquivalent entity;
            DbCommand cmd;

            list = new List<CashAndCashEquivalent>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(CashAndCashEquivalentRepositoryConstants.SP_FindBYAssetsID);
                database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.AssetsID, DbType.Int32, assetsID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = CashAndCashEquivalentHelper(reader);
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

        public override List<CashAndCashEquivalent> FindAll(Common.ActionState actionState)
        {
            List<CashAndCashEquivalent> list;
            CashAndCashEquivalent entity;
            DbCommand cmd;

            list = new List<CashAndCashEquivalent>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(CashAndCashEquivalentRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = CashAndCashEquivalentHelper(reader);
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

        public override CashAndCashEquivalent FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            CashAndCashEquivalent entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(CashAndCashEquivalentRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, CashAndCashEquivalentRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = CashAndCashEquivalentHelper(reader);
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

        public override bool IsExist(CashAndCashEquivalent entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private CashAndCashEquivalent CashAndCashEquivalentHelper(SqlDataReader reader)
        {
            CashAndCashEquivalent entity = new CashAndCashEquivalent();
            entity.ID = Convert.ToInt32(reader[CashAndCashEquivalentConstants.ID]);
            entity.AssetsID = Convert.ToInt32(reader[CashAndCashEquivalentConstants.AssetsID]);
            AssetRepository assetRepository = new AssetRepository();
            entity.Asset = assetRepository.FindByID(Convert.ToInt32(reader[CashAndCashEquivalentConstants.AssetsID]), new Common.ActionState());
            entity.Cash = (float)Convert.ToDouble(reader[CashAndCashEquivalentConstants.Cash]);
            entity.DueAmountFromRelatedParties = (float)Convert.ToDouble(reader[CashAndCashEquivalentConstants.DueAmountFromRelatedParties]);
            entity.CashEquivalentConventional = (float)Convert.ToDouble(reader[CashAndCashEquivalentConstants.CashEquivalentConventional]);
            entity.CashCollateral = (float)Convert.ToDouble(reader[CashAndCashEquivalentConstants.CashCollateral]);
            if (reader[CashAndCashEquivalentConstants.TimeDepositIslamic] != DBNull.Value)
                entity.TimeDepositIslamic = Convert.ToDateTime(reader[CashAndCashEquivalentConstants.TimeDepositIslamic]);
            if (reader[CashAndCashEquivalentConstants.TimeDepositConventional] != DBNull.Value)
                entity.TimeDepositConventional = Convert.ToDateTime(reader[CashAndCashEquivalentConstants.TimeDepositConventional]);
            return entity;
        }
    }
}
