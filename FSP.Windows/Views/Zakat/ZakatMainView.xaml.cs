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
using FSP.Common.Entites.CompanyAdministration;
using FSP.Domain.Domains.CompanyAdministration;
using FSP.Common.Enums;
using FSP.Windows.UICommon;
using FSP.Windows.UIConstants;

namespace FSP.Windows.Views.Zakat
{
    /// <summary>
    /// Interaction logic for ZakatMainView.xaml
    /// </summary>
    public partial class ZakatMainView : UserControl
    {
        public ZakatMainView()
        {
            InitializeComponent();
           
        }
        SectorDomain sectorDomain = new SectorDomain(1, LanguagesEnum.Arabic);
        CompanyDomain companyDomain = new CompanyDomain(1, LanguagesEnum.Arabic);        
        List<Sector> sectorList = new List<Sector>();
        List<Company> companyList = new List<Company>();

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            sectorList = sectorDomain.FindAll();
            if (sectorDomain.ActionState.Status != ActionStatusEnum.NoError)
            {
                MessageBox.Show(sectorDomain.ActionState.Result, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                cmbo_Sector.ItemsSource = sectorList;
            }

            companyList = companyDomain.FindAll();
            if (companyDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
            {
                MessageBox.Show(companyDomain.ActionState.Result, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            

        }

        private void cmbo_Sector_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (cmbo_Sector.SelectedItem != null)
            {
                List<Company> companyListUpdated = new List<Company>();
                var x = from z in companyList where z.Sector.ID == ((Sector)cmbo_Sector.SelectedItem).ID select z;
                cmbo_Company.ItemsSource = x.ToList<Company>();
            }
        }

        private void cmbo_Company_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (cmbo_Company.SelectedItem != null)
            {
                Company company = (Company)cmbo_Company.SelectedItem;
                txt_Capital.Text = company.Capital.ToString();
                txt_EstablishYear.Text = company.EstablishYear.ToString("dd/MM/yyyy");
                cmbo_SubsidiaryCompany.ItemsSource = company.SubsidiaryCompanyList;
            }
        }
    }
}
