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
    public class PermissionRepository : RepositoryBaseClass<Permission>
    {
        public override void Delete(Permission entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(PermissionRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, PermissionRepositoryConstants.ID, DbType.String, entity.ID);


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

        public override void Insert(Permission entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(PermissionRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, PermissionRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, PermissionRepositoryConstants.Description, DbType.String, entity.Description);

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

        public override void Update(Permission entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(PermissionRepositoryConstants.SP_Update);
                database.AddInParameter(cmd, PermissionRepositoryConstants.ID, DbType.String, entity.ID);
                database.AddInParameter(cmd, PermissionRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, PermissionRepositoryConstants.Description, DbType.String, entity.Description);

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

        public override List<Permission> FindAll(Common.ActionState actionState)
        {
            List<Permission> permissionList;
            Permission permissionEntity;
            DbCommand cmd;

            permissionList = new List<Permission>();
            permissionEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(PermissionRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        permissionEntity = PermissionHelper(reader);
                        if (permissionEntity != null)
                        {
                            permissionList.Add(permissionEntity);
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
            return permissionList;
        }

        public  List<Permission> FindByGroupID(int groupID, Common.ActionState actionState)
        {
            List<Permission> permissionList;
            Permission permissionEntity;
            DbCommand cmd;

            permissionList = new List<Permission>();
            permissionEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(GroupRepositoryConstants.GroupPermissionFind);
                database.AddInParameter(cmd, GroupRepositoryConstants.GroupID, DbType.Int32, groupID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        permissionEntity = PermissionHelper(reader);
                        if (permissionEntity != null)
                        {
                            permissionList.Add(permissionEntity);
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
            return permissionList;
        }

        public override Permission FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            Permission permissionEntity;
            DbCommand cmd;

            // Initialization
            permissionEntity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(PermissionRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, PermissionRepositoryConstants.ID, DbType.Int32, entityID);
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
                        permissionEntity = PermissionHelper(reader);
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
            return permissionEntity;
        }

        public override bool IsExist(Permission entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private Permission PermissionHelper(SqlDataReader reader)
        {
            Permission permission = new Permission();
            permission.ID = Convert.ToInt32(reader[PermissionConstants.ID]);
            permission.Name = reader[PermissionConstants.Name].ToString();
            permission.Description = reader[PermissionConstants.Description].ToString();
            return permission;
        }
    }
}
