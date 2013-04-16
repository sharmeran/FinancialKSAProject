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

namespace FSP.Windows.Reports.CompanyAdministration
{
    /// <summary>
    /// Interaction logic for SisterCompanyDetailSectionReport.xaml
    /// </summary>
    public partial class SisterCompanyDetailSectionReport : UserControl
    {
        public SisterCompanyDetailSectionReport()
        {
            InitializeComponent();
        }
        string companyName = "";
        string companySector = "";
        string ownPercentage = "";

        public SisterCompanyDetailSectionReport(string name, string sector, string perc)
        {
            InitializeComponent();
            companyName = name;
            companySector = sector;
            ownPercentage = perc;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txt_CompanyName.Text = companyName;
            txt_CompanySector.Text = companySector;
            txt_OwnerPercentage.Text = ownPercentage;
        }
    }
}
