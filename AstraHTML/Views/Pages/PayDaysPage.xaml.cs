using AstraHTML.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AstraHTML.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для PayDaysPage.xaml
    /// </summary>
    public partial class PayDaysPage : Page
    {
        public PayDaysPage()
        {
            int taxValue = 13;
            InitializeComponent();
            DataContext = new DataManageVM();
            StaffCountBlock.Text = getStaffCount().ToString();
            MoneyBlock.Content = getAllMoneyStaffCount().ToString();
            HighMoneyBlock.Text = getAllHighMoneyStaffCount().ToString();
            MoneyStaffName.Text = getAllHighMoneyStringStaffCount().ToString();
            AllMoneyTaxBlock.Text = (getAllMoneyStaffCount() - ((getAllMoneyStaffCount() / 100) * taxValue)).ToString();
        }

        public int getStaffCount()
        {
            List<Staff> list = DataWorker.GetAllStaffs();
            int count = list.Count;
            return count;
        }

        public int getAllMoneyStaffCount()
        {
            List<Staff> list = DataWorker.GetAllStaffs();
            int sum = 0;
            for(int i = 0; i < list.Count; i++)
            {
                sum += list[i].Salary;
            }
            return sum;
        }
        public int getAllHighMoneyStaffCount()
        {
            List<Staff> list = DataWorker.GetAllStaffs();
            int max = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for(int b = 0; b<list[i].Salary; b++)
                {
                    if(list[i].Salary > max)
                    {
                        max = list[i].Salary;
                    }
                }
            }
            return max;
        }

        public string getAllHighMoneyStringStaffCount()
        {
            List<Staff> list = DataWorker.GetAllStaffs();
            int max = 0;
            string name = "";
            for (int i = 0; i < list.Count; i++)
            {
                for (int b = 0; b < list[i].Salary; b++)
                {
                    if (list[i].Salary > max)
                    {
                        max = list[i].Salary;
                        name = list[i].FullNameStaff;
                    }
                }
            }
            return name;
        }
    }
}
