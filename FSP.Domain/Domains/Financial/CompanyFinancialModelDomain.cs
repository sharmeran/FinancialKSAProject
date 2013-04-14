using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSP.Common.Entites.Financial;
using FSP.Common.Entites.Financial.Assets;
using FSP.Common.Entites.Financial.CashFlow;
using FSP.Common.Entites.Financial.Income;
using FSP.Common.Enums;
using FSP.DataAccess.SQLImlementation.Financial;
using FSP.DataAccess.SQLImlementation.Financial.Assets;
using FSP.DataAccess.SQLImlementation.Financial.Income;
using FSP.DataAccess.SQLImlementation.Financial.CashFlow;
using FSP.Domain.BaseClasses;

namespace FSP.Domain.Domains.Financial
{
    public class CompanyFinancialModelDomain : BusinessDomainBase<CompanyFinancialModel>
    {
        public CompanyFinancialModelDomain(int userID, LanguagesEnum language)
            : base(userID, language)
        {
            DBRepository = new CompanyFinancialModelRepository();
        }

        public override void Add(CompanyFinancialModel entity)
        {
            DBRepository.Insert(entity, ActionState);

            #region Income List Insert
            for (int i = 0; i < entity.IncomeList.Count; i++)
            {
                entity.IncomeList[i].CompanyFinancialModelID = entity.ID;
                IncomeStatmentRepository incomeStatmentRepository = new IncomeStatmentRepository();
                incomeStatmentRepository.Insert(entity.IncomeList[i], ActionState);
                for (int ii = 0; ii < entity.IncomeList[i].GrossProfitList.Count; ii++)
                {
                    entity.IncomeList[i].GrossProfitList[ii].IncomeStatmentID = entity.IncomeList[i].ID;
                    GrossProfitRepository grossProfitRepository = new GrossProfitRepository();
                    grossProfitRepository.Insert(entity.IncomeList[i].GrossProfitList[ii], ActionState);
                }
                for (int ii = 0; ii < entity.IncomeList[i].IncomeBeforeXOList.Count; ii++)
                {
                    entity.IncomeList[i].IncomeBeforeXOList[ii].IncomeStatmentID = entity.IncomeList[i].ID;
                    IncomeBeforeXORepository incomeBeforeXORepository = new IncomeBeforeXORepository();
                    incomeBeforeXORepository.Insert(entity.IncomeList[i].IncomeBeforeXOList[ii], ActionState);
                }
                for (int ii = 0; ii < entity.IncomeList[i].NetIncomeList.Count; ii++)
                {
                    entity.IncomeList[i].NetIncomeList[ii].IncomeStatmentID = entity.IncomeList[i].ID;
                    NetIncomeRepository netIncomeRepository = new NetIncomeRepository();
                    netIncomeRepository.Insert(entity.IncomeList[i].NetIncomeList[ii], ActionState);
                }
                for (int ii = 0; ii < entity.IncomeList[i].OperatingIncomeList.Count; ii++)
                {
                    entity.IncomeList[i].OperatingIncomeList[ii].IncomeStatmentID = entity.IncomeList[i].ID;
                    OperatingIncomeRepository operatingIncomeRepository = new OperatingIncomeRepository();
                    operatingIncomeRepository.Insert(entity.IncomeList[i].OperatingIncomeList[ii], ActionState);
                }
                for (int ii = 0; ii < entity.IncomeList[i].ReferenceItemList.Count; ii++)
                {
                    entity.IncomeList[i].ReferenceItemList[ii].IncomeStatmentID = entity.IncomeList[i].ID;
                    FSP.DataAccess.SQLImlementation.Financial.Income.ReferenceItemRepository referenceItemRepository = new FSP.DataAccess.SQLImlementation.Financial.Income.ReferenceItemRepository();
                    referenceItemRepository.Insert(entity.IncomeList[i].ReferenceItemList[ii], ActionState);
                }
                for (int ii = 0; ii < entity.IncomeList[i].RevenueList.Count; ii++)
                {
                    entity.IncomeList[i].RevenueList[ii].IncomeStatmentID = entity.IncomeList[i].ID;
                    RevenueRepository revenueRepository = new RevenueRepository();
                    revenueRepository.Insert(entity.IncomeList[i].RevenueList[ii], ActionState);
                }
                for (int ii = 0; ii < entity.IncomeList[i].TotalFinancialIncomeList.Count; ii++)
                {
                    entity.IncomeList[i].TotalFinancialIncomeList[ii].IncomeStatmentID = entity.IncomeList[i].ID;
                    TotalFinancialIncomeRepository totalFinancialIncomeRepository = new TotalFinancialIncomeRepository();
                    totalFinancialIncomeRepository.Insert(entity.IncomeList[i].TotalFinancialIncomeList[ii], ActionState);
                }
            }
            #endregion

            #region Assets List Insert
            for (int x = 0; x < entity.AssetsList.Count; x++)
            {
                entity.AssetsList[x].CompanyFinancialModelID = entity.ID;
                AssetRepository assetRepository = new AssetRepository();
                assetRepository.Insert(entity.AssetsList[x], ActionState);
                for (int xx = 0; xx < entity.AssetsList[x].AssetReferenceItemList.Count; xx++)
                {
                    entity.AssetsList[x].AssetReferenceItemList[xx].AssetsID = entity.AssetsList[x].ID;
                    AssetReferenceItemRepository assetReferenceItemRepository = new AssetReferenceItemRepository();
                    assetReferenceItemRepository.Insert(entity.AssetsList[x].AssetReferenceItemList[xx], ActionState);
                }
                for (int xx = 0; xx < entity.AssetsList[x].CashAndCashEquivalentList.Count; xx++)
                {
                    entity.AssetsList[x].CashAndCashEquivalentList[xx].AssetsID = entity.AssetsList[x].ID;
                    CashAndCashEquivalentRepository cashAndCashEquivalentRepository = new CashAndCashEquivalentRepository();
                    cashAndCashEquivalentRepository.Insert(entity.AssetsList[x].CashAndCashEquivalentList[xx], ActionState);
                }
                for (int xx = 0; xx < entity.AssetsList[x].CurrentReceivablesList.Count; xx++)
                {
                    entity.AssetsList[x].CurrentReceivablesList[xx].AssetsID = entity.AssetsList[x].ID;
                    CurrentReceivablesRepository currentReceivablesRepository = new CurrentReceivablesRepository();
                    currentReceivablesRepository.Insert(entity.AssetsList[x].CurrentReceivablesList[xx], ActionState);
                }
                for (int xx = 0; xx < entity.AssetsList[x].IntangiblesList.Count; xx++)
                {
                    entity.AssetsList[x].IntangiblesList[xx].AssetsID = entity.AssetsList[x].ID;
                    IntangiblesRepository intangiblesRepository = new IntangiblesRepository();
                    intangiblesRepository.Insert(entity.AssetsList[x].IntangiblesList[xx], ActionState);
                }
                for (int xx = 0; xx < entity.AssetsList[x].LiabilitiesShareholdersEquityList.Count; xx++)
                {
                    entity.AssetsList[x].LiabilitiesShareholdersEquityList[xx].AssetsID = entity.AssetsList[x].ID;
                    LiabilitiesShareholdersEquityRepository liabilitiesShareholdersEquityRepository = new LiabilitiesShareholdersEquityRepository();
                    liabilitiesShareholdersEquityRepository.Insert(entity.AssetsList[x].LiabilitiesShareholdersEquityList[xx], ActionState);
                }
                for (int xx = 0; xx < entity.AssetsList[x].NetReceivablesList.Count; xx++)
                {
                    entity.AssetsList[x].NetReceivablesList[xx].AssetsID = entity.AssetsList[x].ID;
                    NetReceivablesRepository netReceivablesRepository = new NetReceivablesRepository();
                    netReceivablesRepository.Insert(entity.AssetsList[x].NetReceivablesList[xx], ActionState);
                }
                for (int xx = 0; xx < entity.AssetsList[x].OtherLongTermAssetsList.Count; xx++)
                {
                    entity.AssetsList[x].OtherLongTermAssetsList[xx].AssetsID = entity.AssetsList[x].ID;
                    OtherLongTermAssetsRepository otherLongTermAssetsRepository = new OtherLongTermAssetsRepository();
                    otherLongTermAssetsRepository.Insert(entity.AssetsList[x].OtherLongTermAssetsList[xx], ActionState);
                }
                for (int xx = 0; xx < entity.AssetsList[x].OtherLongTermLiabilitiesList.Count; xx++)
                {
                    entity.AssetsList[x].OtherLongTermLiabilitiesList[xx].AssetsID = entity.AssetsList[x].ID;
                    OtherLongTermLiabilitiesRepository otherLongTermLiabilitiesRepository = new OtherLongTermLiabilitiesRepository();
                    otherLongTermLiabilitiesRepository.Insert(entity.AssetsList[x].OtherLongTermLiabilitiesList[xx], ActionState);
                }
                for (int xx = 0; xx < entity.AssetsList[x].OtherShortTermLiabilitiesList.Count; xx++)
                {
                    entity.AssetsList[x].OtherShortTermLiabilitiesList[xx].AssetsID = entity.AssetsList[x].ID;
                    OtherShortTermLiabilitiesRepository otherShortTermLiabilitiesRepository = new OtherShortTermLiabilitiesRepository();
                    otherShortTermLiabilitiesRepository.Insert(entity.AssetsList[x].OtherShortTermLiabilitiesList[xx], ActionState);
                }
                for (int xx = 0; xx < entity.AssetsList[x].ShortTermInvestmentsList.Count; xx++)
                {
                    entity.AssetsList[x].ShortTermInvestmentsList[xx].AssetsID = entity.AssetsList[x].ID;
                    ShortTermInvestmentsRepository shortTermInvestmentsRepository = new ShortTermInvestmentsRepository();
                    shortTermInvestmentsRepository.Insert(entity.AssetsList[x].ShortTermInvestmentsList[xx], ActionState);
                }
                for (int xx = 0; xx < entity.AssetsList[x].TotalCurrentAssetsList.Count; xx++)
                {
                    entity.AssetsList[x].TotalCurrentAssetsList[xx].AssetsID = entity.AssetsList[x].ID;
                    TotalCurrentAssetsRepository totalCurrentAssetsRepository = new TotalCurrentAssetsRepository();
                    totalCurrentAssetsRepository.Insert(entity.AssetsList[x].TotalCurrentAssetsList[xx], ActionState);
                }
                for (int xx = 0; xx < entity.AssetsList[x].TotalCurrentLiabilitiesList.Count; xx++)
                {
                    entity.AssetsList[x].TotalCurrentLiabilitiesList[xx].AssetsID = entity.AssetsList[x].ID;
                    TotalCurrentLiabilitiesRepository totalCurrentLiabilitiesRepository = new TotalCurrentLiabilitiesRepository();
                    totalCurrentLiabilitiesRepository.Insert(entity.AssetsList[x].TotalCurrentLiabilitiesList[xx], ActionState);
                }
                for (int xx = 0; xx < entity.AssetsList[x].TotalLiabilitiesAndProvisionsList.Count; xx++)
                {
                    entity.AssetsList[x].TotalLiabilitiesAndProvisionsList[xx].AssetsID = entity.AssetsList[x].ID;
                    TotalLiabilitiesAndProvisionsRepository totalLiabilitiesAndProvisionsRepository = new TotalLiabilitiesAndProvisionsRepository();
                    totalLiabilitiesAndProvisionsRepository.Insert(entity.AssetsList[x].TotalLiabilitiesAndProvisionsList[xx], ActionState);
                }
                for (int xx = 0; xx < entity.AssetsList[x].TotalLongTermDebtList.Count; xx++)
                {
                    entity.AssetsList[x].TotalLongTermDebtList[xx].AssetsID = entity.AssetsList[x].ID;
                    TotalLongTermDebtRepository totalLongTermDebtRepository = new TotalLongTermDebtRepository();
                    totalLongTermDebtRepository.Insert(entity.AssetsList[x].TotalLongTermDebtList[xx], ActionState);
                }
                for (int xx = 0; xx < entity.AssetsList[x].TotalLongTermInvestmentList.Count; xx++)
                {
                    entity.AssetsList[x].TotalLongTermInvestmentList[xx].AssetsID = entity.AssetsList[x].ID;
                    TotalLongTermInvestmentRepository totalLongTermInvestmentRepository = new TotalLongTermInvestmentRepository();
                    totalLongTermInvestmentRepository.Insert(entity.AssetsList[x].TotalLongTermInvestmentList[xx], ActionState);
                }
            }
            #endregion

            #region CashFlow List Insert
            for (int z = 0; z < entity.CashFlowList.Count; z++)
            {
                entity.CashFlowList[z].CompanyFinancialModelID = entity.ID;
                CashFlowStatementRepository cashFlowStatementRepository = new CashFlowStatementRepository();
                cashFlowStatementRepository.Insert(entity.CashFlowList[z], ActionState);
                for (int zz = 0; zz < entity.CashFlowList[z].CashCashEquivalentPeriodEndList.Count; zz++)
                {
                    entity.CashFlowList[z].CashCashEquivalentPeriodEndList[zz].CashFlowStatementID = entity.CashFlowList[z].ID;
                    CashCashEquivalentPeriodEndRepository cashCashEquivalentPeriodEndRepository = new CashCashEquivalentPeriodEndRepository();
                    cashCashEquivalentPeriodEndRepository.Insert(entity.CashFlowList[z].CashCashEquivalentPeriodEndList[zz], ActionState);
                }
                for (int zz = 0; zz < entity.CashFlowList[z].CashFlowsFromInvestingActivitiesList.Count; zz++)
                {
                    entity.CashFlowList[z].CashFlowsFromInvestingActivitiesList[zz].CashFlowStatementID = entity.CashFlowList[z].ID;
                    CashFlowsFromInvestingActivitiesRepository cashFlowsFromInvestingActivitiesRepository = new CashFlowsFromInvestingActivitiesRepository();
                    cashFlowsFromInvestingActivitiesRepository.Insert(entity.CashFlowList[z].CashFlowsFromInvestingActivitiesList[zz], ActionState);
                }
                for (int zz = 0; zz < entity.CashFlowList[z].CashFlowsFromOperatingActivitiesList.Count; zz++)
                {
                    entity.CashFlowList[z].CashFlowsFromOperatingActivitiesList[zz].CashFlowStatmentID = entity.CashFlowList[z].ID;
                    CashFlowsFromOperatingActivitiesRepository cashFlowsFromOperatingActivitiesRepository = new CashFlowsFromOperatingActivitiesRepository();
                    cashFlowsFromOperatingActivitiesRepository.Insert(entity.CashFlowList[z].CashFlowsFromOperatingActivitiesList[zz], ActionState);
                }
                for (int zz = 0; zz < entity.CashFlowList[z].CashFromFinancingActivitiesList.Count; zz++)
                {
                    entity.CashFlowList[z].CashFromFinancingActivitiesList[zz].CashFlowStatmentID = entity.CashFlowList[z].ID;
                    CashFromFinancingActivitiesRepository cashFromFinancingActivitiesRepository = new CashFromFinancingActivitiesRepository();
                    cashFromFinancingActivitiesRepository.Insert(entity.CashFlowList[z].CashFromFinancingActivitiesList[zz], ActionState);
                }
                for (int zz = 0; zz < entity.CashFlowList[z].ReferenceItemList.Count; zz++)
                {
                    entity.CashFlowList[z].ReferenceItemList[zz].CashFlowStatementID = entity.CashFlowList[z].ID;
                    FSP.DataAccess.SQLImlementation.Financial.CashFlow.ReferenceItemRepository referenceItemRepository = new FSP.DataAccess.SQLImlementation.Financial.CashFlow.ReferenceItemRepository();
                    referenceItemRepository.Insert(entity.CashFlowList[z].ReferenceItemList[zz], ActionState);
                }
            }
            #endregion
        }

        public override void Delete(CompanyFinancialModel entity)
        {
            DBRepository.Delete(entity, ActionState);

            //Here code to Delete all childs for the entity
        }

        public override void Update(CompanyFinancialModel entity)
        {
            DBRepository.Update(entity, ActionState);
        }

        public override List<CompanyFinancialModel> FindAll()
        {
            return DBRepository.FindAll(ActionState);
        }

        public override CompanyFinancialModel FindByID(int entityID)
        {
            return DBRepository.FindByID(entityID, ActionState);
        }

        public override bool IsExist(CompanyFinancialModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
