using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FSP.Windows.Reports.CompanyAdministration
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            var myRevenues = new List<MonthRevenue>();
            myRevenues.Add(new MonthRevenue() { Amount = 20, Date = new DateTime(2012, 7, 10) });
            myRevenues.Add(new MonthRevenue() { Amount = 10, Date = new DateTime(2012, 8, 10) });
            myRevenues.Add(new MonthRevenue() { Amount = 30, Date = new DateTime(2012, 9, 10) });
            myRevenues.Add(new MonthRevenue() { Amount = 20, Date = new DateTime(2012, 10, 10) });
            myRevenues.Add(new MonthRevenue() { Amount = 40, Date = new DateTime(2012, 11, 10) });
            myRevenues.Add(new MonthRevenue() { Amount = 10, Date = new DateTime(2012, 12, 10) });
            Revenues = myRevenues;
        }

        private List<MonthRevenue> revenues;
        public List<MonthRevenue> Revenues
        {
            get { return revenues; }
            set
            {
                revenues = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(
                   [CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
