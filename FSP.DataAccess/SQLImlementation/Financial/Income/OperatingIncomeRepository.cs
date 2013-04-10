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
    public class OperatingIncomeRepository : RepositoryBaseClass<OperatingIncome>
    {
        public override void Delete(OperatingIncome entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(OperatingIncomeRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(OperatingIncome entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(OperatingIncomeRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.IncomeStatmentID, DbType.Int32, entity.IncomeStatmentID);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.OperatingIncomevalue, DbType.Decimal, entity.OperatingIncomevalue);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.InterestExpense, DbType.Int32, entity.InterestExpense);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.InterestExpenseNonIslamic, DbType.Int32, entity.InterestExpenseNonIslamic);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.InterestIncome, DbType.Int32, entity.InterestIncome);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.InterestIncomeNonIslamic, DbType.Int32, entity.InterestIncomeNonIslamic);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.InvestmentIncome, DbType.Decimal, entity.InvestmentIncome);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.InvestmentIncomeNonIslamic, DbType.Decimal, entity.InvestmentIncomeNonIslamic);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.IncomeFromSister, DbType.Decimal, entity.IncomeFromSister);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.IncomeFromSisterNonIslamic, DbType.Decimal, entity.IncomeFromSisterNonIslamic);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.OtherIncome, DbType.Decimal, entity.OtherIncome);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.OtherExpenses, DbType.Decimal, entity.OtherExpenses);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.OtherIncomeNonIslamic, DbType.Decimal, entity.OtherIncomeNonIslamic);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.OtherExpensesNonIslamic, DbType.Decimal, entity.OtherExpensesNonIslamic);


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

        public override void Update(OperatingIncome entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(OperatingIncomeRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.IncomeStatmentID, DbType.Int32, entity.IncomeStatmentID);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.OperatingIncomevalue, DbType.Decimal, entity.OperatingIncomevalue);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.InterestExpense, DbType.Int32, entity.InterestExpense);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.InterestExpenseNonIslamic, DbType.Int32, entity.InterestExpenseNonIslamic);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.InterestIncome, DbType.Int32, entity.InterestIncome);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.InterestIncomeNonIslamic, DbType.Int32, entity.InterestIncomeNonIslamic);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.InvestmentIncome, DbType.Decimal, entity.InvestmentIncome);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.InvestmentIncomeNonIslamic, DbType.Decimal, entity.InvestmentIncomeNonIslamic);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.IncomeFromSister, DbType.Decimal, entity.IncomeFromSister);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.IncomeFromSisterNonIslamic, DbType.Decimal, entity.IncomeFromSisterNonIslamic);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.OtherIncome, DbType.Decimal, entity.OtherIncome);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.OtherExpenses, DbType.Decimal, entity.OtherExpenses);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.OtherIncomeNonIslamic, DbType.Decimal, entity.OtherIncomeNonIslamic);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.OtherExpensesNonIslamic, DbType.Decimal, entity.OtherExpensesNonIslamic);

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

        public override List<OperatingIncome> FindAll(Common.ActionState actionState)
        {
            List<OperatingIncome> list;
            OperatingIncome entity;
            DbCommand cmd;

            list = new List<OperatingIncome>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(OperatingIncomeRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = OperatingIncomeHelper(reader);
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

        public override OperatingIncome FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            OperatingIncome entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(OperatingIncomeRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, OperatingIncomeRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = OperatingIncomeHelper(reader);
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

        public override bool IsExist(OperatingIncome entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private OperatingIncome OperatingIncomeHelper(SqlDataReader reader)
        {
            OperatingIncome entity = new OperatingIncome();
            entity.ID = Convert.ToInt32(reader[OperatingIncomeConstants.ID]);
            entity.IncomeStatmentID = Convert.ToInt32(reader[OperatingIncomeConstants.IncomeStatmentID]);
            IncomeStatmentRepository incomeStatmentRepository = new IncomeStatmentRepository();
            entity.IncomeStatment = incomeStatmentRepository.FindByID(Convert.ToInt32(reader[OperatingIncomeConstants.IncomeStatmentID]), new Common.ActionState());
            entity.OperatingIncomevalue = (float)Convert.ToDouble(reader[OperatingIncomeConstants.OperatingIncomevalue]);
            entity.InterestExpense = Convert.ToInt32(reader[OperatingIncomeConstants.InterestExpense]);
            entity.InterestExpenseNonIslamic = Convert.ToInt32(reader[OperatingIncomeConstants.InterestExpenseNonIslamic]);
            entity.InterestIncome = Convert.ToInt32(reader[OperatingIncomeConstants.InterestIncome]);
            entity.InterestIncomeNonIslamic = Convert.ToInt32(reader[OperatingIncomeConstants.InterestIncomeNonIslamic]);
            entity.InvestmentIncome = (float)Convert.ToDouble(reader[OperatingIncomeConstants.InvestmentIncome]);
            entity.InvestmentIncomeNonIslamic = (float)Convert.ToDouble(reader[OperatingIncomeConstants.InvestmentIncomeNonIslamic]);
            entity.IncomeFromSister = (float)Convert.ToDouble(reader[OperatingIncomeConstants.IncomeFromSister]);
            entity.IncomeFromSisterNonIslamic = (float)Convert.ToDouble(reader[OperatingIncomeConstants.IncomeFromSisterNonIslamic]);
            entity.OtherIncome = (float)Convert.ToDouble(reader[OperatingIncomeConstants.OtherIncome]);
            entity.OtherExpenses = (float)Convert.ToDouble(reader[OperatingIncomeConstants.OtherExpenses]);
            entity.OtherIncomeNonIslamic = (float)Convert.ToDouble(reader[OperatingIncomeConstants.OtherIncomeNonIslamic]);
            entity.OtherExpensesNonIslamic = (float)Convert.ToDouble(reader[OperatingIncomeConstants.OtherExpensesNonIslamic]);
            return entity;
        }
    }
}
