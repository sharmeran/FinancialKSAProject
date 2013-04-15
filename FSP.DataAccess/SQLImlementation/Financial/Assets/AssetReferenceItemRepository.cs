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
    public class AssetReferenceItemRepository : RepositoryBaseClass<AssetReferenceItem>
    {
        public override void Delete(AssetReferenceItem entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(AssetReferenceItemRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(AssetReferenceItem entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(AssetReferenceItemRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.SharesOutstandIng, DbType.Decimal, entity.SharesOutstandIng);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.NumberofTreasuryShares, DbType.Decimal, entity.NumberofTreasuryShares);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.AmountofTreasuryShares, DbType.Decimal, entity.AmountofTreasuryShares);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.PensionObligations, DbType.Decimal, entity.PensionObligations);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.OperatIngLeases, DbType.Decimal, entity.OperatIngLeases);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.CapitalLeasesShortTerm, DbType.Decimal, entity.CapitalLeasesShortTerm);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.CapitalLeasesLongTerm, DbType.Decimal, entity.CapitalLeasesLongTerm);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.CapitalLeasesTotal, DbType.Decimal, entity.CapitalLeasesTotal);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.OptionsGrantedDurIngPeriod, DbType.Decimal, entity.OptionsGrantedDurIngPeriod);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.OptionsOutstandIngatPeriodEnd, DbType.Decimal, entity.OptionsOutstandIngatPeriodEnd);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.BookValueperShare, DbType.Decimal, entity.BookValueperShare);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.TotalDebttoTotalAssets, DbType.Decimal, entity.TotalDebttoTotalAssets);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.NetDebt, DbType.Decimal, entity.NetDebt);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.NetDebttoEquity, DbType.Decimal, entity.NetDebttoEquity);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.TangibleCommonEquityRatio, DbType.Decimal, entity.TangibleCommonEquityRatio);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.CurrentRatio, DbType.Decimal, entity.CurrentRatio);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.CashConversionCycle, DbType.Decimal, entity.CashConversionCycle);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.InventoryWorkInProgress, DbType.Decimal, entity.InventoryWorkInProgress);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.InventoryFinishedGoods, DbType.Decimal, entity.InventoryFinishedGoods);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.OtherInventory, DbType.Decimal, entity.OtherInventory);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.PureRetaInedEarnIngs, DbType.Decimal, entity.PureRetaInedEarnIngs);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.NumberofEmployees, DbType.Int32, entity.NumberofEmployees);


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

        public override void Update(AssetReferenceItem entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(AssetReferenceItemRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.SharesOutstandIng, DbType.Decimal, entity.SharesOutstandIng);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.NumberofTreasuryShares, DbType.Decimal, entity.NumberofTreasuryShares);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.AmountofTreasuryShares, DbType.Decimal, entity.AmountofTreasuryShares);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.PensionObligations, DbType.Decimal, entity.PensionObligations);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.OperatIngLeases, DbType.Decimal, entity.OperatIngLeases);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.CapitalLeasesShortTerm, DbType.Decimal, entity.CapitalLeasesShortTerm);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.CapitalLeasesLongTerm, DbType.Decimal, entity.CapitalLeasesLongTerm);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.CapitalLeasesTotal, DbType.Decimal, entity.CapitalLeasesTotal);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.OptionsGrantedDurIngPeriod, DbType.Decimal, entity.OptionsGrantedDurIngPeriod);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.OptionsOutstandIngatPeriodEnd, DbType.Decimal, entity.OptionsOutstandIngatPeriodEnd);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.BookValueperShare, DbType.Decimal, entity.BookValueperShare);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.TotalDebttoTotalAssets, DbType.Decimal, entity.TotalDebttoTotalAssets);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.NetDebt, DbType.Decimal, entity.NetDebt);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.NetDebttoEquity, DbType.Decimal, entity.NetDebttoEquity);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.TangibleCommonEquityRatio, DbType.Decimal, entity.TangibleCommonEquityRatio);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.CurrentRatio, DbType.Decimal, entity.CurrentRatio);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.CashConversionCycle, DbType.Decimal, entity.CashConversionCycle);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.InventoryWorkInProgress, DbType.Decimal, entity.InventoryWorkInProgress);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.InventoryFinishedGoods, DbType.Decimal, entity.InventoryFinishedGoods);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.OtherInventory, DbType.Decimal, entity.OtherInventory);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.PureRetaInedEarnIngs, DbType.Decimal, entity.PureRetaInedEarnIngs);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.NumberofEmployees, DbType.Int32, entity.NumberofEmployees);

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
                cmd = database.GetStoredProcCommand(AssetReferenceItemRepositoryConstants.SP_DeleteBYAssetsID);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.AssetsID, DbType.Int32, assetsID);


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

        public List<AssetReferenceItem> FindByAssetsID(int assetsID, Common.ActionState actionState)
        {
            List<AssetReferenceItem> list;
            AssetReferenceItem entity;
            DbCommand cmd;

            list = new List<AssetReferenceItem>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(AssetReferenceItemRepositoryConstants.SP_FindBYAssetsID);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.AssetsID, DbType.Int32, assetsID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = AssetReferenceItemHelper(reader);
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

        public override List<AssetReferenceItem> FindAll(Common.ActionState actionState)
        {
            List<AssetReferenceItem> list;
            AssetReferenceItem entity;
            DbCommand cmd;

            list = new List<AssetReferenceItem>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(AssetReferenceItemRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = AssetReferenceItemHelper(reader);
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

        public override AssetReferenceItem FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            AssetReferenceItem entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(AssetReferenceItemRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, AssetReferenceItemRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = AssetReferenceItemHelper(reader);
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

        public override bool IsExist(AssetReferenceItem entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private AssetReferenceItem AssetReferenceItemHelper(SqlDataReader reader)
        {
            AssetReferenceItem entity = new AssetReferenceItem();
            entity.ID = Convert.ToInt32(reader[AssetReferenceItemConstants.ID]);
            entity.AssetsID = Convert.ToInt32(reader[AssetReferenceItemConstants.AssetsID]);
            AssetRepository assetRepository = new AssetRepository();
            entity.Asset = assetRepository.FindByID(Convert.ToInt32(reader[AssetReferenceItemConstants.AssetsID]), new Common.ActionState());
            entity.SharesOutstandIng = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.SharesOutstandIng]);
            entity.NumberofTreasuryShares = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.NumberofTreasuryShares]);
            entity.AmountofTreasuryShares = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.AmountofTreasuryShares]);
            entity.PensionObligations = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.PensionObligations]);
            entity.OperatIngLeases = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.OperatIngLeases]);
            entity.CapitalLeasesShortTerm = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.CapitalLeasesShortTerm]);
            entity.CapitalLeasesLongTerm = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.CapitalLeasesLongTerm]);
            entity.CapitalLeasesTotal = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.CapitalLeasesTotal]);
            entity.OptionsGrantedDurIngPeriod = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.OptionsGrantedDurIngPeriod]);
            entity.OptionsOutstandIngatPeriodEnd = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.OptionsOutstandIngatPeriodEnd]);
            entity.BookValueperShare = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.BookValueperShare]);
            entity.TotalDebttoTotalAssets = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.TotalDebttoTotalAssets]);
            entity.NetDebt = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.NetDebt]);
            entity.NetDebttoEquity = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.NetDebttoEquity]);
            entity.TangibleCommonEquityRatio = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.TangibleCommonEquityRatio]);
            entity.CurrentRatio = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.CurrentRatio]);
            entity.CashConversionCycle = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.CashConversionCycle]);
            entity.InventoryWorkInProgress = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.InventoryWorkInProgress]);
            entity.InventoryFinishedGoods = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.InventoryFinishedGoods]);
            entity.OtherInventory = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.OtherInventory]);
            entity.PureRetaInedEarnIngs = (float)Convert.ToDouble(reader[AssetReferenceItemConstants.PureRetaInedEarnIngs]);
            entity.NumberofEmployees = Convert.ToInt32(reader[AssetReferenceItemConstants.NumberofEmployees]);
            return entity;
        }
    }
}
