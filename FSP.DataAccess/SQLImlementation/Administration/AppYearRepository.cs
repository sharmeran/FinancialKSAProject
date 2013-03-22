using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Administration;
using FSP.Common.Entites.Administration;
using FSP.Common.Enums;
using FSP.DataAccess.BaseClasses;
using FSP.DataAccess.Constants.Administration;
using FSP.DataAccess.Constants.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace FSP.DataAccess.SQLImlementation.Administration
{
    public class AppYearRepository : RepositoryBaseClass<AppYear>
    {
        public override void Delete(AppYear entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(AppYearRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, AppYearRepositoryConstants.ID, DbType.String, entity.ID);


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

        public override void Insert(AppYear entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(AppYearRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, AppYearRepositoryConstants.Year, DbType.String, entity.Year);
                database.AddInParameter(cmd, AppYearRepositoryConstants.Quarter, DbType.Int32, entity.Quarter);

                spResult = database.ExecuteNonQuery(cmd);
                if (spResult > 0)
                {
                    actionState.SetSuccess();
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

        public override void Update(AppYear entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(AppYearRepositoryConstants.SP_Update);
                database.AddInParameter(cmd, AppYearRepositoryConstants.ID, DbType.String, entity.ID);
                database.AddInParameter(cmd, AppYearRepositoryConstants.Year, DbType.String, entity.Year);
                database.AddInParameter(cmd, AppYearRepositoryConstants.Quarter, DbType.Int32, entity.Quarter);

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

        public override List<AppYear> FindAll(Common.ActionState actionState)
        {
            List<AppYear> appYearList;
            AppYear appYearEntity;
            DbCommand cmd;

            appYearList = new List<AppYear>();
            appYearEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(AppYearRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        appYearEntity = AppYearHelper(reader);
                        if (appYearEntity != null)
                        {
                            appYearList.Add(appYearEntity);
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
            return appYearList;
        }

        public override AppYear FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            AppYear appYearEntity;
            DbCommand cmd;

            // Initialization
            appYearEntity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(AppYearRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, AppYearRepositoryConstants.ID, DbType.Int32, entityID);
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
                        appYearEntity = AppYearHelper(reader);
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
            return appYearEntity;
        }

        public override bool IsExist(AppYear entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private AppYear AppYearHelper(SqlDataReader reader)
        {
            AppYear appYear = new AppYear();
            appYear.ID = Convert.ToInt32(reader[AppYearConstants.ID]);
            appYear.Year = reader[AppYearConstants.Year].ToString();
            appYear.Quarter = Convert.ToInt32(reader[AppYearConstants.Quarter]);
            return appYear;
        }
    }
}
