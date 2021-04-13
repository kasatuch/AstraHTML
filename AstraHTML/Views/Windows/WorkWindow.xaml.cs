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
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Controls.Primitives;
using AstraHTML.Views.Pages;
using AstraHTML.Views.OthWindows;

namespace AstraHTML.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        public WorkWindow()
        {
            InitializeComponent();
            ActiveUserText.Text = DataExchange.ActiveUser.Login;
            UserSpeciality.Text = DataExchange.ActiveUser.Speciality;
            
            if(DataExchange.ActiveUser.Login == "Admin")
            {
                MainFrame.NavigationService.Navigate(new EditDataBasePage());
                EmployeeDBBut.Visibility = Visibility.Collapsed;
                Home.Visibility = Visibility.Collapsed;
                
            }
            else
            {
                MainFrame.NavigationService.Navigate(new ViewDataBasePage());
                PayDays.Visibility = Visibility.Collapsed;
                EditDBBut.Visibility = Visibility.Collapsed;
            }

        }

        #region Интерактивное взаимодействие с формой

        #region Боковая панель

        #region Кнопка View DataBase
        private void Home_MouseEnter(object sender, MouseEventArgs e)
        {
            #region Вызов Popups и передача параметров
            popup_uc.PlacementTarget = Home;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopupText.Text = "View DataBase";
            #endregion
        }

        private void Home_MouseLeave(object sender, MouseEventArgs e)
        {
            #region Скрытие Popups
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
            #endregion
        }

        #endregion

        #region Кнопка EditDBBut
        private void EditDBBut_MouseEnter(object sender, MouseEventArgs e)
        {
            #region Вызов Popups и передача параметров
            popup_uc.PlacementTarget = EditDBBut;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopupText.Text = "Edit DataBase";
            #endregion
        }

        private void EditDBBut_MouseLeave(object sender, MouseEventArgs e)
        {
            #region Скрытие Popups
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
            #endregion
        }
        #endregion

        #region Кнопка PayDays
        private void Settings_MouseEnter(object sender, MouseEventArgs e)
        {
            #region Вызов Popups и передача параметров
            popup_uc.PlacementTarget = PayDays;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopupText.Text = "PayDays";
            #endregion
        }

        private void Settings_MouseLeave(object sender, MouseEventArgs e)
        {
            #region Скрытие Popups
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
            #endregion
        }
        #endregion

        #region Кнопка EditDBBut
        private void EmployeeDBBut_MouseEnter(object sender, MouseEventArgs e)
        {
            #region Вызов Popups и передача параметров
            popup_uc.PlacementTarget = EmployeeDBBut;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopupText.Text = "Edit User";
            #endregion
        }

        private void EmployeeDBBut_MouseLeave(object sender, MouseEventArgs e)
        {
            #region Скрытие Popups
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
            #endregion
        }
        #endregion

        #endregion

        #region Служебные

        #region Возможность перетаскивания окна мышью
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        #endregion

        #region Закрытие программы

        private void ExitBut_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #endregion

        #endregion

        #endregion

        private void ViewDB_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new ViewDataBasePage());
        }

        private void EditDB_Click(object sender, RoutedEventArgs e)
        {
            if(DataExchange.ActiveUser.Login == "Admin")
            {
                MainFrame.NavigationService.Navigate(new EditDataBasePage());
            }
            else
            {
                MessageBox.Show("Вы не обладаете достаточными правами.");
            }
        }

        private void EmployeeDBBut_Click(object sender, RoutedEventArgs e)
        {
            if (DataExchange.ActiveUser.Login != "Admin")
            {
                MainFrame.NavigationService.Navigate(new EmployeeDataBasePage());
            }
            else
            {
                MessageBox.Show("Администратор не может редактировать самого себя.");
            }
        }

        private void PayDays_Click(object sender, RoutedEventArgs e)
        {
            if (DataExchange.ActiveUser.Login == "Admin")
            {
                MainFrame.NavigationService.Navigate(new PayDaysPage());
            }
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            DataExchange.ActiveUser = null;
            this.Close();
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
