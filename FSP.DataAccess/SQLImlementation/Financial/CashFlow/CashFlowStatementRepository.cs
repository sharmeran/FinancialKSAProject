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
    public class CashFlowStatementRepository : RepositoryBaseClass<CashFlowStatement>
    {
        public void DeleteByCompanyFinancialModelID(int companyFinancialModelID, ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CashFlowStatementRepositoryConstants.SP_DeleteByCompanyFinancialModelID);
                database.AddInParameter(cmd, CashFlowStatementRepositoryConstants.CompanyFinancialModelID, DbType.Int32, companyFinancialModelID);


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

        public override void Delete(CashFlowStatement entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override void Insert(CashFlowStatement entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CashFlowStatementRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, CashFlowStatementRepositoryConstants.CompanyFinancialModelID, DbType.Int32, entity.CompanyFinancialModelID);


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

        public override void Update(CashFlowStatement entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override List<CashFlowStatement> FindAll(Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public List<CashFlowStatement> FindByCompanyFinancialModelID(int companyFinancialModelID, Common.ActionState actionState)
        {
            List<CashFlowStatement> CashFlowStatementList;
            CashFlowStatement CashFlowStatementEntity;
            DbCommand cmd;

            CashFlowStatementList = new List<CashFlowStatement>();
            CashFlowStatementEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(CashFlowStatementRepositoryConstants.SP_FindBYCompanyFinancialModelID);
                database.AddInParameter(cmd, CashFlowStatementRepositoryConstants.CompanyFinancialModelID, DbType.Int32, companyFinancialModelID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        CashFlowStatementEntity = CashFlowStatementHelper(reader);
                        if (CashFlowStatementEntity != null)
                        {
                            CashFlowStatementList.Add(CashFlowStatementEntity);
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
            return CashFlowStatementList;
        }

        public override CashFlowStatement FindByID(int entityID, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(CashFlowStatement entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private CashFlowStatement CashFlowStatementHelper(SqlDataReader reader)
        {
            CashFlowStatement cashFlowStatement = new CashFlowStatement();
            cashFlowStatement.CompanyFinancialModelID = Convert.ToInt32(reader[CashFlowStatementConstants.CompanyFinancialModelID]);
            CompanyFinancialModelRepository companyFinancialModelRepository = new CompanyFinancialModelRepository();
            cashFlowStatement.CompanyFinancialModel = companyFinancialModelRepository.FindByID(Convert.ToInt32(reader[CashFlowStatementConstants.CompanyFinancialModelID]), new ActionState());
            cashFlowStatement.ID = Convert.ToInt32(reader[CashFlowStatementConstants.ID]);
            return cashFlowStatement;
        }
    }
}
