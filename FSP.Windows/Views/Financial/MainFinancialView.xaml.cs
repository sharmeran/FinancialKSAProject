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
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
            companyList = companyDomain.FindNotFull();
            cmbo_Company.ItemsSource = companyList;
            cmbo_Company.SelectedIndex = 0;
        }

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Worksheets|*.xls";
            if (openFileDialog.ShowDialog() == true)
            {
                txt_FileName.Text = openFileDialog.FileName;
                MainFinancialDomain mainFinancialDomain = new MainFinancialDomain();
                dataBank=mainFinancialDomain.ProcessingData(openFileDialog.FileName);
                PrpareViewData();

            }
        }

        private void PrpareViewData()
        {
            txt_Revenues.Value = dataBank["Revenues"];
            txt_CostOfRevenue.Value = dataBank["Cost of Revenue"];
            txt_SellingGeneral.Value = dataBank["Selling, General & Admin Expense"];
            txt_GrossProfit.Value = txt_Revenues.Value - txt_CostOfRevenue.Value;
            txt_OperatingIncome.Value = txt_GrossProfit.Value - txt_SellingGeneral.Value;
        }
    }
}
