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
    public class SubsidiaryCompanyRepository : RepositoryBaseClass<SubsidiaryCompany>
    {
        public override void Delete(SubsidiaryCompany entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(SubsidiaryCompanyRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(SubsidiaryCompany entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(SubsidiaryCompanyRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.Description, DbType.String, entity.Description);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.NameEnglish, DbType.String, entity.NameEnglish);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.DescriptionEnglish, DbType.String, entity.DescriptionEnglish);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.Place, DbType.String, entity.Place);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.PlaceEnglish, DbType.String, entity.PlaceEnglish);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.EstablishDate, DbType.Date, entity.EstablishDate);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.CompanyID, DbType.Int32, entity.CompanyID);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.IsOutKSA, DbType.Boolean, entity.IsOutKSA);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.OwnPercentage, DbType.Decimal, entity.OwnPercentage);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.FollowDate, DbType.Date, entity.FollowDate);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.Note, DbType.String, entity.Note);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.NoteEnglish, DbType.String, entity.NoteEnglish);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.Sector, DbType.Int32, entity.Sector.ID);

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

        public override void Update(SubsidiaryCompany entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(SubsidiaryCompanyRepositoryConstants.SP_Update);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.ID, DbType.String, entity.ID);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.Description, DbType.String, entity.Description);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.NameEnglish, DbType.String, entity.NameEnglish);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.DescriptionEnglish, DbType.String, entity.DescriptionEnglish);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.Place, DbType.String, entity.Place);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.PlaceEnglish, DbType.String, entity.PlaceEnglish);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.EstablishDate, DbType.Date, entity.EstablishDate);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.CompanyID, DbType.Int32, entity.CompanyID);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.IsOutKSA, DbType.Boolean, entity.IsOutKSA);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.OwnPercentage, DbType.Decimal, entity.OwnPercentage);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.FollowDate, DbType.Date, entity.FollowDate);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.Note, DbType.String, entity.Note);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.NoteEnglish, DbType.String, entity.NoteEnglish);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.Sector, DbType.Int32, entity.Sector.ID);

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

        public override List<SubsidiaryCompany> FindAll(Common.ActionState actionState)
        {
            List<SubsidiaryCompany> subsidiaryCompanyList;
            SubsidiaryCompany subsidiaryCompanyEntity;
            DbCommand cmd;

            subsidiaryCompanyList = new List<SubsidiaryCompany>();
            subsidiaryCompanyEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(SubsidiaryCompanyRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        subsidiaryCompanyEntity = SubsidiaryCompanyHelper(reader);
                        if (subsidiaryCompanyEntity != null)
                        {
                            subsidiaryCompanyList.Add(subsidiaryCompanyEntity);
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
            return subsidiaryCompanyList;
        }

        public  List<SubsidiaryCompany> FindByCompanyID(int companyID, Common.ActionState actionState)
        {
            List<SubsidiaryCompany> subsidiaryCompanyList;
            SubsidiaryCompany subsidiaryCompanyEntity;
            DbCommand cmd;

            subsidiaryCompanyList = new List<SubsidiaryCompany>();
            subsidiaryCompanyEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(SubsidiaryCompanyRepositoryConstants.SP_FindByCompanyID);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.CompanyID, DbType.Int32, companyID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        subsidiaryCompanyEntity = SubsidiaryCompanyHelper(reader);
                        if (subsidiaryCompanyEntity != null)
                        {
                            subsidiaryCompanyList.Add(subsidiaryCompanyEntity);
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
            return subsidiaryCompanyList;
        }

        public override SubsidiaryCompany FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            SubsidiaryCompany subsidiaryCompanyEntity;
            DbCommand cmd;

            // Initialization
            subsidiaryCompanyEntity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(SubsidiaryCompanyRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, SubsidiaryCompanyRepositoryConstants.ID, DbType.Int32, entityID);
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
                        subsidiaryCompanyEntity = SubsidiaryCompanyHelper(reader);
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
            return subsidiaryCompanyEntity;
        }

        public override bool IsExist(SubsidiaryCompany entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private SubsidiaryCompany SubsidiaryCompanyHelper(SqlDataReader reader)
        {
            SubsidiaryCompany subsidiaryCompany = new SubsidiaryCompany();
            subsidiaryCompany.CompanyID = Convert.ToInt32(reader[SubsidiaryCompanyConstants.CompanyID]);
            subsidiaryCompany.Description = reader[SubsidiaryCompanyConstants.Description].ToString();
            subsidiaryCompany.DescriptionEnglish = reader[SubsidiaryCompanyConstants.DescriptionEnglish].ToString();
            if(reader[SubsidiaryCompanyConstants.EstablishDate]!=DBNull.Value)
            subsidiaryCompany.EstablishDate = Convert.ToDateTime(reader[SubsidiaryCompanyConstants.EstablishDate]);
            if (reader[SubsidiaryCompanyConstants.FollowDate] != DBNull.Value)
            subsidiaryCompany.FollowDate = Convert.ToDateTime(reader[SubsidiaryCompanyConstants.FollowDate]);
            subsidiaryCompany.ID = Convert.ToInt32(reader[SubsidiaryCompanyConstants.ID]);
            subsidiaryCompany.IsOutKSA = Convert.ToBoolean(reader[SubsidiaryCompanyConstants.IsOutKSA]);
            subsidiaryCompany.Name = reader[SubsidiaryCompanyConstants.Name].ToString();
            subsidiaryCompany.NameEnglish = reader[SubsidiaryCompanyConstants.NameEnglish].ToString();
            subsidiaryCompany.Note = reader[SubsidiaryCompanyConstants.Note].ToString();
            subsidiaryCompany.NoteEnglish = reader[SubsidiaryCompanyConstants.NoteEnglish].ToString();
            subsidiaryCompany.OwnPercentage = (float)Convert.ToDecimal(reader[SubsidiaryCompanyConstants.OwnPercentage]);
            subsidiaryCompany.Place = reader[SubsidiaryCompanyConstants.Place].ToString();
            subsidiaryCompany.PlaceEnglish = reader[SubsidiaryCompanyConstants.PlaceEnglish].ToString();
            SectorRepository sectorRepository = new SectorRepository();
            subsidiaryCompany.Sector = sectorRepository.FindByID(Convert.ToInt32(reader[SubsidiaryCompanyConstants.Sector]), new Common.ActionState());
            return subsidiaryCompany;
        }
    }
}
