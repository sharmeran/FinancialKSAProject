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
    public class CashFlowsFromOperatingActivitiesRepository : RepositoryBaseClass<CashFlowsFromOperatingActivities>
    {
        public override void Delete(CashFlowsFromOperatingActivities entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CashFlowsFromOperatingActivitiesRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(CashFlowsFromOperatingActivities entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CashFlowsFromOperatingActivitiesRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.CashFlowStatmentID, DbType.Int32, entity.CashFlowStatmentID);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.NetIncomeBeforeTaxMinorityInterest, DbType.Decimal, entity.NetIncomeBeforeTaxMinorityInterest);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.DepreciationAmortization, DbType.Decimal, entity.DepreciationAmortization);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.InterestedPaid, DbType.Decimal, entity.InterestedPaid);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.InterestReceived, DbType.Decimal, entity.InterestReceived);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.TaxAndZakatPaid, DbType.Decimal, entity.TaxAndZakatPaid);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.MovementOnWoekingCapital, DbType.Decimal, entity.MovementOnWoekingCapital);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.ChangeInOperatingActivities, DbType.Decimal, entity.ChangeInOperatingActivities);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.ChangeInProvisions, DbType.Decimal, entity.ChangeInProvisions);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.Others, DbType.Decimal, entity.Others);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.OtherNonCashAdjustments, DbType.Decimal, entity.OtherNonCashAdjustments);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.ChangesInNonCashCapital, DbType.Decimal, entity.ChangesInNonCashCapital);


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

        public override void Update(CashFlowsFromOperatingActivities entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CashFlowsFromOperatingActivitiesRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.CashFlowStatmentID, DbType.Int32, entity.CashFlowStatmentID);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.NetIncomeBeforeTaxMinorityInterest, DbType.Decimal, entity.NetIncomeBeforeTaxMinorityInterest);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.DepreciationAmortization, DbType.Decimal, entity.DepreciationAmortization);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.InterestedPaid, DbType.Decimal, entity.InterestedPaid);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.InterestReceived, DbType.Decimal, entity.InterestReceived);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.TaxAndZakatPaid, DbType.Decimal, entity.TaxAndZakatPaid);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.MovementOnWoekingCapital, DbType.Decimal, entity.MovementOnWoekingCapital);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.ChangeInOperatingActivities, DbType.Decimal, entity.ChangeInOperatingActivities);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.ChangeInProvisions, DbType.Decimal, entity.ChangeInProvisions);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.Others, DbType.Decimal, entity.Others);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.OtherNonCashAdjustments, DbType.Decimal, entity.OtherNonCashAdjustments);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.ChangesInNonCashCapital, DbType.Decimal, entity.ChangesInNonCashCapital);

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

        public void DeleteByCashFlowStatmentID(int cashFlowStatmentID, ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CashFlowsFromOperatingActivitiesRepositoryConstants.SP_DeleteBYCashFlowStatmentID);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.CashFlowStatmentID, DbType.Int32, cashFlowStatmentID);


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

        public List<CashFlowsFromOperatingActivities> FindByCashFlowStatmentID(int cashFlowStatmentID, Common.ActionState actionState)
        {
            List<CashFlowsFromOperatingActivities> list;
            CashFlowsFromOperatingActivities entity;
            DbCommand cmd;

            list = new List<CashFlowsFromOperatingActivities>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(CashFlowsFromOperatingActivitiesRepositoryConstants.SP_FindBYCashFlowStatmentID);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.CashFlowStatmentID, DbType.Int32, cashFlowStatmentID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = CashFlowsFromOperatingActivitiesHelper(reader);
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

        public override List<CashFlowsFromOperatingActivities> FindAll(Common.ActionState actionState)
        {
            List<CashFlowsFromOperatingActivities> list;
            CashFlowsFromOperatingActivities entity;
            DbCommand cmd;

            list = new List<CashFlowsFromOperatingActivities>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(CashFlowsFromOperatingActivitiesRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = CashFlowsFromOperatingActivitiesHelper(reader);
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

        public override CashFlowsFromOperatingActivities FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            CashFlowsFromOperatingActivities entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(CashFlowsFromOperatingActivitiesRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, CashFlowsFromOperatingActivitiesRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = CashFlowsFromOperatingActivitiesHelper(reader);
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

        public override bool IsExist(CashFlowsFromOperatingActivities entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private CashFlowsFromOperatingActivities CashFlowsFromOperatingActivitiesHelper(SqlDataReader reader)
        {
            CashFlowsFromOperatingActivities entity = new CashFlowsFromOperatingActivities();
            entity.ID = Convert.ToInt32(reader[CashFlowsFromOperatingActivitiesConstants.ID]);
            entity.CashFlowStatmentID = Convert.ToInt32(reader[CashFlowsFromOperatingActivitiesConstants.CashFlowStatmentID]);
            CashFlowStatementRepository cashFlowStatementRepository = new CashFlowStatementRepository();
            entity.CashFlowStatement = cashFlowStatementRepository.FindByID(Convert.ToInt32(reader[CashFlowsFromOperatingActivitiesConstants.CashFlowStatmentID]), new Common.ActionState());
            entity.NetIncomeBeforeTaxMinorityInterest = (float)Convert.ToDouble(reader[CashFlowsFromOperatingActivitiesConstants.NetIncomeBeforeTaxMinorityInterest]);
            entity.DepreciationAmortization = (float)Convert.ToDouble(reader[CashFlowsFromOperatingActivitiesConstants.DepreciationAmortization]);
            entity.InterestedPaid = (float)Convert.ToDouble(reader[CashFlowsFromOperatingActivitiesConstants.InterestedPaid]);
            entity.InterestReceived = (float)Convert.ToDouble(reader[CashFlowsFromOperatingActivitiesConstants.InterestReceived]);
            entity.TaxAndZakatPaid = (float)Convert.ToDouble(reader[CashFlowsFromOperatingActivitiesConstants.TaxAndZakatPaid]);
            entity.MovementOnWoekingCapital = (float)Convert.ToDouble(reader[CashFlowsFromOperatingActivitiesConstants.MovementOnWoekingCapital]);
            entity.ChangeInOperatingActivities = (float)Convert.ToDouble(reader[CashFlowsFromOperatingActivitiesConstants.ChangeInOperatingActivities]);
            entity.ChangeInProvisions = (float)Convert.ToDouble(reader[CashFlowsFromOperatingActivitiesConstants.ChangeInProvisions]);
            entity.Others = (float)Convert.ToDouble(reader[CashFlowsFromOperatingActivitiesConstants.Others]);
            entity.OtherNonCashAdjustments = (float)Convert.ToDouble(reader[CashFlowsFromOperatingActivitiesConstants.OtherNonCashAdjustments]);
            entity.ChangesInNonCashCapital = (float)Convert.ToDouble(reader[CashFlowsFromOperatingActivitiesConstants.ChangesInNonCashCapital]);
            return entity;
        }
    }
}
