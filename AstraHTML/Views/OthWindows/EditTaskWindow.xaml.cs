using AstraHTML.Models;
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
using System.Windows.Shapes;

namespace AstraHTML.Views.OthWindows
{
    /// <summary>
    /// Логика взаимодействия для EditTaskWindow.xaml
    /// </summary>
    public partial class EditTaskWindow : Window
    {
        public EditTaskWindow(Tasks taskToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            DataManageVM.SelectedTask = taskToEdit;
            DataManageVM.TaskName = taskToEdit.Name;
            DataManageVM.TaskDescription = taskToEdit.Description;
            DataManageVM.TaskPriority = taskToEdit.Priority;
        }
    }
}
