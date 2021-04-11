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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NameBlock.Text == "")
            {
                NameBlock.BorderBrush = Brushes.Red;
            }
            else
            {
                NameBlock.BorderBrush = Brushes.Green;
            }

            if (SurnameBlock.Text == "")
            {
                SurnameBlock.BorderBrush = Brushes.Red;
            }
            else
            {
                SurnameBlock.BorderBrush = Brushes.Green;
            }

            if (SpecialityBlock.Text == "")
            {
                SpecialityBlock.BorderBrush = Brushes.Red;
            }
            else
            {
                SpecialityBlock.BorderBrush = Brushes.Green;
            }

            if (PostBlock.Text == "")
            {
                PostBlock.BorderBrush = Brushes.Red;
            }
            else
            {
                PostBlock.BorderBrush = Brushes.Green;
            }

            int salary = Convert.ToInt32(SalaryBlock.Text);

            if (salary < 0 || salary == 0)
            {
                SalaryBlock.BorderBrush = Brushes.Red;
            }
            else
            {
                SalaryBlock.BorderBrush = Brushes.Green;
            }

            if (LoginBlock.Text == "")
            {
                LoginBlock.BorderBrush = Brushes.Red;
            }
            else
            {
                LoginBlock.BorderBrush = Brushes.Green;
            }

            if (PasswordBlock.Text == "")
            {
                PasswordBlock.BorderBrush = Brushes.Red;
            }
            else
            {
                PasswordBlock.BorderBrush = Brushes.Green;
            }
        }
    }
}
