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
    public class TotalLongTermInvestmentRepository : RepositoryBaseClass<TotalLongTermInvestment>
    {
        public override void Delete(TotalLongTermInvestment entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(TotalLongTermInvestmentRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(TotalLongTermInvestment entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(TotalLongTermInvestmentRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.InvestmentInMutualFunds, DbType.Decimal, entity.InvestmentInMutualFunds);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.InvestmentInMutualFundsNonIslamic, DbType.Decimal, entity.InvestmentInMutualFundsNonIslamic);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.InvestmentInShares, DbType.Decimal, entity.InvestmentInShares);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.InvestmentInSharesNonIslamic, DbType.Decimal, entity.InvestmentInSharesNonIslamic);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.InvestmentInAssocaites, DbType.Decimal, entity.InvestmentInAssocaites);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.InvestmentInAssocaitesNonIslamic, DbType.Decimal, entity.InvestmentInAssocaitesNonIslamic);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.InvestmentInSubsidiaries, DbType.Decimal, entity.InvestmentInSubsidiaries);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.InvestmentInSubsidiariesNonIslamic, DbType.Decimal, entity.InvestmentInSubsidiariesNonIslamic);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.OtherLongTermInvestment, DbType.Decimal, entity.OtherLongTermInvestment);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.OtherLongTermInvestmentNonIslamic, DbType.Decimal, entity.OtherLongTermInvestmentNonIslamic);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.GovernmentBonds, DbType.Decimal, entity.GovernmentBonds);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.GovernmentBondsNonIslamic, DbType.Decimal, entity.GovernmentBondsNonIslamic);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.GovernmentSukuk, DbType.Decimal, entity.GovernmentSukuk);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.CorporateSukuk, DbType.Decimal, entity.CorporateSukuk);

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

        public override void Update(TotalLongTermInvestment entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(TotalLongTermInvestmentRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.InvestmentInMutualFunds, DbType.Decimal, entity.InvestmentInMutualFunds);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.InvestmentInMutualFundsNonIslamic, DbType.Decimal, entity.InvestmentInMutualFundsNonIslamic);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.InvestmentInShares, DbType.Decimal, entity.InvestmentInShares);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.InvestmentInSharesNonIslamic, DbType.Decimal, entity.InvestmentInSharesNonIslamic);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.InvestmentInAssocaites, DbType.Decimal, entity.InvestmentInAssocaites);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.InvestmentInAssocaitesNonIslamic, DbType.Decimal, entity.InvestmentInAssocaitesNonIslamic);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.InvestmentInSubsidiaries, DbType.Decimal, entity.InvestmentInSubsidiaries);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.InvestmentInSubsidiariesNonIslamic, DbType.Decimal, entity.InvestmentInSubsidiariesNonIslamic);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.OtherLongTermInvestment, DbType.Decimal, entity.OtherLongTermInvestment);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.OtherLongTermInvestmentNonIslamic, DbType.Decimal, entity.OtherLongTermInvestmentNonIslamic);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.GovernmentBonds, DbType.Decimal, entity.GovernmentBonds);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.GovernmentBondsNonIslamic, DbType.Decimal, entity.GovernmentBondsNonIslamic);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.GovernmentSukuk, DbType.Decimal, entity.GovernmentSukuk);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.CorporateSukuk, DbType.Decimal, entity.CorporateSukuk);

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
                cmd = database.GetStoredProcCommand(TotalLongTermInvestmentRepositoryConstants.SP_DeleteBYAssetsID);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.AssetsID, DbType.Int32, assetsID);


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

        public List<TotalLongTermInvestment> FindByAssetsID(int assetsID, Common.ActionState actionState)
        {
            List<TotalLongTermInvestment> list;
            TotalLongTermInvestment entity;
            DbCommand cmd;

            list = new List<TotalLongTermInvestment>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(TotalLongTermInvestmentRepositoryConstants.SP_FindBYAssetsID);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.AssetsID, DbType.Int32, assetsID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = TotalLongTermInvestmentHelper(reader);
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

        public override List<TotalLongTermInvestment> FindAll(Common.ActionState actionState)
        {
            List<TotalLongTermInvestment> list;
            TotalLongTermInvestment entity;
            DbCommand cmd;

            list = new List<TotalLongTermInvestment>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(TotalLongTermInvestmentRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = TotalLongTermInvestmentHelper(reader);
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

        public override TotalLongTermInvestment FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            TotalLongTermInvestment entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(TotalLongTermInvestmentRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, TotalLongTermInvestmentRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = TotalLongTermInvestmentHelper(reader);
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

        public override bool IsExist(TotalLongTermInvestment entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private TotalLongTermInvestment TotalLongTermInvestmentHelper(SqlDataReader reader)
        {
            TotalLongTermInvestment entity = new TotalLongTermInvestment();
            entity.ID = Convert.ToInt32(reader[TotalLongTermInvestmentConstants.ID]);
            entity.AssetsID = Convert.ToInt32(reader[TotalLongTermInvestmentConstants.AssetsID]);
            AssetRepository assetRepository = new AssetRepository();
            entity.Asset = assetRepository.FindByID(Convert.ToInt32(reader[TotalLongTermInvestmentConstants.AssetsID]), new Common.ActionState());
            entity.InvestmentInMutualFunds = (float)Convert.ToDouble(reader[TotalLongTermInvestmentConstants.InvestmentInMutualFunds]);
            entity.InvestmentInMutualFundsNonIslamic = (float)Convert.ToDouble(reader[TotalLongTermInvestmentConstants.InvestmentInMutualFundsNonIslamic]);
            entity.InvestmentInShares = (float)Convert.ToDouble(reader[TotalLongTermInvestmentConstants.InvestmentInShares]);
            entity.InvestmentInSharesNonIslamic = (float)Convert.ToDouble(reader[TotalLongTermInvestmentConstants.InvestmentInSharesNonIslamic]);
            entity.InvestmentInAssocaites = (float)Convert.ToDouble(reader[TotalLongTermInvestmentConstants.InvestmentInAssocaites]);
            entity.InvestmentInAssocaitesNonIslamic = (float)Convert.ToDouble(reader[TotalLongTermInvestmentConstants.InvestmentInAssocaitesNonIslamic]);
            entity.InvestmentInSubsidiaries = (float)Convert.ToDouble(reader[TotalLongTermInvestmentConstants.InvestmentInSubsidiaries]);
            entity.InvestmentInSubsidiariesNonIslamic = (float)Convert.ToDouble(reader[TotalLongTermInvestmentConstants.InvestmentInSubsidiariesNonIslamic]);
            entity.OtherLongTermInvestment = (float)Convert.ToDouble(reader[TotalLongTermInvestmentConstants.OtherLongTermInvestment]);
            entity.OtherLongTermInvestmentNonIslamic = (float)Convert.ToDouble(reader[TotalLongTermInvestmentConstants.OtherLongTermInvestmentNonIslamic]);
            entity.GovernmentBonds = (float)Convert.ToDouble(reader[TotalLongTermInvestmentConstants.GovernmentBonds]);
            entity.GovernmentBondsNonIslamic = (float)Convert.ToDouble(reader[TotalLongTermInvestmentConstants.GovernmentBondsNonIslamic]);
            entity.GovernmentSukuk = (float)Convert.ToDouble(reader[TotalLongTermInvestmentConstants.GovernmentSukuk]);
            entity.CorporateSukuk = (float)Convert.ToDouble(reader[TotalLongTermInvestmentConstants.CorporateSukuk]);
            return entity;
        }
    }
}
