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
    /// Interaction logic for CompanyReportChart.xaml
    /// </summary>
    public partial class CompanyReportChart : UserControl
    {
        public CompanyReportChart()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //xRadChart.DefaultView.ChartArea.AxisX.LabelRotationAngle = 45;
            text.LabelFormat = "dd/MM/yyyy";
            
            
            xRadChart.DataContext = new MainViewModel();

        }
    }
}
