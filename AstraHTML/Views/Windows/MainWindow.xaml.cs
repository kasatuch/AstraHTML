using AstraHTML.Data;
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
            if(e.LeftButton == MouseButtonState.Pressed)
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
                this.Close();
                WorkWindow wnd = new WorkWindow();
                wnd.Show();
            }
        }

        private void RegBut_Click(object sender, RoutedEventArgs e)
        {
            Register wnd = new Register();
            wnd.Show();
        }
    }
}
