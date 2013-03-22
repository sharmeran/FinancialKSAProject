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
    public class AccessListRepository : RepositoryBaseClass<AccessList>
    {
        public override void Delete(AccessList entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(AccessListRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, AccessListRepositoryConstants.ID,DbType.String, entity.ID);


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

        public override void Insert(AccessList entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(AccessListRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, AccessListRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, AccessListRepositoryConstants.Description, DbType.String, entity.Description);

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

        public override void Update(AccessList entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(AccessListRepositoryConstants.SP_Update);
                database.AddInParameter(cmd, AccessListRepositoryConstants.ID, DbType.String, entity.ID);
                database.AddInParameter(cmd, AccessListRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, AccessListRepositoryConstants.Description, DbType.String, entity.Description);

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
        public override List<AccessList> FindAll(Common.ActionState actionState)
        {
            List<AccessList> accessList;
            AccessList accessListEntity;
            DbCommand cmd;

            accessList = new List<AccessList>();
            accessListEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(AccessListRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        accessListEntity = AccessListHelper(reader);
                        if (accessListEntity != null)
                        {
                            accessList.Add(accessListEntity);
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
            return accessList;
        }

        public  List<AccessList> FindByGroupID(int groupID, Common.ActionState actionState)
        {
            List<AccessList> accessList;
            AccessList accessListEntity;
            DbCommand cmd;

            accessList = new List<AccessList>();
            accessListEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(GroupRepositoryConstants.GroupAccessListFind);
                database.AddInParameter(cmd, GroupRepositoryConstants.GroupID, DbType.Int32, groupID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        accessListEntity = AccessListHelper(reader);
                        if (accessListEntity != null)
                        {
                            accessList.Add(accessListEntity);
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
            return accessList;
        }

        public override AccessList FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            AccessList accessListEntity;
            DbCommand cmd;

            // Initialization
            accessListEntity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(AccessListRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, AccessListRepositoryConstants.ID, DbType.Int32, entityID);
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
                        accessListEntity = AccessListHelper(reader);
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
            return accessListEntity;
        }

        public override bool IsExist(AccessList entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private AccessList AccessListHelper(SqlDataReader reader)
        {
            AccessList accessList = new AccessList();
            accessList.ID = Convert.ToInt32(reader[AccessListConstants.ID]);
            accessList.Name = reader[AccessListConstants.Name].ToString();
            accessList.Description = reader[AccessListConstants.Description].ToString();
            return accessList;
        }
    }
}
