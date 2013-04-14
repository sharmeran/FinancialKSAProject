using FSP.Common.Entites.CompanyAdministration;
using FSP.Domain.Domains.CompanyAdministration;
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
using Telerik.Windows.Controls;

namespace FSP.Windows.Reports.CompanyAdministration
{
    /// <summary>
    /// Interaction logic for CompanyReport.xaml
    /// </summary>
    public partial class CompanyReport : UserControl
    {
        public CompanyReport()
        {
            InitializeComponent();
        }

        private void cmbo_Year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbo_Company.SelectedItem!=null)
            {
                CompanyDetailReport soldgersPrintData = new CompanyDetailReport(((Company)(cmbo_Company.SelectedItem)).ID);
                soldgersPrintData.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                soldgersPrintData.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                soldgersPrintData.Margin = new Thickness(0, 20, 0, 0);
                FixedDocument fixedDoc = new FixedDocument();
                PageContent pageContent = new PageContent();
                FixedPage fixedPage = new FixedPage();
                fixedPage.Width = 850;
                fixedPage.Height = 1220;
                fixedPage.Children.Add(soldgersPrintData);
                ((System.Windows.Markup.IAddChild)pageContent).AddChild(fixedPage);
                fixedDoc.Pages.Add(pageContent);
                dcViewer.Document = fixedDoc;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CompanyDomain domain = new CompanyDomain(1, Common.Enums.LanguagesEnum.Arabic);
            cmbo_Company.ItemsSource = domain.FindNotFull();
        }
    }
}
