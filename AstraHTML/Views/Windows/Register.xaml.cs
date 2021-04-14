using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AstraHTML.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        DataManageVM vm = new DataManageVM();
        public Register()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NameBlock.Text == "")
            {
                NameImg.Foreground = Brushes.Red;
            }
            else
            {
                NameImg.Foreground = Brushes.Green;
            }

            if (SurnameBlock.Text == "")
            {
                SurnameImg.Foreground = Brushes.Red;
            }
            else
            {
                SurnameImg.Foreground = Brushes.Green;
            }

            if (SpecialityBlock.Text == "")
            {
                SpecialityImg.Foreground = Brushes.Red;
            }
            else
            {
                SpecialityImg.Foreground = Brushes.Green;
            }

            if (PostBlock.Text == "")
            {
                PostImg.Foreground = Brushes.Red;
            }
            else
            {
                PostImg.Foreground = Brushes.Green;
            }

            int salary = Convert.ToInt32(SalaryBlock.Text);

            if (salary < 0 || salary == 0)
            {
                SalaryImg.Foreground = Brushes.Red;
            }
            else
            {
                SalaryImg.Foreground = Brushes.Green;
            }

            if (LoginBlock.Text == "")
            {
                LoginImg.Foreground = Brushes.Red;
            }
            else
            {
                LoginImg.Foreground = Brushes.Green;
            }

            if (PasswordBlock.Text == "")
            {
                PasswordImg.Foreground = Brushes.Red;
            }
            else
            {
                PasswordImg.Foreground = Brushes.Green;
            }
        }
    }
}
