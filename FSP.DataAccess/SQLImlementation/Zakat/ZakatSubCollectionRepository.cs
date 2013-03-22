using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common;
using FSP.Common.Constants.Zakat;
using FSP.Common.Entites.Zakat;
using FSP.Common.Enums;
using FSP.DataAccess.BaseClasses;
using FSP.DataAccess.Constants.Common;
using FSP.DataAccess.Constants.Zakat;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace FSP.DataAccess.SQLImlementation.Zakat
{
    public class ZakatSubCollectionRepository : RepositoryBaseClass<ZakatSubCollection>
    {

        public void DeleteByZakatMetaID(int zakatMetaID, ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(ZakatSubCollectionRepositoryConstants.SP_DeleteByZakatMetaID);
                database.AddInParameter(cmd, ZakatSubCollectionRepositoryConstants.ZakatMetaID, DbType.Int32, zakatMetaID);


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

        public override void Delete(ZakatSubCollection entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(ZakatSubCollectionRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, ZakatSubCollectionRepositoryConstants.Value, DbType.Decimal, entity.Value);
                database.AddInParameter(cmd, ZakatSubCollectionRepositoryConstants.Year, DbType.Int32, entity.Value);
                database.AddInParameter(cmd, ZakatSubCollectionRepositoryConstants.ZakatMetaID, DbType.Int32, entity.ZakatMetaID);
                database.AddInParameter(cmd, ZakatSubCollectionRepositoryConstants.CompanyID, DbType.Int32, entity.CompanyID);

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

        public override void Insert(ZakatSubCollection entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override void Update(ZakatSubCollection entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public List<ZakatSubCollection> FindByZakatMetaID(int zakatMetaID, Common.ActionState actionState)
        {
            List<ZakatSubCollection> zakatSubCollectionList;
            ZakatSubCollection zakatSubCollection;
            DbCommand cmd;

            zakatSubCollectionList = new List<ZakatSubCollection>();
            zakatSubCollection = null;

            try
            {
                cmd = database.GetStoredProcCommand(ZakatSubCollectionRepositoryConstants.SP_FindByZakatMetaID);
                database.AddInParameter(cmd, ZakatSubCollectionRepositoryConstants.ZakatMetaID, DbType.Int32, zakatMetaID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        zakatSubCollection = ZakatSubCollectionHelper(reader);
                        if (zakatSubCollection != null)
                        {
                            zakatSubCollectionList.Add(zakatSubCollection);
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
            return zakatSubCollectionList;
        }

        public override List<ZakatSubCollection> FindAll(Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override ZakatSubCollection FindByID(int entityID, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(ZakatSubCollection entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private ZakatSubCollection ZakatSubCollectionHelper(SqlDataReader reader)
        {
            ZakatSubCollection zakatSubCollection = new ZakatSubCollection();
            zakatSubCollection.CompanyID = Convert.ToInt32(reader[ZakatSubCollectionConstants.CompanyID]);
            zakatSubCollection.ID = Convert.ToInt32(reader[ZakatSubCollectionConstants.ID]);
            zakatSubCollection.Value = (float)Convert.ToDecimal(reader[ZakatSubCollectionConstants.Value]);
            zakatSubCollection.Year = Convert.ToInt32(reader[ZakatSubCollectionConstants.Year]);
            zakatSubCollection.ZakatMetaID = Convert.ToInt32(reader[ZakatSubCollectionConstants.ZakatMetaID]);
            return zakatSubCollection;
        }
    }
}
