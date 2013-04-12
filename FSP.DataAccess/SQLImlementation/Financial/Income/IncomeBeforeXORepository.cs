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
    public class IncomeBeforeXORepository : RepositoryBaseClass<IncomeBeforeXO>
    {
        public override void Delete(IncomeBeforeXO entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(IncomeBeforeXORepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, IncomeBeforeXORepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(IncomeBeforeXO entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(IncomeBeforeXORepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, IncomeBeforeXORepositoryConstants.IncomeStatmentID, DbType.Int32, entity.IncomeStatmentID);
                database.AddInParameter(cmd, IncomeBeforeXORepositoryConstants.IncomeBeforeXOItems, DbType.Int32, entity.IncomeBeforeXOItems);
                database.AddInParameter(cmd, IncomeBeforeXORepositoryConstants.ExtraordinaryLossNetof, DbType.Int32, entity.ExtraordinaryLossNetof);
                database.AddInParameter(cmd, IncomeBeforeXORepositoryConstants.NetProfitBeforeMinority, DbType.Decimal, entity.NetProfitBeforeMinority);
                database.AddInParameter(cmd, IncomeBeforeXORepositoryConstants.MinorityInterests, DbType.Int32, entity.MinorityInterests);


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

        public override void Update(IncomeBeforeXO entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(IncomeBeforeXORepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, IncomeBeforeXORepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, IncomeBeforeXORepositoryConstants.IncomeStatmentID, DbType.Int32, entity.IncomeStatmentID);
                database.AddInParameter(cmd, IncomeBeforeXORepositoryConstants.IncomeBeforeXOItems, DbType.Int32, entity.IncomeBeforeXOItems);
                database.AddInParameter(cmd, IncomeBeforeXORepositoryConstants.ExtraordinaryLossNetof, DbType.Int32, entity.ExtraordinaryLossNetof);
                database.AddInParameter(cmd, IncomeBeforeXORepositoryConstants.NetProfitBeforeMinority, DbType.Decimal, entity.NetProfitBeforeMinority);
                database.AddInParameter(cmd, IncomeBeforeXORepositoryConstants.MinorityInterests, DbType.Int32, entity.MinorityInterests);

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

        public override List<IncomeBeforeXO> FindAll(Common.ActionState actionState)
        {
            List<IncomeBeforeXO> list;
            IncomeBeforeXO entity;
            DbCommand cmd;

            list = new List<IncomeBeforeXO>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(IncomeBeforeXORepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = IncomeBeforeXOHelper(reader);
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

        public List<IncomeBeforeXO> FindByIncomeStatmentID(int incomeStatmentID, Common.ActionState actionState)
        {
            List<IncomeBeforeXO> list;
            IncomeBeforeXO entity;
            DbCommand cmd;

            list = new List<IncomeBeforeXO>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(IncomeBeforeXORepositoryConstants.SP_FindBYIncomeStatmentID);
                database.AddInParameter(cmd, IncomeBeforeXORepositoryConstants.IncomeStatmentID, DbType.Int32, incomeStatmentID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = IncomeBeforeXOHelper(reader);
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

        public override IncomeBeforeXO FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            IncomeBeforeXO entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(IncomeBeforeXORepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, IncomeBeforeXORepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = IncomeBeforeXOHelper(reader);
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

        public override bool IsExist(IncomeBeforeXO entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private IncomeBeforeXO IncomeBeforeXOHelper(SqlDataReader reader)
        {
            IncomeBeforeXO entity = new IncomeBeforeXO();
            entity.ID = Convert.ToInt32(reader[IncomeBeforeXOConstants.ID]);
            entity.IncomeStatmentID = Convert.ToInt32(reader[IncomeBeforeXOConstants.IncomeStatmentID]);
            IncomeStatmentRepository incomeStatmentRepository = new IncomeStatmentRepository();
            entity.IncomeStatment = incomeStatmentRepository.FindByID(Convert.ToInt32(reader[IncomeBeforeXOConstants.IncomeStatmentID]), new Common.ActionState());
            entity.NetProfitBeforeMinority = (float)Convert.ToDouble(reader[IncomeBeforeXOConstants.NetProfitBeforeMinority]);
            entity.IncomeBeforeXOItems = Convert.ToInt32(reader[IncomeBeforeXOConstants.IncomeBeforeXOItems]);
            entity.ExtraordinaryLossNetof = Convert.ToInt32(reader[IncomeBeforeXOConstants.ExtraordinaryLossNetof]);
            entity.MinorityInterests = Convert.ToInt32(reader[IncomeBeforeXOConstants.MinorityInterests]);
            return entity;
        }
    }
}
