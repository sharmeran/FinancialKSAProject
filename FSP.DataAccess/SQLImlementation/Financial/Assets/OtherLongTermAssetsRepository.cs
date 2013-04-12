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
    public class OtherLongTermAssetsRepository : RepositoryBaseClass<OtherLongTermAssets>
    {
        public override void Delete(OtherLongTermAssets entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(OtherLongTermAssetsRepositoryConstants.SP_Delete);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.ID, DbType.Int32, entity.ID);


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

        public override void Insert(OtherLongTermAssets entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(OtherLongTermAssetsRepositoryConstants.SP_Insert);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.DueAmountfromRelatedParties, DbType.Decimal, entity.DueAmountfromRelatedParties);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.DueFromOtherTelecomOperatorsLT, DbType.Decimal, entity.DueFromOtherTelecomOperatorsLT);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.NotesReceivables, DbType.Decimal, entity.NotesReceivables);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.NotesReceivablesNonIslamic, DbType.Decimal, entity.NotesReceivablesNonIslamic);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.PrepaidExpensesLT, DbType.Decimal, entity.PrepaidExpensesLT);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.EmployeesUnionLoan, DbType.Decimal, entity.EmployeesUnionLoan);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.EmployeesUnionLoanNonIslamic, DbType.Decimal, entity.EmployeesUnionLoanNonIslamic);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.IncomeReceivables, DbType.Decimal, entity.IncomeReceivables);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.DueFromTaxAuthority, DbType.Decimal, entity.DueFromTaxAuthority);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.DueFromSisterCompaniesLT, DbType.Decimal, entity.DueFromSisterCompaniesLT);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.DueFromSisterCompaniesLTNonIslamic, DbType.Decimal, entity.DueFromSisterCompaniesLTNonIslamic);

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

        public override void Update(OtherLongTermAssets entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(OtherLongTermAssetsRepositoryConstants.SP_Update);
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                DateTime date = Convert.ToDateTime("1/1/0001", format);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.ID, DbType.Int32, entity.ID);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.AssetsID, DbType.Int32, entity.AssetsID);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.DueAmountfromRelatedParties, DbType.Decimal, entity.DueAmountfromRelatedParties);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.DueFromOtherTelecomOperatorsLT, DbType.Decimal, entity.DueFromOtherTelecomOperatorsLT);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.NotesReceivables, DbType.Decimal, entity.NotesReceivables);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.NotesReceivablesNonIslamic, DbType.Decimal, entity.NotesReceivablesNonIslamic);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.PrepaidExpensesLT, DbType.Decimal, entity.PrepaidExpensesLT);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.EmployeesUnionLoan, DbType.Decimal, entity.EmployeesUnionLoan);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.EmployeesUnionLoanNonIslamic, DbType.Decimal, entity.EmployeesUnionLoanNonIslamic);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.IncomeReceivables, DbType.Decimal, entity.IncomeReceivables);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.DueFromTaxAuthority, DbType.Decimal, entity.DueFromTaxAuthority);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.DueFromSisterCompaniesLT, DbType.Decimal, entity.DueFromSisterCompaniesLT);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.DueFromSisterCompaniesLTNonIslamic, DbType.Decimal, entity.DueFromSisterCompaniesLTNonIslamic);

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

        public List<OtherLongTermAssets> FindByAssetsID(int assetsID, Common.ActionState actionState)
        {
            List<OtherLongTermAssets> list;
            OtherLongTermAssets entity;
            DbCommand cmd;

            list = new List<OtherLongTermAssets>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(OtherLongTermAssetsRepositoryConstants.SP_FindBYAssetsID);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.AssetsID, DbType.Int32, assetsID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = OtherLongTermAssetsHelper(reader);
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

        public override List<OtherLongTermAssets> FindAll(Common.ActionState actionState)
        {
            List<OtherLongTermAssets> list;
            OtherLongTermAssets entity;
            DbCommand cmd;

            list = new List<OtherLongTermAssets>();
            entity = null;

            try
            {
                cmd = database.GetStoredProcCommand(OtherLongTermAssetsRepositoryConstants.SP_FindAll);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        entity = OtherLongTermAssetsHelper(reader);
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

        public override OtherLongTermAssets FindByID(int entityID, Common.ActionState actionState)
        {
            // Declaration 
            OtherLongTermAssets entity;
            DbCommand cmd;

            // Initialization
            entity = null;
            cmd = null;

            // Implementation 
            try
            {
                cmd = database.GetStoredProcCommand(OtherLongTermAssetsRepositoryConstants.SP_FindByID);
                database.AddInParameter(cmd, OtherLongTermAssetsRepositoryConstants.ID, DbType.Int32, entityID);
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
                        entity = OtherLongTermAssetsHelper(reader);
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

        public override bool IsExist(OtherLongTermAssets entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private OtherLongTermAssets OtherLongTermAssetsHelper(SqlDataReader reader)
        {
            OtherLongTermAssets entity = new OtherLongTermAssets();
            entity.ID = Convert.ToInt32(reader[OtherLongTermAssetsConstants.ID]);
            entity.AssetsID = Convert.ToInt32(reader[OtherLongTermAssetsConstants.AssetsID]);
            AssetRepository assetRepository = new AssetRepository();
            entity.Asset = assetRepository.FindByID(Convert.ToInt32(reader[OtherLongTermAssetsConstants.AssetsID]), new Common.ActionState());
            entity.DueAmountfromRelatedParties = (float)Convert.ToDouble(reader[OtherLongTermAssetsConstants.DueAmountfromRelatedParties]);
            entity.DueFromOtherTelecomOperatorsLT = (float)Convert.ToDouble(reader[OtherLongTermAssetsConstants.DueFromOtherTelecomOperatorsLT]);
            entity.NotesReceivables = (float)Convert.ToDouble(reader[OtherLongTermAssetsConstants.NotesReceivables]);
            entity.NotesReceivablesNonIslamic = (float)Convert.ToDouble(reader[OtherLongTermAssetsConstants.NotesReceivablesNonIslamic]);
            entity.PrepaidExpensesLT = (float)Convert.ToDouble(reader[OtherLongTermAssetsConstants.PrepaidExpensesLT]);
            entity.EmployeesUnionLoan = (float)Convert.ToDouble(reader[OtherLongTermAssetsConstants.EmployeesUnionLoan]);
            entity.EmployeesUnionLoanNonIslamic = (float)Convert.ToDouble(reader[OtherLongTermAssetsConstants.EmployeesUnionLoanNonIslamic]);
            entity.IncomeReceivables = (float)Convert.ToDouble(reader[OtherLongTermAssetsConstants.IncomeReceivables]);
            entity.DueFromTaxAuthority = (float)Convert.ToDouble(reader[OtherLongTermAssetsConstants.DueFromTaxAuthority]);
            entity.DueFromSisterCompaniesLT = (float)Convert.ToDouble(reader[OtherLongTermAssetsConstants.DueFromSisterCompaniesLT]);
            entity.DueFromSisterCompaniesLTNonIslamic = (float)Convert.ToDouble(reader[OtherLongTermAssetsConstants.DueFromSisterCompaniesLTNonIslamic]);
            return entity;
        }
    }
}
