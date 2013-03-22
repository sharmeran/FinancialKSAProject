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
using FSP.Domain.Domains.Administration;

namespace FSP.Windows.Views.Administration
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click_1(object sender, RoutedEventArgs e)
        {
            //Environment.Exit(Environment.ExitCode);
            ClearError();
        }

        private void btn_Login_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Username.Text) && string.IsNullOrEmpty(txt_Password.Password))
            {
                SetError(3, "يجب ملئ اسم المستخدم و كلمة المرور قبل الشروع بالدخول");
            }
            else if(string.IsNullOrEmpty(txt_Username.Text) )
            {
                SetError(1, "يجب ملئ اسم المستخدم قبل الشروع بالدخول");
            }
            else if (string.IsNullOrEmpty(txt_Password.Password))
            {
                SetError(2, "يجب ملئ كلمة المرور قبل الشروع بالدخول");
            }
            else
            {
                UserDomain userDomain = new UserDomain(1, Common.Enums.LanguagesEnum.Arabic);
                userDomain.CheckUserLogin(txt_Username.Text, txt_Password.Password);
                if (userDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
                {
                    SetError(0, userDomain.ActionState.Result);
                }
                else
                {
                    AppWindow appWindow = new AppWindow();
                    appWindow.Show();
                    ((Window)((Grid)this.Parent).Parent).Close();
                    
                }
            }
        }
        private void SetError(int controlsToBeSet, string error)
        {
            if (controlsToBeSet == 0)
            {
                txt_ErrorDisplay.Text = error;
            }
            else if(controlsToBeSet==1)
            {
                brdr_Username.BorderBrush = new SolidColorBrush(Colors.Red);
                txt_ErrorDisplay.Text = error;
            }
            else if (controlsToBeSet == 2)
            {
                brdr_Password.BorderBrush = new SolidColorBrush(Colors.Red);
                txt_ErrorDisplay.Text = error;
            }
            else
            {
                brdr_Username.BorderBrush = new SolidColorBrush(Colors.Red);
                brdr_Password.BorderBrush = new SolidColorBrush(Colors.Red);
                txt_ErrorDisplay.Text = error;
            }
        }
        private void ClearError()
        {
            brdr_Username.BorderBrush = new SolidColorBrush(Colors.White);
            brdr_Password.BorderBrush = new SolidColorBrush(Colors.White);
            txt_ErrorDisplay.Text = string.Empty;
        }
    }
}
