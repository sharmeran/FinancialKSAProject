using FSP.Windows.UICommon;
using FSP.Windows.UIConstants;
using FSP.Windows.Views.Administration;
using FSP.Windows.Views.Companies;
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
using System.Windows.Shapes;

namespace FSP.Windows
{
    /// <summary>
    /// Interaction logic for AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        public AppWindow()
        {
            InitializeComponent();
            this.Closed += AppWindow_Closed;
            

        }

        void AppWindow_Closed(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (UISecurity.IsHasAccessList(UISecurity.UserEntity.Group.AccessList, UIAccessListConstants.MainAdministrationView))
            {
                tab_Administration.Visibility = System.Windows.Visibility.Visible;
            }

            if (UISecurity.IsHasAccessList(UISecurity.UserEntity.Group.AccessList, UIAccessListConstants.MainAdministrationView))
            {
                tab_Company.Visibility = System.Windows.Visibility.Visible;
            }

            //tab_Administration.Content = new MainAdministrationView();
            //tab_Company.Content = new MainCompanyAdministration();
        }
    }
}
