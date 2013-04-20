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
    public class IncomeStatmentRepository : RepositoryBaseClass<IncomeStatment>
    {
        public void DeleteByCompanyFinancialModelID(int companyFinancialModelID, ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(IncomeStatmentRepositoryConstants.SP_DeleteByCompanyFinancialModelID);
                database.AddInParameter(cmd, IncomeStatmentRepositoryConstants.CompanyFinancialModelID, DbType.Int32, companyFinancialModelID);


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

        public override void Delete(IncomeStatment entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override void Insert(IncomeStatment entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(IncomeStatmentRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, IncomeStatmentRepositoryConstants.CompanyFinancialModelID, DbType.Int32, entity.CompanyFinancialModelID);


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

        public override void Update(IncomeStatment entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override List<IncomeStatment> FindAll(Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public List<IncomeStatment> FindByCompanyFinancialModelID(int companyFinancialModelID, Common.ActionState actionState)
        {
            List<IncomeStatment> IncomeStatmentList;
            IncomeStatment IncomeStatmentEntity;
            DbCommand cmd;

            IncomeStatmentList = new List<IncomeStatment>();
            IncomeStatmentEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(IncomeStatmentRepositoryConstants.SP_FindBYCompanyFinancialModelID);
                database.AddInParameter(cmd, IncomeStatmentRepositoryConstants.CompanyFinancialModelID, DbType.Int32, companyFinancialModelID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        IncomeStatmentEntity = IncomeStatmentHelper(reader);
                        if (IncomeStatmentEntity != null)
                        {
                            IncomeStatmentList.Add(IncomeStatmentEntity);
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
            return IncomeStatmentList;
        }

        public override IncomeStatment FindByID(int entityID, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(IncomeStatment entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private IncomeStatment IncomeStatmentHelper(SqlDataReader reader)
        {
            IncomeStatment incomeStatment = new IncomeStatment();
            incomeStatment.CompanyFinancialModelID = Convert.ToInt32(reader[IncomeStatmentConstants.CompanyFinancialModelID]);
            CompanyFinancialModelRepository companyFinancialModelRepository = new CompanyFinancialModelRepository();
            incomeStatment.CompanyFinancialModel = companyFinancialModelRepository.FindByID(incomeStatment.CompanyFinancialModelID, new ActionState());
            incomeStatment.ID = Convert.ToInt32(reader[IncomeStatmentConstants.ID]);
            GrossProfitRepository grossProfitRepository = new GrossProfitRepository();
            incomeStatment.GrossProfitList = grossProfitRepository.FindByIncomeStatmentID(incomeStatment.ID, new ActionState());
            IncomeBeforeXORepository incomeBeforeXORepository = new IncomeBeforeXORepository();
            incomeStatment.IncomeBeforeXOList = incomeBeforeXORepository.FindByIncomeStatmentID(incomeStatment.ID, new ActionState());
            NetIncomeRepository netIncomeRepository = new NetIncomeRepository();
            incomeStatment.NetIncomeList = netIncomeRepository.FindByIncomeStatmentID(incomeStatment.ID, new ActionState());
            OperatingIncomeRepository operatingIncomeRepository = new OperatingIncomeRepository();
            incomeStatment.OperatingIncomeList = operatingIncomeRepository.FindByIncomeStatmentID(incomeStatment.ID, new ActionState());
            ReferenceItemRepository referenceItemRepository = new ReferenceItemRepository();
            incomeStatment.ReferenceItemList = referenceItemRepository.FindByIncomeStatmentID(incomeStatment.ID, new ActionState());
            RevenueRepository revenueRepository = new RevenueRepository();
            incomeStatment.RevenueList = revenueRepository.FindByIncomeStatmentID(incomeStatment.ID, new ActionState());
            TotalFinancialIncomeRepository totalFinancialIncomeRepository = new TotalFinancialIncomeRepository();
            incomeStatment.TotalFinancialIncomeList = totalFinancialIncomeRepository.FindByIncomeStatmentID(incomeStatment.ID, new ActionState());

            return incomeStatment;
        }
    }
}
