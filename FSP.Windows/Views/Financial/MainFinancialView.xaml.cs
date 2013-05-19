using FSP.Common;
using FSP.Common.Entites.CompanyAdministration;
using FSP.Domain.Domains.CompanyAdministration;
using FSP.Domain.Domains.Financial;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FSP.Windows.Views.Financial
{
    /// <summary>
    /// Interaction logic for MainFinancialView.xaml
    /// </summary>
    public partial class MainFinancialView : UserControl
    {
        public MainFinancialView()
        {
            InitializeComponent();
        }
        CompanyDomain companyDomain = new CompanyDomain(1, Common.Enums.LanguagesEnum.Arabic);
        List<Company> companyList = new List<Company>();
        Dictionary<string, decimal> dataBank = new Dictionary<string, decimal>();
        MainFinancialDomain mainFinancialDomain = new MainFinancialDomain();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            companyList = companyDomain.FindNotFull();
            cmbo_Company.ItemsSource = companyList;
            cmbo_Company.SelectedIndex = 0;
        }

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txt_FileName.Text = openFileDialog.FileName;
                ActionState actionState = new ActionState();
                dataBank = mainFinancialDomain.ProcessingData(openFileDialog.FileName, actionState);
                if (actionState.Status == Common.Enums.ActionStatusEnum.NoError)
                    PrpareViewData();
                else
                    MessageBox.Show(actionState.Result, "خطأ في استخلاص البيانات", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void PrpareViewData()
        {
            #region Income Statment
            txt_Revenues.Value = mainFinancialDomain.GetValue(dataBank, "Revenues");
            txt_CostOfRevenue.Value = mainFinancialDomain.GetValue(dataBank, "Cost of Revenue");
            txt_SellingGeneral.Value = mainFinancialDomain.GetValue(dataBank, "Selling, General & Admin Expense");
            txt_GrossProfit.Value = txt_Revenues.Value - txt_CostOfRevenue.Value;
            //txt_OperatingIncome.Value = txt_GrossProfit.Value - txt_SellingGeneral.Value;
            txt_InterestExpense.Value = mainFinancialDomain.GetValue(dataBank, "Interest Expense");
            txt_NetProfitBeforeTax.Value = mainFinancialDomain.GetValue(dataBank, "Pretax Income");
            txt_IncomeTax.Value = mainFinancialDomain.GetValue(dataBank, "Income Tax Expense");
            txt_InterestExpense.Value = mainFinancialDomain.GetValue(dataBank, "Interest Expense");
            txt_IncomeBeforeXOItems.Value = mainFinancialDomain.GetValue(dataBank, "Income Before XO Items");
            txt_ExtraordinaryLossNetOfTax.Value = mainFinancialDomain.GetValue(dataBank, "Extraordinary Loss Net of Tax");
            txt_MinorityInterests.Value = mainFinancialDomain.GetValue(dataBank, "Minority Interests");
            txt_NetIncome.Value = mainFinancialDomain.GetValue(dataBank, "Net Income");
            txt_TotalCashPreferredDividends.Value = mainFinancialDomain.GetValue(dataBank, "Total Cash Preferred Dividends");
            txt_OtherAdjustment.Value = mainFinancialDomain.GetValue(dataBank, "Other Adjustments");
            txt_NetIncAvailtoCommonShareholders.Value = mainFinancialDomain.GetValue(dataBank, "Net Inc Avail to Common Shareholders");
            txt_AbnormalLoss.Value = mainFinancialDomain.GetValue(dataBank, "Abnormal Loss");
            txt_TaxEffectOnAbnormalItems.Value = mainFinancialDomain.GetValue(dataBank, "Tax Effect on Abnormal Items");
            txt_NormalizedIncome.Value = mainFinancialDomain.GetValue(dataBank, "Normalized Income");
            txt_ComprehensiveIncome.Value = mainFinancialDomain.GetValue(dataBank, "Comprehensive Income");
            txt_ComprehensiveIncomePerShare.Value = mainFinancialDomain.GetValue(dataBank, "Comprehensive Income per Share");
            txt_BasicEPSBeforeAbnormalItems.Value = mainFinancialDomain.GetValue(dataBank, "Basic EPS Before Abnormal Items");
            txt_BasicEPSBeforeXOItems.Value = mainFinancialDomain.GetValue(dataBank, "Basic EPS Before XO Items");
            txt_BasicEPS.Value = mainFinancialDomain.GetValue(dataBank, "Basic EPS");
            txt_BasicWeightedAvgShares.Value = mainFinancialDomain.GetValue(dataBank, "Basic Weighted Avg Shares");
            txt_DilutedEPSBeforeAbnormalItems.Value = mainFinancialDomain.GetValue(dataBank, "Diluted EPS Before Abnormal Items");
            txt_DilutedEPSBeforeXOItems.Value = mainFinancialDomain.GetValue(dataBank, "Diluted EPS Before XO Items");
            txt_DilutedEPS.Value = mainFinancialDomain.GetValue(dataBank, "Diluted EPS");
            txt_DilutedWeightedAvgShares.Value = mainFinancialDomain.GetValue(dataBank, "Diluted Weighted Avg Shares");
            txt_EBITDA.Value = mainFinancialDomain.GetValue(dataBank, "EBITDA");
            txt_GrossMargin.Value = mainFinancialDomain.GetValue(dataBank, "Gross Margin");
            txt_OperatingMargin.Value = mainFinancialDomain.GetValue(dataBank, "Operating Margin");
            txt_ProfitMargin.Value = mainFinancialDomain.GetValue(dataBank, "Profit Margin");
            txt_ActualSalesPerEmployee.Value = mainFinancialDomain.GetValue(dataBank, "Actual Sales Per Employee");
            txt_DividendsPerShare.Value = mainFinancialDomain.GetValue(dataBank, "Dividends per Share");
            txt_TotalCashCommonDividends.Value = mainFinancialDomain.GetValue(dataBank, "Total Cash Common Dividends");
            txt_SalesGrowth.Value = mainFinancialDomain.GetValue(dataBank, "Sales Growth");
            txt_BasicEPSBeforeXOGrowth.Value = mainFinancialDomain.GetValue(dataBank, "Basic EPS Before XO Growth");
            txt_InterestIncome.Value = mainFinancialDomain.GetValue(dataBank, "Interest Income");
            txt_CapitalizedInterestExpense.Value = mainFinancialDomain.GetValue(dataBank, "Capitalized Interest Expense");
            txt_ResearchDevelopmentExpense.Value = mainFinancialDomain.GetValue(dataBank, "Research & Development Expense");
            txt_DepreciationExpense.Value = mainFinancialDomain.GetValue(dataBank, "Depreciation Expense");
            txt_PartialRecordIndicator.Value = mainFinancialDomain.GetValue(dataBank, "Partial Record Indicator");
            txt_GrossProfit.Value = txt_Revenues.Value - txt_CostOfRevenue.Value;
            txt_OperatingIncome.Value = txt_GrossProfit.Value - txt_SellingGeneral.Value;
            TotalFinancialIncomeCalc();
            txt_IncomeBeforeXOItems.Value = txt_NetProfitBeforeTax.Value + txt_IncomeTax.Value + txt_TaxProvision.Value;
            txt_NetProfitBeforeMinorityInterest.Value = txt_IncomeBeforeXOItems.Value - txt_ExtraordinaryLossNetOfTax.Value;
            txt_NetIncome.Value = txt_NetProfitBeforeMinorityInterest.Value - txt_MinorityInterests.Value;
            #endregion
            #region Cash Flow
            txt_CashFlowsFromOperatingActivities.Value = mainFinancialDomain.GetValue(dataBank, "Cash From Operating Activities");
            txt_NetIncomeBeforeTaxMinorityInterest.Value = mainFinancialDomain.GetValue(dataBank, "Net Income");
            txt_DepreciationAmortization.Value = mainFinancialDomain.GetValue(dataBank, "Depreciation & Amortization");
            txt_OtherNonCashAdjustments.Value = mainFinancialDomain.GetValue(dataBank, "Other Non-Cash Adjustments");
            txt_ChangesInNonCashCapital.Value = mainFinancialDomain.GetValue(dataBank, "Changes in Non-Cash Capital");
            txt_CashFlowsFromInvestingActivities.Value = mainFinancialDomain.GetValue(dataBank, "Cash From Investing Activities");
            txt_DisposalOfFixedAssets.Value = mainFinancialDomain.GetValue(dataBank, "Disposal of Fixed Assets");
            txt_CapitalExpenditures.Value = mainFinancialDomain.GetValue(dataBank, "Capital Expenditures");
            txt_IncreaseInInvestments.Value = mainFinancialDomain.GetValue(dataBank, "Increase in Investments");
            txt_DecreaseInInvestments.Value = mainFinancialDomain.GetValue(dataBank, "Decrease in Investments");
            txt_OtherCashInflowOutflow.Value = mainFinancialDomain.GetValue(dataBank, "Other Investing Activities");
            txt_CashFromFinancingActivities.Value = mainFinancialDomain.GetValue(dataBank, "Cash from Financing Activities");
            txt_DividendsPaidDuringTheYear.Value = mainFinancialDomain.GetValue(dataBank, "Dividends Paid");
            txt_IssuancesPurchasesOfEquityShares.Value = mainFinancialDomain.GetValue(dataBank, "Issuances (Purchases) of Equity Shares");
            txt_ChangeInShortTermBorrowings.Value = mainFinancialDomain.GetValue(dataBank, "Change in Short-Term Borrowings");
            txt_OtherFinInflowOutflow.Value = mainFinancialDomain.GetValue(dataBank, "Other Financing Activities");
            txt_NetChangeCashAndCashEquivalents.Value = mainFinancialDomain.GetValue(dataBank, "Net Changes in Cash");
            txt_EBITDACashFlow.Value = mainFinancialDomain.GetValue(dataBank, "EBITDA");
            txt_NetCashPaidForAcquisitions.Value = mainFinancialDomain.GetValue(dataBank, "Net Cash Paid for Acquisitions");
            txt_FreeCashFlow.Value = mainFinancialDomain.GetValue(dataBank, "Free Cash Flow");
            txt_FreeCashFlowToFirm.Value = mainFinancialDomain.GetValue(dataBank, "Free Cash Flow To Firm");
            txt_FreeCashFlowToEquity.Value = mainFinancialDomain.GetValue(dataBank, "Free Cash Flow to Equity");
            txt_FreeCashFlowPerBasicShare.Value = mainFinancialDomain.GetValue(dataBank, "Free Cash Flow per Basic Share");
            txt_PriceToFreeCashFlow.Value = mainFinancialDomain.GetValue(dataBank, "Price to Free Cash Flow");
            txt_CashFlowToNetIncome.Value = mainFinancialDomain.GetValue(dataBank, "Cash Flow to Net Income");
            CashFlowsFromOperatingActivitiesCalculation();
            CashFlowsFromInvestingActivitiesCalc();
            CashFromFinancingActivitiesCalc();
            txt_CashAndCashEquivalentAtPeriodEnd.Value =
              txt_NetChangeCashAndCashEquivalents.Value +
              txt_CashCashEquivalentAtStartOfPeriod.Value;

            txt_CashAndCashEquivalent.Value = mainFinancialDomain.GetValue(dataBank, "Cash & Near Cash Items");
            txt_ShortTermInvestments.Value = mainFinancialDomain.GetValue(dataBank, "Short-Term Investments");
            txt_NetReceivables.Value = mainFinancialDomain.GetValue(dataBank, "Accounts & Notes Receivable");
            txt_Inventories.Value = mainFinancialDomain.GetValue(dataBank, "Inventories");
            txt_OtherCurrentAssets.Value = mainFinancialDomain.GetValue(dataBank, "Other Current Assets");
            txt_TotalCurrentAssets.Value = mainFinancialDomain.GetValue(dataBank, "Total Current Assets");
            #endregion
        }
        #region Income Statment Calculations
        private void txt_Revenues_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            txt_GrossProfit.Value = txt_Revenues.Value - txt_CostOfRevenue.Value;
        }

        private void txt_CostOfRevenue_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            txt_GrossProfit.Value = txt_Revenues.Value - txt_CostOfRevenue.Value;
        }



        private void txt_SellingGeneral_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            txt_OperatingIncome.Value = txt_GrossProfit.Value - txt_SellingGeneral.Value;
        }

        private void TotalFinancialIncomeCalc()
        {
            txt_TotalFinancialIncome.Value = txt_InterestExpense.Value +
                txt_InterestExpenseNonIslamic.Value +
                txt_InterestIncome.Value +
                txt_InterestIncomeNonIslamic.Value +
                txt_InvestmentIncome.Value +
                txt_InvestmentIncomeNonIslamic.Value +
                txt_IncomeFromSisterCompany.Value +
                txt_IncomeFromSisterCompanyNonIslamic.Value +
                txt_OtherIncome.Value +
                txt_OtherExpense.Value +
                txt_OtherIncomeNonIslamic.Value +
                txt_OtherExpenseNonIslamic.Value;
        }

        private void txt_InterestExpense_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            TotalFinancialIncomeCalc();
        }

        private void txt_InterestExpenseNonIslamic_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            TotalFinancialIncomeCalc();
        }

        private void txt_InterestIncome_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            TotalFinancialIncomeCalc();
        }

        private void txt_InterestIncomeNonIslamic_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            TotalFinancialIncomeCalc();
        }

        private void txt_InvestmentIncome_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            TotalFinancialIncomeCalc();
        }

        private void txt_InvestmentIncomeNonIslamic_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            TotalFinancialIncomeCalc();
        }

        private void txt_IncomeFromSisterCompany_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            TotalFinancialIncomeCalc();
        }

        private void txt_IncomeFromSisterCompanyNonIslamic_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            TotalFinancialIncomeCalc();
        }

        private void txt_OtherIncome_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            TotalFinancialIncomeCalc();
        }

        private void txt_OtherExpense_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            TotalFinancialIncomeCalc();
        }

        private void txt_OtherIncomeNonIslamic_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            TotalFinancialIncomeCalc();
        }

        private void txt_OtherExpenseNonIslamic_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            TotalFinancialIncomeCalc();
        }

        private void txt_NetProfitBeforeTax_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            txt_IncomeBeforeXOItems.Value = txt_NetProfitBeforeTax.Value + txt_IncomeTax.Value + txt_TaxProvision.Value;
        }

        private void txt_IncomeTax_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            txt_IncomeBeforeXOItems.Value = txt_NetProfitBeforeTax.Value + txt_IncomeTax.Value + txt_TaxProvision.Value;
        }

        private void txt_TaxProvision_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            txt_IncomeBeforeXOItems.Value = txt_NetProfitBeforeTax.Value + txt_IncomeTax.Value + txt_TaxProvision.Value;
        }

        private void txt_ExtraordinaryLossNetOfTax_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            txt_NetProfitBeforeMinorityInterest.Value = txt_IncomeBeforeXOItems.Value - txt_ExtraordinaryLossNetOfTax.Value;
        }

        private void txt_IncomeBeforeXOItems_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            txt_NetProfitBeforeMinorityInterest.Value = txt_IncomeBeforeXOItems.Value - txt_ExtraordinaryLossNetOfTax.Value;
        }

        private void txt_NetProfitBeforeMinorityInterest_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            txt_NetIncome.Value = txt_NetProfitBeforeMinorityInterest.Value - txt_MinorityInterests.Value;
        }

        private void txt_MinorityInterests_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            txt_NetIncome.Value = txt_NetProfitBeforeMinorityInterest.Value - txt_MinorityInterests.Value;
        }

        private void txt_GrossProfit_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            txt_OperatingIncome.Value = txt_GrossProfit.Value - txt_SellingGeneral.Value;
        }

        #endregion

        #region Cash Flow Calculations
        private void CashFlowsFromOperatingActivitiesCalculation()
        {
            txt_CashFlowsFromOperatingActivities.Value =
                txt_NetIncomeBeforeTaxMinorityInterest.Value +
                txt_DepreciationAmortization.Value +
                txt_InterestedPaid.Value +
                txt_InterestReceived.Value +
                txt_TaxAndZakatPaid.Value +
                txt_MovementonWoekingCapital.Value +
                txt_ChangeInOperatingActivities.Value +
                txt_ChangeInProvisions.Value +
                txt_OthersCashFlow.Value +
                txt_OtherNonCashAdjustments.Value +
                txt_ChangesInNonCashCapital.Value;
        }

        private void CashFlowsFromInvestingActivitiesCalc()
        {
            txt_CashFlowsFromInvestingActivities.Value =
                txt_DisposalOfFixedAssets.Value +
                txt_CapitalExpenditures.Value +
                txt_IncDecInpropertyPlant.Value +
                txt_IncreaseInInvestments.Value +
                txt_DecreaseInInvestments.Value +
                txt_OtherCashInflowOutflow.Value;
        }
        private void CashFromFinancingActivitiesCalc()
        {
            txt_CashFromFinancingActivities.Value =
                txt_DividendsPaidDuringTheYear.Value +
                txt_IssuancesPurchasesOfEquityShares.Value +
                txt_ChangeInShortTermBorrowings.Value +
                txt_IncDecInLongTermBorrowings.Value +
                txt_IncDecInCapitalStocks.Value +
                txt_IncDecInLoans.Value +
                txt_EffectOfExchangeRatesOnCash.Value +
                txt_OtherFinInflowOutflow.Value;
        }
        private void txt_NetIncomeBeforeTaxMinorityInterest_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFlowsFromOperatingActivitiesCalculation();
        }

        private void txt_DepreciationAmortization_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFlowsFromOperatingActivitiesCalculation();
        }

        private void txt_InterestedPaid_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFlowsFromOperatingActivitiesCalculation();
        }

        private void txt_InterestReceived_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFlowsFromOperatingActivitiesCalculation();
        }

        private void txt_TaxAndZakatPaid_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFlowsFromOperatingActivitiesCalculation();
        }

        private void txt_MovementonWoekingCapital_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFlowsFromOperatingActivitiesCalculation();
        }

        private void txt_ChangeInOperatingActivities_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFlowsFromOperatingActivitiesCalculation();
        }

        private void txt_ChangeInProvisions_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFlowsFromOperatingActivitiesCalculation();
        }

        private void txt_OthersCashFlow_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFlowsFromOperatingActivitiesCalculation();
        }

        private void txt_OtherNonCashAdjustments_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFlowsFromOperatingActivitiesCalculation();
        }

        private void txt_ChangesInNonCashCapital_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFlowsFromOperatingActivitiesCalculation();
        }

        private void txt_DisposalOfFixedAssets_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFlowsFromInvestingActivitiesCalc();
        }

        private void txt_CapitalExpenditures_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFlowsFromInvestingActivitiesCalc();
        }

        private void txt_IncDecInpropertyPlant_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFlowsFromInvestingActivitiesCalc();
        }

        private void txt_IncreaseInInvestments_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFlowsFromInvestingActivitiesCalc();
        }

        private void txt_DecreaseInInvestments_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFlowsFromInvestingActivitiesCalc();
        }

        private void txt_OtherCashInflowOutflow_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFlowsFromInvestingActivitiesCalc();
        }

        private void txt_DividendsPaidDuringTheYear_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFromFinancingActivitiesCalc();
        }

        private void txt_IssuancesPurchasesOfEquityShares_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFromFinancingActivitiesCalc();
        }

        private void txt_ChangeInShortTermBorrowings_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFromFinancingActivitiesCalc();
        }

        private void txt_IncDecInLongTermBorrowings_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFromFinancingActivitiesCalc();
        }

        private void txt_IncDecInCapitalStocks_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFromFinancingActivitiesCalc();
        }

        private void txt_IncDecInLoans_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFromFinancingActivitiesCalc();
        }

        private void txt_EffectOfExchangeRatesOnCash_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFromFinancingActivitiesCalc();
        }

        private void txt_OtherFinInflowOutflow_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashFromFinancingActivitiesCalc();
        }

        private void txt_NetChangeCashAndCashEquivalents_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            txt_CashAndCashEquivalentAtPeriodEnd.Value =
                txt_NetChangeCashAndCashEquivalents.Value +
                txt_CashCashEquivalentAtStartOfPeriod.Value;
        }

        private void txt_CashCashEquivalentAtStartOfPeriod_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            txt_CashAndCashEquivalentAtPeriodEnd.Value =
              txt_NetChangeCashAndCashEquivalents.Value +
              txt_CashCashEquivalentAtStartOfPeriod.Value;
        }

        #endregion

        private void CashAndCahsEquilventCalculation()
        {
            txt_CashAndCashEquivalent.Value =
                txt_Cash.Value +
                txt_DueAmountFromRelatedParties.Value +
                txt_CashEquivalentConventional.Value +
                txt_CashCollateral.Value +
                txt_TimeDepositIslamic.Value +
                txt_TimeDepositConventional.Value;
        }

        private void txt_Cash_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashAndCahsEquilventCalculation();
        }

        private void txt_DueAmountFromRelatedParties_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashAndCahsEquilventCalculation();
        }

        private void txt_CashEquivalentConventional_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashAndCahsEquilventCalculation();
        }

        private void txt_CashCollateral_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashAndCahsEquilventCalculation();
        }

        private void txt_TimeDepositIslamic_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashAndCahsEquilventCalculation();
        }

        private void txt_TimeDepositConventional_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            CashAndCahsEquilventCalculation();
        }

        private void ShortTermInvestmentCalc()
        {
            txt_ShortTermInvestments.Value =
                txt_MoneyMarketFundIslamicMMFI.Value +
                txt_MoneyMarketFundConventionalMMFC.Value +
                txt_ConventionalBonds.Value +
                txt_Sukuk.Value;
        }

        private void txt_MoneyMarketFundIslamicMMFI_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            ShortTermInvestmentCalc();
        }

        private void txt_MoneyMarketFundConventionalMMFC_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            ShortTermInvestmentCalc();
        }

        private void txt_ConventionalBonds_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            ShortTermInvestmentCalc();
        }

        private void txt_Sukuk_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            ShortTermInvestmentCalc();
        }

        private void txt_AccountsReceivables_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            txt_NetReceivables.Value =
                txt_AccountsReceivables.Value +
                txt_ProvisionForDoubtfulReceivables.Value +
                txt_OtherReceivables.Value;
        }

        private void txt_ProvisionForDoubtfulReceivables_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            txt_NetReceivables.Value =
               txt_AccountsReceivables.Value +
               txt_ProvisionForDoubtfulReceivables.Value +
               txt_OtherReceivables.Value;
        }

        private void txt_OtherReceivables_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            txt_NetReceivables.Value =
               txt_AccountsReceivables.Value +
               txt_ProvisionForDoubtfulReceivables.Value +
               txt_OtherReceivables.Value;
        }

        private void txt_AdvancedPaymentsToSuppliers_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
           txt_CurrentReceivables.Value= txt_Inventories.Value + txt_OtherCurrentAssets.Value;
           txt_Inventories.Value = txt_AdvancedPaymentsToSuppliers.Value;
        }

        private void txt_OtherCurrentAssetsNonIslamic_ValueChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            txt_OtherCurrentAssets.Value = txt_OtherCurrentAssetsNonIslamic.Value;
            txt_TotalCurrentAssets.Value = txt_CurrentReceivables.Value + txt_NetReceivables.Value
                + txt_ShortTermInvestments.Value + txt_CashAndCashEquivalent.Value;
        }

    }
}
