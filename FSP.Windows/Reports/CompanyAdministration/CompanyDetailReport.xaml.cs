using FSP.Common.Entites.CompanyAdministration;
using FSP.Domain.Domains.CompanyAdministration;
using FSP.Windows.CommonView;
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

namespace FSP.Windows.Reports.CompanyAdministration
{
    /// <summary>
    /// Interaction logic for CompanyDetailReport.xaml
    /// </summary>
    public partial class CompanyDetailReport : UserControl
    {
        public CompanyDetailReport()
        {
            InitializeComponent();
        }
        int CompanyID = 0;
        CompanyDomain domain = new CompanyDomain(1, Common.Enums.LanguagesEnum.Arabic);
        Company company = new Company();
        public CompanyDetailReport(int companyID)
        {
            InitializeComponent();
            CompanyID = companyID;
           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
            company = domain.FindByID(CompanyID);
            string[] cap = company.Capital.ToString("C", CultureInfo.CreateSpecificCulture("ar-SA")).Split(' ');
            txt_CompanyCapital.Text = cap[1]+ " "+cap[0];
            txt_CompanyDesc.Text = company.Description;
            string[] date = GerToHejri(company.EstablishYear.ToString("dd/MM/yyyy")).Split('/');
            txt_CompanyEstablish.Text = date[2] + "/" + date[1] + "/" + date[0];
            txt_CompanyName.Text = company.Name;
            txt_CompanySec.Text = company.Sector.Name;
            //foreach (Behaviour behaviour in company.BehaviourList)
            //{
            //    SectorDetailSectionReport sectorDetailSectionReport = new SectorDetailSectionReport(behaviour.Name, behaviour.Description);
            //    stk_BehaviourDetails.Children.Add(sectorDetailSectionReport);
            //}

            foreach (SisterCompany sister in company.SisterCompanyList)
            {
                SisterCompanyDetailSectionReport sisterCompanyDetailSectionReport = new SisterCompanyDetailSectionReport(sister.Name, sister.Sector.Name, sister.OwnerPercentage.ToString());
                stk_SisterCompany.Children.Add(sisterCompanyDetailSectionReport);
            }

            foreach (SubsidiaryCompany subsidiary in company.SubsidiaryCompanyList)
            {
                SisterCompanyDetailSectionReport sisterCompanyDetailSectionReport = new SisterCompanyDetailSectionReport(subsidiary.Name, subsidiary.Sector.Name, subsidiary.OwnPercentage.ToString());
                stk_SubCompany.Children.Add(sisterCompanyDetailSectionReport);
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


    }
}
