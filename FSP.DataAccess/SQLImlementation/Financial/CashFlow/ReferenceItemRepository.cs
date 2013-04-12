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
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.CashFlowStatementID, DbType.Int32, entity.CashFlowStatementID);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.EBITDA, DbType.Decimal, entity.EBITDA);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.NetCashPaidForAcquisitions, DbType.Decimal, entity.NetCashPaidForAcquisitions);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.FreeCashFlow, DbType.Decimal, entity.FreeCashFlow);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.FreeCashFlowToFirm, DbType.Decimal, entity.FreeCashFlowToFirm);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.FreeCashFlowEquity, DbType.Decimal, entity.FreeCashFlowEquity);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.FreeCashFlowBasicShare, DbType.Decimal, entity.FreeCashFlowBasicShare);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.PriceFreeCashFlow, DbType.Decimal, entity.PriceFreeCashFlow);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.CashFlowNetIncome, DbType.Decimal, entity.CashFlowNetIncome);


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
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.CashFlowStatementID, DbType.Int32, entity.CashFlowStatementID);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.EBITDA, DbType.Decimal, entity.EBITDA);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.NetCashPaidForAcquisitions, DbType.Decimal, entity.NetCashPaidForAcquisitions);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.FreeCashFlow, DbType.Decimal, entity.FreeCashFlow);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.FreeCashFlowToFirm, DbType.Decimal, entity.FreeCashFlowToFirm);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.FreeCashFlowEquity, DbType.Decimal, entity.FreeCashFlowEquity);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.FreeCashFlowBasicShare, DbType.Decimal, entity.FreeCashFlowBasicShare);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.PriceFreeCashFlow, DbType.Decimal, entity.PriceFreeCashFlow);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.CashFlowNetIncome, DbType.Decimal, entity.CashFlowNetIncome);

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

        public List<ReferenceItem> FindByCashFlowStatmentID(int cashFlowStatmentID, Common.ActionState actionState)
        {
            List<ReferenceItem> list;
            ReferenceItem entity;
            DbCommand cmd;

            list = new List<ReferenceItem>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(ReferenceItemRepositoryConstants.SP_FindBYCashFlowStatmentID);
                database.AddInParameter(cmd, ReferenceItemRepositoryConstants.CashFlowStatementID, DbType.Int32, cashFlowStatmentID);
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
            entity.CashFlowStatementID = Convert.ToInt32(reader[ReferenceItemConstants.CashFlowStatementID]);
            CashFlowStatementRepository cashFlowStatementRepository = new CashFlowStatementRepository();
            entity.CashFlowStatement = cashFlowStatementRepository.FindByID(Convert.ToInt32(reader[ReferenceItemConstants.CashFlowStatementID]), new Common.ActionState());
            entity.EBITDA = (float)Convert.ToDouble(reader[ReferenceItemConstants.EBITDA]);
            entity.NetCashPaidForAcquisitions = (float)Convert.ToDouble(reader[ReferenceItemConstants.NetCashPaidForAcquisitions]);
            entity.FreeCashFlow = (float)Convert.ToDouble(reader[ReferenceItemConstants.FreeCashFlow]);
            entity.FreeCashFlowToFirm = (float)Convert.ToDouble(reader[ReferenceItemConstants.FreeCashFlowToFirm]);
            entity.FreeCashFlowEquity = (float)Convert.ToDouble(reader[ReferenceItemConstants.FreeCashFlowEquity]);
            entity.FreeCashFlowBasicShare = (float)Convert.ToDouble(reader[ReferenceItemConstants.FreeCashFlowBasicShare]);
            entity.PriceFreeCashFlow = (float)Convert.ToDouble(reader[ReferenceItemConstants.PriceFreeCashFlow]);
            entity.CashFlowNetIncome = (float)Convert.ToDouble(reader[ReferenceItemConstants.CashFlowNetIncome]);
            return entity;
        }
    }
}
