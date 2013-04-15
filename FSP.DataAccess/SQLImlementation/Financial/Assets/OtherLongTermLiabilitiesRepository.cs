using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Constants.Financial;
using FSP.Common.Entites.Financial;
using FSP.Common.Constants.Financial.Assets;
using FSP.Common.Entites.Financial.Assets;
using FSP.Common.Enums;
using FSP.Common;
using FSP.DataAccess.BaseClasses;
using FSP.DataAccess.Constants.Common;
using FSP.DataAccess.Constants.Financial;
using FSP.DataAccess.Constants.Financial.Assets;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FSP.DataAccess.SQLImlementation.Financial;
using FSP.DataAccess.SQLImlementation.Financial.Assets;

namespace FSP.DataAccess.SQLImlementation.Financial.Assets
{
    public class OtherLongTermLiabilitiesRepository : RepositoryBaseClass<OtherLongTermLiabilities>
    {
        public override void Delete(OtherLongTermLiabilities entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(OtherLongTermLiabilitiesRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(OtherLongTermLiabilities entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(OtherLongTermLiabilitiesRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.OtherLongTermLiabilitiesIslamic, DbType.Decimal, entity.OtherLongTermLiabilitiesIslamic);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.OtherLongTermLiabilitiesNonIslamic, DbType.Decimal, entity.OtherLongTermLiabilitiesNonIslamic);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.TotalLongTermLiabilities, DbType.Decimal, entity.TotalLongTermLiabilities);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.TotalLiabilities, DbType.Decimal, entity.TotalLiabilities);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.TotalProvisions, DbType.Decimal, entity.TotalProvisions);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.TaxProvisions, DbType.Decimal, entity.TaxProvisions);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.DeferredTaxIncome, DbType.Decimal, entity.DeferredTaxIncome);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.DeferredIncome, DbType.Decimal, entity.DeferredIncome);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.ProvisionForEmployeesTermInationbenefits, DbType.Decimal, entity.ProvisionForEmployeesTermInationbenefits);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.WarrantiesAndOptions, DbType.Decimal, entity.WarrantiesAndOptions);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.WarrantiesAndOptionsNonIslamic, DbType.Decimal, entity.WarrantiesAndOptionsNonIslamic);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.OtherProvisions, DbType.Decimal, entity.OtherProvisions);

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

        public override void Update(OtherLongTermLiabilities entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(OtherLongTermLiabilitiesRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.OtherLongTermLiabilitiesIslamic, DbType.Decimal, entity.OtherLongTermLiabilitiesIslamic);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.OtherLongTermLiabilitiesNonIslamic, DbType.Decimal, entity.OtherLongTermLiabilitiesNonIslamic);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.TotalLongTermLiabilities, DbType.Decimal, entity.TotalLongTermLiabilities);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.TotalLiabilities, DbType.Decimal, entity.TotalLiabilities);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.TotalProvisions, DbType.Decimal, entity.TotalProvisions);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.TaxProvisions, DbType.Decimal, entity.TaxProvisions);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.DeferredTaxIncome, DbType.Decimal, entity.DeferredTaxIncome);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.DeferredIncome, DbType.Decimal, entity.DeferredIncome);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.ProvisionForEmployeesTermInationbenefits, DbType.Decimal, entity.ProvisionForEmployeesTermInationbenefits);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.WarrantiesAndOptions, DbType.Decimal, entity.WarrantiesAndOptions);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.WarrantiesAndOptionsNonIslamic, DbType.Decimal, entity.WarrantiesAndOptionsNonIslamic);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.OtherProvisions, DbType.Decimal, entity.OtherProvisions);

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

        public void DeleteByAssetsID(int assetsID, ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(OtherLongTermLiabilitiesRepositoryConstants.SP_DeleteBYAssetsID);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.AssetsID, DbType.Int32, assetsID);


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

        public List<OtherLongTermLiabilities> FindByAssetsID(int assetsID, Common.ActionState actionState)
        {
            List<OtherLongTermLiabilities> list;
            OtherLongTermLiabilities entity;
            DbCommand cmd;

            list = new List<OtherLongTermLiabilities>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(OtherLongTermLiabilitiesRepositoryConstants.SP_FindBYAssetsID);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.AssetsID, DbType.Int32, assetsID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = OtherLongTermLiabilitiesHelper(reader);
                        if (entity != null)
                        {
                            list.Add(entity);
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
            return list;
        }

        public override List<OtherLongTermLiabilities> FindAll(Common.ActionState actionState)
        {
            List<OtherLongTermLiabilities> list;
            OtherLongTermLiabilities entity;
            DbCommand cmd;

            list = new List<OtherLongTermLiabilities>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(OtherLongTermLiabilitiesRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = OtherLongTermLiabilitiesHelper(reader);
                        if (entity != null)
                        {
                            list.Add(entity);
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
            return list;
        }

        public override OtherLongTermLiabilities FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            OtherLongTermLiabilities entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(OtherLongTermLiabilitiesRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, OtherLongTermLiabilitiesRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = OtherLongTermLiabilitiesHelper(reader);
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
            return entity;
        }

        public override bool IsExist(OtherLongTermLiabilities entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private OtherLongTermLiabilities OtherLongTermLiabilitiesHelper(SqlDataReader reader)
        {
            OtherLongTermLiabilities entity = new OtherLongTermLiabilities();
            entity.ID = Convert.ToInt32(reader[OtherLongTermLiabilitiesConstants.ID]);
            entity.AssetsID = Convert.ToInt32(reader[OtherLongTermLiabilitiesConstants.AssetsID]);
            AssetRepository assetRepository = new AssetRepository();
            entity.Asset = assetRepository.FindByID(Convert.ToInt32(reader[OtherLongTermLiabilitiesConstants.AssetsID]), new Common.ActionState());
            entity.OtherLongTermLiabilitiesIslamic = (float)Convert.ToDouble(reader[OtherLongTermLiabilitiesConstants.OtherLongTermLiabilitiesIslamic]);
            entity.OtherLongTermLiabilitiesNonIslamic = (float)Convert.ToDouble(reader[OtherLongTermLiabilitiesConstants.OtherLongTermLiabilitiesNonIslamic]);
            entity.TotalLongTermLiabilities = (float)Convert.ToDouble(reader[OtherLongTermLiabilitiesConstants.TotalLongTermLiabilities]);
            entity.TotalLiabilities = (float)Convert.ToDouble(reader[OtherLongTermLiabilitiesConstants.TotalLiabilities]);
            entity.TotalProvisions = (float)Convert.ToDouble(reader[OtherLongTermLiabilitiesConstants.TotalProvisions]);
            entity.TaxProvisions = (float)Convert.ToDouble(reader[OtherLongTermLiabilitiesConstants.TaxProvisions]);
            entity.DeferredTaxIncome = (float)Convert.ToDouble(reader[OtherLongTermLiabilitiesConstants.DeferredTaxIncome]);
            entity.DeferredIncome = (float)Convert.ToDouble(reader[OtherLongTermLiabilitiesConstants.DeferredIncome]);
            entity.ProvisionForEmployeesTermInationbenefits = (float)Convert.ToDouble(reader[OtherLongTermLiabilitiesConstants.ProvisionForEmployeesTermInationbenefits]);
            entity.WarrantiesAndOptions = (float)Convert.ToDouble(reader[OtherLongTermLiabilitiesConstants.WarrantiesAndOptions]);
            entity.WarrantiesAndOptionsNonIslamic = (float)Convert.ToDouble(reader[OtherLongTermLiabilitiesConstants.WarrantiesAndOptionsNonIslamic]);
            entity.OtherProvisions = (float)Convert.ToDouble(reader[OtherLongTermLiabilitiesConstants.OtherProvisions]);
            return entity;
        }
    }
}
