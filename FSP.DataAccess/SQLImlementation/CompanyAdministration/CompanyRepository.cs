using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
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
    public class CompanyRepository : RepositoryBaseClass<Company>
    {
        public override void Delete(Company entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CompanyRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, CompanyRepositoryConstants.ID, DbType.String, entity.ID);


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

        public override void Insert(Company entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CompanyRepositoryConstants.SP_Insert);
                 DateTimeFormatInfo format = new DateTimeFormatInfo();
                        format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date=Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, CompanyRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, CompanyRepositoryConstants.Description, DbType.String, entity.Description);
                database.AddInParameter(cmd, CompanyRepositoryConstants.EstablishDate, DbType.Date, entity.EstablishYear);
                database.AddInParameter(cmd, CompanyRepositoryConstants.Information, DbType.String, entity.Information);
                database.AddInParameter(cmd, CompanyRepositoryConstants.Sector, DbType.Int32, entity.Sector.ID);
                database.AddInParameter(cmd, CompanyRepositoryConstants.NameEnglish, DbType.String, entity.NameEnglish);
                database.AddInParameter(cmd, CompanyRepositoryConstants.DescriptionEnglish, DbType.String, entity.DescriptionEnglish);
                database.AddInParameter(cmd, CompanyRepositoryConstants.InformationEnglish, DbType.String, entity.InformationEnglish);
                database.AddInParameter(cmd, CompanyRepositoryConstants.Capital, DbType.Decimal, entity.Capital);
                database.AddInParameter(cmd, CompanyRepositoryConstants.Behavior, DbType.String, entity.Behavior);
                if (entity.WithLimitedLiability.Day == date.Day && entity.WithLimitedLiability.Month == date.Month && entity.WithLimitedLiability.Year == date.Year)
                {
                    database.AddInParameter(cmd, CompanyRepositoryConstants.WithLimitedLiability, DbType.Date, null);
                }
                else
                {
                    database.AddInParameter(cmd, CompanyRepositoryConstants.WithLimitedLiability, DbType.Date, entity.WithLimitedLiability);
                }
                if (entity.ClosedJointStockCompany.Day == date.Day && entity.ClosedJointStockCompany.Month == date.Month && entity.ClosedJointStockCompany.Year == date.Year)
                {
                    database.AddInParameter(cmd, CompanyRepositoryConstants.ClosedJointStockCompany, DbType.Date, null);
                }
                else
                {
                    database.AddInParameter(cmd, CompanyRepositoryConstants.ClosedJointStockCompany, DbType.Date, entity.ClosedJointStockCompany);
                }
                if (entity.IPO.Day == date.Day && entity.IPO.Month == date.Month && entity.IPO.Year == date.Year)
                {
                    database.AddInParameter(cmd, CompanyRepositoryConstants.IPO, DbType.Date,null);
                }
                else
                {
                    database.AddInParameter(cmd, CompanyRepositoryConstants.IPO, DbType.Date, entity.IPO);
                }
                if (entity.GeneralCompany.Day == date.Day && entity.GeneralCompany.Month == date.Month && entity.GeneralCompany.Year == date.Year)
                {
                    database.AddInParameter(cmd, CompanyRepositoryConstants.GeneralCompany, DbType.Date, null);
                }
                else
                {
                    database.AddInParameter(cmd, CompanyRepositoryConstants.GeneralCompany, DbType.Date, entity.GeneralCompany);
                }

                database.AddInParameter(cmd, CompanyRepositoryConstants.Rank, DbType.Int32, entity.Rank);


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

        public override void Update(Company entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(CompanyRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, CompanyRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, CompanyRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, CompanyRepositoryConstants.Description, DbType.String, entity.Description);
                database.AddInParameter(cmd, CompanyRepositoryConstants.EstablishDate, DbType.Date, entity.EstablishYear);
                database.AddInParameter(cmd, CompanyRepositoryConstants.Information, DbType.String, entity.Information);
                database.AddInParameter(cmd, CompanyRepositoryConstants.Sector, DbType.Int32, entity.Sector.ID);
                database.AddInParameter(cmd, CompanyRepositoryConstants.NameEnglish, DbType.String, entity.NameEnglish);
                database.AddInParameter(cmd, CompanyRepositoryConstants.DescriptionEnglish, DbType.String, entity.DescriptionEnglish);
                database.AddInParameter(cmd, CompanyRepositoryConstants.InformationEnglish, DbType.String, entity.InformationEnglish);
                database.AddInParameter(cmd, CompanyRepositoryConstants.Capital, DbType.Decimal, entity.Capital);
                database.AddInParameter(cmd, CompanyRepositoryConstants.Behavior, DbType.String, entity.Behavior);
                if (entity.WithLimitedLiability.Day == date.Day && entity.WithLimitedLiability.Month == date.Month && entity.WithLimitedLiability.Year == date.Year)
                {
                    database.AddInParameter(cmd, CompanyRepositoryConstants.WithLimitedLiability, DbType.Date, null);
                }
                else
                {
                    database.AddInParameter(cmd, CompanyRepositoryConstants.WithLimitedLiability, DbType.Date, entity.WithLimitedLiability);
                }
                if (entity.ClosedJointStockCompany.Day == date.Day && entity.ClosedJointStockCompany.Month == date.Month && entity.ClosedJointStockCompany.Year == date.Year)
                {
                    database.AddInParameter(cmd, CompanyRepositoryConstants.ClosedJointStockCompany, DbType.Date, null);
                }
                else
                {
                    database.AddInParameter(cmd, CompanyRepositoryConstants.ClosedJointStockCompany, DbType.Date, entity.ClosedJointStockCompany);
                }
                if (entity.IPO.Day == date.Day && entity.IPO.Month == date.Month && entity.IPO.Year == date.Year)
                {
                    database.AddInParameter(cmd, CompanyRepositoryConstants.IPO, DbType.Date, null);
                }
                else
                {
                    database.AddInParameter(cmd, CompanyRepositoryConstants.IPO, DbType.Date, entity.IPO);
                }
                if (entity.GeneralCompany.Day == date.Day && entity.GeneralCompany.Month == date.Month && entity.GeneralCompany.Year == date.Year)
                {
                    database.AddInParameter(cmd, CompanyRepositoryConstants.GeneralCompany, DbType.Date, null);
                }
                else
                {
                    database.AddInParameter(cmd, CompanyRepositoryConstants.GeneralCompany, DbType.Date, entity.GeneralCompany);
                }
                database.AddInParameter(cmd, CompanyRepositoryConstants.Rank, DbType.Int32, entity.Rank);

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

        //public void InsertCompanyBehaviours(Company entity, Common.ActionState actionState)
        //{


        //    try
        //    {
        //        BehaviourRepository behaviourRepository = new BehaviourRepository();

        //        for (int i = 0; i < entity.BehaviourList.Count; i++)
        //        {
        //            behaviourRepository.InsertCompanyBehaviours(entity.ID, entity.BehaviourList[i].ID, actionState);
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        actionState.SetFail(ActionStatusEnum.CannotInsert, LocalizationConstants.Err_CannotInsert);
        //    }

        //}

        //public void DeleteCompanyBehaviours(Company entity, Common.ActionState actionState)
        //{
        //    BehaviourRepository behaviourRepository = new BehaviourRepository();
        //    behaviourRepository.DeleteCompanyBehavioursByCompanyID(entity.ID, actionState);
        //}

        public override List<Company> FindAll(Common.ActionState actionState)
        {
            List<Company> companyList;
            Company companyEntity;
            DbCommand cmd;

            companyList = new List<Company>();
            companyEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(CompanyRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        companyEntity = CompanyHelper(reader,true);
                        if (companyEntity != null)
                        {
                            companyList.Add(companyEntity);
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
            return companyList;
        }

        public  List<Company> FindAllParcial(Common.ActionState actionState)
        {
            List<Company> companyList;
            Company companyEntity;
            DbCommand cmd;

            companyList = new List<Company>();
            companyEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(CompanyRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        companyEntity = CompanyHelper(reader, false);
                        if (companyEntity != null)
                        {
                            companyList.Add(companyEntity);
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
            return companyList;
        }

        public override Company FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            Company companyEntity;
            DbCommand cmd;

            // Initialization
            companyEntity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(CompanyRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, CompanyRepositoryConstants.ID, DbType.Int32, entityID);
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
                        companyEntity = CompanyHelper(reader,true);
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
            return companyEntity;
        }

        public override bool IsExist(Company entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private Company CompanyHelper(SqlDataReader reader, bool isFull)
        {
            Company company = new Company();
            
            company.ID = Convert.ToInt32(reader[CompanyConstants.ID]);
            company.Name = reader[CompanyConstants.Name].ToString();
            company.Description = reader[CompanyConstants.Description].ToString();
            if (isFull)
            {
                if (reader[CompanyConstants.EstablishDate] != DBNull.Value)
                    company.EstablishYear = Convert.ToDateTime(reader[CompanyConstants.EstablishDate]);
                company.Information = reader[CompanyConstants.Information].ToString();
                SectorRepository sectorRepository = new SectorRepository();
                company.Sector = sectorRepository.FindByID(Convert.ToInt32(reader[CompanyConstants.SectorID]), new Common.ActionState());
                company.NameEnglish = reader[CompanyConstants.NameEnglish].ToString();
                company.DescriptionEnglish = reader[CompanyConstants.DescriptionEnglish].ToString();
                company.InformationEnglish = reader[CompanyConstants.InformationEnglish].ToString();
                company.Capital = (float)Convert.ToDouble(reader[CompanyConstants.Capital]);
                if (reader[CompanyConstants.WithLimitedLiability] != DBNull.Value)
                    company.WithLimitedLiability = Convert.ToDateTime(reader[CompanyConstants.WithLimitedLiability]);
                if (reader[CompanyConstants.ClosedJointStockCompany] != DBNull.Value)
                    company.ClosedJointStockCompany = Convert.ToDateTime(reader[CompanyConstants.ClosedJointStockCompany]);
                if (reader[CompanyConstants.IPO] != DBNull.Value)
                    company.IPO = Convert.ToDateTime(reader[CompanyConstants.IPO]);
                if (reader[CompanyConstants.GeneralCompany] != DBNull.Value)
                    company.GeneralCompany = Convert.ToDateTime(reader[CompanyConstants.GeneralCompany]);
                BehaviourRepository behaviourRepository = new BehaviourRepository();
               // company.BehaviourList = behaviourRepository.FindByCompanyID(company.ID, new Common.ActionState());
                SubsidiaryCompanyRepository subsidiaryCompanyRepository = new SubsidiaryCompanyRepository();
                company.SubsidiaryCompanyList = subsidiaryCompanyRepository.FindByCompanyID(company.ID, new Common.ActionState());
                SisterCompanyRepository sisterCompanyRepository = new SisterCompanyRepository();
                company.SisterCompanyList = sisterCompanyRepository.FindByCompanyID(company.ID, new Common.ActionState());
                company.Behavior = reader[CompanyConstants.Behavior].ToString();
                company.Rank = Convert.ToInt32(reader[CompanyConstants.Rank]);
            }
            return company;
        }


    }
}
