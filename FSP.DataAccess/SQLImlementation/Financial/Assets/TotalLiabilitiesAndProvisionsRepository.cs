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
    public class TotalLiabilitiesAndProvisionsRepository : RepositoryBaseClass<TotalLiabilitiesAndProvisions>
    {
        public override void Delete(TotalLiabilitiesAndProvisions entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(TotalLiabilitiesAndProvisionsRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(TotalLiabilitiesAndProvisions entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(TotalLiabilitiesAndProvisionsRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.TotalShareholdersEquity, DbType.Decimal, entity.TotalShareholdersEquity);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.MinorityInterest, DbType.Decimal, entity.MinorityInterest);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.PaidupCapital, DbType.Decimal, entity.PaidupCapital);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.SharePremium, DbType.Decimal, entity.SharePremium);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.LegalStatutoryReserve, DbType.Decimal, entity.LegalStatutoryReserve);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.GeneralVoluntaryReserve, DbType.Decimal, entity.GeneralVoluntaryReserve);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.CapitalReserve, DbType.Decimal, entity.CapitalReserve);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.ChgInFairValResvTranslationAdj, DbType.Decimal, entity.ChgInFairValResvTranslationAdj);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.Reserves, DbType.Decimal, entity.Reserves);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.DueToShareholdersAppropriate, DbType.Decimal, entity.DueToShareholdersAppropriate);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.RetaInedEarnIngsAccimulatedLosses, DbType.Decimal, entity.RetaInedEarnIngsAccimulatedLosses);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.NetProfitofTheYear, DbType.Decimal, entity.NetProfitofTheYear);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.TreasuryStock, DbType.Decimal, entity.TreasuryStock);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.TotalLiabilitiesAndEquity, DbType.Decimal, entity.TotalLiabilitiesAndEquity);

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

        public override void Update(TotalLiabilitiesAndProvisions entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(TotalLiabilitiesAndProvisionsRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.TotalShareholdersEquity, DbType.Decimal, entity.TotalShareholdersEquity);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.MinorityInterest, DbType.Decimal, entity.MinorityInterest);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.PaidupCapital, DbType.Decimal, entity.PaidupCapital);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.SharePremium, DbType.Decimal, entity.SharePremium);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.LegalStatutoryReserve, DbType.Decimal, entity.LegalStatutoryReserve);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.GeneralVoluntaryReserve, DbType.Decimal, entity.GeneralVoluntaryReserve);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.CapitalReserve, DbType.Decimal, entity.CapitalReserve);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.ChgInFairValResvTranslationAdj, DbType.Decimal, entity.ChgInFairValResvTranslationAdj);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.Reserves, DbType.Decimal, entity.Reserves);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.DueToShareholdersAppropriate, DbType.Decimal, entity.DueToShareholdersAppropriate);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.RetaInedEarnIngsAccimulatedLosses, DbType.Decimal, entity.RetaInedEarnIngsAccimulatedLosses);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.NetProfitofTheYear, DbType.Decimal, entity.NetProfitofTheYear);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.TreasuryStock, DbType.Decimal, entity.TreasuryStock);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.TotalLiabilitiesAndEquity, DbType.Decimal, entity.TotalLiabilitiesAndEquity);

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

        public override List<TotalLiabilitiesAndProvisions> FindAll(Common.ActionState actionState)
        {
            List<TotalLiabilitiesAndProvisions> list;
            TotalLiabilitiesAndProvisions entity;
            DbCommand cmd;

            list = new List<TotalLiabilitiesAndProvisions>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(TotalLiabilitiesAndProvisionsRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = TotalLiabilitiesAndProvisionsHelper(reader);
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

        public override TotalLiabilitiesAndProvisions FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            TotalLiabilitiesAndProvisions entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(TotalLiabilitiesAndProvisionsRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, TotalLiabilitiesAndProvisionsRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = TotalLiabilitiesAndProvisionsHelper(reader);
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

        public override bool IsExist(TotalLiabilitiesAndProvisions entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private TotalLiabilitiesAndProvisions TotalLiabilitiesAndProvisionsHelper(SqlDataReader reader)
        {
            TotalLiabilitiesAndProvisions entity = new TotalLiabilitiesAndProvisions();
            entity.ID = Convert.ToInt32(reader[TotalLiabilitiesAndProvisionsConstants.ID]);
            entity.AssetsID = Convert.ToInt32(reader[TotalLiabilitiesAndProvisionsConstants.AssetsID]);
            AssetRepository assetRepository = new AssetRepository();
            entity.Asset = assetRepository.FindByID(Convert.ToInt32(reader[TotalLiabilitiesAndProvisionsConstants.AssetsID]), new Common.ActionState());
            entity.TotalShareholdersEquity = (float)Convert.ToDouble(reader[TotalLiabilitiesAndProvisionsConstants.TotalShareholdersEquity]);
            entity.MinorityInterest = (float)Convert.ToDouble(reader[TotalLiabilitiesAndProvisionsConstants.MinorityInterest]);
            entity.PaidupCapital = (float)Convert.ToDouble(reader[TotalLiabilitiesAndProvisionsConstants.PaidupCapital]);
            entity.SharePremium = (float)Convert.ToDouble(reader[TotalLiabilitiesAndProvisionsConstants.SharePremium]);
            entity.LegalStatutoryReserve = (float)Convert.ToDouble(reader[TotalLiabilitiesAndProvisionsConstants.LegalStatutoryReserve]);
            entity.GeneralVoluntaryReserve = (float)Convert.ToDouble(reader[TotalLiabilitiesAndProvisionsConstants.GeneralVoluntaryReserve]);
            entity.CapitalReserve = (float)Convert.ToDouble(reader[TotalLiabilitiesAndProvisionsConstants.CapitalReserve]);
            entity.ChgInFairValResvTranslationAdj = (float)Convert.ToDouble(reader[TotalLiabilitiesAndProvisionsConstants.ChgInFairValResvTranslationAdj]);
            entity.Reserves = (float)Convert.ToDouble(reader[TotalLiabilitiesAndProvisionsConstants.Reserves]);
            entity.DueToShareholdersAppropriate = (float)Convert.ToDouble(reader[TotalLiabilitiesAndProvisionsConstants.DueToShareholdersAppropriate]);
            entity.RetaInedEarnIngsAccimulatedLosses = (float)Convert.ToDouble(reader[TotalLiabilitiesAndProvisionsConstants.RetaInedEarnIngsAccimulatedLosses]);
            entity.NetProfitofTheYear = (float)Convert.ToDouble(reader[TotalLiabilitiesAndProvisionsConstants.NetProfitofTheYear]);
            entity.TreasuryStock = (float)Convert.ToDouble(reader[TotalLiabilitiesAndProvisionsConstants.TreasuryStock]);
            entity.TotalLiabilitiesAndEquity = (float)Convert.ToDouble(reader[TotalLiabilitiesAndProvisionsConstants.TotalLiabilitiesAndEquity]);
            return entity;
        }
    }
}
