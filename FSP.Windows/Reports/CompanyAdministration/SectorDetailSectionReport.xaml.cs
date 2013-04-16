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
    /// Interaction logic for SectorDetailSectionReport.xaml
    /// </summary>
    public partial class SectorDetailSectionReport : UserControl
    {
        public SectorDetailSectionReport()
        {
            InitializeComponent();
        }
        string behaviourName = "";
        string behaviourDesc = "";
        public SectorDetailSectionReport(string name, string desc)
        {
            InitializeComponent();
            behaviourName = name;
            behaviourDesc = desc;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txt_BehaviourDesc.Text = behaviourDesc;
            txt_BehaviourName.Text = behaviourName;
        }
    }
}
