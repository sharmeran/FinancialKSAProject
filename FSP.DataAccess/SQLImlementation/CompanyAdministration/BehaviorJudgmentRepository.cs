using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.CompanyAdministration;
using FSP.Common.Entites.CompanyAdministration;
using FSP.Common.Enums;
using FSP.DataAccess.BaseClasses;
using FSP.DataAccess.Constants.Common;
using FSP.DataAccess.Constants.CompanyAdministration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace FSP.DataAccess.SQLImlementation.CompanyAdministration
{
    public class BehaviorJudgmentRepository : RepositoryBaseClass<BehaviorJudgment>
    {
        public override void Delete(BehaviorJudgment entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(BehaviorJudgmentRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, BehaviorJudgmentRepositoryConstants.ID, DbType.String, entity.ID);


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

        public override void Insert(BehaviorJudgment entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(BehaviorJudgmentRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, BehaviorJudgmentRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, BehaviorJudgmentRepositoryConstants.Description, DbType.String , entity.Description);
                database.AddInParameter(cmd, BehaviorJudgmentRepositoryConstants.NameEnglish, DbType.String, entity.NameEnglish);
                database.AddInParameter(cmd, BehaviorJudgmentRepositoryConstants.DescriptionEnglish, DbType.String, entity.DescriptionEnglish);
                database.AddInParameter(cmd, BehaviorJudgmentRepositoryConstants.Value, DbType.Int32, entity.Value);


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

        public override void Update(BehaviorJudgment entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(BehaviorJudgmentRepositoryConstants.SP_Update);
                database.AddInParameter(cmd, BehaviorJudgmentRepositoryConstants.ID, DbType.String, entity.ID);
                database.AddInParameter(cmd, BehaviorJudgmentRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, BehaviorJudgmentRepositoryConstants.Description, DbType.String, entity.Description);
                database.AddInParameter(cmd, BehaviorJudgmentRepositoryConstants.NameEnglish, DbType.String, entity.NameEnglish);
                database.AddInParameter(cmd, BehaviorJudgmentRepositoryConstants.DescriptionEnglish, DbType.String, entity.DescriptionEnglish);
                database.AddInParameter(cmd, BehaviorJudgmentRepositoryConstants.Value, DbType.Int32, entity.Value);

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

        public override List<BehaviorJudgment> FindAll(Common.ActionState actionState)
        {
            List<BehaviorJudgment> behaviorJudgmentList;
            BehaviorJudgment behaviorJudgmentEntity;
            DbCommand cmd;

            behaviorJudgmentList = new List<BehaviorJudgment>();
            behaviorJudgmentEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(BehaviorJudgmentRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        behaviorJudgmentEntity = BehaviorJudgmentHelper(reader);
                        if (behaviorJudgmentEntity != null)
                        {
                            behaviorJudgmentList.Add(behaviorJudgmentEntity);
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
            return behaviorJudgmentList;
        }

        public override BehaviorJudgment FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            BehaviorJudgment behaviorJudgmentEntity;
            DbCommand cmd;

            // Initialization
            behaviorJudgmentEntity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(BehaviorJudgmentRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, BehaviorJudgmentRepositoryConstants.ID, DbType.Int32, entityID);
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
                        behaviorJudgmentEntity = BehaviorJudgmentHelper(reader);
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
            return behaviorJudgmentEntity;
        }

        public override bool IsExist(BehaviorJudgment entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private BehaviorJudgment BehaviorJudgmentHelper(SqlDataReader reader)
        {
            BehaviorJudgment behaviorJudgment = new BehaviorJudgment();
            behaviorJudgment.ID = Convert.ToInt32(reader[BehaviorJudgmentConstants.ID]);
            behaviorJudgment.Name = reader[BehaviorJudgmentConstants.Name].ToString();
            behaviorJudgment.Description = reader[BehaviorJudgmentConstants.Description].ToString();
            behaviorJudgment.DescriptionEnglish = reader[BehaviorJudgmentConstants.DescriptionEnglish].ToString();
            behaviorJudgment.NameEnglish = reader[BehaviorJudgmentConstants.NameEnglish].ToString();
            behaviorJudgment.Value = Convert.ToInt32(reader[BehaviorJudgmentConstants.Value]);
            return behaviorJudgment;
        }
    }
}
