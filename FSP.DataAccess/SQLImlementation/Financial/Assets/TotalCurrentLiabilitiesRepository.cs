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
    public class TotalCurrentLiabilitiesRepository : RepositoryBaseClass<TotalCurrentLiabilities>
    {
        public override void Delete(TotalCurrentLiabilities entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(TotalCurrentLiabilitiesRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(TotalCurrentLiabilities entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(TotalCurrentLiabilitiesRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.GovernmentCharge, DbType.Decimal, entity.GovernmentCharge);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.AccountsPayable, DbType.Decimal, entity.AccountsPayable);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.AccruedExpense, DbType.Decimal, entity.AccruedExpense);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.DownPayment, DbType.Decimal, entity.DownPayment);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.TaxesPayable, DbType.Decimal, entity.TaxesPayable);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.ZakatPayable, DbType.Decimal, entity.ZakatPayable);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.DividendsPayable, DbType.Decimal, entity.DividendsPayable);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.DueToSisterCompanies, DbType.Decimal, entity.DueToSisterCompanies);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.OtherCurrentLiabilities, DbType.Decimal, entity.OtherCurrentLiabilities);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.OtherCurrentLiabilitiesNonIslamic, DbType.Decimal, entity.OtherCurrentLiabilitiesNonIslamic);

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

        public override void Update(TotalCurrentLiabilities entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(TotalCurrentLiabilitiesRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.GovernmentCharge, DbType.Decimal, entity.GovernmentCharge);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.AccountsPayable, DbType.Decimal, entity.AccountsPayable);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.AccruedExpense, DbType.Decimal, entity.AccruedExpense);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.DownPayment, DbType.Decimal, entity.DownPayment);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.TaxesPayable, DbType.Decimal, entity.TaxesPayable);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.ZakatPayable, DbType.Decimal, entity.ZakatPayable);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.DividendsPayable, DbType.Decimal, entity.DividendsPayable);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.DueToSisterCompanies, DbType.Decimal, entity.DueToSisterCompanies);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.OtherCurrentLiabilities, DbType.Decimal, entity.OtherCurrentLiabilities);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.OtherCurrentLiabilitiesNonIslamic, DbType.Decimal, entity.OtherCurrentLiabilitiesNonIslamic);

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

        public List<TotalCurrentLiabilities> FindByAssetsID(int assetsID, Common.ActionState actionState)
        {
            List<TotalCurrentLiabilities> list;
            TotalCurrentLiabilities entity;
            DbCommand cmd;

            list = new List<TotalCurrentLiabilities>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(TotalCurrentLiabilitiesRepositoryConstants.SP_FindBYAssetsID);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.AssetsID, DbType.Int32, assetsID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = TotalCurrentLiabilitiesHelper(reader);
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

        public override List<TotalCurrentLiabilities> FindAll(Common.ActionState actionState)
        {
            List<TotalCurrentLiabilities> list;
            TotalCurrentLiabilities entity;
            DbCommand cmd;

            list = new List<TotalCurrentLiabilities>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(TotalCurrentLiabilitiesRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = TotalCurrentLiabilitiesHelper(reader);
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

        public override TotalCurrentLiabilities FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            TotalCurrentLiabilities entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(TotalCurrentLiabilitiesRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, TotalCurrentLiabilitiesRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = TotalCurrentLiabilitiesHelper(reader);
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

        public override bool IsExist(TotalCurrentLiabilities entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private TotalCurrentLiabilities TotalCurrentLiabilitiesHelper(SqlDataReader reader)
        {
            TotalCurrentLiabilities entity = new TotalCurrentLiabilities();
            entity.ID = Convert.ToInt32(reader[TotalCurrentLiabilitiesConstants.ID]);
            entity.AssetsID = Convert.ToInt32(reader[TotalCurrentLiabilitiesConstants.AssetsID]);
            AssetRepository assetRepository = new AssetRepository();
            entity.Asset = assetRepository.FindByID(Convert.ToInt32(reader[TotalCurrentLiabilitiesConstants.AssetsID]), new Common.ActionState());
            entity.GovernmentCharge = (float)Convert.ToDouble(reader[TotalCurrentLiabilitiesConstants.GovernmentCharge]);
            entity.AccountsPayable = (float)Convert.ToDouble(reader[TotalCurrentLiabilitiesConstants.AccountsPayable]);
            entity.AccruedExpense = (float)Convert.ToDouble(reader[TotalCurrentLiabilitiesConstants.AccruedExpense]);
            entity.DownPayment = (float)Convert.ToDouble(reader[TotalCurrentLiabilitiesConstants.DownPayment]);
            entity.TaxesPayable = (float)Convert.ToDouble(reader[TotalCurrentLiabilitiesConstants.TaxesPayable]);
            entity.ZakatPayable = (float)Convert.ToDouble(reader[TotalCurrentLiabilitiesConstants.ZakatPayable]);
            entity.DividendsPayable = (float)Convert.ToDouble(reader[TotalCurrentLiabilitiesConstants.DividendsPayable]);
            entity.DueToSisterCompanies = (float)Convert.ToDouble(reader[TotalCurrentLiabilitiesConstants.DueToSisterCompanies]);
            entity.OtherCurrentLiabilities = (float)Convert.ToDouble(reader[TotalCurrentLiabilitiesConstants.OtherCurrentLiabilities]);
            entity.OtherCurrentLiabilitiesNonIslamic = (float)Convert.ToDouble(reader[TotalCurrentLiabilitiesConstants.OtherCurrentLiabilitiesNonIslamic]);
            return entity;
        }
    }
}
