using AstraHTML.Data;
using AstraHTML.Models;
using AstraHTML.Views;
using AstraHTML.Views.Windows;
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

namespace AstraHTML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ExitBut_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AuthBut_Click(object sender, RoutedEventArgs e)
        {
            if (DataWorker.StaffExistence(LoginTextbox.Text, PasswordTextbox.Password))
            {
                DataExchange.GetStaff(LoginTextbox.Text, PasswordTextbox.Password);
                this.Close();
                WorkWindow wnd = new WorkWindow();
                wnd.Show();
            }
            else
            {
                MessageBox.Show("Пользователя не существует.");
            }
        }

        private void RegBut_Click(object sender, RoutedEventArgs e)
        {
            Register wnd = new Register();
            wnd.Show();
        }


        private void LoginTextbox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var textBox = ((TextBox)sender);
            textBox.Dispatcher.BeginInvoke(new Action(() =>
            {
                textBox.SelectAll();
            }));
        }

        private void PasswordTextbox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var textBox = ((PasswordBox)sender);
            textBox.Dispatcher.BeginInvoke(new Action(() =>
            {
                textBox.SelectAll();
            }));
        }
    }

    public static class DataExchange
    {
        public static Staff ActiveUser;

        public static void GetStaff(string login, string password)
        {
            string result = "Такой задачи не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Staff s = new Staff();
                s = db.Staff.FirstOrDefault(s => s.Login == login && s.Password == password);
                ActiveUser = s;
            }

        }

    }
}
