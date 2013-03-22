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
    public class UserRepository : RepositoryBaseClass<User>
    {
        public override void Delete(User entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(UserRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, UserRepositoryConstants.ID, DbType.String, entity.ID);


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

        public override void Insert(User entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(UserRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, UserRepositoryConstants.Username, DbType.String, entity.Username);
                database.AddInParameter(cmd, UserRepositoryConstants.Password, DbType.String, entity.Password);
                database.AddInParameter(cmd, UserRepositoryConstants.FullName, DbType.String, entity.FullName);
                database.AddInParameter(cmd, UserRepositoryConstants.Group, DbType.String, entity.Group.ID);
                database.AddInParameter(cmd, UserRepositoryConstants.Phone, DbType.String, entity.Phone);
                database.AddInParameter(cmd, UserRepositoryConstants.Email, DbType.String, entity.Email);

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

        public override void Update(User entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(UserRepositoryConstants.SP_Update);
                database.AddInParameter(cmd, UserRepositoryConstants.ID, DbType.String, entity.ID);
                database.AddInParameter(cmd, UserRepositoryConstants.Username, DbType.String, entity.Username);
                database.AddInParameter(cmd, UserRepositoryConstants.Password, DbType.String, entity.Password);
                database.AddInParameter(cmd, UserRepositoryConstants.FullName, DbType.String, entity.FullName);
                database.AddInParameter(cmd, UserRepositoryConstants.Group, DbType.String, entity.Group.ID);
                database.AddInParameter(cmd, UserRepositoryConstants.Phone, DbType.String, entity.Phone);
                database.AddInParameter(cmd, UserRepositoryConstants.Email, DbType.String, entity.Email);

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

        public override List<User> FindAll(Common.ActionState actionState)
        {
            List<User> userList;
            User userEntity;
            DbCommand cmd;

            userList = new List<User>();
            userEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(UserRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        userEntity = UserHelper(reader, false);
                        if (userEntity != null)
                        {
                            userList.Add(userEntity);
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
            return userList;
        }

        public override User FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            User userEntity;
            DbCommand cmd;

            // Initialization
            userEntity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(UserRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, UserRepositoryConstants.ID, DbType.Int32, entityID);
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
                        userEntity = UserHelper(reader, true);
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
            return userEntity;
        }

        public  User CheckUserLogin(string username, string password, Common.ActionState actionState)
        {
            // Declaration 
            User userEntity;
            DbCommand cmd;

            // Initialization
            userEntity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(UserRepositoryConstants.SP_CheckUserLogin);
                database.AddInParameter(cmd, UserRepositoryConstants.Username, DbType.String, username);
                database.AddInParameter(cmd, UserRepositoryConstants.Password, DbType.String, password);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    if (!reader.HasRows)
                    {
                        actionState.SetFail(ActionStatusEnum.NotFound, LocalizationConstants.Err_FaildLogin);
                    }
                    else
                    {
                        actionState.SetSuccess();
                        reader.Read();
                        userEntity = UserHelper(reader, true);
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
            return userEntity;
        }

        public override bool IsExist(User entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private User UserHelper(SqlDataReader reader, bool isFull)
        {
            User user = new User();
            user.Username = reader[UserConstants.Username].ToString();
            user.Password = reader[UserConstants.Password].ToString();
            user.FullName = reader[UserConstants.FullName].ToString();
            user.Phone = reader[UserConstants.Phone].ToString();
            user.Email = reader[UserConstants.Email].ToString();
            if (isFull)
            {
                GroupRepository groupRepository = new GroupRepository();

                user.Group = groupRepository.FindByID(Convert.ToInt32(reader[UserConstants.Group]), new Common.ActionState());
            }
            return user;
        }
    }
}
