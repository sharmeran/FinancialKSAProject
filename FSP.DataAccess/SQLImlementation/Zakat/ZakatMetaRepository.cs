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
    public class ZakatMetaRepository : RepositoryBaseClass<ZakatMeta>
    {

        public void DeleteByZakatMainID(int zakatMainID, ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(ZakatMetaRepositoryConstants.SP_DeleteByZakatMainID);
                database.AddInParameter(cmd, ZakatMetaRepositoryConstants.ZakatMainID, DbType.Int32, zakatMainID);


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

        public override void Delete(ZakatMeta entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override void Insert(ZakatMeta entity, Common.ActionState actionState)
        {
            int spResult;
            DbCommand cmd;

            try
            {
                cmd = database.GetStoredProcCommand(ZakatMetaRepositoryConstants.SP_Insert);
                database.AddInParameter(cmd, ZakatMetaRepositoryConstants.ZakatMainID, DbType.Int32, entity.ZakatMainID);
                database.AddInParameter(cmd, ZakatMetaRepositoryConstants.ZakatCollectionNumber, DbType.Int32, entity.ZakatCollectionNumber);
                database.AddInParameter(cmd, ZakatMetaRepositoryConstants.ZakatCustomCollectionNumber, DbType.Int32, entity.ZakatCustomCollectionNumber);
                database.AddInParameter(cmd, ZakatMetaRepositoryConstants.ZacatSubCollectionNumber, DbType.Int32, entity.ZacatSubCollectionNumber);
                database.AddInParameter(cmd, ZakatMetaRepositoryConstants.ZakatSubCustomCollectionNumber, DbType.Int32, entity.ZakatSubCustomCollectionNumber);         


                spResult =Convert.ToInt32( database.ExecuteScalar(cmd));
                if (spResult > 0)
                {
                    entity.ID = spResult;
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

        public override void Update(ZakatMeta entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override List<ZakatMeta> FindAll(Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public override ZakatMeta FindByID(int entityID, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        public List<ZakatMeta> FindByZakatMainID(int zakatMainID, Common.ActionState actionState)
        {
            List<ZakatMeta> zakatMetaList;
            ZakatMeta zakatMeta;
            DbCommand cmd;

            zakatMetaList = new List<ZakatMeta>();
            zakatMeta = null;

            try
            {
                cmd = database.GetStoredProcCommand(ZakatMetaRepositoryConstants.SP_FindByZakatMainID);
                database.AddInParameter(cmd, ZakatMetaRepositoryConstants.ZakatMainID, DbType.Int32, zakatMainID);
                using (SqlDataReader reader = ((SqlDataReader)((RefCountingDataReader)database.ExecuteReader(cmd)).InnerReader))
                {
                    while (reader.Read())
                    {
                        zakatMeta = ZakatMetaHelper(reader);
                        if (zakatMeta != null)
                        {
                            zakatMetaList.Add(zakatMeta);
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
            return zakatMetaList;
        }

        public override bool IsExist(ZakatMeta entity, Common.ActionState actionState)
        {
            throw new NotImplementedException();
        }

        private ZakatMeta ZakatMetaHelper(SqlDataReader reader)
        {
            ZakatMeta zakatMeta = new ZakatMeta();
            zakatMeta.ID = Convert.ToInt32(reader[ZakatMetaConstants.ID]);
            zakatMeta.ZacatSubCollectionNumber = Convert.ToInt32(reader[ZakatMetaConstants.ZacatSubCollectionNumber]);
            ZakatCollectionRepository zakatCollectionRepository= new ZakatCollectionRepository();
            zakatMeta.ZakatCollectionList = zakatCollectionRepository.FindByZakatMetaID(zakatMeta.ID, new Common.ActionState());
            zakatMeta.ZakatCollectionNumber = Convert.ToInt32(reader[ZakatMetaConstants.ZakatCollectionNumber]);
            ZakatCustomCollectionRepository zakatCustomCollectionRepository= new ZakatCustomCollectionRepository();
            zakatMeta.ZakatCustomCollectionList = zakatCustomCollectionRepository.FindByZakatMetaID(zakatMeta.ID, new Common.ActionState());
            zakatMeta.ZakatCustomCollectionNumber = Convert.ToInt32(reader[ZakatMetaConstants.ZakatCustomCollectionNumber]);
            ZakatCustomSubCollectionRepository zakatCustomSubCollectionRepository= new ZakatCustomSubCollectionRepository();
            zakatMeta.ZakatCustomSubCollectionList = zakatCustomSubCollectionRepository.FindByZakatMetaID(zakatMeta.ID, new Common.ActionState());
            zakatMeta.ZakatMainID = Convert.ToInt32(reader[ZakatMetaConstants.ZakatMainID]);
            ZakatSubCollectionRepository zakatSubCollectionRepository= new ZakatSubCollectionRepository();
            zakatMeta.ZakatSubCollectionList = zakatSubCollectionRepository.FindByZakatMetaID(zakatMeta.ID, new Common.ActionState());
            zakatMeta.ZakatSubCustomCollectionNumber = Convert.ToInt32(reader[ZakatMetaConstants.ZakatSubCustomCollectionNumber]);
            return zakatMeta;
        }
    }
}
