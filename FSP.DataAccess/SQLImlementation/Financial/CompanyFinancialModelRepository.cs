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
using FSP.Common.Enums;
using FSP.DataAccess.BaseClasses;
using FSP.DataAccess.Constants.Common;
using FSP.DataAccess.Constants.Financial;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FSP.DataAccess.SQLImlementation.CompanyAdministration;
using FSP.DataAccess.SQLImlementation.Administration;
using FSP.DataAccess.SQLImlementation.Financial.Income;
using FSP.DataAccess.SQLImlementation.Financial.CashFlow;
using FSP.DataAccess.SQLImlementation.Financial.Assets;

namespace FSP.DataAccess.SQLImlementation.Financial
{
    public class CompanyFinancialModelRepository : RepositoryBaseClass<CompanyFinancialModel>
    {
        public override void Delete(CompanyFinancialModel entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CompanyFinancialModelRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(CompanyFinancialModel entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CompanyFinancialModelRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.CompanyID, DbType.Int32, entity.CompanyID);
                database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.Year, DbType.Int32, entity.Year);
                database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.UserID, DbType.Int32, entity.UserID);
                database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.ReviewedUserID, DbType.Int32, entity.ReviewedUserID);
                database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.IsApproved, DbType.Boolean, entity.IsApproved);
                database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.IsReviewed, DbType.Boolean, entity.IsReviewed);
                if (entity.CreatedDate.Day == date.Day && entity.CreatedDate.Month == date.Month && entity.CreatedDate.Year == date.Year)
                {
                    database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.CreatedDate, DbType.Date, null);
                }
                else
                {
                    database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.CreatedDate, DbType.Date, entity.CreatedDate);
                }


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

        public override void Update(CompanyFinancialModel entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CompanyFinancialModelRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.CompanyID, DbType.Int32, entity.CompanyID);
                database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.Year, DbType.Int32, entity.Year);
                database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.UserID, DbType.Int32, entity.UserID);
                database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.ReviewedUserID, DbType.Int32, entity.ReviewedUserID);
                database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.IsApproved, DbType.Boolean, entity.IsApproved);
                database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.IsReviewed, DbType.Boolean, entity.IsReviewed);
                if (entity.CreatedDate.Day == date.Day && entity.CreatedDate.Month == date.Month && entity.CreatedDate.Year == date.Year)
                {
                    database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.CreatedDate, DbType.Date, null);
                }
                else
                {
                    database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.CreatedDate, DbType.Date, entity.CreatedDate);
                }

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

        public override List<CompanyFinancialModel> FindAll(Common.ActionState actionState)
        {
            List<CompanyFinancialModel> list;
            CompanyFinancialModel entity;
            DbCommand cmd;

            list = new List<CompanyFinancialModel>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(CompanyFinancialModelRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = CompanyFinancialModelHelper(reader, false);
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

        public override CompanyFinancialModel FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            CompanyFinancialModel entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(CompanyFinancialModelRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, CompanyFinancialModelRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = CompanyFinancialModelHelper(reader, true);
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

        public override bool IsExist(CompanyFinancialModel entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private CompanyFinancialModel CompanyFinancialModelHelper(SqlDataReader reader, bool isFull)
        {
            CompanyFinancialModel entity = new CompanyFinancialModel();
            entity.ID = Convert.ToInt32(reader[CompanyFinancialModelConstants.ID]);
            entity.CompanyID = Convert.ToInt32(reader[CompanyFinancialModelConstants.CompanyID]);
            CompanyRepository companyRepository = new CompanyRepository();
            entity.Company = companyRepository.FindByID(Convert.ToInt32(reader[CompanyFinancialModelConstants.CompanyID]), new Common.ActionState());
            entity.Year = Convert.ToInt32(reader[CompanyFinancialModelConstants.Year]);
            entity.UserID = Convert.ToInt32(reader[CompanyFinancialModelConstants.UserID]);
            UserRepository userRepository = new UserRepository();
            entity.User = userRepository.FindByID(Convert.ToInt32(reader[CompanyFinancialModelConstants.UserID]), new Common.ActionState());
            entity.ReviewedUserID = Convert.ToInt32(reader[CompanyFinancialModelConstants.ReviewedUserID]);
            entity.ReviewedUser = userRepository.FindByID(Convert.ToInt32(reader[CompanyFinancialModelConstants.ReviewedUserID]), new Common.ActionState());
            entity.IsApproved = Convert.ToBoolean(reader[CompanyFinancialModelConstants.IsApproved]);
            entity.IsReviewed = Convert.ToBoolean(reader[CompanyFinancialModelConstants.IsReviewed]);
            if (reader[CompanyFinancialModelConstants.CreatedDate] != DBNull.Value)
                entity.CreatedDate = Convert.ToDateTime(reader[CompanyFinancialModelConstants.CreatedDate]);
            if (isFull)
            {
                IncomeStatmentRepository incomeStatmentRepository = new IncomeStatmentRepository();
                entity.IncomeList = incomeStatmentRepository.FindByCompanyFinancialModelID(entity.ID, new Common.ActionState());
                CashFlowStatementRepository cashFlowStatementRepository = new CashFlowStatementRepository();
                entity.CashFlowList = cashFlowStatementRepository.FindByCompanyFinancialModelID(entity.ID, new Common.ActionState());
                AssetRepository assetRepository = new AssetRepository();
                entity.AssetsList = assetRepository.FindByCompanyFinancialModelID(entity.ID, new Common.ActionState());
            }
            return entity;
        }
    }
}
