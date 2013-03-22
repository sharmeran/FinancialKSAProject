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
    public class ZakatCustomSubCollectionRepository : RepositoryBaseClass<ZakatCustomSubCollection>
    {

        public void DeleteByZakatMetaID(int zakatMetaID, ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(ZakatCustomSubCollectionRepositoryConstants.SP_DeleteByZakatMetaID);
                database.AddInParameter(cmd, ZakatCustomSubCollectionRepositoryConstants.ZakatMetaID, DbType.Int32, zakatMetaID);


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

        public override void Delete(ZakatCustomSubCollection entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override void Insert(ZakatCustomSubCollection entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(ZakatCustomSubCollectionRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, ZakatCustomSubCollectionRepositoryConstants.Value, DbType.Decimal, entity.Value);
                database.AddInParameter(cmd, ZakatCustomSubCollectionRepositoryConstants.Year, DbType.Int32, entity.Value);
                database.AddInParameter(cmd, ZakatCustomSubCollectionRepositoryConstants.ZakatMetaID, DbType.Int32, entity.ZakatMetaID);
                database.AddInParameter(cmd, ZakatCustomSubCollectionRepositoryConstants.CompanyID, DbType.Int32, entity.CompanyID);

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

        public override void Update(ZakatCustomSubCollection entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public List<ZakatCustomSubCollection> FindByZakatMetaID(int zakatMetaID, Common.ActionState actionState)
        {
            List<ZakatCustomSubCollection> zakatCustomSubCollectionList;
            ZakatCustomSubCollection zakatCustomSubCollection;
            DbCommand cmd;

            zakatCustomSubCollectionList = new List<ZakatCustomSubCollection>();
            zakatCustomSubCollection = null;

            try
            {
                cmd = database.GetStoredProcCommand(ZakatCustomSubCollectionRepositoryConstants.SP_FindByZakatMetaID);
                database.AddInParameter(cmd, ZakatCustomSubCollectionRepositoryConstants.ZakatMetaID, DbType.Int32, zakatMetaID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        zakatCustomSubCollection = ZakatCustomSubCollectionHelper(reader);
                        if (zakatCustomSubCollection != null)
                        {
                            zakatCustomSubCollectionList.Add(zakatCustomSubCollection);
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
            return zakatCustomSubCollectionList;
        }

        public override List<ZakatCustomSubCollection> FindAll(Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override ZakatCustomSubCollection FindByID(int entityID, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(ZakatCustomSubCollection entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private ZakatCustomSubCollection ZakatCustomSubCollectionHelper(SqlDataReader reader)
        {
            ZakatCustomSubCollection zakatCustomSubCollection = new ZakatCustomSubCollection();
            zakatCustomSubCollection.CompanyID = Convert.ToInt32(reader[ZakatCustomSubCollectionConstants.CompanyID]);
            zakatCustomSubCollection.ID = Convert.ToInt32(reader[ZakatCustomSubCollectionConstants.ID]);
            zakatCustomSubCollection.Value=(float)Convert.ToDecimal(reader[ZakatCustomSubCollectionConstants.Value]);
            zakatCustomSubCollection.Year = Convert.ToInt32(reader[ZakatCustomSubCollectionConstants.Year]);
            zakatCustomSubCollection.ZakatMetaID = Convert.ToInt32(reader[ZakatCustomSubCollectionConstants.ZakatMetaID]);
            return zakatCustomSubCollection;
        }
    }
}
