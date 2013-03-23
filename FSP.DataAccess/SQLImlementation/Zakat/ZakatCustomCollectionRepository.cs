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
    public class ZakatCustomCollectionRepository : RepositoryBaseClass<ZakatCustomCollection>
    {

        public void DeleteByZakatMetaID(int zakatMetaID, ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(ZakatCustomCollectionRepositoryConstants.SP_DeleteByZakatMetaID);
                database.AddInParameter(cmd, ZakatCustomCollectionRepositoryConstants.ZakatMetaID, DbType.Int32, zakatMetaID);


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

        public override void Delete(ZakatCustomCollection entity, Common.ActionState actionState)
        {            
        }

        public override void Insert(ZakatCustomCollection entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(ZakatCustomCollectionRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, ZakatCustomCollectionRepositoryConstants.Value, DbType.Decimal, entity.Value);
                database.AddInParameter(cmd, ZakatCustomCollectionRepositoryConstants.Year, DbType.Int32, entity.Year);
                database.AddInParameter(cmd, ZakatCustomCollectionRepositoryConstants.ZakatMetaID, DbType.Int32, entity.ZakatMetaID);

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


        public override void Update(ZakatCustomCollection entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public List<ZakatCustomCollection> FindByZakatMetaID(int zakatMetaID, Common.ActionState actionState)
        {
            List<ZakatCustomCollection> zakatCustomCollectionList;
            ZakatCustomCollection zakatCustomCollection;
            DbCommand cmd;

            zakatCustomCollectionList = new List<ZakatCustomCollection>();
            zakatCustomCollection = null;

            try
            {
                cmd = database.GetStoredProcCommand(ZakatCustomCollectionRepositoryConstants.SP_FindByZakatMetaID);
                database.AddInParameter(cmd, ZakatCustomCollectionRepositoryConstants.ZakatMetaID, DbType.Int32, zakatMetaID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        zakatCustomCollection = ZakatCustomCollectionHelper(reader);
                        if (zakatCustomCollection != null)
                        {
                            zakatCustomCollectionList.Add(zakatCustomCollection);
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
            return zakatCustomCollectionList;
        }

        public override List<ZakatCustomCollection> FindAll(Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override ZakatCustomCollection FindByID(int entityID, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(ZakatCustomCollection entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private ZakatCustomCollection ZakatCustomCollectionHelper(SqlDataReader reader)
        {
            ZakatCustomCollection zakatCustomCollection = new ZakatCustomCollection();
            zakatCustomCollection.ID = Convert.ToInt32(reader[ZakatCustomCollectionConstants.ID]);
            zakatCustomCollection.Value = (float)Convert.ToDecimal(reader[ZakatCustomCollectionConstants.Value]);
            zakatCustomCollection.Year = Convert.ToInt32(reader[ZakatCustomCollectionConstants.Year]);
            zakatCustomCollection.ZakatMetaID = Convert.ToInt32(reader[ZakatCustomCollectionConstants.ZakatMetaID]);
            return zakatCustomCollection;
        }
    }
}
