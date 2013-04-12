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
    public class LiabilitiesShareholdersEquityRepository : RepositoryBaseClass<LiabilitiesShareholdersEquity>
    {
        public override void Delete(LiabilitiesShareholdersEquity entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(LiabilitiesShareholdersEquityRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(LiabilitiesShareholdersEquity entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(LiabilitiesShareholdersEquityRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.TotalShortTermDebt, DbType.Decimal, entity.TotalShortTermDebt);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.ShortTermIslamicFinance, DbType.Decimal, entity.ShortTermIslamicFinance);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.SaudiIndustrialDevelopmentFund, DbType.Decimal, entity.SaudiIndustrialDevelopmentFund);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.ShortTermNonIslamicFinance, DbType.Decimal, entity.ShortTermNonIslamicFinance);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.PublicInvestmentFund, DbType.Decimal, entity.PublicInvestmentFund);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.Percentageofownershipofgovernment, DbType.Decimal, entity.Percentageofownershipofgovernment);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.OwnershipofcompanyExecludeGovernment, DbType.Decimal, entity.OwnershipofcompanyExecludeGovernment);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.DrawnuptodateFullAmount, DbType.Decimal, entity.DrawnuptodateFullAmount);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.PercentageofDrawnofgovernment, DbType.Decimal, entity.PercentageofDrawnofgovernment);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.DrawnuptodateExecludeGovrnemnt, DbType.Decimal, entity.DrawnuptodateExecludeGovrnemnt);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.ConventionalFinance, DbType.Decimal, entity.ConventionalFinance);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.CurrentPortionofLongTermDebt, DbType.Decimal, entity.CurrentPortionofLongTermDebt);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.CurrentPortionofLongTermDebtNonIslamic, DbType.Decimal, entity.CurrentPortionofLongTermDebtNonIslamic);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.CurrentPortionofLongTermLease, DbType.Decimal, entity.CurrentPortionofLongTermLease);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.CurrentPortionofLongTermLeaseNonIslamic, DbType.Decimal, entity.CurrentPortionofLongTermLeaseNonIslamic);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.DueToOtherCommercialParties, DbType.Decimal, entity.DueToOtherCommercialParties);

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

        public override void Update(LiabilitiesShareholdersEquity entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(LiabilitiesShareholdersEquityRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.TotalShortTermDebt, DbType.Decimal, entity.TotalShortTermDebt);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.ShortTermIslamicFinance, DbType.Decimal, entity.ShortTermIslamicFinance);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.SaudiIndustrialDevelopmentFund, DbType.Decimal, entity.SaudiIndustrialDevelopmentFund);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.ShortTermNonIslamicFinance, DbType.Decimal, entity.ShortTermNonIslamicFinance);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.PublicInvestmentFund, DbType.Decimal, entity.PublicInvestmentFund);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.Percentageofownershipofgovernment, DbType.Decimal, entity.Percentageofownershipofgovernment);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.OwnershipofcompanyExecludeGovernment, DbType.Decimal, entity.OwnershipofcompanyExecludeGovernment);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.DrawnuptodateFullAmount, DbType.Decimal, entity.DrawnuptodateFullAmount);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.PercentageofDrawnofgovernment, DbType.Decimal, entity.PercentageofDrawnofgovernment);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.DrawnuptodateExecludeGovrnemnt, DbType.Decimal, entity.DrawnuptodateExecludeGovrnemnt);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.ConventionalFinance, DbType.Decimal, entity.ConventionalFinance);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.CurrentPortionofLongTermDebt, DbType.Decimal, entity.CurrentPortionofLongTermDebt);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.CurrentPortionofLongTermDebtNonIslamic, DbType.Decimal, entity.CurrentPortionofLongTermDebtNonIslamic);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.CurrentPortionofLongTermLease, DbType.Decimal, entity.CurrentPortionofLongTermLease);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.CurrentPortionofLongTermLeaseNonIslamic, DbType.Decimal, entity.CurrentPortionofLongTermLeaseNonIslamic);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.DueToOtherCommercialParties, DbType.Decimal, entity.DueToOtherCommercialParties);

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

        public List<LiabilitiesShareholdersEquity> FindByAssetsID(int assetsID, Common.ActionState actionState)
        {
            List<LiabilitiesShareholdersEquity> list;
            LiabilitiesShareholdersEquity entity;
            DbCommand cmd;

            list = new List<LiabilitiesShareholdersEquity>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(LiabilitiesShareholdersEquityRepositoryConstants.SP_FindBYAssetsID);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.AssetsID, DbType.Int32, assetsID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = LiabilitiesShareholdersEquityHelper(reader);
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

        public override List<LiabilitiesShareholdersEquity> FindAll(Common.ActionState actionState)
        {
            List<LiabilitiesShareholdersEquity> list;
            LiabilitiesShareholdersEquity entity;
            DbCommand cmd;

            list = new List<LiabilitiesShareholdersEquity>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(LiabilitiesShareholdersEquityRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = LiabilitiesShareholdersEquityHelper(reader);
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

        public override LiabilitiesShareholdersEquity FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            LiabilitiesShareholdersEquity entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(LiabilitiesShareholdersEquityRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, LiabilitiesShareholdersEquityRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = LiabilitiesShareholdersEquityHelper(reader);
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

        public override bool IsExist(LiabilitiesShareholdersEquity entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private LiabilitiesShareholdersEquity LiabilitiesShareholdersEquityHelper(SqlDataReader reader)
        {
            LiabilitiesShareholdersEquity entity = new LiabilitiesShareholdersEquity();
            entity.ID = Convert.ToInt32(reader[LiabilitiesShareholdersEquityConstants.ID]);
            entity.AssetsID = Convert.ToInt32(reader[LiabilitiesShareholdersEquityConstants.AssetsID]);
            AssetRepository assetRepository = new AssetRepository();
            entity.Asset = assetRepository.FindByID(Convert.ToInt32(reader[LiabilitiesShareholdersEquityConstants.AssetsID]), new Common.ActionState());
            entity.TotalShortTermDebt = (float)Convert.ToDouble(reader[LiabilitiesShareholdersEquityConstants.TotalShortTermDebt]);
            entity.ShortTermIslamicFinance = (float)Convert.ToDouble(reader[LiabilitiesShareholdersEquityConstants.ShortTermIslamicFinance]);
            entity.SaudiIndustrialDevelopmentFund = (float)Convert.ToDouble(reader[LiabilitiesShareholdersEquityConstants.SaudiIndustrialDevelopmentFund]);
            entity.ShortTermNonIslamicFinance = (float)Convert.ToDouble(reader[LiabilitiesShareholdersEquityConstants.ShortTermNonIslamicFinance]);
            entity.PublicInvestmentFund = (float)Convert.ToDouble(reader[LiabilitiesShareholdersEquityConstants.PublicInvestmentFund]);
            entity.Percentageofownershipofgovernment = (float)Convert.ToDouble(reader[LiabilitiesShareholdersEquityConstants.Percentageofownershipofgovernment]);
            entity.OwnershipofcompanyExecludeGovernment = (float)Convert.ToDouble(reader[LiabilitiesShareholdersEquityConstants.OwnershipofcompanyExecludeGovernment]);
            entity.DrawnuptodateFullAmount = (float)Convert.ToDouble(reader[LiabilitiesShareholdersEquityConstants.DrawnuptodateFullAmount]);
            entity.PercentageofDrawnofgovernment = (float)Convert.ToDouble(reader[LiabilitiesShareholdersEquityConstants.PercentageofDrawnofgovernment]);
            entity.DrawnuptodateExecludeGovrnemnt = (float)Convert.ToDouble(reader[LiabilitiesShareholdersEquityConstants.DrawnuptodateExecludeGovrnemnt]);
            entity.ConventionalFinance = (float)Convert.ToDouble(reader[LiabilitiesShareholdersEquityConstants.ConventionalFinance]);
            entity.CurrentPortionofLongTermDebt = (float)Convert.ToDouble(reader[LiabilitiesShareholdersEquityConstants.CurrentPortionofLongTermDebt]);
            entity.CurrentPortionofLongTermDebtNonIslamic = (float)Convert.ToDouble(reader[LiabilitiesShareholdersEquityConstants.CurrentPortionofLongTermDebtNonIslamic]);
            entity.CurrentPortionofLongTermLease = (float)Convert.ToDouble(reader[LiabilitiesShareholdersEquityConstants.CurrentPortionofLongTermLease]);
            entity.CurrentPortionofLongTermLeaseNonIslamic = (float)Convert.ToDouble(reader[LiabilitiesShareholdersEquityConstants.CurrentPortionofLongTermLeaseNonIslamic]);
            entity.DueToOtherCommercialParties = (float)Convert.ToDouble(reader[LiabilitiesShareholdersEquityConstants.DueToOtherCommercialParties]);
            return entity;
        }
    }
}
