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
    public class RevenueRepository : RepositoryBaseClass<Revenue>
    {
        public override void Delete(Revenue entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(RevenueRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, RevenueRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(Revenue entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(RevenueRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, RevenueRepositoryConstants.IncomeStatmentID, DbType.Int32, entity.IncomeStatmentID);
                database.AddInParameter(cmd, RevenueRepositoryConstants.RevenueValue, DbType.Decimal, entity.RevenueValue);
                database.AddInParameter(cmd, RevenueRepositoryConstants.CostOfRevenue, DbType.Decimal, entity.CostOfRevenue);


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

        public override void Update(Revenue entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(RevenueRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, RevenueRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, RevenueRepositoryConstants.IncomeStatmentID, DbType.Int32, entity.IncomeStatmentID);
                database.AddInParameter(cmd, RevenueRepositoryConstants.RevenueValue, DbType.Decimal, entity.RevenueValue);
                database.AddInParameter(cmd, RevenueRepositoryConstants.CostOfRevenue, DbType.Decimal, entity.CostOfRevenue);

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

        public List<Revenue> FindByIncomeStatmentID(int incomeStatmentID, Common.ActionState actionState)
        {
            List<Revenue> list;
            Revenue entity;
            DbCommand cmd;

            list = new List<Revenue>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(RevenueRepositoryConstants.SP_FindBYIncomeStatmentID);
                database.AddInParameter(cmd, RevenueRepositoryConstants.IncomeStatmentID, DbType.Int32, incomeStatmentID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = RevenueHelper(reader);
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

        public override List<Revenue> FindAll(Common.ActionState actionState)
        {
            List<Revenue> list;
            Revenue entity;
            DbCommand cmd;

            list = new List<Revenue>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(RevenueRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = RevenueHelper(reader);
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

        public override Revenue FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            Revenue entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(RevenueRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, RevenueRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = RevenueHelper(reader);
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

        public override bool IsExist(Revenue entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private Revenue RevenueHelper(SqlDataReader reader)
        {
            Revenue entity = new Revenue();
            entity.ID = Convert.ToInt32(reader[RevenueConstants.ID]);
            entity.IncomeStatmentID = Convert.ToInt32(reader[RevenueConstants.IncomeStatmentID]);
            IncomeStatmentRepository incomeStatmentRepository = new IncomeStatmentRepository();
            entity.IncomeStatment = incomeStatmentRepository.FindByID(Convert.ToInt32(reader[RevenueConstants.IncomeStatmentID]), new Common.ActionState());
            entity.RevenueValue = (float)Convert.ToDouble(reader[RevenueConstants.RevenueValue]);
            entity.CostOfRevenue = (float)Convert.ToDouble(reader[RevenueConstants.CostOfRevenue]);
            return entity;
        }
    }
}
