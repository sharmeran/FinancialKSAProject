using FSP.Windows.UICommon;
using FSP.Windows.UIConstants;
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

namespace FSP.Windows.Views.Administration
{
    /// <summary>
    /// Interaction logic for MainAdministrationView.xaml
    /// </summary>
    public partial class MainAdministrationView : UserControl
    {
        public MainAdministrationView()
        {
            InitializeComponent();
     
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (UISecurity.IsHasAccessList(UISecurity.UserEntity.Group.AccessList, UIAccessListConstants.GroupView))
            {
                tab_GroupAdministrtion.Visibility = System.Windows.Visibility.Visible;
            }

            if (UISecurity.IsHasAccessList(UISecurity.UserEntity.Group.AccessList, UIAccessListConstants.UserView))
            {
                tab_UserAdministrtion.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
