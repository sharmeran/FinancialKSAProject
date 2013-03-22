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
    /// Interaction logic for CompanyView.xaml
    /// </summary>
    public partial class CompanyView : UserControl
    {
        public CompanyView()
        {
            InitializeComponent();
        }
        List<Company> companyList = new List<Company>();
        Company company = new Company();
        CompanyDomain companyDomain = new CompanyDomain(1, Common.Enums.LanguagesEnum.Arabic);
        List<Sector> sectorList = new List<Sector>();
        SectorDomain sectorDomain = new SectorDomain(1, Common.Enums.LanguagesEnum.Arabic);


        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            companyList = companyDomain.FindAll();
            if (companyDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
            {
                MessageBox.Show(companyDomain.ActionState.Result, "جلب الشركات", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                grd_Company.ItemsSource = companyList;
            }
            sectorList = sectorDomain.FindAll();
            if (sectorDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
            {
                MessageBox.Show(sectorDomain.ActionState.Result, "جلب القطاعات", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                cmbo_Sector.ItemsSource = sectorList;
            }

            BehaviourDomain behaviourDomain = new BehaviourDomain(1, Common.Enums.LanguagesEnum.Arabic);
            List<Behaviour> behaviorList = new List<Behaviour>();
            List<CheckBox> chkList = new List<CheckBox>();
            behaviorList = behaviourDomain.FindAll();
            if (behaviourDomain.ActionState.Status == Common.Enums.ActionStatusEnum.NoError)
            {
                for (int i = 0; i < behaviorList.Count; i++)
                {
                    CheckBox chkBox = new CheckBox();
                    chkBox.DataContext = behaviorList[i];
                    chkBox.Content = behaviorList[i].Name;
                    chkList.Add(chkBox);
                }
                cmbo_Behaviours.ItemsSource=chkList;
            }
            txt_Name.Focus();
        }

        private void btn_Save_Click_1(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                company.Capital =(float) Convert.ToDouble(txt_Capital.Text);
                if (!string.IsNullOrEmpty(dtpkr_ClosedJointStockCompany_Ger.Text))
                {
                    if (Helper.CheckDateGer(dtpkr_ClosedJointStockCompany_Ger.Text))
                    {
                        DateTimeFormatInfo format = new DateTimeFormatInfo();
                        format.ShortDatePattern = "dd/MM/yyyy";
                        company.ClosedJointStockCompany = Convert.ToDateTime(dtpkr_ClosedJointStockCompany_Ger.Text, format);
                    }
                }
                
                
                    
                

                company.Description = txt_Description.Text;
                company.DescriptionEnglish = txt_DescriptionEnglish.Text;

                 if (!string.IsNullOrEmpty(dtpkr_EstablishGer.Text))
                {
                    if (Helper.CheckDateGer(dtpkr_EstablishGer.Text))
                    {                        
                        DateTimeFormatInfo format = new DateTimeFormatInfo();
                        format.ShortDatePattern = "dd/MM/yyyy";
                        company.EstablishYear= Convert.ToDateTime(dtpkr_EstablishGer.Text, format);
                    }
                }

                 if (!string.IsNullOrEmpty(dtpkr_GeneralCompany_Ger.Text))
                 {
                     if (Helper.CheckDateGer(dtpkr_GeneralCompany_Ger.Text))
                     {
                         DateTimeFormatInfo format = new DateTimeFormatInfo();
                         format.ShortDatePattern = "dd/MM/yyyy";
                         company.GeneralCompany = Convert.ToDateTime(dtpkr_GeneralCompany_Ger.Text, format);
                     }
                 }
                 company.Information = txt_Information.Text;
                 company.InformationEnglish = txt_InformationEnglish.Text;
                 if (!string.IsNullOrEmpty(dtpkr_IPO_Ger.Text))
                 {
                     if (Helper.CheckDateGer(dtpkr_IPO_Ger.Text))
                     {
                         DateTimeFormatInfo format = new DateTimeFormatInfo();
                         format.ShortDatePattern = "dd/MM/yyyy";
                         company.IPO = Convert.ToDateTime(dtpkr_IPO_Ger.Text, format);
                     }
                 }
                 company.Rank = Convert.ToInt32(txt_Rank.Text);
                 company.Name = txt_Name.Text;
                 company.NameEnglish = txt_NameEnglish.Text;
                 company.Sector = ((Sector)cmbo_Sector.SelectedItem);
                if (!string.IsNullOrEmpty(dtpkr_WithLimitedLiability_Ger.Text))
                 {
                     if (Helper.CheckDateGer(dtpkr_WithLimitedLiability_Ger.Text))
                     {
                         DateTimeFormatInfo format = new DateTimeFormatInfo();
                         format.ShortDatePattern = "dd/MM/yyyy";
                         company.WithLimitedLiability = Convert.ToDateTime(dtpkr_WithLimitedLiability_Ger.Text, format);
                     }
                 }
                List<Behaviour> behaviours = new List<Behaviour>();
                for (int i = 0; i < cmbo_Behaviours.Items.Count; i++)
                {
                    CheckBox checkBox =(CheckBox)cmbo_Behaviours.Items[i];
                    if ((bool)checkBox.IsChecked)
                    {
                        behaviours.Add((Behaviour)checkBox.DataContext);
                    }
                }
                company.BehaviourList = behaviours;

                if (company.ID == 0)
                {
                    companyDomain.Add(company);
                    if (companyDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show(companyDomain.ActionState.Result, "اضافة شركة", MessageBoxButton.OK, MessageBoxImage.Error);
                        Clear();
                        
                    }
                    else
                    {
                        MessageBox.Show("تمت الاضافة بنجاح", "اضافة شركة", MessageBoxButton.OK, MessageBoxImage.Information);
                        companyList.Add(company);
                        grd_Company.ItemsSource = null;
                        grd_Company.ItemsSource = companyList;
                        Clear();
                        stk_SubCompanies.Visibility = System.Windows.Visibility.Visible;
                    }
                }
                else
                {
                    companyDomain.Update(company);
                    if (companyDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show(companyDomain.ActionState.Result, "تعديل شركة", MessageBoxButton.OK, MessageBoxImage.Error);
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("تم التعديل بنجاح", "تعديل شركة", MessageBoxButton.OK, MessageBoxImage.Information);
                        for (int i = 0; i < companyList.Count; i++)
                        {
                            if (companyList[i].ID == company.ID)
                            {
                                companyList[i] = company;
                                grd_Company.ItemsSource = null;
                                grd_Company.ItemsSource = companyList;
                                break;
                            }
                        }
                        Clear();
                        stk_SubCompanies.Visibility = System.Windows.Visibility.Visible;
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
            if (grd_Company.SelectedItem != null)
            {
                company = (Company)grd_Company.SelectedItem;
                MessageBoxResult result = MessageBox.Show("هل انت متأكد من حذف " + company.Name, "حذف الشركة", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    companyDomain.Delete(company);
                    if (companyDomain.ActionState.Status == Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show("تم الحذف بنجاح", "حذف الشركة", MessageBoxButton.OK, MessageBoxImage.Information);
                        companyList.Remove(company);
                        grd_Company.ItemsSource = null;
                        grd_Company.ItemsSource = companyList;
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(companyDomain.ActionState.Result, "حذف الشركة", MessageBoxButton.OK, MessageBoxImage.Error);
                        Clear();
                    }
                }
            }
        }

        private void grd_Sector_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            Clear();
            if (grd_Company.SelectedItem != null)
            {
                company = (Company)grd_Company.SelectedItem;
                txt_Capital.Text = company.Capital.ToString();
                txt_Description.Text = company.Description;
                txt_DescriptionEnglish.Text = company.DescriptionEnglish;
                txt_Information.Text = company.Information;
                txt_InformationEnglish.Text = company.InformationEnglish;
                txt_Name.Text = company.Name;
                txt_NameEnglish.Text = company.NameEnglish;
                txt_Rank.Text = company.Rank.ToString();
                for (int i = 0; i < cmbo_Sector.Items.Count; i++)
                {
                    if (company.Sector.ID == ((Sector)cmbo_Sector.Items[i]).ID)
                    {
                        cmbo_Sector.SelectedIndex = i;
                        break;
                    }
                }

                if (company.EstablishYear.Year != 1)
                {
                    dtpkr_EstablishGer.Text = company.EstablishYear.Date.ToString("dd/MM/yyyy");
                    dtpkr_EstablishHij.Text = GerToHejri(dtpkr_EstablishGer.Text);
                }

                if (company.WithLimitedLiability.Year != 1)                
                {
                    dtpkr_WithLimitedLiability_Ger.Text = company.WithLimitedLiability.Date.ToString("dd/MM/yyyy");
                    dtpkr_WithLimitedLiability_Hijri.Text = GerToHejri(dtpkr_WithLimitedLiability_Ger.Text);
                }

                if (company.ClosedJointStockCompany.Year != 1)
                {
                    dtpkr_ClosedJointStockCompany_Ger.Text = company.ClosedJointStockCompany.Date.ToString("dd/MM/yyyy");
                    dtpkr_ClosedJointStockCompany_Hijri.Text = GerToHejri(dtpkr_ClosedJointStockCompany_Ger.Text);
                }

                if (company.IPO.Year != 1)
                {
                    dtpkr_IPO_Ger.Text = company.IPO.Date.ToString("dd/MM/yyyy");
                    dtpkr_IPO_Hijri.Text = GerToHejri(dtpkr_IPO_Ger.Text);
                }

                if (company.GeneralCompany.Year != 1)
                {
                    dtpkr_GeneralCompany_Ger.Text = company.GeneralCompany.Date.ToString("dd/MM/yyyy");
                    dtpkr_GeneralCompany_Hijri.Text = GerToHejri(dtpkr_GeneralCompany_Ger.Text);
                }

                stk_SubCompanies.Visibility = System.Windows.Visibility.Visible;
                for (int i = 0; i < company.BehaviourList.Count; i++)
                {
                    for (int j = 0; j < cmbo_Behaviours.Items.Count; j++)
                    {
                        if (((Behaviour)((CheckBox)cmbo_Behaviours.Items[j]).DataContext).ID == company.BehaviourList[i].ID)
                        {
                            ((CheckBox)cmbo_Behaviours.Items[j]).IsChecked = true;
                        }
                    }
                }
            }
        }

        private void Clear()
        {
            txt_Capital.Text = string.Empty;
            txt_Description.Text = string.Empty;
            txt_DescriptionEnglish.Text = string.Empty;
            txt_Err_Capital.Text = string.Empty;
            txt_Err_ClosedJointStockCompany.Text = string.Empty;
            txt_Err_Description.Text = string.Empty;
            txt_Err_DescriptionEnglish.Text = string.Empty;
            txt_Err_Establish.Text = string.Empty;
            txt_Err_GeneralCompany.Text = string.Empty;
            txt_Err_Information.Text = string.Empty;
            txt_Err_InformationEnglish.Text = string.Empty;
            txt_Err_IPO.Text = string.Empty;
            txt_Err_Name.Text = string.Empty;
            txt_Err_NameEnglish.Text = string.Empty;
            txt_Err_WithLimitedLiability.Text = string.Empty;
            txt_Information.Text = string.Empty;
            txt_InformationEnglish.Text = string.Empty;
            txt_Name.Text = string.Empty;
            txt_NameEnglish.Text = string.Empty;

            dtpkr_ClosedJointStockCompany_Ger.Text = string.Empty;
            dtpkr_ClosedJointStockCompany_Hijri.Text = string.Empty;
            dtpkr_EstablishGer.Text = string.Empty;
            dtpkr_EstablishHij.Text = string.Empty;
            dtpkr_GeneralCompany_Ger.Text = string.Empty;
            dtpkr_GeneralCompany_Hijri.Text = string.Empty;
            dtpkr_IPO_Ger.Text = string.Empty;
            dtpkr_IPO_Hijri.Text = string.Empty;
            dtpkr_WithLimitedLiability_Ger.Text = string.Empty;
            dtpkr_WithLimitedLiability_Hijri.Text = string.Empty;
            txt_Err_Rank.Text = string.Empty;
            txt_Rank.Text = string.Empty;
            company = new Company();
            cmbo_Sector.SelectedIndex = 0;
            stk_SubCompanies.Visibility = System.Windows.Visibility.Collapsed;
            for (int i = 0; i < cmbo_Behaviours.Items.Count; i++)
            {
                ((CheckBox)cmbo_Behaviours.Items[i]).IsChecked = false;
            }
        }

        private void dtpkr_EstablishGer_LostFocus_1(object sender, RoutedEventArgs e)
        {
            RadWatermarkTextBox radWatermarkTextBox=(RadWatermarkTextBox)sender;
            if (radWatermarkTextBox.Name == "dtpkr_EstablishGer")
            {
                dtpkr_EstablishHij.Text = GerToHejri(radWatermarkTextBox.Text);
            }
            else if (radWatermarkTextBox.Name == "dtpkr_WithLimitedLiability_Ger")
            {
                dtpkr_WithLimitedLiability_Hijri.Text = GerToHejri(radWatermarkTextBox.Text);
            }
            else if (radWatermarkTextBox.Name == "dtpkr_ClosedJointStockCompany_Ger")
            {
                dtpkr_ClosedJointStockCompany_Hijri.Text = GerToHejri(radWatermarkTextBox.Text);
            }
            else if (radWatermarkTextBox.Name == "dtpkr_IPO_Ger")
            {
                dtpkr_IPO_Hijri.Text = GerToHejri(radWatermarkTextBox.Text);
            }
            else if (radWatermarkTextBox.Name == "dtpkr_GeneralCompany_Ger")
            {
                dtpkr_GeneralCompany_Hijri.Text = GerToHejri(radWatermarkTextBox.Text);
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
            bool rank = false;

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
                establishDate = true;
                txt_Err_Establish.Text = string.Empty;
            }
            else
            {
                establishDate = false;
                txt_Err_Establish.Text = "يجب ملئ سنة التأسيس";
            }
            if (string.IsNullOrEmpty(txt_Capital.Text) == false)
            {
                float cap;

                if (float.TryParse(txt_Capital.Text, out cap))
                {
                    txt_Err_Capital.Text = string.Empty;
                    capital = true;
                }
                else
                {
                    capital = false;
                    txt_Err_Capital.Text = "رأس مال الشركة يجب ان يكون ارقام ";
                }

            }
            else
            {
                capital = false;
                txt_Err_Capital.Text = "يجب ملئ رأس مال الشركة";
            }

            if (string.IsNullOrEmpty(txt_Rank.Text) == false)
            {
                float cap;

                if (float.TryParse(txt_Rank.Text, out cap))
                {
                    txt_Err_Rank.Text = string.Empty;
                    rank = true;
                }
                else
                {
                    rank = false;
                    txt_Err_Rank.Text = "ترتيب الشركة يجب ان يكون ارقام ";
                }

            }
            else
            {
                capital = false;
                txt_Err_Rank.Text = "يجب ملئ رأس ترتيب الشركة";
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
            return nameEnglish & name & description & descriptionEnglish & information & informationEnglish & capital & establishDate & rank;
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
            else if (radWatermarkTextBox.Name == "dtpkr_WithLimitedLiability_Hijri")
            {
                dtpkr_WithLimitedLiability_Ger.Text = HijriToGer(radWatermarkTextBox.Text);
            }
            else if (radWatermarkTextBox.Name == "dtpkr_ClosedJointStockCompany_Hijri")
            {
                dtpkr_ClosedJointStockCompany_Ger.Text = HijriToGer(radWatermarkTextBox.Text);
            }
            else if (radWatermarkTextBox.Name == "dtpkr_IPO_Hijri")
            {
                dtpkr_IPO_Ger.Text = HijriToGer(radWatermarkTextBox.Text);
            }
            else if (radWatermarkTextBox.Name == "dtpkr_GeneralCompany_Hijri")
            {
                dtpkr_GeneralCompany_Ger.Text = HijriToGer(radWatermarkTextBox.Text);
            }
        }

        private void btn_SisterCompany_Click_1(object sender, RoutedEventArgs e)
        {
            if (company.ID != 0)
            {
                SisterCompanyView sisterCompanyView = new SisterCompanyView(company.ID);
                Window window = new Window();
                window.Content = sisterCompanyView;
                window.ShowDialog();
            }
        }

        private void btn_SubsidiaryCompany_Click_1(object sender, RoutedEventArgs e)
        {
            if (company.ID != 0)
            {
                SubsidiaryCompanyView subsidiaryCompanyView = new SubsidiaryCompanyView(company.ID);
                Window window = new Window();
                window.Content = subsidiaryCompanyView;
                window.ShowDialog();
            }
        }


    }
}
