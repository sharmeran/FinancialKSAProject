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

namespace FSP.Windows.Views.Companies
{
    /// <summary>
    /// Interaction logic for BehaviourJudgmentView.xaml
    /// </summary>
    public partial class BehaviourJudgmentView : UserControl
    {
        public BehaviourJudgmentView()
        {
            InitializeComponent();
        }

        BehaviorJudgmentDomain behaviorJudgmentDomain = new BehaviorJudgmentDomain(1, Common.Enums.LanguagesEnum.Arabic);
        List<BehaviorJudgment> behaviorJudgmentList = new List<BehaviorJudgment>();
        BehaviorJudgment behaviorJudgment = new BehaviorJudgment();
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            behaviorJudgmentList = behaviorJudgmentDomain.FindAll();
            if (behaviorJudgmentDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
            {
                MessageBox.Show(behaviorJudgmentDomain.ActionState.Result);
            }
            else
            {
                grd_BehaviourJudgment.ItemsSource = behaviorJudgmentList;
            }
            txt_Name.Focus();
        }

        private void btn_Save_Click_1(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                behaviorJudgment.Description = txt_Description.Text;
                behaviorJudgment.Name = txt_Name.Text;
                behaviorJudgment.NameEnglish = txt_EnglishName.Text;
                behaviorJudgment.DescriptionEnglish = txt_EnglishDescription.Text;
                behaviorJudgment.Value = Convert.ToInt32(txt_Value.Text);
                if (behaviorJudgment.ID == 0)
                {
                    behaviorJudgmentDomain.Add(behaviorJudgment);
                    if (behaviorJudgmentDomain.ActionState.Status == Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show("تمت الاضافة بنجاح", "اضافة حكم للنشاط", MessageBoxButton.OK, MessageBoxImage.Information);
                        behaviorJudgmentList.Add(behaviorJudgment);
                        grd_BehaviourJudgment.ItemsSource = null;
                        grd_BehaviourJudgment.ItemsSource = behaviorJudgmentList;
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(behaviorJudgmentDomain.ActionState.Result, "اضافة حكم للنشاط", MessageBoxButton.OK, MessageBoxImage.Error);                        
                        Clear();
                    }
                }
                else
                {
                    behaviorJudgmentDomain.Update(behaviorJudgment);
                    if (behaviorJudgmentDomain.ActionState.Status == Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show("تم التعديل بنجاح", "تعديل حكم للنشاط", MessageBoxButton.OK, MessageBoxImage.Information);
                        for (int i = 0; i < behaviorJudgmentList.Count; i++)
                        {
                            if (behaviorJudgmentList[i].ID == behaviorJudgment.ID)
                            {
                                behaviorJudgmentList[i] = behaviorJudgment;
                                break;
                            }
                        }
                        grd_BehaviourJudgment.ItemsSource = null;
                        grd_BehaviourJudgment.ItemsSource = behaviorJudgmentList;
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(behaviorJudgmentDomain.ActionState.Result, "تعديل حكم للنشاط", MessageBoxButton.OK, MessageBoxImage.Error);
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

            if (grd_BehaviourJudgment.SelectedItem != null)
            {
               
                behaviorJudgment = (BehaviorJudgment)grd_BehaviourJudgment.SelectedItem;
                MessageBoxResult result= MessageBox.Show("هل انت متأكد من حذف " + behaviorJudgment.Name, "حذف حكم النشاط", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    behaviorJudgmentDomain.Delete(behaviorJudgment);
                    if (behaviorJudgmentDomain.ActionState.Status == Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show("تم الحذف بنجاح", "حذف حكم النشاط", MessageBoxButton.OK, MessageBoxImage.Information);
                        behaviorJudgmentList.Remove(behaviorJudgment);
                        grd_BehaviourJudgment.ItemsSource = null;
                        grd_BehaviourJudgment.ItemsSource = behaviorJudgmentList;
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(behaviorJudgmentDomain.ActionState.Result, "حذف حكم النشاط", MessageBoxButton.OK, MessageBoxImage.Error);
                        Clear();
                    }
                }
            }
        }

        private void Clear()
        {
            txt_Description.Text = string.Empty;
            txt_EnglishDescription.Text = string.Empty;
            txt_EnglishName.Text = string.Empty;
            txt_Err_Description.Text = string.Empty;
            txt_Err_EnglishDescription.Text = string.Empty;
            txt_Err_EnglishName.Text = string.Empty;
            txt_Err_Name.Text = string.Empty;
            txt_Err_Value.Text = string.Empty;
            txt_Name.Text = string.Empty;
            txt_Value.Text = string.Empty;
            behaviorJudgment = new BehaviorJudgment();
        }

        private bool Validation()
        {
            bool name = false;
            bool englishName = false;
            bool description = false;
            bool englishDescription = false;
            bool value = false;

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

            if (string.IsNullOrEmpty(txt_EnglishName.Text))
            {
                txt_Err_EnglishName.Text = "الرجاء ملئ الاسم بالانجليزية";
                englishName = false;
            }
            else
            {
                txt_Err_EnglishName.Text = string.Empty;
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

            if (string.IsNullOrEmpty(txt_EnglishDescription.Text))
            {
                txt_Err_EnglishDescription.Text = "الرجاء ملئ الوصف بالانجليزية";
                englishDescription = false;
            }
            else
            {
                txt_Err_EnglishDescription.Text = string.Empty;
                englishDescription = true;
            }

            if (string.IsNullOrEmpty(txt_Value.Text))
            {
                txt_Err_Value.Text = "الرجاء ملئ القيمة";
                englishDescription = false;
            }
            else
            {
                string Str = txt_Value.Text.Trim();
                int num;
                bool isNum = int.TryParse(Str, out num);
                if (isNum == true)
                {
                    txt_Err_EnglishDescription.Text = string.Empty;
                    value = true;
                }
                else
                {
                    txt_Err_Value.Text = "الرجاء ملئ القيمة بأرقام فقط";
                    value = false;
                }
               
            }
            return name & englishName & description & englishDescription & value;
        }

        private void grd_BehaviourJudgment_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (grd_BehaviourJudgment.SelectedItem != null)
            {
                behaviorJudgment = (BehaviorJudgment)grd_BehaviourJudgment.SelectedItem;
                txt_Description.Text = behaviorJudgment.Description;
                txt_EnglishDescription.Text = behaviorJudgment.DescriptionEnglish;
                txt_EnglishName.Text = behaviorJudgment.NameEnglish;
                txt_Name.Text = behaviorJudgment.Name;
                txt_Value.Text = behaviorJudgment.Value.ToString();
            }
        }
    }
}
