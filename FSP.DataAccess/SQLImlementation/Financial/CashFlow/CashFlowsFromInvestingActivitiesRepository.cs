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
    public class CashFlowsFromInvestingActivitiesRepository : RepositoryBaseClass<CashFlowsFromInvestingActivities>
    {
        public override void Delete(CashFlowsFromInvestingActivities entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CashFlowsFromInvestingActivitiesRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, CashFlowsFromInvestingActivitiesRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(CashFlowsFromInvestingActivities entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CashFlowsFromInvestingActivitiesRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, CashFlowsFromInvestingActivitiesRepositoryConstants.CashFlowStatementID, DbType.Int32, entity.CashFlowStatementID);
                database.AddInParameter(cmd, CashFlowsFromInvestingActivitiesRepositoryConstants.DisposalOfFixedAssets, DbType.Decimal, entity.DisposalOfFixedAssets);
                database.AddInParameter(cmd, CashFlowsFromInvestingActivitiesRepositoryConstants.CapitalExpenditures, DbType.Decimal, entity.CapitalExpenditures);
                database.AddInParameter(cmd, CashFlowsFromInvestingActivitiesRepositoryConstants.DecInPropertyPlant, DbType.Decimal, entity.DecInPropertyPlant);
                database.AddInParameter(cmd, CashFlowsFromInvestingActivitiesRepositoryConstants.IncreaseInInvestments, DbType.Decimal, entity.IncreaseInInvestments);
                database.AddInParameter(cmd, CashFlowsFromInvestingActivitiesRepositoryConstants.DecreaseInInvestments, DbType.Decimal, entity.DecreaseInInvestments);
                database.AddInParameter(cmd, CashFlowsFromInvestingActivitiesRepositoryConstants.OtherCashInflow, DbType.Decimal, entity.OtherCashInflow);


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

        public override void Update(CashFlowsFromInvestingActivities entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CashFlowsFromInvestingActivitiesRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, CashFlowsFromInvestingActivitiesRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, CashFlowsFromInvestingActivitiesRepositoryConstants.CashFlowStatementID, DbType.Int32, entity.CashFlowStatementID);
                database.AddInParameter(cmd, CashFlowsFromInvestingActivitiesRepositoryConstants.DisposalOfFixedAssets, DbType.Decimal, entity.DisposalOfFixedAssets);
                database.AddInParameter(cmd, CashFlowsFromInvestingActivitiesRepositoryConstants.CapitalExpenditures, DbType.Decimal, entity.CapitalExpenditures);
                database.AddInParameter(cmd, CashFlowsFromInvestingActivitiesRepositoryConstants.DecInPropertyPlant, DbType.Decimal, entity.DecInPropertyPlant);
                database.AddInParameter(cmd, CashFlowsFromInvestingActivitiesRepositoryConstants.IncreaseInInvestments, DbType.Decimal, entity.IncreaseInInvestments);
                database.AddInParameter(cmd, CashFlowsFromInvestingActivitiesRepositoryConstants.DecreaseInInvestments, DbType.Decimal, entity.DecreaseInInvestments);
                database.AddInParameter(cmd, CashFlowsFromInvestingActivitiesRepositoryConstants.OtherCashInflow, DbType.Decimal, entity.OtherCashInflow);

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

        public List<CashFlowsFromInvestingActivities> FindByCashFlowStatmentID(int cashFlowStatmentID, Common.ActionState actionState)
        {
            List<CashFlowsFromInvestingActivities> list;
            CashFlowsFromInvestingActivities entity;
            DbCommand cmd;

            list = new List<CashFlowsFromInvestingActivities>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(CashFlowsFromInvestingActivitiesRepositoryConstants.SP_FindBYCashFlowStatmentID);
                database.AddInParameter(cmd, CashFlowsFromInvestingActivitiesRepositoryConstants.CashFlowStatementID, DbType.Int32, cashFlowStatmentID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = CashFlowsFromInvestingActivitiesHelper(reader);
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

        public override List<CashFlowsFromInvestingActivities> FindAll(Common.ActionState actionState)
        {
            List<CashFlowsFromInvestingActivities> list;
            CashFlowsFromInvestingActivities entity;
            DbCommand cmd;

            list = new List<CashFlowsFromInvestingActivities>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(CashFlowsFromInvestingActivitiesRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = CashFlowsFromInvestingActivitiesHelper(reader);
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

        public override CashFlowsFromInvestingActivities FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            CashFlowsFromInvestingActivities entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(CashFlowsFromInvestingActivitiesRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, CashFlowsFromInvestingActivitiesRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = CashFlowsFromInvestingActivitiesHelper(reader);
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

        public override bool IsExist(CashFlowsFromInvestingActivities entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private CashFlowsFromInvestingActivities CashFlowsFromInvestingActivitiesHelper(SqlDataReader reader)
        {
            CashFlowsFromInvestingActivities entity = new CashFlowsFromInvestingActivities();
            entity.ID = Convert.ToInt32(reader[CashFlowsFromInvestingActivitiesConstants.ID]);
            entity.CashFlowStatementID = Convert.ToInt32(reader[CashFlowsFromInvestingActivitiesConstants.CashFlowStatementID]);
            CashFlowStatementRepository cashFlowStatementRepository = new CashFlowStatementRepository();
            entity.CashFlowStatement = cashFlowStatementRepository.FindByID(Convert.ToInt32(reader[CashFlowsFromInvestingActivitiesConstants.CashFlowStatementID]), new Common.ActionState());
            entity.DisposalOfFixedAssets = (float)Convert.ToDouble(reader[CashFlowsFromInvestingActivitiesConstants.DisposalOfFixedAssets]);
            entity.CapitalExpenditures = (float)Convert.ToDouble(reader[CashFlowsFromInvestingActivitiesConstants.CapitalExpenditures]);
            entity.DecInPropertyPlant = (float)Convert.ToDouble(reader[CashFlowsFromInvestingActivitiesConstants.DecInPropertyPlant]);
            entity.IncreaseInInvestments = (float)Convert.ToDouble(reader[CashFlowsFromInvestingActivitiesConstants.IncreaseInInvestments]);
            entity.DecreaseInInvestments = (float)Convert.ToDouble(reader[CashFlowsFromInvestingActivitiesConstants.DecreaseInInvestments]);
            entity.OtherCashInflow = (float)Convert.ToDouble(reader[CashFlowsFromInvestingActivitiesConstants.OtherCashInflow]);
            return entity;
        }
    }
}
