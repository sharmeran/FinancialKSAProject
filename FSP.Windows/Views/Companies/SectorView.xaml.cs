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
using FSP.Common.Entites.CompanyAdministration;
using FSP.Domain.Domains.CompanyAdministration;
using FSP.Windows.UIConstants;
using FSP.Windows.UICommon;

namespace FSP.Windows.Views.Companies
{
    /// <summary>
    /// Interaction logic for SectorView.xaml
    /// </summary>
    public partial class SectorView : UserControl
    {
        public SectorView()
        {
            InitializeComponent();
           
        }

        SectorDomain sectorDomain = new SectorDomain(1, Common.Enums.LanguagesEnum.Arabic);
        Sector sector = new Sector();
        List<Sector> sectorList = new List<Sector>();

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (!UISecurity.IsHasPermission(UISecurity.UserEntity.Group.Permissions, UIPermissionsConstants.SectorViewAdd))
            {
                btn_Save.Visibility = System.Windows.Visibility.Hidden;
            }
            if (!UISecurity.IsHasPermission(UISecurity.UserEntity.Group.Permissions, UIPermissionsConstants.SectorViewDelete))
            {
                btn_Delete.Visibility = System.Windows.Visibility.Hidden;
            }
            if (!UISecurity.IsHasPermission(UISecurity.UserEntity.Group.Permissions, UIPermissionsConstants.SectorViewView))
            {
                grd_Sector.Visibility = System.Windows.Visibility.Hidden;
            }

            sectorList = sectorDomain.FindAll();
            if (sectorDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
            {
                MessageBox.Show(sectorDomain.ActionState.Result, "جلب القطاعات", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                grd_Sector.ItemsSource = sectorList;
            }
            txt_Name.Focus();
        }


        private void btn_Save_Click_1(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                sector.Description = txt_Description.Text;
                sector.DescriptionEnglish = txt_DescriptionEnglish.Text;                
                sector.Name = txt_Name.Text;
                sector.NameEnglish = txt_NameEnglish.Text;

                if (sector.ID == 0)
                {
                    sectorDomain.Add(sector);
                    if (sectorDomain.ActionState.Status == Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show("تمت الاضافة بنجاح", "اضافة القطاع", MessageBoxButton.OK, MessageBoxImage.Information);
                        sectorList.Add(sector);
                        grd_Sector.ItemsSource = null;
                        grd_Sector.ItemsSource = sectorList;
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(sectorDomain.ActionState.Result, "اضافة النشاط", MessageBoxButton.OK, MessageBoxImage.Error);
                        Clear();
                    }
                }
                else
                {
                    sectorDomain.Update(sector);
                    if (sectorDomain.ActionState.Status == Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show("تم التعديل بنجاح", "تعديل القطاع", MessageBoxButton.OK, MessageBoxImage.Information);
                        for (int i = 0; i < sectorList.Count; i++)
                        {
                            if (sectorList[i].ID == sector.ID)
                            {
                                sectorList[i] = sector;
                                break;
                            }
                        }
                        grd_Sector.ItemsSource = null;
                        grd_Sector.ItemsSource = sectorList;
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(sectorDomain.ActionState.Result, "تعديل النشاط", MessageBoxButton.OK, MessageBoxImage.Error);
                        Clear();
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
            if (grd_Sector.SelectedItem != null)
            {
                sector = (Sector)grd_Sector.SelectedItem;
                MessageBoxResult result = MessageBox.Show("هل انت متأكد من حذف " + sector.Name, "حذف القطاع", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    sectorDomain.Delete(sector);
                    if (sectorDomain.ActionState.Status == Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show("تم الحذف بنجاح", "حذف القطاع", MessageBoxButton.OK, MessageBoxImage.Information);
                        sectorList.Remove(sector);
                        grd_Sector.ItemsSource = null;
                        grd_Sector.ItemsSource = sectorList;
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(sectorDomain.ActionState.Result, "حذف القطاع", MessageBoxButton.OK, MessageBoxImage.Error);
                        Clear();
                    }
                }
            }
        }

        private void grd_Sector_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            if (grd_Sector.SelectedItem != null)
            {
                sector = (Sector)grd_Sector.SelectedItem;
                txt_Description.Text = sector.Description;
                txt_DescriptionEnglish.Text = sector.DescriptionEnglish;
                txt_NameEnglish.Text = sector.NameEnglish;
                txt_Name.Text = sector.Name;
                

            }
        }
        private void Clear()
        {
            txt_Description.Text = string.Empty;
            txt_DescriptionEnglish.Text = string.Empty;
            txt_NameEnglish.Text = string.Empty;
            txt_Err_Description.Text = string.Empty;
            txt_Err_DescriptionEnglish.Text = string.Empty;
            txt_Err_NameEnglish.Text = string.Empty;
            txt_Err_Name.Text = string.Empty;
            txt_Name.Text = string.Empty;
            sector = new Sector();
            
        }

        private bool Validation()
        {
            bool name = false;
            bool englishName = false;
            bool description = false;
            bool englishDescription = false;


            if (string.IsNullOrEmpty(txt_Name.Text))
            {
                txt_Err_Name.Text = "الرجاء ملئ الاسم";
                name = false;
            }
            else
            {
                txt_Err_Name.Text = string.Empty;
                name = true;
            }

            if (string.IsNullOrEmpty(txt_NameEnglish.Text))
            {
                txt_Err_NameEnglish.Text = "الرجاء ملئ الاسم بالانجليزية";
                englishName = false;
            }
            else
            {
                txt_Err_NameEnglish.Text = string.Empty;
                englishName = true;
            }

            if (string.IsNullOrEmpty(txt_Description.Text))
            {
                txt_Err_Description.Text = "الرجاء ملئ الوصف";
                description = false;
            }
            else
            {
                txt_Err_Description.Text = string.Empty;
                description = true;
            }

            if (string.IsNullOrEmpty(txt_DescriptionEnglish.Text))
            {
                txt_Err_DescriptionEnglish.Text = "الرجاء ملئ الوصف بالانجليزية";
                englishDescription = false;
            }
            else
            {
                txt_Err_DescriptionEnglish.Text = string.Empty;
                englishDescription = true;
            }


            return name & englishName & description & englishDescription;
        }
    }
}
