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
        User userEntity = new User();
        UserDomain userDomain = new UserDomain(1, Common.Enums.LanguagesEnum.Arabic);
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

            GroupDomain groupDomain = new GroupDomain(1, Common.Enums.LanguagesEnum.Arabic);
            List<Group> groupList = new List<Group>();
            groupList = groupDomain.FindAll();
            if (groupDomain.ActionState.Status == Common.Enums.ActionStatusEnum.NoError)
            {
                cmbo_Group.ItemsSource = groupList;
            }
            else
            {
                MessageBox.Show(groupDomain.ActionState.Result, "المجموعات", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            userList = userDomain.FindAll();
            grd_Users.ItemsSource = userList;
            cmbo_Group.SelectedIndex = 0;
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txt_Email.Text = string.Empty;
            txt_FullName.Text = string.Empty;
            txt_Password.Password = string.Empty;
            txt_Phone.Text = string.Empty;
            cmbo_Group.SelectedIndex = 0;
            txt_RePassword.Password = string.Empty;
            txt_Username.Text = string.Empty;

            txt_Err_Email.Text = string.Empty;
            txt_Err_FullName.Text = string.Empty;
            txt_Err_Password.Text = string.Empty;
            txt_Err_Phone.Text = string.Empty;
            txt_Err_RePassword.Text = string.Empty;
            txt_Err_Username.Text = string.Empty;
            userEntity = new User();
        }

        private void grd_Users_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (grd_Users.SelectedItem != null)
            {
                userEntity = (User)grd_Users.SelectedItem;
                userEntity = userDomain.FindByID(userEntity.ID);
                if (userDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
                {
                    MessageBox.Show(userDomain.ActionState.Result, "جلب معلومات المستخدم", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                txt_Email.Text = userEntity.Email;
                txt_FullName.Text = userEntity.FullName;
                txt_Password.Password = userEntity.Password;
                txt_Phone.Text = userEntity.Phone;
                txt_RePassword.Password = txt_Password.Password;
                txt_Username.Text = userEntity.Username;

                for (int i = 0; i < cmbo_Group.Items.Count; i++)
                {
                    if (((Group)cmbo_Group.Items[i]).ID == userEntity.Group.ID)
                    {
                        cmbo_Group.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
            }
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (grd_Users.SelectedItem != null)
            {
                userEntity = (User)grd_Users.SelectedItem;
                MessageBoxResult result = MessageBox.Show("هل انت متأكد من حذف " + userEntity.FullName, "حذف المستخدم", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    userDomain.Delete(userEntity);
                    if (userDomain.ActionState.Status == Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show("تم الحذف بنجاح", "حذف المستخدم", MessageBoxButton.OK, MessageBoxImage.Information);
                        userList.Remove(userEntity);
                        grd_Users.ItemsSource = null;
                        grd_Users.ItemsSource = userList;
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(userDomain.ActionState.Result, "حذف المستخدم", MessageBoxButton.OK, MessageBoxImage.Error);
                        Clear();
                    }
                }
            }
        }

        private bool Validation()
        {
            bool isUserName = false;
            bool isPassword = false;
            bool isRePassword = false;
            bool isMatchPassword = false;
            bool isFullName = false;
            bool isPhoneNumber = false;
            bool isEmail = false;

            if(txt_Username.Text!=string.Empty)
            {
                isUserName=true;
                txt_Err_Username.Text = string.Empty;
            }
            else
            {
                isUserName = false;
                txt_Err_Username.Text = "يجب ملئ اسم المستخدم";
            }

            if (txt_Password.Password != string.Empty)
            {
                isPassword = true;
                txt_Err_Password.Text = string.Empty;
            }
            else
            {
                isPassword = false;
                txt_Err_Password.Text = "يجب ملئ كلمة المرور";
            }

            if (txt_RePassword.Password != string.Empty)
            {
                isRePassword = true;
                txt_Err_RePassword.Text = string.Empty;
            }
            else
            {
                isPassword = false;
                txt_Err_RePassword.Text = "يجب اعادة كلمة المرور";
            }

            if (txt_Password.Password == txt_RePassword.Password)
            {
                isMatchPassword = true;
                txt_Err_Password.Text = string.Empty;
            }
            else
            {
                isMatchPassword = false;
                txt_Err_Password.Text = "يجب ان تتطابق كلمتي المرور";
            }

            if (txt_FullName.Text != string.Empty)
            {
                isFullName = true;
                txt_Err_FullName.Text = string.Empty;
            }
            else
            {
                isFullName = false;
                txt_Err_FullName.Text = "يجب ملئ الاسم";
            }

            if (txt_Phone.Text != string.Empty)
            {
                isPhoneNumber = true;
                txt_Err_Phone.Text = string.Empty;
            }
            else
            {
                isPhoneNumber = false;
                txt_Err_Phone.Text = "يجب ملئ رقم الهاتف";
            }

            if (txt_Email.Text != string.Empty)
            {
                isEmail = true;
                txt_Err_Email.Text = string.Empty;
            }
            else
            {
                isEmail = false;
                txt_Err_Email.Text = "يجب ملئ البريد الالكتروني";
            }

            return isUserName & isPassword & isRePassword & isMatchPassword & isFullName & isPhoneNumber & isEmail;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            Validation();
        }





    }
}
