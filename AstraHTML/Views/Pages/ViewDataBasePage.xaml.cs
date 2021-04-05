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
        ApplicationContext db = new ApplicationContext();
        public ViewDataBasePage()
        {
            InitializeComponent();
            List<Tasks> TasksTable = db.Tasks.ToList();
            TaskTable.ItemsSource = TasksTable;
        }
    }
}
