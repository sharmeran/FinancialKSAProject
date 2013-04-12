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
    public class SisterCompanyRepository : RepositoryBaseClass<SisterCompany>
    {
        public override void Delete(SisterCompany entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(SisterCompanyRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.ID, DbType.String, entity.ID);


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

        public override void Insert(SisterCompany entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(SisterCompanyRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.Description, DbType.String, entity.Description);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.NameEnglish, DbType.String, entity.NameEnglish);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.DescriptionEnglish, DbType.String, entity.DescriptionEnglish);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.Place, DbType.String, entity.Place);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.PlaceEnglish, DbType.String, entity.PlaceEnglish);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.EstablishDate, DbType.Date, entity.EstablishDate);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.Company, DbType.Int32, entity.CompanyID);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.IsOutKsa, DbType.Boolean, entity.IsOutKSA);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.Sector, DbType.Int32, entity.Sector.ID);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.OwnPercentage, DbType.Decimal, entity.OwnerPercentage);

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

        public override void Update(SisterCompany entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(SisterCompanyRepositoryConstants.SP_Update);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.ID, DbType.String, entity.ID);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.Description, DbType.String, entity.Description);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.NameEnglish, DbType.String, entity.NameEnglish);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.DescriptionEnglish, DbType.String, entity.DescriptionEnglish);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.Place, DbType.String, entity.Place);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.PlaceEnglish, DbType.String, entity.PlaceEnglish);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.EstablishDate, DbType.Date, entity.EstablishDate);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.Company, DbType.Int32, entity.CompanyID);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.IsOutKsa, DbType.Boolean, entity.IsOutKSA);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.Sector, DbType.Int32, entity.Sector.ID);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.OwnPercentage, DbType.Decimal, entity.OwnerPercentage);

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

        public override List<SisterCompany> FindAll(Common.ActionState actionState)
        {
            List<SisterCompany> sisterCompanyList;
            SisterCompany sisterCompanyEntity;
            DbCommand cmd;

            sisterCompanyList = new List<SisterCompany>();
            sisterCompanyEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(SisterCompanyRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        sisterCompanyEntity = SisterCompanyHelper(reader);
                        if (sisterCompanyEntity != null)
                        {
                            sisterCompanyList.Add(sisterCompanyEntity);
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
            return sisterCompanyList;
        }

        public  List<SisterCompany> FindByCompanyID(int companyID, Common.ActionState actionState)
        {
            List<SisterCompany> sisterCompanyList;
            SisterCompany sisterCompanyEntity;
            DbCommand cmd;

            sisterCompanyList = new List<SisterCompany>();
            sisterCompanyEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(SisterCompanyRepositoryConstants.SP_FindByCompanyID);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.Company, DbType.Int32, companyID);

                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        sisterCompanyEntity = SisterCompanyHelper(reader);
                        if (sisterCompanyEntity != null)
                        {
                            sisterCompanyList.Add(sisterCompanyEntity);
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
            return sisterCompanyList;
        }

        public override SisterCompany FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            SisterCompany sisterCompanyEntity;
            DbCommand cmd;

            // Initialization
            sisterCompanyEntity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(SisterCompanyRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, SisterCompanyRepositoryConstants.ID, DbType.Int32, entityID);
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
                        sisterCompanyEntity = SisterCompanyHelper(reader);
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
            return sisterCompanyEntity;
        }

        public override bool IsExist(SisterCompany entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private SisterCompany SisterCompanyHelper(SqlDataReader reader)
        {
            SisterCompany sisterCompany = new SisterCompany();       
            sisterCompany.CompanyID = Convert.ToInt32(reader[SisterCompanyConstants.Company]);
            sisterCompany.Description = reader[SisterCompanyConstants.Description].ToString();
            sisterCompany.DescriptionEnglish = reader[SisterCompanyConstants.DescriptionEnglish].ToString();
            if(reader[SisterCompanyConstants.EstablishDate]!= DBNull.Value)
            sisterCompany.EstablishDate = Convert.ToDateTime(reader[SisterCompanyConstants.EstablishDate]);
            sisterCompany.ID = Convert.ToInt32(reader[SisterCompanyConstants.ID]);
            sisterCompany.IsOutKSA = Convert.ToBoolean(reader[SisterCompanyConstants.IsOutKsa]);
            sisterCompany.Name = reader[SisterCompanyConstants.Name].ToString();
            sisterCompany.NameEnglish = reader[SisterCompanyConstants.NameEnglish].ToString();
            sisterCompany.Place = reader[SisterCompanyConstants.Place].ToString();
            sisterCompany.PlaceEnglish = reader[SisterCompanyConstants.PlaceEnglish].ToString();
            SectorRepository sectorRepository = new SectorRepository();
            sisterCompany.Sector = sectorRepository.FindByID(Convert.ToInt32(reader[SisterCompanyConstants.Sector]), new Common.ActionState());
            sisterCompany.OwnerPercentage = (float)Convert.ToDecimal(reader[SisterCompanyConstants.OwnPercentage]);
            return sisterCompany;
        }
    }
}
