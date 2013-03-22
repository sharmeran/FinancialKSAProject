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
    public class BehaviourRepository : RepositoryBaseClass<Behaviour>
    {
        public override void Delete(Behaviour entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(BehaviourRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, BehaviourRepositoryConstants.ID, DbType.String, entity.ID);


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

        public  void DeleteCompanyBehavioursByCompanyID(int companyID, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(BehaviourRepositoryConstants.SP_DeleteCompanyBehaviourByCompanyID);
                database.AddInParameter(cmd, BehaviourRepositoryConstants.CompanyID, DbType.String, companyID);


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

        public void InsertCompanyBehaviours(int companyID,int behaviourID, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(BehaviourRepositoryConstants.SP_InsertCompanyBehaviour);
                database.AddInParameter(cmd, BehaviourRepositoryConstants.CompanyID, DbType.String, companyID);
                database.AddInParameter(cmd, BehaviourRepositoryConstants.BehaviourID, DbType.String, behaviourID);

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

        public override void Insert(Behaviour entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(BehaviourRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, BehaviourRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, BehaviourRepositoryConstants.Description, DbType.String, entity.Description);
                database.AddInParameter(cmd, BehaviourRepositoryConstants.Judgment, DbType.Int32, entity.Judgment.ID);
                database.AddInParameter(cmd, BehaviourRepositoryConstants.NameEnglish, DbType.String, entity.NameEnglish);
                database.AddInParameter(cmd, BehaviourRepositoryConstants.DescriptionEnglish, DbType.String, entity.DescriptionEnglish);

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

        public override void Update(Behaviour entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(BehaviourRepositoryConstants.SP_Update);
                database.AddInParameter(cmd, BehaviourRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, BehaviourRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, BehaviourRepositoryConstants.Description, DbType.String, entity.Description);
                database.AddInParameter(cmd, BehaviourRepositoryConstants.Judgment, DbType.Int32, entity.Judgment.ID);
                database.AddInParameter(cmd, BehaviourRepositoryConstants.NameEnglish, DbType.String, entity.NameEnglish);
                database.AddInParameter(cmd, BehaviourRepositoryConstants.DescriptionEnglish, DbType.String, entity.DescriptionEnglish);

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

        public override List<Behaviour> FindAll(Common.ActionState actionState)
        {
            List<Behaviour> behaviourList;
            Behaviour behaviourEntity;
            DbCommand cmd;

            behaviourList = new List<Behaviour>();
            behaviourEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(BehaviourRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        behaviourEntity = BehaviourHelper(reader);
                        if (behaviourEntity != null)
                        {
                            behaviourList.Add(behaviourEntity);
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
            return behaviourList;
        }

        public  List<Behaviour> FindByCompanyID(int companyID, Common.ActionState actionState)
        {
            List<Behaviour> behaviourList;
            Behaviour behaviourEntity;
            DbCommand cmd;

            behaviourList = new List<Behaviour>();
            behaviourEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(BehaviourRepositoryConstants.SP_FindByCompanyID);
                database.AddInParameter(cmd, BehaviourRepositoryConstants.CompanyID, DbType.Int32, companyID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        behaviourEntity = BehaviourHelper(reader);
                        if (behaviourEntity != null)
                        {
                            behaviourList.Add(behaviourEntity);
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
            return behaviourList;
        }

        public override Behaviour FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            Behaviour behaviourEntity;
            DbCommand cmd;

            // Initialization
            behaviourEntity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(BehaviourRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, BehaviourRepositoryConstants.ID, DbType.Int32, entityID);
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
                        behaviourEntity = BehaviourHelper(reader);
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
            return behaviourEntity;
        }

        public override bool IsExist(Behaviour entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private Behaviour BehaviourHelper(SqlDataReader reader)
        {
            Behaviour behaviour = new Behaviour();
            behaviour.ID = Convert.ToInt32(reader[BehaviourConstants.ID]);
            behaviour.Name = reader[BehaviourConstants.Name].ToString();
            behaviour.Description = reader[BehaviourConstants.Description].ToString();
            BehaviorJudgmentRepository behaviorJudgmentRepository = new BehaviorJudgmentRepository();
            behaviour.Judgment = behaviorJudgmentRepository.FindByID(Convert.ToInt32(reader[BehaviourConstants.JudgmentID]), new Common.ActionState());
            behaviour.NameEnglish = reader[BehaviourConstants.NameEnglish].ToString();
            behaviour.DescriptionEnglish = reader[BehaviourConstants.DescriptionEnglish].ToString();
            return behaviour;
        }
    }

}
