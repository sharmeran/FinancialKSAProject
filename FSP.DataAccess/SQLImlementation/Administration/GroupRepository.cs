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
    public class GroupRepository : RepositoryBaseClass<Group>
    {
        public override void Delete(Group entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(GroupRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, GroupRepositoryConstants.ID, DbType.String, entity.ID);

                DeleteGroupSecurity(entity);
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

        public  void DeleteGroupAccessList(int  groupID, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(GroupRepositoryConstants.GroupAccessListDelete);
                database.AddInParameter(cmd, GroupRepositoryConstants.GroupID, DbType.Int32, groupID);


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
        public void DeleteGroupPermission(int groupID, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(GroupRepositoryConstants.GroupPermissionDelete);
                database.AddInParameter(cmd, GroupRepositoryConstants.GroupID, DbType.Int32, groupID);


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

        public override void Insert(Group entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(GroupRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, GroupRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, GroupRepositoryConstants.Description, DbType.String, entity.Description);                
                entity.ID =Convert.ToInt32( database.ExecuteScalar(cmd));
                if (entity.ID > 0)
                {
                    UpdateGroupSecurity(entity);
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

        public  void InsertGroupAccessList(int groupID, int accessListID , Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(GroupRepositoryConstants.GroupAccessListInsert);
                database.AddInParameter(cmd, GroupRepositoryConstants.GroupID, DbType.Int32, groupID);
                database.AddInParameter(cmd, GroupRepositoryConstants.AccessListID, DbType.Int32, accessListID);
                
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

        public void InsertGroupPermission(int groupID, int permissionID, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(GroupRepositoryConstants.GroupPermissionInsert);
                database.AddInParameter(cmd, GroupRepositoryConstants.GroupID, DbType.Int32, groupID);
                database.AddInParameter(cmd, GroupRepositoryConstants.PermissionID, DbType.Int32, permissionID);

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

        public void UpdateGroupSecurity(Group entity)
        {
            DeleteGroupAccessList(entity.ID, new Common.ActionState());
            DeleteGroupPermission(entity.ID, new Common.ActionState());
            for (int i = 0; i < entity.AccessList.Count; i++)
            {
                InsertGroupAccessList(entity.ID, entity.AccessList[i].ID, new Common.ActionState());
            }

            for (int j = 0; j < entity.Permissions.Count; j++)
            {
                InsertGroupPermission(entity.ID, entity.Permissions[j].ID, new Common.ActionState());
            }
        }

        public void DeleteGroupSecurity(Group entity)
        {
            DeleteGroupAccessList(entity.ID, new Common.ActionState());
            DeleteGroupPermission(entity.ID, new Common.ActionState());
        }

        public override void Update(Group entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(GroupRepositoryConstants.SP_Update);
                database.AddInParameter(cmd, GroupRepositoryConstants.ID, DbType.String, entity.ID);
                database.AddInParameter(cmd, GroupRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, GroupRepositoryConstants.Description, DbType.String, entity.Description);
                UpdateGroupSecurity(entity);
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

        public override List<Group> FindAll(Common.ActionState actionState)
        {
            List<Group> groupList;
            Group groupEntity;
            DbCommand cmd;

            groupList = new List<Group>();
            groupEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(GroupRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        groupEntity = GroupHelper(reader, false);
                        if (groupEntity != null)
                        {
                            groupList.Add(groupEntity);
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
            return groupList;
        }

        public override Group FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            Group groupEntity;
            DbCommand cmd;

            // Initialization
            groupEntity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(GroupRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, GroupRepositoryConstants.ID, DbType.Int32, entityID);
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
                        groupEntity = GroupHelper(reader, true);
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
            return groupEntity;
        }

        public override bool IsExist(Group entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private Group GroupHelper(SqlDataReader reader, bool isFull)
        {
            Group group = new Group();
            group.ID = Convert.ToInt32(reader[GroupConstants.ID]);
            group.Name = reader[GroupConstants.Name].ToString();
            group.Description = reader[GroupConstants.Description].ToString();
            if (isFull)
            {
                
                AccessListRepository accessListRepository = new AccessListRepository();
                group.AccessList = accessListRepository.FindByGroupID(group.ID, new Common.ActionState());
                PermissionRepository permissionRepository = new PermissionRepository();
                group.Permissions = permissionRepository.FindByGroupID(group.ID, new Common.ActionState());
            }
            return group;
        }
    }
}
