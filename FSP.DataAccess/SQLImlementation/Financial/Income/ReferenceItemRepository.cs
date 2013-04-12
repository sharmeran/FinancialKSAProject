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
    public class ReferenceItemRepository : RepositoryBaseClass<ReferenceItem>
    {
        public override void Delete(ReferenceItem entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(ReferenceItemRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(ReferenceItem entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(ReferenceItemRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.IncomeStatmentID, DbType.Int32, entity.IncomeStatmentID);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.EBITDA, DbType.Int32, entity.EBITDA);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.GrossMargin, DbType.Int32, entity.GrossMargin);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.OperatingMargin, DbType.Int32, entity.OperatingMargin);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.ProfitMargin, DbType.Int32, entity.ProfitMargin);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.ActualSalesPerEmployee, DbType.Decimal, entity.ActualSalesPerEmployee);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.DividendsPerShare, DbType.Decimal, entity.DividendsPerShare);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.TotalCashCommonDividends, DbType.Decimal, entity.TotalCashCommonDividends);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.SalesGrowth, DbType.Int32, entity.SalesGrowth);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.BasicEPSBeforeXOGrowth, DbType.Int32, entity.BasicEPSBeforeXOGrowth);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.InterestIncome, DbType.Int32, entity.InterestIncome);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.CapitalizedInterestExpense, DbType.Decimal, entity.CapitalizedInterestExpense);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.ResearchDevelopmentExpense, DbType.Decimal, entity.ResearchDevelopmentExpense);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.DepreciationExpense, DbType.Decimal, entity.DepreciationExpense);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.PartialRecordIndicator, DbType.Int32, entity.PartialRecordIndicator);


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

        public override void Update(ReferenceItem entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(ReferenceItemRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.IncomeStatmentID, DbType.Int32, entity.IncomeStatmentID);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.EBITDA, DbType.Int32, entity.EBITDA);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.GrossMargin, DbType.Int32, entity.GrossMargin);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.OperatingMargin, DbType.Int32, entity.OperatingMargin);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.ProfitMargin, DbType.Int32, entity.ProfitMargin);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.ActualSalesPerEmployee, DbType.Decimal, entity.ActualSalesPerEmployee);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.DividendsPerShare, DbType.Decimal, entity.DividendsPerShare);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.TotalCashCommonDividends, DbType.Decimal, entity.TotalCashCommonDividends);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.SalesGrowth, DbType.Int32, entity.SalesGrowth);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.BasicEPSBeforeXOGrowth, DbType.Int32, entity.BasicEPSBeforeXOGrowth);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.InterestIncome, DbType.Int32, entity.InterestIncome);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.CapitalizedInterestExpense, DbType.Decimal, entity.CapitalizedInterestExpense);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.ResearchDevelopmentExpense, DbType.Decimal, entity.ResearchDevelopmentExpense);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.DepreciationExpense, DbType.Decimal, entity.DepreciationExpense);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.PartialRecordIndicator, DbType.Int32, entity.PartialRecordIndicator);

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

        public List<ReferenceItem> FindByIncomeStatmentID(int incomeStatmentID, Common.ActionState actionState)
        {
            List<ReferenceItem> list;
            ReferenceItem entity;
            DbCommand cmd;

            list = new List<ReferenceItem>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(ReferenceItemRepositoryConstants.SP_FindBYIncomeStatmentID);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.IncomeStatmentID, DbType.Int32, incomeStatmentID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = ReferenceItemHelper(reader);
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

        public override List<ReferenceItem> FindAll(Common.ActionState actionState)
        {
            List<ReferenceItem> list;
            ReferenceItem entity;
            DbCommand cmd;

            list = new List<ReferenceItem>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(ReferenceItemRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = ReferenceItemHelper(reader);
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

        public override ReferenceItem FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            ReferenceItem entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(ReferenceItemRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = ReferenceItemHelper(reader);
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

        public override bool IsExist(ReferenceItem entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private ReferenceItem ReferenceItemHelper(SqlDataReader reader)
        {
            ReferenceItem entity = new ReferenceItem();
            entity.ID = Convert.ToInt32(reader[ReferenceItemConstants.ID]);
            entity.IncomeStatmentID = Convert.ToInt32(reader[ReferenceItemConstants.IncomeStatmentID]);
            IncomeStatmentRepository incomeStatmentRepository = new IncomeStatmentRepository();
            entity.IncomeStatment = incomeStatmentRepository.FindByID(Convert.ToInt32(reader[ReferenceItemConstants.IncomeStatmentID]), new Common.ActionState());
            entity.EBITDA = Convert.ToInt32(reader[ReferenceItemConstants.EBITDA]);
            entity.GrossMargin = Convert.ToInt32(reader[ReferenceItemConstants.GrossMargin]);
            entity.OperatingMargin = Convert.ToInt32(reader[ReferenceItemConstants.OperatingMargin]);
            entity.ProfitMargin = Convert.ToInt32(reader[ReferenceItemConstants.ProfitMargin]);
            entity.ActualSalesPerEmployee = (float)Convert.ToDouble(reader[ReferenceItemConstants.ActualSalesPerEmployee]);
            entity.DividendsPerShare = (float)Convert.ToDouble(reader[ReferenceItemConstants.DividendsPerShare]);
            entity.TotalCashCommonDividends = (float)Convert.ToDouble(reader[ReferenceItemConstants.TotalCashCommonDividends]);
            entity.SalesGrowth = Convert.ToInt32(reader[ReferenceItemConstants.SalesGrowth]);
            entity.BasicEPSBeforeXOGrowth = Convert.ToInt32(reader[ReferenceItemConstants.BasicEPSBeforeXOGrowth]);
            entity.InterestIncome = Convert.ToInt32(reader[ReferenceItemConstants.InterestIncome]);
            entity.CapitalizedInterestExpense = (float)Convert.ToDouble(reader[ReferenceItemConstants.CapitalizedInterestExpense]);
            entity.ResearchDevelopmentExpense = (float)Convert.ToDouble(reader[ReferenceItemConstants.ResearchDevelopmentExpense]);
            entity.DepreciationExpense = (float)Convert.ToDouble(reader[ReferenceItemConstants.DepreciationExpense]);
            entity.PartialRecordIndicator = Convert.ToInt32(reader[ReferenceItemConstants.PartialRecordIndicator]);
            return entity;
        }
    }
}
