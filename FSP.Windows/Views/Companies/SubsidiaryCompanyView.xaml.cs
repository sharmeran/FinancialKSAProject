using System;
using System.Collections.Generic;
using System.Globalization;
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
using FSP.Windows.CommonView;
using Telerik.Windows.Controls;
using FSP.Windows.UIConstants;
using FSP.Windows.UICommon;

namespace FSP.Windows.Views.Companies
{
    /// <summary>
    /// Interaction logic for SubsidiaryCompanyView.xaml
    /// </summary>
    public partial class SubsidiaryCompanyView : UserControl
    {
        int CompanyID = 0;
        SubsidiaryCompany subsidiaryCompany = new SubsidiaryCompany();
        List<SubsidiaryCompany> subsidiaryCompanyList = new List<SubsidiaryCompany>();
        SubsidiaryCompanyDomain subsidiaryCompanyDomain = new SubsidiaryCompanyDomain(1, Common.Enums.LanguagesEnum.Arabic);
        List<Sector> sectorList = new List<Sector>();
        public SubsidiaryCompanyView()
        {
            InitializeComponent();


        }

        public SubsidiaryCompanyView(int companyID)
        {
            InitializeComponent();
            CompanyID = companyID;
           
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (!UISecurity.IsHasPermission(UISecurity.UserEntity.Group.Permissions, UIPermissionsConstants.SubsidiaryCompanyViewAdd))
            {
                btn_Save.Visibility = System.Windows.Visibility.Hidden;
            }
            if (!UISecurity.IsHasPermission(UISecurity.UserEntity.Group.Permissions, UIPermissionsConstants.SubsidiaryCompanyViewDelete))
            {
                btn_Delete.Visibility = System.Windows.Visibility.Hidden;
            }
            if (!UISecurity.IsHasPermission(UISecurity.UserEntity.Group.Permissions, UIPermissionsConstants.SubsidiaryCompanyViewView))
            {
                grd_SubCompany.Visibility = System.Windows.Visibility.Hidden;
            } 

            subsidiaryCompanyList = subsidiaryCompanyDomain.FindByCompanyID(CompanyID);
            if (subsidiaryCompanyDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
            {
                MessageBox.Show(subsidiaryCompanyDomain.ActionState.Result, "جلب سجلات الشركات التابعة", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                grd_SubCompany.ItemsSource = subsidiaryCompanyList;
            }

            SectorDomain sectorDomain = new SectorDomain(1, Common.Enums.LanguagesEnum.Arabic);
            sectorList = sectorDomain.FindAll();
            if (sectorDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
            {
                MessageBox.Show(sectorDomain.ActionState.Result, "جلب سجلات القطاعات", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                cmbo_Sector.ItemsSource = sectorList;
            }
        }

        private void dtpkr_EstablishGer_LostFocus_1(object sender, RoutedEventArgs e)
        {
            RadWatermarkTextBox radWatermarkTextBox = (RadWatermarkTextBox)sender;
            if (radWatermarkTextBox.Name == "dtpkr_EstablishGer")
            {
                dtpkr_EstablishHij.Text = GerToHejri(radWatermarkTextBox.Text);
            }
            else
            {
                dtpkr_FollowDateHij.Text = GerToHejri(radWatermarkTextBox.Text);
            }
        }

        private void dtpkr_EstablishHij_LostFocus_1(object sender, RoutedEventArgs e)
        {
            RadWatermarkTextBox radWatermarkTextBox = (RadWatermarkTextBox)sender;
            if (radWatermarkTextBox.Name == "dtpkr_EstablishHij")
            {
                dtpkr_EstablishGer.Text = HijriToGer(radWatermarkTextBox.Text);
            }
            else
            {
                dtpkr_FollowDateGer.Text = HijriToGer(radWatermarkTextBox.Text);
            }
        }

        private void btn_Save_Click_1(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                subsidiaryCompany.CompanyID = CompanyID;
                subsidiaryCompany.Description = txt_Description.Text;
                subsidiaryCompany.DescriptionEnglish = txt_DescriptionEnglish.Text;
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                subsidiaryCompany.EstablishDate = Convert.ToDateTime(dtpkr_EstablishGer.Text, format);
                subsidiaryCompany.FollowDate = Convert.ToDateTime(dtpkr_FollowDateGer.Text, format);
                subsidiaryCompany.IsOutKSA = Convert.ToBoolean(chk_IsOutKSA.IsChecked);
                subsidiaryCompany.Name = txt_Name.Text;
                subsidiaryCompany.NameEnglish = txt_NameEnglish.Text;
                subsidiaryCompany.Note = txt_Information.Text;
                subsidiaryCompany.NoteEnglish = txt_InformationEnglish.Text;
                subsidiaryCompany.Place = txt_Place.Text;
                subsidiaryCompany.PlaceEnglish = txt_PlaceEnglish.Text;
                subsidiaryCompany.Sector = (Sector)cmbo_Sector.SelectedItem;
                subsidiaryCompany.OwnPercentage = Convert.ToInt32(txt_OwnerPercentage.Text);
                subsidiaryCompany.IsOutKSA = Convert.ToBoolean(chk_IsOutKSA.IsChecked);

                if (subsidiaryCompany.ID == 0)
                {
                    subsidiaryCompanyDomain.Add(subsidiaryCompany);
                    if (subsidiaryCompanyDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show(subsidiaryCompanyDomain.ActionState.Result, "اضافة شركة تابعة", MessageBoxButton.OK, MessageBoxImage.Error);
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("تمت الاضافة بنجاح", "اضافة شركة", MessageBoxButton.OK, MessageBoxImage.Information);
                        subsidiaryCompanyList.Add(subsidiaryCompany);
                        grd_SubCompany.ItemsSource = null;
                        grd_SubCompany.ItemsSource = subsidiaryCompanyList;
                        Clear();
                    }
                }
                else
                {
                    subsidiaryCompanyDomain.Update(subsidiaryCompany);
                    if (subsidiaryCompanyDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show(subsidiaryCompanyDomain.ActionState.Result, "تعديل شركة تابعة", MessageBoxButton.OK, MessageBoxImage.Error);
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("تم التعديل بنجاح", "تعديل شركة", MessageBoxButton.OK, MessageBoxImage.Information);
                        for (int i = 0; i < subsidiaryCompanyList.Count; i++)
                        {
                            if (subsidiaryCompanyList[i].ID == subsidiaryCompany.ID)
                            {
                                subsidiaryCompanyList[i] = subsidiaryCompany;
                                grd_SubCompany.ItemsSource = null;
                                grd_SubCompany.ItemsSource = subsidiaryCompanyList;
                                break;
                            }
                        }
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
            if (grd_SubCompany.SelectedItem != null)
            {
                subsidiaryCompany = (SubsidiaryCompany)grd_SubCompany.SelectedItem;
                MessageBoxResult result = MessageBox.Show("هل انت متأكد من حذف " + subsidiaryCompany.Name, "حذف الشركة", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    subsidiaryCompanyDomain.Delete(subsidiaryCompany);
                    if (subsidiaryCompanyDomain.ActionState.Status == Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show("تم الحذف بنجاح", "حذف الشركة", MessageBoxButton.OK, MessageBoxImage.Information);
                        subsidiaryCompanyList.Remove(subsidiaryCompany);
                        grd_SubCompany.ItemsSource = null;
                        grd_SubCompany.ItemsSource = subsidiaryCompanyList;
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(subsidiaryCompanyDomain.ActionState.Result, "حذف الشركة", MessageBoxButton.OK, MessageBoxImage.Error);
                        Clear();
                    }
                }
            }
        }

        private void grd_SubCompany_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            if (grd_SubCompany.SelectedItem != null)
            {
                subsidiaryCompany = (SubsidiaryCompany)grd_SubCompany.SelectedItem;
                txt_Description.Text = subsidiaryCompany.Description;
                txt_DescriptionEnglish.Text = subsidiaryCompany.DescriptionEnglish;
                txt_Information.Text = subsidiaryCompany.Note;
                txt_InformationEnglish.Text = subsidiaryCompany.NoteEnglish;
                txt_Name.Text = subsidiaryCompany.Name;
                txt_NameEnglish.Text = subsidiaryCompany.NameEnglish;
                txt_OwnerPercentage.Text = subsidiaryCompany.OwnPercentage.ToString();
                txt_Place.Text = subsidiaryCompany.Place;
                txt_PlaceEnglish.Text = subsidiaryCompany.PlaceEnglish;
                chk_IsOutKSA.IsChecked = subsidiaryCompany.IsOutKSA;
                if (subsidiaryCompany.EstablishDate.Year != 1)
                {
                    dtpkr_EstablishGer.Text = subsidiaryCompany.EstablishDate.Date.ToString("dd/MM/yyyy");
                    dtpkr_EstablishHij.Text = GerToHejri(dtpkr_EstablishGer.Text);
                }

                if (subsidiaryCompany.FollowDate.Year != 1)
                {
                    dtpkr_FollowDateGer.Text = subsidiaryCompany.FollowDate.Date.ToString("dd/MM/yyyy");
                    dtpkr_FollowDateHij.Text = GerToHejri(dtpkr_EstablishGer.Text);
                }

                chk_IsOutKSA.IsChecked = subsidiaryCompany.IsOutKSA;
                for (int i = 0; i < cmbo_Sector.Items.Count; i++)
                {
                    if (subsidiaryCompany.Sector.ID == ((Sector)cmbo_Sector.Items[i]).ID)
                    {
                        cmbo_Sector.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void Clear()
        {
            txt_OwnerPercentage.Text = string.Empty;
            txt_Description.Text = string.Empty;
            txt_DescriptionEnglish.Text = string.Empty;
            txt_Err_OwnerPercentage.Text = string.Empty;
            txt_Place.Text = string.Empty;
            txt_PlaceEnglish.Text = string.Empty;
            txt_Err_Place.Text = string.Empty;
            txt_Err_PlaceEnglish.Text = string.Empty;
            txt_Err_Description.Text = string.Empty;
            txt_Err_DescriptionEnglish.Text = string.Empty;
            txt_Err_Establish.Text = string.Empty;            
            txt_Err_Information.Text = string.Empty;
            txt_Err_InformationEnglish.Text = string.Empty;            
            txt_Err_Name.Text = string.Empty;
            txt_Err_NameEnglish.Text = string.Empty;
            
            txt_Information.Text = string.Empty;
            txt_InformationEnglish.Text = string.Empty;
            txt_Name.Text = string.Empty;
            txt_NameEnglish.Text = string.Empty;


            dtpkr_EstablishGer.Text = string.Empty;
            dtpkr_EstablishHij.Text = string.Empty;

            dtpkr_FollowDateGer.Text = string.Empty;
            dtpkr_FollowDateHij.Text = string.Empty;

            txt_Err_FollowDate.Text = string.Empty;
            subsidiaryCompany = new SubsidiaryCompany();
            cmbo_Sector.SelectedIndex = 0;
            
        }

        private bool Validation()
        {
            bool name = false;
            bool description = false;
            bool establishDate = false;
            bool information = false;
            bool nameEnglish = false;
            bool descriptionEnglish = false;
            bool informationEnglish = false;
            bool capital = false;
            bool followDate = false;
            bool place = false;
            bool placeEnglish = false;

            if (string.IsNullOrEmpty(txt_Name.Text) == false)
            {
                name = true;
                txt_Err_Name.Text = string.Empty;
            }
            else
            {
                name = false;
                txt_Err_Name.Text = "يجب ملئ الاسم";
            }
            if (string.IsNullOrEmpty(txt_Description.Text) == false)
            {
                description = true;
                txt_Err_Description.Text = string.Empty;
            }
            else
            {
                description = false;
                txt_Err_Description.Text = "يجب ملئ الوصف";
            }
            if (string.IsNullOrEmpty(txt_DescriptionEnglish.Text) == false)
            {
                descriptionEnglish = true;
                txt_Err_DescriptionEnglish.Text = string.Empty;
            }
            else
            {
                descriptionEnglish = false;
                txt_Err_DescriptionEnglish.Text = "يجب ملئ الوصف بالنجليزي";
            }
            if (string.IsNullOrEmpty(dtpkr_EstablishGer.Text) == false)
            {
                if (Helper.CheckDateGer(dtpkr_EstablishGer.Text))
                {
                    establishDate = true;
                    txt_Err_Establish.Text = string.Empty;
                }
                else
                {
                    txt_Err_Establish.Text = "يجب ملئ سنة التأسيس";
                }
            }
            else
            {
                establishDate = false;
                txt_Err_Establish.Text = "يجب ملئ سنة التأسيس";
            }

            if (string.IsNullOrEmpty(dtpkr_FollowDateGer.Text) == false)
            {
                if (Helper.CheckDateGer(dtpkr_FollowDateGer.Text))
                {
                    followDate = true;
                    txt_Err_FollowDate.Text = string.Empty;
                }
                else
                {
                    txt_Err_FollowDate.Text = "يجب ملئ سنة التبعية";
                }
            }
            else
            {
               
                
                    followDate = false;
                    txt_Err_FollowDate.Text = "يجب ملئ سنة التبعية";
                
            }

            if (string.IsNullOrEmpty(txt_OwnerPercentage.Text) == false)
            {
                float cap;

                if (float.TryParse(txt_OwnerPercentage.Text, out cap))
                {
                    txt_Err_OwnerPercentage.Text = string.Empty;
                    capital = true;
                }
                else
                {
                    capital = false;
                    txt_Err_OwnerPercentage.Text = "نسبة التبعية يجب ان يكون ارقام ";
                }

            }
            else
            {
                capital = false;
                txt_Err_OwnerPercentage.Text = "يجب ملئ نسبة التبعية الشركة";
            }

            if (string.IsNullOrEmpty(txt_Information.Text) == false)
            {
                txt_Err_Information.Text = string.Empty;
                information = true;
            }
            else
            {
                txt_Err_Information.Text = "يجب ملئ معلومات عن الشركة";
                information = false;
            }

            if (string.IsNullOrEmpty(txt_InformationEnglish.Text) == false)
            {
                txt_Err_InformationEnglish.Text = string.Empty;
                informationEnglish = true;
            }
            else
            {
                txt_Err_InformationEnglish.Text = "يجب ملئ معلومات بالانجليزية";
                informationEnglish = false;
            }

            if (string.IsNullOrEmpty(txt_NameEnglish.Text) == false)
            {
                txt_Err_NameEnglish.Text = string.Empty;
                nameEnglish = true;
            }
            else
            {
                txt_Err_NameEnglish.Text = "يجب ملئ الاسم بالانجليزية";
                nameEnglish = false;
            }

            if (string.IsNullOrEmpty(txt_Place.Text) == false)
            {
                txt_Err_Place.Text = string.Empty;
                place = true;
            }
            else
            {
                txt_Err_Place.Text = "يجب ملئ العنوان عن الشركة";
                place = false;
            }

            if (string.IsNullOrEmpty(txt_PlaceEnglish.Text) == false)
            {
                txt_Err_PlaceEnglish.Text = string.Empty;
                placeEnglish = true;
            }
            else
            {
                txt_Err_PlaceEnglish.Text = "يجب ملئ العنوان بالانجليزية";
                placeEnglish = false;
            }

            return nameEnglish & name & description & descriptionEnglish & information & informationEnglish & capital & establishDate & followDate &place & placeEnglish;
        }
        private string GerToHejri(string date)
        {
            if (string.IsNullOrEmpty(date) == false && Helper.CheckDateGer(date))
            {
                DateTime dt = new DateTime();
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                dt = Convert.ToDateTime(date, format);
                return Helper.ConvertDateCalendar(dt, CalendarEnum.Hijri);
            }
            else
                return string.Empty;
        }

        private string HijriToGer(string date)
        {
            if (string.IsNullOrEmpty(date) == false && Helper.CheckDateHijri(date))
            {
                DateTime dt = new DateTime();
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                dt = Convert.ToDateTime(date, format);
                return Helper.ConvertDateCalendar(dt, CalendarEnum.Gregorian);
            }
            else
            {
                return string.Empty;
            }
        }

    }
}
