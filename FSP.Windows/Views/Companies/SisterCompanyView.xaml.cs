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

namespace FSP.Windows.Views.Companies
{
    /// <summary>
    /// Interaction logic for SisterCompany.xaml
    /// </summary>
    public partial class SisterCompanyView : UserControl
    {
        public SisterCompanyView()
        {
            InitializeComponent();
        }
        int CompanyID = 0;
        SisterCompany sisterCompany = new SisterCompany();
        List<SisterCompany> sisterCompanyList = new List<SisterCompany>();
        List<Sector> sectorList = new List<Sector>();

        public SisterCompanyView(int companyID)
        {
            InitializeComponent();
            CompanyID = companyID;
        }
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            SisterCompanyDomain sisterCompanyDomain = new SisterCompanyDomain(1, Common.Enums.LanguagesEnum.Arabic);
            sisterCompanyList = sisterCompanyDomain.FindByCompanyID(CompanyID);
            if (sisterCompanyDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
            {
                MessageBox.Show(sisterCompanyDomain.ActionState.Result, "جلب سجلات الشركات الشقيقة", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                grd_SisterCompany.ItemsSource = sisterCompanyList;
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

        private void grd_SisterCompany_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            if (grd_SisterCompany.SelectedItem != null)
            {
                sisterCompany = (SisterCompany)grd_SisterCompany.SelectedItem;
                txt_Description.Text = sisterCompany.Description;
                txt_DescriptionEnglish.Text = sisterCompany.DescriptionEnglish;
                txt_Name.Text = sisterCompany.Name;
                txt_NameEnglish.Text = sisterCompany.NameEnglish;
                txt_Place.Text = sisterCompany.Place;
                txt_PlaceEnglish.Text = sisterCompany.PlaceEnglish;
                for (int i = 0; i < cmbo_Sector.Items.Count; i++)
                {
                    if (sisterCompany.Sector.ID == ((Sector)cmbo_Sector.Items[i]).ID)
                    {
                        cmbo_Sector.SelectedIndex = i;
                        break;
                    }
                }
                if (sisterCompany.EstablishDate.Year != 1)
                {
                    dtpkr_EstablishGer.Text = sisterCompany.EstablishDate.Date.ToString("dd/MM/yyyy");
                    dtpkr_EstablishHij.Text = GerToHejri(dtpkr_EstablishGer.Text);
                }
                chk_IsOutKSA.IsChecked = sisterCompany.IsOutKSA;
            }
        }

        private void btn_Delete_Click_1(object sender, RoutedEventArgs e)
        {
            if (grd_SisterCompany.SelectedItem != null)
            {
                SisterCompanyDomain sisterCompanyDomain = new SisterCompanyDomain(1, Common.Enums.LanguagesEnum.Arabic);
                sisterCompany = (SisterCompany)grd_SisterCompany.SelectedItem;
                MessageBoxResult result = MessageBox.Show("هل انت متأكد من حذف " + sisterCompany.Name, "حذف الشركة", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {

                    sisterCompanyDomain.Delete(sisterCompany);
                    if (sisterCompanyDomain.ActionState.Status == Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show("تم الحذف بنجاح", "حذف الشركة", MessageBoxButton.OK, MessageBoxImage.Information);
                        sisterCompanyList.Remove(sisterCompany);
                        grd_SisterCompany.ItemsSource = null;
                        grd_SisterCompany.ItemsSource = sisterCompanyList;
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(sisterCompanyDomain.ActionState.Result, "حذف الشركة", MessageBoxButton.OK, MessageBoxImage.Error);
                        Clear();
                    }
                }
            }
        }

        private void btn_Clear_Click_1(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void btn_Save_Click_1(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                sisterCompany.CompanyID = CompanyID;
                sisterCompany.Description = txt_Description.Text;
                sisterCompany.DescriptionEnglish = txt_DescriptionEnglish.Text;
                DateTimeFormatInfo format = new DateTimeFormatInfo();
                format.ShortDatePattern = "dd/MM/yyyy";
                sisterCompany.EstablishDate = Convert.ToDateTime(dtpkr_EstablishGer.Text, format);
                sisterCompany.IsOutKSA = Convert.ToBoolean(chk_IsOutKSA.IsChecked);
                sisterCompany.Name = txt_Name.Text;
                sisterCompany.NameEnglish = txt_NameEnglish.Text;
                sisterCompany.Place = txt_Place.Text;
                sisterCompany.PlaceEnglish = txt_PlaceEnglish.Text;
                sisterCompany.Sector = (Sector)cmbo_Sector.SelectedItem;

                if (sisterCompany.ID == 0)
                {
                    SisterCompanyDomain sisterCompanyDomain = new SisterCompanyDomain(1, Common.Enums.LanguagesEnum.Arabic);
                    sisterCompanyDomain.Add(sisterCompany);
                    if (sisterCompanyDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show(sisterCompanyDomain.ActionState.Result, "إضافة شركة شقيقة", MessageBoxButton.OK, MessageBoxImage.Error);                        
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("تمت الإضافة بنجاح", "إضافة شركة شقيقة", MessageBoxButton.OK, MessageBoxImage.Information);
                        sisterCompanyList.Add(sisterCompany);
                        grd_SisterCompany.ItemsSource = null;
                        grd_SisterCompany.ItemsSource = sisterCompanyList;
                        Clear();

                    }
                }
                else
                {
                    SisterCompanyDomain sisterCompanyDomain = new SisterCompanyDomain(1, Common.Enums.LanguagesEnum.Arabic);
                    sisterCompanyDomain.Update(sisterCompany);
                    if (sisterCompanyDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show(sisterCompanyDomain.ActionState.Result, "تعديل شركة شقيقة", MessageBoxButton.OK, MessageBoxImage.Error);
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("تم التعديل بنجاح", "تعديل شركة شقيقة", MessageBoxButton.OK, MessageBoxImage.Information);                        
                        for (int i = 0; i < sisterCompanyList.Count; i++)
                        {
                            if (sisterCompanyList[i].ID == sisterCompany.ID)
                            {
                                sisterCompanyList[i] = sisterCompany;
                                grd_SisterCompany.ItemsSource = null;
                                grd_SisterCompany.ItemsSource = sisterCompanyList;
                            }
                        }
                        Clear();

                    }
                }

            }
        }

        private void dtpkr_EstablishGer_LostFocus_1(object sender, RoutedEventArgs e)
        {
            RadWatermarkTextBox radWatermarkTextBox = (RadWatermarkTextBox)sender;
            if (radWatermarkTextBox.Name == "dtpkr_EstablishGer")
            {
                dtpkr_EstablishHij.Text = GerToHejri(radWatermarkTextBox.Text);
            }
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
        private void dtpkr_EstablishHij_LostFocus_1(object sender, RoutedEventArgs e)
        {
            RadWatermarkTextBox radWatermarkTextBox = (RadWatermarkTextBox)sender;
            if (radWatermarkTextBox.Name == "dtpkr_EstablishHij")
            {
                dtpkr_EstablishGer.Text = HijriToGer(radWatermarkTextBox.Text);
            }
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
                    establishDate = false;
                    txt_Err_Establish.Text = "يجب ملئ سنة التأسيس";
                }
            }
            else
            {
                establishDate = false;
                txt_Err_Establish.Text = "يجب ملئ سنة التأسيس";
            }

            if (string.IsNullOrEmpty(txt_Place.Text) == false)
            {
                txt_Err_Place.Text = string.Empty;
                information = true;
            }
            else
            {
                txt_Err_Place.Text = "يجب ملئ العنوان عن الشركة";
                information = false;
            }

            if (string.IsNullOrEmpty(txt_PlaceEnglish.Text) == false)
            {
                txt_Err_PlaceEnglish.Text = string.Empty;
                informationEnglish = true;
            }
            else
            {
                txt_Err_PlaceEnglish.Text = "يجب ملئ العنوان بالانجليزية";
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
            return nameEnglish & name & description & descriptionEnglish & information & informationEnglish & establishDate;
        }

        private void Clear()
        {

            txt_Description.Text = string.Empty;
            txt_DescriptionEnglish.Text = string.Empty;
            txt_Err_Description.Text = string.Empty;
            txt_Err_DescriptionEnglish.Text = string.Empty;
            txt_Err_Establish.Text = string.Empty;
            txt_Err_Name.Text = string.Empty;
            txt_Err_NameEnglish.Text = string.Empty;
            txt_NameEnglish.Text = string.Empty;
            txt_Name.Text = string.Empty;
            txt_Err_Place.Text = string.Empty;
            txt_Err_PlaceEnglish.Text = string.Empty;
            txt_Place.Text = string.Empty;
            txt_PlaceEnglish.Text = string.Empty;
            dtpkr_EstablishGer.Text = string.Empty;
            dtpkr_EstablishHij.Text = string.Empty;
            sisterCompany = new SisterCompany();
            cmbo_Sector.SelectedIndex = 0;
        }
    }
}
