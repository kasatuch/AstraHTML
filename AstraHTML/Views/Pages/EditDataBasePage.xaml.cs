using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для EditDataBasePage.xaml
    /// </summary>
    public partial class EditDataBasePage : Page
    {
        public static ListView AllStaffsView;
        public static ListView AllTasksView;
        public static ListView AllProjectsView;
        public EditDataBasePage()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            AllStaffsView = ViewAllStaffs;
            AllTasksView = ViewAllTasks;
            AllProjectsView = ViewAllProjects;
        }

    }
}
