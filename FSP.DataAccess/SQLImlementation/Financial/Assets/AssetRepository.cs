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
    public class AssetRepository : RepositoryBaseClass<Asset>
    {
        public void DeleteByCompanyFinancialModelID(int companyFinancialModelID, ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(AssetRepositoryConstants.SP_DeleteByCompanyFinancialModelID);
                database.AddInParameter(cmd, AssetRepositoryConstants.CompanyFinancialModelID, DbType.Int32, companyFinancialModelID);


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

        public override void Delete(Asset entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override void Insert(Asset entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(AssetRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, AssetRepositoryConstants.CompanyFinancialModelID, DbType.Int32, entity.CompanyFinancialModelID);


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

        public override void Update(Asset entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override List<Asset> FindAll(Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public List<Asset> FindByCompanyFinancialModelID(int companyFinancialModelID, Common.ActionState actionState)
        {
            List<Asset> AssetList;
            Asset AssetEntity;
            DbCommand cmd;

            AssetList = new List<Asset>();
            AssetEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(AssetRepositoryConstants.SP_FindBYCompanyFinancialModelID);
                database.AddInParameter(cmd, AssetRepositoryConstants.CompanyFinancialModelID, DbType.Int32, companyFinancialModelID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        AssetEntity = AssetHelper(reader);
                        if (AssetEntity != null)
                        {
                            AssetList.Add(AssetEntity);
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
            return AssetList;
        }

        public override Asset FindByID(int entityID, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(Asset entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private Asset AssetHelper(SqlDataReader reader)
        {
            Asset asset = new Asset();
            asset.CompanyFinancialModelID = Convert.ToInt32(reader[AssetConstants.CompanyFinancialModelID]);
            CompanyFinancialModelRepository companyFinancialModelRepository = new CompanyFinancialModelRepository();
            asset.CompanyFinancialModel = companyFinancialModelRepository.FindByID(Convert.ToInt32(reader[AssetConstants.CompanyFinancialModelID]), new ActionState());
            asset.ID = Convert.ToInt32(reader[AssetConstants.ID]);
            return asset;
        }
    }
}
