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
    public class IntangiblesRepository : RepositoryBaseClass<Intangibles>
    {
        public override void Delete(Intangibles entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(IntangiblesRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, IntangiblesRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(Intangibles entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(IntangiblesRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, IntangiblesRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, IntangiblesRepositoryConstants.Goodwill, DbType.Decimal, entity.Goodwill);
                database.AddInParameter(cmd, IntangiblesRepositoryConstants.Licences, DbType.Decimal, entity.Licences);
                database.AddInParameter(cmd, IntangiblesRepositoryConstants.TotalLongTermAssets, DbType.Decimal, entity.TotalLongTermAssets);

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

        public override void Update(Intangibles entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(IntangiblesRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, IntangiblesRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, IntangiblesRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, IntangiblesRepositoryConstants.Goodwill, DbType.Decimal, entity.Goodwill);
                database.AddInParameter(cmd, IntangiblesRepositoryConstants.Licences, DbType.Decimal, entity.Licences);
                database.AddInParameter(cmd, IntangiblesRepositoryConstants.TotalLongTermAssets, DbType.Decimal, entity.TotalLongTermAssets);

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

        public List<Intangibles> FindByAssetsID(int assetsID, Common.ActionState actionState)
        {
            List<Intangibles> list;
            Intangibles entity;
            DbCommand cmd;

            list = new List<Intangibles>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(IntangiblesRepositoryConstants.SP_FindBYAssetsID);
                database.AddInParameter(cmd, IntangiblesRepositoryConstants.AssetsID, DbType.Int32, assetsID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = IntangiblesHelper(reader);
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

        public override List<Intangibles> FindAll(Common.ActionState actionState)
        {
            List<Intangibles> list;
            Intangibles entity;
            DbCommand cmd;

            list = new List<Intangibles>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(IntangiblesRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = IntangiblesHelper(reader);
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

        public override Intangibles FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            Intangibles entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(IntangiblesRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, IntangiblesRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = IntangiblesHelper(reader);
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

        public override bool IsExist(Intangibles entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private Intangibles IntangiblesHelper(SqlDataReader reader)
        {
            Intangibles entity = new Intangibles();
            entity.ID = Convert.ToInt32(reader[IntangiblesConstants.ID]);
            entity.AssetsID = Convert.ToInt32(reader[IntangiblesConstants.AssetsID]);
            AssetRepository assetRepository = new AssetRepository();
            entity.Asset = assetRepository.FindByID(Convert.ToInt32(reader[IntangiblesConstants.AssetsID]), new Common.ActionState());
            entity.Goodwill = (float)Convert.ToDouble(reader[IntangiblesConstants.Goodwill]);
            entity.Licences = (float)Convert.ToDouble(reader[IntangiblesConstants.Licences]);
            entity.TotalLongTermAssets = (float)Convert.ToDouble(reader[IntangiblesConstants.TotalLongTermAssets]);
            return entity;
        }
    }
}
