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
    /// Interaction logic for BehaviorView.xaml
    /// </summary>
    public partial class BehaviorView : UserControl
    {
        public BehaviorView()
        {
            InitializeComponent();
        }
        BehaviourDomain behaviourDomain = new BehaviourDomain(1, Common.Enums.LanguagesEnum.Arabic);
        Behaviour behaviour = new Behaviour();
        List<Behaviour> behaviourList = new List<Behaviour>();
        List<BehaviorJudgment> behaviourJudgmentList = new List<BehaviorJudgment>();
        BehaviorJudgmentDomain behaviorJudgmentDomain = new BehaviorJudgmentDomain(1, Common.Enums.LanguagesEnum.Arabic);
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            behaviourList = behaviourDomain.FindAll();
            if (behaviourDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
            {
                MessageBox.Show(behaviourDomain.ActionState.Result, "جلب النشاطات", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                grd_Behaviour.ItemsSource = behaviourList;
            }
            behaviourJudgmentList = behaviorJudgmentDomain.FindAll();
            if (behaviorJudgmentDomain.ActionState.Status != Common.Enums.ActionStatusEnum.NoError)
            {
                MessageBox.Show(behaviorJudgmentDomain.ActionState.Result, "جلب الحكم على النشاط", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                cmbo_JudgmentBehavior.ItemsSource = behaviourJudgmentList;
            }
            txt_Name.Focus();
        }

        private void btn_Save_Click_1(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                behaviour.Description = txt_Description.Text;
                behaviour.DescriptionEnglish = txt_DescriptionEnglish.Text;
                behaviour.Judgment = (BehaviorJudgment)cmbo_JudgmentBehavior.SelectedItem;
                behaviour.Name = txt_Name.Text;
                behaviour.NameEnglish = txt_NameEnglish.Text;

                if (behaviour.ID == 0)
                {
                    behaviourDomain.Add(behaviour);
                    if (behaviourDomain.ActionState.Status == Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show("تمت الاضافة بنجاح", "اضافة النشاط", MessageBoxButton.OK, MessageBoxImage.Information);
                        behaviourList.Add(behaviour);
                        grd_Behaviour.ItemsSource = null;
                        grd_Behaviour.ItemsSource = behaviourList;
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(behaviourDomain.ActionState.Result, "اضافة النشاط", MessageBoxButton.OK, MessageBoxImage.Error);
                        Clear();
                    }
                }
                else
                {
                    behaviourDomain.Update(behaviour);
                    if (behaviourDomain.ActionState.Status == Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show("تم التعديل بنجاح", "تعديل النشاط", MessageBoxButton.OK, MessageBoxImage.Information);
                        for (int i = 0; i < behaviourList.Count; i++)
                        {
                            if (behaviourList[i].ID == behaviour.ID)
                            {
                                behaviourList[i] = behaviour;
                                break;
                            }
                        }
                        grd_Behaviour.ItemsSource = null;
                        grd_Behaviour.ItemsSource = behaviourList;
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(behaviourDomain.ActionState.Result, "تعديل النشاط", MessageBoxButton.OK, MessageBoxImage.Error);
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
            if (grd_Behaviour.SelectedItem != null)
            {
                behaviour = (Behaviour)grd_Behaviour.SelectedItem;
                MessageBoxResult result = MessageBox.Show("هل انت متأكد من حذف " + behaviour.Name, "حذف النشاط", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    behaviourDomain.Delete(behaviour);
                    if (behaviourDomain.ActionState.Status == Common.Enums.ActionStatusEnum.NoError)
                    {
                        MessageBox.Show("تم الحذف بنجاح", "حذف النشاط", MessageBoxButton.OK, MessageBoxImage.Information);
                        behaviourList.Remove(behaviour);
                        grd_Behaviour.ItemsSource = null;
                        grd_Behaviour.ItemsSource = behaviourList;
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show(behaviourDomain.ActionState.Result, "حذف النشاط", MessageBoxButton.OK, MessageBoxImage.Error);
                        Clear();
                    }
                }
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
            behaviour = new Behaviour();
            cmbo_JudgmentBehavior.SelectedIndex = 0;
        }

        private bool  Validation()
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

        private void grd_Behaviour_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            if (grd_Behaviour.SelectedItem != null)
            {
                behaviour = (Behaviour)grd_Behaviour.SelectedItem;
                txt_Description.Text = behaviour.Description;
                txt_DescriptionEnglish.Text = behaviour.DescriptionEnglish;
                txt_NameEnglish.Text = behaviour.NameEnglish;
                txt_Name.Text = behaviour.Name;
                for (int i = 0; i < cmbo_JudgmentBehavior.Items.Count; i++)
                {
                    if (behaviour.Judgment.ID == ((BehaviorJudgment)cmbo_JudgmentBehavior.Items[i]).ID)
                    {
                        cmbo_JudgmentBehavior.SelectedIndex = i;
                        break;
                    }
                }
                
            }
        }
    }
}
