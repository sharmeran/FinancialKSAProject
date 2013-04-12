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
    public class TotalFinancialIncomeRepository : RepositoryBaseClass<TotalFinancialIncome>
    {
        public override void Delete(TotalFinancialIncome entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(TotalFinancialIncomeRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, TotalFinancialIncomeRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(TotalFinancialIncome entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(TotalFinancialIncomeRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, TotalFinancialIncomeRepositoryConstants.IncomeStatmentID, DbType.Int32, entity.IncomeStatmentID);
                database.AddInParameter(cmd, TotalFinancialIncomeRepositoryConstants.TotalFinancialIncomeValue, DbType.Decimal, entity.TotalFinancialIncomeValue);
                database.AddInParameter(cmd, TotalFinancialIncomeRepositoryConstants.NetProfit, DbType.Decimal, entity.NetProfit);
                database.AddInParameter(cmd, TotalFinancialIncomeRepositoryConstants.IncomeTaxZakat, DbType.Decimal, entity.IncomeTaxZakat);
                database.AddInParameter(cmd, TotalFinancialIncomeRepositoryConstants.TaxZakatProvision, DbType.Decimal, entity.TaxZakatProvision);
                database.AddInParameter(cmd, TotalFinancialIncomeRepositoryConstants.ZakatRate, DbType.Decimal, entity.ZakatRate);


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

        public override void Update(TotalFinancialIncome entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(TotalFinancialIncomeRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, TotalFinancialIncomeRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, TotalFinancialIncomeRepositoryConstants.IncomeStatmentID, DbType.Int32, entity.IncomeStatmentID);
                database.AddInParameter(cmd, TotalFinancialIncomeRepositoryConstants.TotalFinancialIncomeValue, DbType.Decimal, entity.TotalFinancialIncomeValue);
                database.AddInParameter(cmd, TotalFinancialIncomeRepositoryConstants.NetProfit, DbType.Decimal, entity.NetProfit);
                database.AddInParameter(cmd, TotalFinancialIncomeRepositoryConstants.IncomeTaxZakat, DbType.Decimal, entity.IncomeTaxZakat);
                database.AddInParameter(cmd, TotalFinancialIncomeRepositoryConstants.TaxZakatProvision, DbType.Decimal, entity.TaxZakatProvision);
                database.AddInParameter(cmd, TotalFinancialIncomeRepositoryConstants.ZakatRate, DbType.Decimal, entity.ZakatRate);

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

        public List<TotalFinancialIncome> FindByIncomeStatmentID(int incomeStatmentID, Common.ActionState actionState)
        {
            List<TotalFinancialIncome> list;
            TotalFinancialIncome entity;
            DbCommand cmd;

            list = new List<TotalFinancialIncome>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(TotalFinancialIncomeRepositoryConstants.SP_FindBYIncomeStatmentID);
                database.AddInParameter(cmd, TotalFinancialIncomeRepositoryConstants.IncomeStatmentID, DbType.Int32, incomeStatmentID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = TotalFinancialIncomeHelper(reader);
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

        public override List<TotalFinancialIncome> FindAll(Common.ActionState actionState)
        {
            List<TotalFinancialIncome> list;
            TotalFinancialIncome entity;
            DbCommand cmd;

            list = new List<TotalFinancialIncome>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(TotalFinancialIncomeRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = TotalFinancialIncomeHelper(reader);
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

        public override TotalFinancialIncome FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            TotalFinancialIncome entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(TotalFinancialIncomeRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, TotalFinancialIncomeRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = TotalFinancialIncomeHelper(reader);
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

        public override bool IsExist(TotalFinancialIncome entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private TotalFinancialIncome TotalFinancialIncomeHelper(SqlDataReader reader)
        {
            TotalFinancialIncome entity = new TotalFinancialIncome();
            entity.ID = Convert.ToInt32(reader[TotalFinancialIncomeConstants.ID]);
            entity.IncomeStatmentID = Convert.ToInt32(reader[TotalFinancialIncomeConstants.IncomeStatmentID]);
            IncomeStatmentRepository incomeStatmentRepository = new IncomeStatmentRepository();
            entity.IncomeStatment = incomeStatmentRepository.FindByID(Convert.ToInt32(reader[TotalFinancialIncomeConstants.IncomeStatmentID]), new Common.ActionState());
            entity.TotalFinancialIncomeValue = (float)Convert.ToDouble(reader[TotalFinancialIncomeConstants.TotalFinancialIncomeValue]);
            entity.NetProfit = (float)Convert.ToDouble(reader[TotalFinancialIncomeConstants.NetProfit]);
            entity.IncomeTaxZakat = (float)Convert.ToDouble(reader[TotalFinancialIncomeConstants.IncomeTaxZakat]);
            entity.TaxZakatProvision = (float)Convert.ToDouble(reader[TotalFinancialIncomeConstants.TaxZakatProvision]);
            entity.ZakatRate = (float)Convert.ToDouble(reader[TotalFinancialIncomeConstants.ZakatRate]);
            return entity;
        }
    }
}
