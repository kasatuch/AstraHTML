using AstraHTML.Data;
using AstraHTML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AstraHTML.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewDataBasePage.xaml
    /// </summary>
    public partial class ViewDataBasePage : Page
    {
        public static ListView AllTasksView;


        public ViewDataBasePage()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            List<Tasks> task = new List<Tasks>();
            task = DataWorker.GetAllTasks();
            List<Tasks> newTasks = new List<Tasks>();
            newTasks = task.FindAll(t => t.Staffid == DataExchange.ActiveUser.id);
            ViewAllTasks.ItemsSource = newTasks;
        }

        private void MenuItemRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<Tasks> task = new List<Tasks>();
            task = DataWorker.GetAllTasks();
            List<Tasks> newTasks = new List<Tasks>();
            newTasks = task.FindAll(t => t.Staffid == DataExchange.ActiveUser.id);
            ViewAllTasks.ItemsSource = newTasks;
        }
    }
}
