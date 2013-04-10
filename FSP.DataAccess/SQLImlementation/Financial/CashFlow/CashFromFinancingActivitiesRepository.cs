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
using FSP.Common.Constants.Financial.CashFlow;
using FSP.Common.Entites.Financial.CashFlow;
using FSP.Common.Enums;
using FSP.Common;
using FSP.DataAccess.BaseClasses;
using FSP.DataAccess.Constants.Common;
using FSP.DataAccess.Constants.Financial;
using FSP.DataAccess.Constants.Financial.CashFlow;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FSP.DataAccess.SQLImlementation.Financial;
using FSP.DataAccess.SQLImlementation.Financial.CashFlow;

namespace FSP.DataAccess.SQLImlementation.Financial.CashFlow
{
    public class CashFromFinancingActivitiesRepository : RepositoryBaseClass<CashFromFinancingActivities>
    {
        public override void Delete(CashFromFinancingActivities entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CashFromFinancingActivitiesRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(CashFromFinancingActivities entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CashFromFinancingActivitiesRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.CashFlowStatmentID, DbType.Int32, entity.CashFlowStatmentID);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.DividendsPaidDuringTheYear, DbType.Decimal, entity.DividendsPaidDuringTheYear);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.IssuancesPurchasesEquityShares, DbType.Decimal, entity.IssuancesPurchasesEquityShares);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.ChangeInShortTermBorrowings, DbType.Decimal, entity.ChangeInShortTermBorrowings);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.InLongTermBorrowings, DbType.Decimal, entity.InLongTermBorrowings);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.InCapitalStocks, DbType.Decimal, entity.InCapitalStocks);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.InLoans, DbType.Decimal, entity.InLoans);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.EffectOfExchangeRatesOnCash, DbType.Decimal, entity.EffectOfExchangeRatesOnCash);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.OtherFinInflow, DbType.Decimal, entity.OtherFinInflow);


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

        public override void Update(CashFromFinancingActivities entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CashFromFinancingActivitiesRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.CashFlowStatmentID, DbType.Int32, entity.CashFlowStatmentID);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.DividendsPaidDuringTheYear, DbType.Decimal, entity.DividendsPaidDuringTheYear);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.IssuancesPurchasesEquityShares, DbType.Decimal, entity.IssuancesPurchasesEquityShares);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.ChangeInShortTermBorrowings, DbType.Decimal, entity.ChangeInShortTermBorrowings);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.InLongTermBorrowings, DbType.Decimal, entity.InLongTermBorrowings);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.InCapitalStocks, DbType.Decimal, entity.InCapitalStocks);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.InLoans, DbType.Decimal, entity.InLoans);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.EffectOfExchangeRatesOnCash, DbType.Decimal, entity.EffectOfExchangeRatesOnCash);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.OtherFinInflow, DbType.Decimal, entity.OtherFinInflow);

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

        public override List<CashFromFinancingActivities> FindAll(Common.ActionState actionState)
        {
            List<CashFromFinancingActivities> list;
            CashFromFinancingActivities entity;
            DbCommand cmd;

            list = new List<CashFromFinancingActivities>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(CashFromFinancingActivitiesRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = CashFromFinancingActivitiesHelper(reader);
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

        public override CashFromFinancingActivities FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            CashFromFinancingActivities entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(CashFromFinancingActivitiesRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, CashFromFinancingActivitiesRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = CashFromFinancingActivitiesHelper(reader);
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

        public override bool IsExist(CashFromFinancingActivities entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private CashFromFinancingActivities CashFromFinancingActivitiesHelper(SqlDataReader reader)
        {
            CashFromFinancingActivities entity = new CashFromFinancingActivities();
            entity.ID = Convert.ToInt32(reader[CashFromFinancingActivitiesConstants.ID]);
            entity.CashFlowStatmentID = Convert.ToInt32(reader[CashFromFinancingActivitiesConstants.CashFlowStatmentID]);
            CashFlowStatementRepository cashFlowStatementRepository = new CashFlowStatementRepository();
            entity.CashFlowStatement = cashFlowStatementRepository.FindByID(Convert.ToInt32(reader[CashFromFinancingActivitiesConstants.CashFlowStatmentID]), new Common.ActionState());
            entity.DividendsPaidDuringTheYear = (float)Convert.ToDouble(reader[CashFromFinancingActivitiesConstants.DividendsPaidDuringTheYear]);
            entity.IssuancesPurchasesEquityShares = (float)Convert.ToDouble(reader[CashFromFinancingActivitiesConstants.IssuancesPurchasesEquityShares]);
            entity.ChangeInShortTermBorrowings = (float)Convert.ToDouble(reader[CashFromFinancingActivitiesConstants.ChangeInShortTermBorrowings]);
            entity.InLongTermBorrowings = (float)Convert.ToDouble(reader[CashFromFinancingActivitiesConstants.InLongTermBorrowings]);
            entity.InCapitalStocks = (float)Convert.ToDouble(reader[CashFromFinancingActivitiesConstants.InCapitalStocks]);
            entity.InLoans = (float)Convert.ToDouble(reader[CashFromFinancingActivitiesConstants.InLoans]);
            entity.EffectOfExchangeRatesOnCash = (float)Convert.ToDouble(reader[CashFromFinancingActivitiesConstants.EffectOfExchangeRatesOnCash]);
            entity.OtherFinInflow = (float)Convert.ToDouble(reader[CashFromFinancingActivitiesConstants.OtherFinInflow]);
            return entity;
        }
    }
}
