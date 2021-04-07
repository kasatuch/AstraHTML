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
    /// Логика взаимодействия для AddNewProjectWindow.xaml
    /// </summary>
    public partial class AddNewProjectWindow : Window
    {
        public AddNewProjectWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}
