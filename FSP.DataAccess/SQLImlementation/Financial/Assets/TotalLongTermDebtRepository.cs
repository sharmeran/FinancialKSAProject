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
    public class TotalLongTermDebtRepository : RepositoryBaseClass<TotalLongTermDebt>
    {
        public override void Delete(TotalLongTermDebt entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(TotalLongTermDebtRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(TotalLongTermDebt entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(TotalLongTermDebtRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.LongTermDebt, DbType.Decimal, entity.LongTermDebt);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.SaudiIndustrialDevelopmentFund, DbType.Decimal, entity.SaudiIndustrialDevelopmentFund);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.PublicInvestmentFund, DbType.Decimal, entity.PublicInvestmentFund);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.Percentageofownershipofgovernment, DbType.Decimal, entity.Percentageofownershipofgovernment);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.Ownershipofcompany, DbType.Decimal, entity.Ownershipofcompany);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.DrawnuptodateFullAmount, DbType.Decimal, entity.DrawnuptodateFullAmount);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.PercentageofDrawnofgovernment, DbType.Decimal, entity.PercentageofDrawnofgovernment);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.DrawnuptodateExecludeGveronemnt, DbType.Decimal, entity.DrawnuptodateExecludeGveronemnt);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.ConventionalFinance, DbType.Decimal, entity.ConventionalFinance);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.Drawnuptodate, DbType.Decimal, entity.Drawnuptodate);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.GrossLongTermDebt, DbType.Decimal, entity.GrossLongTermDebt);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.LongTermIslamicFinancIng, DbType.Decimal, entity.LongTermIslamicFinancIng);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.LongTermDebtNonIslamic, DbType.Decimal, entity.LongTermDebtNonIslamic);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.CapitalLease, DbType.Decimal, entity.CapitalLease);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.CapitalLeaseNonIslamic, DbType.Decimal, entity.CapitalLeaseNonIslamic);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.GovernmentSukuk, DbType.Decimal, entity.GovernmentSukuk);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.GovernmentBondsNonIslamic, DbType.Decimal, entity.GovernmentBondsNonIslamic);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.CorporateSukuk, DbType.Decimal, entity.CorporateSukuk);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.CorporateBondsNonIslamic, DbType.Decimal, entity.CorporateBondsNonIslamic);

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

        public override void Update(TotalLongTermDebt entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(TotalLongTermDebtRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.LongTermDebt, DbType.Decimal, entity.LongTermDebt);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.SaudiIndustrialDevelopmentFund, DbType.Decimal, entity.SaudiIndustrialDevelopmentFund);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.PublicInvestmentFund, DbType.Decimal, entity.PublicInvestmentFund);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.Percentageofownershipofgovernment, DbType.Decimal, entity.Percentageofownershipofgovernment);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.Ownershipofcompany, DbType.Decimal, entity.Ownershipofcompany);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.DrawnuptodateFullAmount, DbType.Decimal, entity.DrawnuptodateFullAmount);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.PercentageofDrawnofgovernment, DbType.Decimal, entity.PercentageofDrawnofgovernment);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.DrawnuptodateExecludeGveronemnt, DbType.Decimal, entity.DrawnuptodateExecludeGveronemnt);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.ConventionalFinance, DbType.Decimal, entity.ConventionalFinance);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.Drawnuptodate, DbType.Decimal, entity.Drawnuptodate);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.GrossLongTermDebt, DbType.Decimal, entity.GrossLongTermDebt);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.LongTermIslamicFinancIng, DbType.Decimal, entity.LongTermIslamicFinancIng);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.LongTermDebtNonIslamic, DbType.Decimal, entity.LongTermDebtNonIslamic);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.CapitalLease, DbType.Decimal, entity.CapitalLease);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.CapitalLeaseNonIslamic, DbType.Decimal, entity.CapitalLeaseNonIslamic);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.GovernmentSukuk, DbType.Decimal, entity.GovernmentSukuk);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.GovernmentBondsNonIslamic, DbType.Decimal, entity.GovernmentBondsNonIslamic);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.CorporateSukuk, DbType.Decimal, entity.CorporateSukuk);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.CorporateBondsNonIslamic, DbType.Decimal, entity.CorporateBondsNonIslamic);

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

        public List<TotalLongTermDebt> FindByAssetsID(int assetsID, Common.ActionState actionState)
        {
            List<TotalLongTermDebt> list;
            TotalLongTermDebt entity;
            DbCommand cmd;

            list = new List<TotalLongTermDebt>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(TotalLongTermDebtRepositoryConstants.SP_FindBYAssetsID);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.AssetsID, DbType.Int32, assetsID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = TotalLongTermDebtHelper(reader);
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

        public override List<TotalLongTermDebt> FindAll(Common.ActionState actionState)
        {
            List<TotalLongTermDebt> list;
            TotalLongTermDebt entity;
            DbCommand cmd;

            list = new List<TotalLongTermDebt>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(TotalLongTermDebtRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = TotalLongTermDebtHelper(reader);
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

        public override TotalLongTermDebt FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            TotalLongTermDebt entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(TotalLongTermDebtRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, TotalLongTermDebtRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = TotalLongTermDebtHelper(reader);
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

        public override bool IsExist(TotalLongTermDebt entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private TotalLongTermDebt TotalLongTermDebtHelper(SqlDataReader reader)
        {
            TotalLongTermDebt entity = new TotalLongTermDebt();
            entity.ID = Convert.ToInt32(reader[TotalLongTermDebtConstants.ID]);
            entity.AssetsID = Convert.ToInt32(reader[TotalLongTermDebtConstants.AssetsID]);
            AssetRepository assetRepository = new AssetRepository();
            entity.Asset = assetRepository.FindByID(Convert.ToInt32(reader[TotalLongTermDebtConstants.AssetsID]), new Common.ActionState());
            entity.LongTermDebt = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.LongTermDebt]);
            entity.SaudiIndustrialDevelopmentFund = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.SaudiIndustrialDevelopmentFund]);
            entity.PublicInvestmentFund = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.PublicInvestmentFund]);
            entity.Percentageofownershipofgovernment = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.Percentageofownershipofgovernment]);
            entity.Ownershipofcompany = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.Ownershipofcompany]);
            entity.DrawnuptodateFullAmount = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.DrawnuptodateFullAmount]);
            entity.PercentageofDrawnofgovernment = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.PercentageofDrawnofgovernment]);
            entity.DrawnuptodateExecludeGveronemnt = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.DrawnuptodateExecludeGveronemnt]);
            entity.ConventionalFinance = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.ConventionalFinance]);
            entity.Drawnuptodate = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.Drawnuptodate]);
            entity.GrossLongTermDebt = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.GrossLongTermDebt]);
            entity.LongTermIslamicFinancIng = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.LongTermIslamicFinancIng]);
            entity.LongTermDebtNonIslamic = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.LongTermDebtNonIslamic]);
            entity.CapitalLease = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.CapitalLease]);
            entity.CapitalLeaseNonIslamic = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.CapitalLeaseNonIslamic]);
            entity.GovernmentSukuk = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.GovernmentSukuk]);
            entity.GovernmentBondsNonIslamic = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.GovernmentBondsNonIslamic]);
            entity.CorporateSukuk = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.CorporateSukuk]);
            entity.CorporateBondsNonIslamic = (float)Convert.ToDouble(reader[TotalLongTermDebtConstants.CorporateBondsNonIslamic]);
            return entity;
        }
    }
}
