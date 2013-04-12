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
    public class OtherShortTermLiabilitiesRepository : RepositoryBaseClass<OtherShortTermLiabilities>
    {
        public override void Delete(OtherShortTermLiabilities entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(OtherShortTermLiabilitiesRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, OtherShortTermLiabilitiesRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(OtherShortTermLiabilities entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(OtherShortTermLiabilitiesRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, OtherShortTermLiabilitiesRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, OtherShortTermLiabilitiesRepositoryConstants.OtherShortTerm, DbType.Decimal, entity.OtherShortTerm);
                database.AddInParameter(cmd, OtherShortTermLiabilitiesRepositoryConstants.OtherShortTermNonIslamic, DbType.Decimal, entity.OtherShortTermNonIslamic);

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

        public override void Update(OtherShortTermLiabilities entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(OtherShortTermLiabilitiesRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, OtherShortTermLiabilitiesRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, OtherShortTermLiabilitiesRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, OtherShortTermLiabilitiesRepositoryConstants.OtherShortTerm, DbType.Decimal, entity.OtherShortTerm);
                database.AddInParameter(cmd, OtherShortTermLiabilitiesRepositoryConstants.OtherShortTermNonIslamic, DbType.Decimal, entity.OtherShortTermNonIslamic);

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

        public List<OtherShortTermLiabilities> FindByAssetsID(int assetsID, Common.ActionState actionState)
        {
            List<OtherShortTermLiabilities> list;
            OtherShortTermLiabilities entity;
            DbCommand cmd;

            list = new List<OtherShortTermLiabilities>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(OtherShortTermLiabilitiesRepositoryConstants.SP_FindBYAssetsID);
                database.AddInParameter(cmd, OtherShortTermLiabilitiesRepositoryConstants.AssetsID, DbType.Int32, assetsID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = OtherShortTermLiabilitiesHelper(reader);
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

        public override List<OtherShortTermLiabilities> FindAll(Common.ActionState actionState)
        {
            List<OtherShortTermLiabilities> list;
            OtherShortTermLiabilities entity;
            DbCommand cmd;

            list = new List<OtherShortTermLiabilities>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(OtherShortTermLiabilitiesRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = OtherShortTermLiabilitiesHelper(reader);
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

        public override OtherShortTermLiabilities FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            OtherShortTermLiabilities entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(OtherShortTermLiabilitiesRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, OtherShortTermLiabilitiesRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = OtherShortTermLiabilitiesHelper(reader);
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

        public override bool IsExist(OtherShortTermLiabilities entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private OtherShortTermLiabilities OtherShortTermLiabilitiesHelper(SqlDataReader reader)
        {
            OtherShortTermLiabilities entity = new OtherShortTermLiabilities();
            entity.ID = Convert.ToInt32(reader[OtherShortTermLiabilitiesConstants.ID]);
            entity.AssetsID = Convert.ToInt32(reader[OtherShortTermLiabilitiesConstants.AssetsID]);
            AssetRepository assetRepository = new AssetRepository();
            entity.Asset = assetRepository.FindByID(Convert.ToInt32(reader[OtherShortTermLiabilitiesConstants.AssetsID]), new Common.ActionState());
            entity.OtherShortTerm = (float)Convert.ToDouble(reader[OtherShortTermLiabilitiesConstants.OtherShortTerm]);
            entity.OtherShortTermNonIslamic = (float)Convert.ToDouble(reader[OtherShortTermLiabilitiesConstants.OtherShortTermNonIslamic]);
            return entity;
        }
    }
}
