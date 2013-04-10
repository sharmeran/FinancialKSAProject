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
    public class CashCashEquivalentPeriodEndRepository : RepositoryBaseClass<CashCashEquivalentPeriodEnd>
    {
        public override void Delete(CashCashEquivalentPeriodEnd entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CashCashEquivalentPeriodEndRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, CashCashEquivalentPeriodEndRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(CashCashEquivalentPeriodEnd entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CashCashEquivalentPeriodEndRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, CashCashEquivalentPeriodEndRepositoryConstants.CashFlowStatementID, DbType.Int32, entity.CashFlowStatementID);
                database.AddInParameter(cmd, CashCashEquivalentPeriodEndRepositoryConstants.NetChangeCashCashEquivalents, DbType.Decimal, entity.NetChangeCashCashEquivalents);
                database.AddInParameter(cmd, CashCashEquivalentPeriodEndRepositoryConstants.CashCashEquivalentAtStartOfPeriod, DbType.Decimal, entity.CashCashEquivalentAtStartOfPeriod);


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

        public override void Update(CashCashEquivalentPeriodEnd entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CashCashEquivalentPeriodEndRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, CashCashEquivalentPeriodEndRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, CashCashEquivalentPeriodEndRepositoryConstants.CashFlowStatementID, DbType.Int32, entity.CashFlowStatementID);
                database.AddInParameter(cmd, CashCashEquivalentPeriodEndRepositoryConstants.NetChangeCashCashEquivalents, DbType.Decimal, entity.NetChangeCashCashEquivalents);
                database.AddInParameter(cmd, CashCashEquivalentPeriodEndRepositoryConstants.CashCashEquivalentAtStartOfPeriod, DbType.Decimal, entity.CashCashEquivalentAtStartOfPeriod);

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

        public override List<CashCashEquivalentPeriodEnd> FindAll(Common.ActionState actionState)
        {
            List<CashCashEquivalentPeriodEnd> list;
            CashCashEquivalentPeriodEnd entity;
            DbCommand cmd;

            list = new List<CashCashEquivalentPeriodEnd>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(CashCashEquivalentPeriodEndRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = CashCashEquivalentPeriodEndHelper(reader);
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

        public override CashCashEquivalentPeriodEnd FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            CashCashEquivalentPeriodEnd entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(CashCashEquivalentPeriodEndRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, CashCashEquivalentPeriodEndRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = CashCashEquivalentPeriodEndHelper(reader);
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

        public override bool IsExist(CashCashEquivalentPeriodEnd entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private CashCashEquivalentPeriodEnd CashCashEquivalentPeriodEndHelper(SqlDataReader reader)
        {
            CashCashEquivalentPeriodEnd entity = new CashCashEquivalentPeriodEnd();
            entity.ID = Convert.ToInt32(reader[CashCashEquivalentPeriodEndConstants.ID]);
            entity.CashFlowStatementID = Convert.ToInt32(reader[CashCashEquivalentPeriodEndConstants.CashFlowStatementID]);
            CashFlowStatementRepository cashFlowStatementRepository = new CashFlowStatementRepository();
            entity.CashFlowStatement = cashFlowStatementRepository.FindByID(Convert.ToInt32(reader[CashCashEquivalentPeriodEndConstants.CashFlowStatementID]), new Common.ActionState());
            entity.NetChangeCashCashEquivalents = (float)Convert.ToDouble(reader[CashCashEquivalentPeriodEndConstants.NetChangeCashCashEquivalents]);
            entity.CashCashEquivalentAtStartOfPeriod = (float)Convert.ToDouble(reader[CashCashEquivalentPeriodEndConstants.CashCashEquivalentAtStartOfPeriod]);
            return entity;
        }
    }
}
