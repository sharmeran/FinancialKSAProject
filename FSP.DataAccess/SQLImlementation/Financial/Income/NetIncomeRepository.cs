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
using FSP.Common.Constants.Financial.Income;
using FSP.Common.Entites.Financial.Income;
using FSP.Common.Enums;
using FSP.Common;
using FSP.DataAccess.BaseClasses;
using FSP.DataAccess.Constants.Common;
using FSP.DataAccess.Constants.Financial;
using FSP.DataAccess.Constants.Financial.Income;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FSP.DataAccess.SQLImlementation.Financial;
using FSP.DataAccess.SQLImlementation.Financial.Income;

namespace FSP.DataAccess.SQLImlementation.Financial.Income
{
    public class NetIncomeRepository : RepositoryBaseClass<NetIncome>
    {
        public override void Delete(NetIncome entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(NetIncomeRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(NetIncome entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(NetIncomeRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.IncomeStatmentID, DbType.Int32, entity.IncomeStatmentID);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.TotalCashPreferredDividends, DbType.Decimal, entity.TotalCashPreferredDividends);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.TotalCashPreferredDividendsNonIslamic, DbType.Decimal, entity.TotalCashPreferredDividendsNonIslamic);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.OtherAdjustments, DbType.Decimal, entity.OtherAdjustments);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.NetIncAvailtoCommonShareholders, DbType.Decimal, entity.NetIncAvailtoCommonShareholders);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.AbnormalLoss, DbType.Decimal, entity.AbnormalLoss);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.TaxEffectOnAbnormalItems, DbType.Decimal, entity.TaxEffectOnAbnormalItems);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.NormalizedIncome, DbType.Decimal, entity.NormalizedIncome);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.ComprehensiveIncome, DbType.Decimal, entity.ComprehensiveIncome);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.ComprehensiveIncomePerShare, DbType.Decimal, entity.ComprehensiveIncomePerShare);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.BasicEPSBeforeAbnormalItems, DbType.Decimal, entity.BasicEPSBeforeAbnormalItems);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.BasicEPSBeforeXOItems, DbType.Decimal, entity.BasicEPSBeforeXOItems);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.BasicEPS, DbType.Decimal, entity.BasicEPS);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.BasicWeightedAvgShares, DbType.Decimal, entity.BasicWeightedAvgShares);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.DilutedEPSBeforeAbnormalItems, DbType.Decimal, entity.DilutedEPSBeforeAbnormalItems);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.DilutedEPSBeforeXOItems, DbType.Decimal, entity.DilutedEPSBeforeXOItems);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.DilutedEPS, DbType.Decimal, entity.DilutedEPS);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.DilutedWeightedAvgShares, DbType.Decimal, entity.DilutedWeightedAvgShares);


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

        public override void Update(NetIncome entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(NetIncomeRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.IncomeStatmentID, DbType.Int32, entity.IncomeStatmentID);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.TotalCashPreferredDividends, DbType.Decimal, entity.TotalCashPreferredDividends);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.TotalCashPreferredDividendsNonIslamic, DbType.Decimal, entity.TotalCashPreferredDividendsNonIslamic);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.OtherAdjustments, DbType.Decimal, entity.OtherAdjustments);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.NetIncAvailtoCommonShareholders, DbType.Decimal, entity.NetIncAvailtoCommonShareholders);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.AbnormalLoss, DbType.Decimal, entity.AbnormalLoss);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.TaxEffectOnAbnormalItems, DbType.Decimal, entity.TaxEffectOnAbnormalItems);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.NormalizedIncome, DbType.Decimal, entity.NormalizedIncome);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.ComprehensiveIncome, DbType.Decimal, entity.ComprehensiveIncome);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.ComprehensiveIncomePerShare, DbType.Decimal, entity.ComprehensiveIncomePerShare);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.BasicEPSBeforeAbnormalItems, DbType.Decimal, entity.BasicEPSBeforeAbnormalItems);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.BasicEPSBeforeXOItems, DbType.Decimal, entity.BasicEPSBeforeXOItems);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.BasicEPS, DbType.Decimal, entity.BasicEPS);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.BasicWeightedAvgShares, DbType.Decimal, entity.BasicWeightedAvgShares);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.DilutedEPSBeforeAbnormalItems, DbType.Decimal, entity.DilutedEPSBeforeAbnormalItems);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.DilutedEPSBeforeXOItems, DbType.Decimal, entity.DilutedEPSBeforeXOItems);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.DilutedEPS, DbType.Decimal, entity.DilutedEPS);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.DilutedWeightedAvgShares, DbType.Decimal, entity.DilutedWeightedAvgShares);

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

        public void DeleteByIncomeStatmentID(int incomeStatmentID, ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(NetIncomeRepositoryConstants.SP_DeleteBYIncomeStatmentID);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.IncomeStatmentID, DbType.Int32, incomeStatmentID);


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

        public override List<NetIncome> FindAll(Common.ActionState actionState)
        {
            List<NetIncome> list;
            NetIncome entity;
            DbCommand cmd;

            list = new List<NetIncome>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(NetIncomeRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = NetIncomeHelper(reader);
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

        public List<NetIncome> FindByIncomeStatmentID(int incomeStatmentID, Common.ActionState actionState)
        {
            List<NetIncome> list;
            NetIncome entity;
            DbCommand cmd;

            list = new List<NetIncome>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(NetIncomeRepositoryConstants.SP_FindBYIncomeStatmentID);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.IncomeStatmentID, DbType.Int32, incomeStatmentID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = NetIncomeHelper(reader);
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

        public override NetIncome FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            NetIncome entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(NetIncomeRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, NetIncomeRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = NetIncomeHelper(reader);
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

        public override bool IsExist(NetIncome entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private NetIncome NetIncomeHelper(SqlDataReader reader)
        {
            NetIncome entity = new NetIncome();
            entity.ID = Convert.ToInt32(reader[NetIncomeConstants.ID]);
            entity.IncomeStatmentID = Convert.ToInt32(reader[NetIncomeConstants.IncomeStatmentID]);
            IncomeStatmentRepository incomeStatmentRepository = new IncomeStatmentRepository();
            entity.IncomeStatment = incomeStatmentRepository.FindByID(Convert.ToInt32(reader[NetIncomeConstants.IncomeStatmentID]), new Common.ActionState());
            entity.TotalCashPreferredDividends = (float)Convert.ToDouble(reader[NetIncomeConstants.TotalCashPreferredDividends]);
            entity.TotalCashPreferredDividendsNonIslamic = (float)Convert.ToDouble(reader[NetIncomeConstants.TotalCashPreferredDividendsNonIslamic]);
            entity.OtherAdjustments = (float)Convert.ToDouble(reader[NetIncomeConstants.OtherAdjustments]);
            entity.NetIncAvailtoCommonShareholders = (float)Convert.ToDouble(reader[NetIncomeConstants.NetIncAvailtoCommonShareholders]);
            entity.AbnormalLoss = (float)Convert.ToDouble(reader[NetIncomeConstants.AbnormalLoss]);
            entity.TaxEffectOnAbnormalItems = (float)Convert.ToDouble(reader[NetIncomeConstants.TaxEffectOnAbnormalItems]);
            entity.NormalizedIncome = (float)Convert.ToDouble(reader[NetIncomeConstants.NormalizedIncome]);
            entity.ComprehensiveIncome = (float)Convert.ToDouble(reader[NetIncomeConstants.ComprehensiveIncome]);
            entity.ComprehensiveIncomePerShare = (float)Convert.ToDouble(reader[NetIncomeConstants.ComprehensiveIncomePerShare]);
            entity.BasicEPSBeforeAbnormalItems = (float)Convert.ToDouble(reader[NetIncomeConstants.BasicEPSBeforeAbnormalItems]);
            entity.BasicEPSBeforeXOItems = (float)Convert.ToDouble(reader[NetIncomeConstants.BasicEPSBeforeXOItems]);
            entity.BasicEPS = (float)Convert.ToDouble(reader[NetIncomeConstants.BasicEPS]);
            entity.BasicWeightedAvgShares = (float)Convert.ToDouble(reader[NetIncomeConstants.BasicWeightedAvgShares]);
            entity.DilutedEPSBeforeAbnormalItems = (float)Convert.ToDouble(reader[NetIncomeConstants.DilutedEPSBeforeAbnormalItems]);
            entity.DilutedEPSBeforeXOItems = (float)Convert.ToDouble(reader[NetIncomeConstants.DilutedEPSBeforeXOItems]);
            entity.DilutedEPS = (float)Convert.ToDouble(reader[NetIncomeConstants.DilutedEPS]);
            entity.DilutedWeightedAvgShares = (float)Convert.ToDouble(reader[NetIncomeConstants.DilutedWeightedAvgShares]);
            return entity;
        }
    }
}
