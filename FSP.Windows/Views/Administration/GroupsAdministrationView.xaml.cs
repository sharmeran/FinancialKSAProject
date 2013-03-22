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
    /// Interaction logic for GroupsAdministrationView.xaml
    /// </summary>
    public partial class GroupsAdministrationView : UserControl
    {

        List<AccessList> accessList = new List<AccessList>();
        List<Permission> permissionList = new List<Permission>();
        List<Group> groupList = new List<Group>();
        AccessListDomain accessListDomain = new AccessListDomain(1, Common.Enums.LanguagesEnum.Arabic);
        PermissionDomain permissionDomain = new PermissionDomain(1, Common.Enums.LanguagesEnum.Arabic);
        GroupDomain groupDomain = new GroupDomain(1, Common.Enums.LanguagesEnum.Arabic);
        Group groupEntity = new Group();

        public GroupsAdministrationView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            accessList = accessListDomain.FindAll();
            if (accessListDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
            {
                MessageBox.Show(accessListDomain.ActionState.Result, "خطأ في جلب بيانات صلاحيات القوائم", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                List<CheckBox> accessListCheckBoxLis = new List<CheckBox>();
                for (int i = 0; i < accessList.Count; i++)
                {
                    CheckBox chkBox = new CheckBox();
                    chkBox.DataContext = accessList[i];
                    chkBox.Content = accessList[i].Name;
                    accessListCheckBoxLis.Add(chkBox);
                }
                cmbo_AccessList.ItemsSource = accessListCheckBoxLis;
            }

            permissionList = permissionDomain.FindAll();
            if (permissionDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
            {
                MessageBox.Show(permissionDomain.ActionState.Result, "خطأ في جلب بيانات صلاحيات العمليات", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                List<CheckBox> permissionCheckBoxLis = new List<CheckBox>();
                for (int i = 0; i < permissionList.Count; i++)
                {
                    CheckBox chkBox = new CheckBox();
                    chkBox.DataContext = permissionList[i];
                    chkBox.Content = permissionList[i].Name;
                    permissionCheckBoxLis.Add(chkBox);
                }
                cmbo_Permissions.ItemsSource = permissionCheckBoxLis;
            }

            groupList = groupDomain.FindAll();
            if (groupDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
            {
                MessageBox.Show(groupDomain.ActionState.Result, "خطأ في جلب بيانات المجموعات", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                grd_Groups.ItemsSource = groupList;
            }
        }

        private void btn_Save_Click_1(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                groupEntity.Name = txt_Name.Text;
                groupEntity.Description = txt_Description.Text;
                List<AccessList> accessListCheckedValues = new List<AccessList>();
                for (int i = 0; i < cmbo_AccessList.Items.Count; i++)
                {
                    CheckBox checkBox = (CheckBox)cmbo_AccessList.Items[i];
                    if ((bool)checkBox.IsChecked)
                    {
                        accessListCheckedValues.Add((AccessList)checkBox.DataContext);
                    }
                }
                groupEntity.AccessList = accessListCheckedValues;
                List<Permission> permissionCheckedValues = new List<Permission>();
                for (int i = 0; i < cmbo_Permissions.Items.Count; i++)
                {
                    CheckBox checkBox = (CheckBox)cmbo_Permissions.Items[i];
                    if ((bool)checkBox.IsChecked)
                    {
                        permissionCheckedValues.Add((Permission)checkBox.DataContext);
                    }
                }
                groupEntity.Permissions = permissionCheckedValues;

                if (groupEntity.ID == 0)
                {
                    groupDomain.Add(groupEntity);
                    if (groupDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show(groupDomain.ActionState.Result, "اضافة مجموعة", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show("تمت الاضافة بنجاح", "اضافة مجموعة", MessageBoxButton.OK, MessageBoxImage.Information);
                        groupList.Add(groupEntity);
                        grd_Groups.ItemsSource = null;
                        grd_Groups.ItemsSource = groupList;
                        Clear();
                    }
                }
                else
                {
                    groupDomain.Update(groupEntity);
                    if (groupDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show(groupDomain.ActionState.Result, "تعديل مجموعة", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show("تم التعديل بنجاح", "اضافة مجموعة", MessageBoxButton.OK, MessageBoxImage.Information);
                        for (int i = 0; i < groupList.Count; i++)
                        {
                            if (groupList[i].ID == groupEntity.ID)
                            {
                                groupList[i] = groupEntity;
                                break;
                            }
                            grd_Groups.ItemsSource = null;
                            grd_Groups.ItemsSource = groupList;
                            Clear();

                        }
                    }
                }

            }
        }

        private void btn_Clear_Click_1(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void btn_Delete_Click_1(object sender, RoutedEventArgs e)
        {
            if (grd_Groups.SelectedItem != null)
            {
                groupEntity = (Group)grd_Groups.SelectedItem;
                MessageBoxResult result = MessageBox.Show("هل انت متأكد من حذف " + groupEntity.Name, "حذف المجموعة", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    groupDomain.Delete(groupEntity);
                    if (groupDomain.ActionState.Status == Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show("تم الحذف بنجاح", "حذف المجموعة", MessageBoxButton.OK, MessageBoxImage.Information);
                        groupList.Remove(groupEntity);
                        grd_Groups.ItemsSource = null;
                        grd_Groups.ItemsSource = groupEntity;
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(groupDomain.ActionState.Result, "حذف المجموعة", MessageBoxButton.OK, MessageBoxImage.Error);
                        Clear();
                    }
                }
            }
        }

        private void grd_Behaviour_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            if (grd_Groups.SelectedItem != null)
            {
                groupEntity = (Group)grd_Groups.SelectedItem;
                groupEntity = groupDomain.FindByID(groupEntity.ID);
                if (groupDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
                {
                    MessageBox.Show(groupDomain.ActionState.Result, "جلب سجل المجموعة", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    txt_Description.Text = groupEntity.Description;
                    txt_Name.Text = groupEntity.Name;
                    for (int i = 0; i < groupEntity.AccessList.Count; i++)
                    {
                        for (int j = 0; j < cmbo_AccessList.Items.Count; j++)
                        {
                            if (((AccessList)((CheckBox)cmbo_AccessList.Items[j]).DataContext).ID == groupEntity.AccessList[i].ID)
                            {
                                ((CheckBox)cmbo_AccessList.Items[j]).IsChecked = true;
                            }
                          
                        }
                    }

                    for (int k = 0; k < groupEntity.Permissions.Count; k++)
                    {
                        for (int m = 0; m < cmbo_Permissions.Items.Count; m++)
                        {
                            if (((Permission)((CheckBox)cmbo_Permissions.Items[m]).DataContext).ID == groupEntity.Permissions[k].ID)
                            {
                                ((CheckBox)cmbo_Permissions.Items[m]).IsChecked = true;
                            }

                        }
                    }
                }
            }
        }

        private void Clear()
        {
            txt_Description.Text = string.Empty;
            txt_Err_Description.Text = string.Empty;
            txt_Err_Name.Text = string.Empty;
            txt_Name.Text = string.Empty;
            for (int i = 0; i < cmbo_AccessList.Items.Count; i++)
            {
                ((CheckBox)cmbo_AccessList.Items[i]).IsChecked = false;
            }
            for (int j = 0; j < cmbo_Permissions.Items.Count; j++)
            {
                ((CheckBox)cmbo_Permissions.Items[j]).IsChecked = false;
            }
            groupEntity = new Group();
        }

        private bool Validation()
        {
            bool name = false;
            bool description = false;

            if (string.IsNullOrEmpty(txt_Description.Text))
            {
                txt_Err_Description.Text = "يجب ملئ الوصف";
                description = false;
            }
            else
            {
                txt_Err_Description.Text = string.Empty;
                description = true;
            }

            if (string.IsNullOrEmpty(txt_Name.Text))
            {
                txt_Err_Name.Text = "يجب ملئ الاسم";
                name = false;
            }
            else
            {
                txt_Err_Name.Text = string.Empty;
                name = true;
            }

            return name & description;
        }
    }
}
