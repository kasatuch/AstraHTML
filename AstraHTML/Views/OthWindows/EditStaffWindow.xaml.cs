using AstraHTML.Models;
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

namespace AstraHTML.Views.OthWindows
{
    /// <summary>
    /// Логика взаимодействия для EditStaffWindow.xaml
    /// </summary>
    public partial class EditStaffWindow : Window
    {
        public EditStaffWindow(Staff staffToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            DataManageVM.SelectedStaff = staffToEdit;
            DataManageVM.StaffName = staffToEdit.Name;
            DataManageVM.StaffSurname = staffToEdit.Surname;
            DataManageVM.StaffSpeciality = staffToEdit.Speciality;
            DataManageVM.StaffPost = staffToEdit.Post;
            DataManageVM.StaffLogin = staffToEdit.Login;
            DataManageVM.StaffPassword = staffToEdit.Password;
        }
        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
