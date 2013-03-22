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
    public class ZakatCollectionRepository : RepositoryBaseClass<ZakatCollection>
    {
        public void DeleteByZakatMetaID(int zakatMetaID, ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(ZakatCollectionRepositoryConstants.SP_DeleteByZakatMetaID);
                database.AddInParameter(cmd, ZakatCollectionRepositoryConstants.ZakatMetaID, DbType.Int32, zakatMetaID);


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

        public override void Delete(ZakatCollection entity, Common.ActionState actionState)
        {
            
        }

        public override void Insert(ZakatCollection entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(ZakatCollectionRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, ZakatCollectionRepositoryConstants.Value, DbType.Decimal, entity.Value);
                database.AddInParameter(cmd, ZakatCollectionRepositoryConstants.Year, DbType.Int32, entity.Value);
                database.AddInParameter(cmd, ZakatCollectionRepositoryConstants.ZakatMetaID, DbType.Int32, entity.ZakatMetaID);

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

        public List<ZakatCollection> FindByZakatMetaID(int zakatMetaID, Common.ActionState actionState)
        {
            List<ZakatCollection> zakatCollectionList;
            ZakatCollection zakatCollectionEntity;
            DbCommand cmd;

            zakatCollectionList = new List<ZakatCollection>();
            zakatCollectionEntity = null;

            try
            {
                cmd = database.GetStoredProcCommand(ZakatCollectionRepositoryConstants.SP_FindByZakatMetaID);
                database.AddInParameter(cmd, ZakatCollectionRepositoryConstants.ZakatMetaID, DbType.Int32, zakatMetaID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        zakatCollectionEntity = ZakatCollectionHelper(reader);
                        if (zakatCollectionEntity != null)
                        {
                            zakatCollectionList.Add(zakatCollectionEntity);
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
            return zakatCollectionList;
        }


        public override void Update(ZakatCollection entity, Common.ActionState actionState)
        {
            
        }

        public override List<ZakatCollection> FindAll(Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override ZakatCollection FindByID(int entityID, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(ZakatCollection entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private ZakatCollection ZakatCollectionHelper(SqlDataReader reader)
        {
            ZakatCollection zakatCollection = new ZakatCollection();
            zakatCollection.ID = Convert.ToInt32(reader[ZakatCollectionConstants.ID]);
            zakatCollection.Year = Convert.ToInt32(reader[ZakatCollectionConstants.Year]);
            zakatCollection.ZakatMetaID = Convert.ToInt32(reader[ZakatCollectionConstants.ZakatMetaID]);
            zakatCollection.Value = (float)Convert.ToDouble(reader[ZakatCollectionConstants.Value]);
            return zakatCollection;
        }
    }
}
