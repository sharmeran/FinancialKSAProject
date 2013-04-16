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

namespace FSP.Windows.Views.Companies
{
    /// <summary>
    /// Interaction logic for MainCompanyAdministration.xaml
    /// </summary>
    public partial class MainCompanyAdministration : UserControl
    {
        public MainCompanyAdministration()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (UISecurity.IsHasAccessList(UISecurity.UserEntity.Group.AccessList, UIAccessListConstants.BehaviourView))
            {
                tab_Behaviour.Visibility = System.Windows.Visibility.Visible;
            }

            if (UISecurity.IsHasAccessList(UISecurity.UserEntity.Group.AccessList, UIAccessListConstants.BehaviourJudgmentView))
            {
                tab_BehaviourJudgment.Visibility = System.Windows.Visibility.Visible;
            }

            if (UISecurity.IsHasAccessList(UISecurity.UserEntity.Group.AccessList, UIAccessListConstants.CompanyView))
            {
                tab_Company.Visibility = System.Windows.Visibility.Visible;
            }

            if (UISecurity.IsHasAccessList(UISecurity.UserEntity.Group.AccessList, UIAccessListConstants.SectorView))
            {
                tab_Sector.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
