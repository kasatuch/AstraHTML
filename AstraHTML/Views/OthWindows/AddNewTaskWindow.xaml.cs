﻿using System;
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
    /// Логика взаимодействия для AddNewTaskWindow.xaml
    /// </summary>
    public partial class AddNewTaskWindow : Window
    {
        public AddNewTaskWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
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
