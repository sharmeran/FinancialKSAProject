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
    public class SectorRepository : RepositoryBaseClass<Sector>
    {
        public override void Delete(Sector entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(SectorRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, SectorRepositoryConstants.ID, DbType.String, entity.ID);


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

        public override void Insert(Sector entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(SectorRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, SectorRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, SectorRepositoryConstants.Description, DbType.String, entity.Description);
                database.AddInParameter(cmd, SectorRepositoryConstants.NameEnglish, DbType.String, entity.NameEnglish);
                database.AddInParameter(cmd, SectorRepositoryConstants.DescriptionEnglish, DbType.String, entity.DescriptionEnglish);


                spResult =Convert.ToInt32( database.ExecuteScalar(cmd));
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

        public override void Update(Sector entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(SectorRepositoryConstants.SP_Update);
                database.AddInParameter(cmd, SectorRepositoryConstants.ID, DbType.String, entity.ID);
                database.AddInParameter(cmd, SectorRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, SectorRepositoryConstants.Description, DbType.String, entity.Description);
                database.AddInParameter(cmd, SectorRepositoryConstants.Name, DbType.String, entity.Name);
                database.AddInParameter(cmd, SectorRepositoryConstants.Description, DbType.String, entity.Description);
                database.AddInParameter(cmd, SectorRepositoryConstants.NameEnglish, DbType.String, entity.NameEnglish);
                database.AddInParameter(cmd, SectorRepositoryConstants.DescriptionEnglish, DbType.String, entity.DescriptionEnglish);

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

        public override List<Sector> FindAll(Common.ActionState actionState)
        {
            List<Sector> sectortList;
            Sector sectorEntity;
            DbCommand cmd;

            sectortList = new List<Sector>();
            sectorEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(SectorRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        sectorEntity = SectorHelper(reader);
                        if (sectorEntity != null)
                        {
                            sectortList.Add(sectorEntity);
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
            return sectortList;
        }

        public override Sector FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            Sector sectorEntity;
            DbCommand cmd;

            // Initialization
            sectorEntity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(SectorRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, SectorRepositoryConstants.ID, DbType.Int32, entityID);
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
                        sectorEntity = SectorHelper(reader);
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
            return sectorEntity;
        }

        public override bool IsExist(Sector entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private Sector SectorHelper(SqlDataReader reader)
        {
            Sector sector = new Sector();
            sector.ID = Convert.ToInt32(reader[SectorConstants.ID]);
            sector.Name = reader[SectorConstants.Name].ToString();
            sector.Description = reader[SectorConstants.Description].ToString();
            sector.NameEnglish = reader[SectorConstants.NameEnglish].ToString();
            sector.DescriptionEnglish = reader[SectorConstants.DescriptionEnglish].ToString();
            return sector;
        }
    }
}
