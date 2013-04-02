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
using FSP.Common.Entites.Administration;
using FSP.Domain.Domains.Administration;
using FSP.Windows.UIConstants;
using FSP.Windows.UICommon;

namespace FSP.Windows.Views.Administration
{
    /// <summary>
    /// Interaction logic for UserAdministration.xaml
    /// </summary>
    public partial class UserAdministration : UserControl
    {
        public UserAdministration()
        {
            InitializeComponent();

           
        }
        List<User> userList = new List<User>();
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (!UISecurity.IsHasPermission(UISecurity.UserEntity.Group.Permissions, UIPermissionsConstants.UserViewAdd))
            {
                btn_Save.Visibility = System.Windows.Visibility.Hidden;
            }
            if (!UISecurity.IsHasPermission(UISecurity.UserEntity.Group.Permissions, UIPermissionsConstants.UserViewDelete))
            {
                btn_Delete.Visibility = System.Windows.Visibility.Hidden;
            }
            if (!UISecurity.IsHasPermission(UISecurity.UserEntity.Group.Permissions, UIPermissionsConstants.UserViewView))
            {
                grd_Users.Visibility = System.Windows.Visibility.Hidden;
            }

            UserDomain userDomain = new UserDomain(1, Common.Enums.LanguagesEnum.Arabic);
            userList = userDomain.FindAll();
            grd_Users.ItemsSource = userList;
        }
    }
}
