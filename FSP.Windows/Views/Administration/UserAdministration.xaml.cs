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
            UserDomain userDomain = new UserDomain(1, Common.Enums.LanguagesEnum.Arabic);
            userList = userDomain.FindAll();
            grd_Users.ItemsSource = userList;
        }
    }
}
