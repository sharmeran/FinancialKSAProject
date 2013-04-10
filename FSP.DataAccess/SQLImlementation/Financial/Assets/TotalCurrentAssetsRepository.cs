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
    public class TotalCurrentAssetsRepository : RepositoryBaseClass<TotalCurrentAssets>
    {
        public override void Delete(TotalCurrentAssets entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(TotalCurrentAssetsRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(TotalCurrentAssets entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(TotalCurrentAssetsRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.LongTermInvestments, DbType.Decimal, entity.LongTermInvestments);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.GrossFixedAssets, DbType.Decimal, entity.GrossFixedAssets);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.LandAndBuildings, DbType.Decimal, entity.LandAndBuildings);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.LeaseholdImprovements, DbType.Decimal, entity.LeaseholdImprovements);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.CellSitesInfrastructure, DbType.Decimal, entity.CellSitesInfrastructure);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.FurnitureAndEquipment, DbType.Decimal, entity.FurnitureAndEquipment);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.OtherFixedAssets, DbType.Decimal, entity.OtherFixedAssets);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.AccumulatedDepreciation, DbType.Decimal, entity.AccumulatedDepreciation);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.CapitalWorkingInProgress, DbType.Decimal, entity.CapitalWorkingInProgress);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.NetFixedAssets, DbType.Decimal, entity.NetFixedAssets);

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

        public override void Update(TotalCurrentAssets entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(TotalCurrentAssetsRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.LongTermInvestments, DbType.Decimal, entity.LongTermInvestments);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.GrossFixedAssets, DbType.Decimal, entity.GrossFixedAssets);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.LandAndBuildings, DbType.Decimal, entity.LandAndBuildings);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.LeaseholdImprovements, DbType.Decimal, entity.LeaseholdImprovements);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.CellSitesInfrastructure, DbType.Decimal, entity.CellSitesInfrastructure);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.FurnitureAndEquipment, DbType.Decimal, entity.FurnitureAndEquipment);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.OtherFixedAssets, DbType.Decimal, entity.OtherFixedAssets);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.AccumulatedDepreciation, DbType.Decimal, entity.AccumulatedDepreciation);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.CapitalWorkingInProgress, DbType.Decimal, entity.CapitalWorkingInProgress);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.NetFixedAssets, DbType.Decimal, entity.NetFixedAssets);

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

        public override List<TotalCurrentAssets> FindAll(Common.ActionState actionState)
        {
            List<TotalCurrentAssets> list;
            TotalCurrentAssets entity;
            DbCommand cmd;

            list = new List<TotalCurrentAssets>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(TotalCurrentAssetsRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = TotalCurrentAssetsHelper(reader);
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

        public override TotalCurrentAssets FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            TotalCurrentAssets entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(TotalCurrentAssetsRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, TotalCurrentAssetsRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = TotalCurrentAssetsHelper(reader);
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

        public override bool IsExist(TotalCurrentAssets entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private TotalCurrentAssets TotalCurrentAssetsHelper(SqlDataReader reader)
        {
            TotalCurrentAssets entity = new TotalCurrentAssets();
            entity.ID = Convert.ToInt32(reader[TotalCurrentAssetsConstants.ID]);
            entity.AssetsID = Convert.ToInt32(reader[TotalCurrentAssetsConstants.AssetsID]);
            AssetRepository assetRepository = new AssetRepository();
            entity.Asset = assetRepository.FindByID(Convert.ToInt32(reader[TotalCurrentAssetsConstants.AssetsID]), new Common.ActionState());
            entity.LongTermInvestments = (float)Convert.ToDouble(reader[TotalCurrentAssetsConstants.LongTermInvestments]);
            entity.GrossFixedAssets = (float)Convert.ToDouble(reader[TotalCurrentAssetsConstants.GrossFixedAssets]);
            entity.LandAndBuildings = (float)Convert.ToDouble(reader[TotalCurrentAssetsConstants.LandAndBuildings]);
            entity.LeaseholdImprovements = (float)Convert.ToDouble(reader[TotalCurrentAssetsConstants.LeaseholdImprovements]);
            entity.CellSitesInfrastructure = (float)Convert.ToDouble(reader[TotalCurrentAssetsConstants.CellSitesInfrastructure]);
            entity.FurnitureAndEquipment = (float)Convert.ToDouble(reader[TotalCurrentAssetsConstants.FurnitureAndEquipment]);
            entity.OtherFixedAssets = (float)Convert.ToDouble(reader[TotalCurrentAssetsConstants.OtherFixedAssets]);
            entity.AccumulatedDepreciation = (float)Convert.ToDouble(reader[TotalCurrentAssetsConstants.AccumulatedDepreciation]);
            entity.CapitalWorkingInProgress = (float)Convert.ToDouble(reader[TotalCurrentAssetsConstants.CapitalWorkingInProgress]);
            entity.NetFixedAssets = (float)Convert.ToDouble(reader[TotalCurrentAssetsConstants.NetFixedAssets]);
            return entity;
        }
    }
}
