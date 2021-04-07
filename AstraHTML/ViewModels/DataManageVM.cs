using AstraHTML.Data;
using AstraHTML.Infrastructure.Commands;
using AstraHTML.Models;
using AstraHTML.Views.OthWindows;
using AstraHTML.Views.Pages;
using AstraHTML.Views.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AstraHTML.Views
{
    class DataManageVM : INotifyPropertyChanged
    {
        #region GetData

        private List<Staff> allStaffs = DataWorker.GetAllStaffs();
        public List<Staff> AllStaffs
        {
            get { return allStaffs; }
            set {
                allStaffs = value;
                NotifyPropertyChanged("AllStaffs");
            }
        }

        private List<Tasks> allTasks = DataWorker.GetAllTasks();
        public List<Tasks> AllTasks
        {
            get { return allTasks; }
            set
            {
                allTasks = value;
                NotifyPropertyChanged("AllTasks");
            }
        }

        private List<Projects> allProjects = DataWorker.GetAllProjects();
        public List<Projects> AllProjects
        {
            get { return allProjects; }
            set
            {
                allProjects = value;
                NotifyPropertyChanged("AllProjects");
            }
        }

        #endregion

        #region Commands to Add


        #region Add Staff
        public string StaffName { get; set; }
        public string StaffSurname { get; set; }
        public string StaffSpeciality { get; set; }
        public string StaffPost { get; set; }
        public int StaffSalary { get; set; }
        public string StaffLogin { get; set; }
        public string StaffPassword { get; set; }

        private LambdaCommand addNewStaff;
        public LambdaCommand AddNewStaff
        {
            get
            {
                return addNewStaff ?? new LambdaCommand(obj =>
                {
                    Window wnd = new Window();
                    string resultStr = "";

                    if (StaffName == null || StaffName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "NameBlock");
                    }

                    if (StaffSurname == null || StaffSurname.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "SurnameBlock");
                    }

                    if (StaffSpeciality == null || StaffSpeciality.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "SpecialityBlock");
                    }

                    if (StaffPost == null || StaffPost.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "PostBlock");
                    }

                    if (StaffSalary == 0)
                    {
                        SetRedBlockControl(wnd, "SalaryBlock");
                    }

                    if (StaffLogin == null || StaffLogin.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "LoginBlock");
                    }

                    if (StaffPassword == null || StaffPassword.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "PasswordBlock");
                    }

                    else
                    {
                        resultStr = DataWorker.CreateStaff(StaffName, StaffSurname, StaffSpeciality, StaffPost, StaffSalary, StaffLogin, StaffPassword);
                        ShowMessageToUser(resultStr);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }

                    );
            }
        }

        #endregion

        #region Add Task

        public string TaskName { get; set; }
        public string TaskDescription { get; set; }

        public Staff TaskStaff { get; set; }
        public Projects TaskProject { get; set; }

        public string TaskPriority { get; set; }

        //Todo

        private LambdaCommand addNewTask;
        public LambdaCommand AddNewTask
        {
            get
            {
                return addNewTask ?? new LambdaCommand(obj =>
                {
                    Window wnd = new Window();
                    string resultStr = "";
                    if (TaskName == null || TaskName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "NameBlock");
                    }
                    if (TaskDescription == null || TaskName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "DescriptionBlock");
                    }
                    if (TaskProject == null)
                    {
                        MessageBox.Show("Вы не выбрали проект");
                    }
                    if (TaskStaff == null)
                    {
                        MessageBox.Show("Вы не выбрали разработчика");
                    }
                    if (TaskPriority == null)
                    {
                        MessageBox.Show("Вы не выбрали приоритет");
                    }
                    else
                    {
                        //Костыль
                        resultStr = DataWorker.CreateTask(TaskName, TaskDescription, TaskProject, TaskStaff, TaskPriority.Replace("System.Windows.Controls.ComboBoxItem: ", ""));
                        ShowMessageToUser(resultStr);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }

                    );
            }
        }

        #endregion

        #region Add Project

        public string ProjectTitle { get; set; }
        public string ProjectClient { get; set; }
        public string ProjectDescription { get; set; }

        private LambdaCommand addNewProject;
        public LambdaCommand AddNewProject
        {
            get
            {
                return addNewProject ?? new LambdaCommand(obj =>
                {
                    Window wnd = obj as Window;

                    string resultStr = "";

                    if(ProjectTitle == null || ProjectTitle.Replace(" ","").Length == 0)
                {
                        SetRedBlockControl(wnd, "TitleBlock");
                }
                    if (ProjectClient == null || ProjectClient.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "ClientBlock");
                    }
                    if (ProjectDescription == null || ProjectDescription.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControl(wnd, "DescriptionBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateProject(ProjectTitle, ProjectClient, ProjectDescription);
                        ShowMessageToUser(resultStr);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }

                    );
            }
        }

        #endregion

        #region Вспомогательные

        //Выделяет красным поля с неправильными введёнными данными
        private void SetRedBlockControl(Window window, string BlockName)
        {
            Control block = window.FindName(BlockName) as Control;
            block.BorderBrush = Brushes.Red;
        }

       
        private void ShowMessageToUser(string Message)
        {
            MessageView messageView = new MessageView(Message);
            SetCenterPositionAndOpen(messageView);
        }

        #region UpdatePositions

        private void UpdateAllDataView()
        {
           UpdateAllStaffs();
            UpdateAllTasks();
            UpdateAllProjects();
        }
        //не работает
        private void UpdateAllStaffs()
        {
            AllStaffs = DataWorker.GetAllStaffs();
            EditDataBasePage.AllStaffsView.ItemsSource = null;
            EditDataBasePage.AllStaffsView.Items.Clear();
            EditDataBasePage.AllStaffsView.ItemsSource = AllStaffs;
            EditDataBasePage.AllStaffsView.Items.Refresh();
        }

        private void UpdateAllTasks()
        {
            AllTasks = DataWorker.GetAllTasks();
            EditDataBasePage.AllTasksView.ItemsSource = null;
            EditDataBasePage.AllTasksView.Items.Clear();
            EditDataBasePage.AllTasksView.ItemsSource = allTasks;
            EditDataBasePage.AllTasksView.Items.Refresh();
        }

        private void UpdateAllProjects()
        {
            AllProjects = DataWorker.GetAllProjects();
            EditDataBasePage.AllProjectsView.ItemsSource = null;
            EditDataBasePage.AllProjectsView.Items.Clear();
            EditDataBasePage.AllProjectsView.ItemsSource = allProjects;
            EditDataBasePage.AllProjectsView.Items.Refresh();
        }

        private void SetNullValuesToProperties()
        {
            #region Staff
            StaffName = null;
            StaffSurname = null;
            StaffSpeciality = null;
            StaffPost = null;
            StaffSalary = 0;
            StaffLogin = null;
            StaffPassword = null;

            #endregion

            #region Task

            TaskName = null;
            TaskDescription = null;
            TaskProject = null;
            TaskStaff = null;
            TaskPriority = null;

            #endregion

            #region Project

            ProjectTitle = null;
            ProjectClient = null;
            ProjectDescription = null;

            #endregion
        }

        #endregion

        #endregion

        #endregion

        #region Commands to show windows

        #region Open Commands

        #region Open Staff Command

        private LambdaCommand openAddNewStaffWindow;

        public LambdaCommand OpenAddNewStaffWindow
        {
            get
            {
                return openAddNewStaffWindow ?? new LambdaCommand(obj =>
                {
                    OpenAddStaffWindowMethod();
                }
                    );
            }
        }

        #endregion

        #region Open Task Command
        private LambdaCommand openAddNewTaskWindow;

        public LambdaCommand OpenAddNewTaskWindow
        {
            get
            {
                return openAddNewTaskWindow ?? new LambdaCommand(obj =>
                {
                    OpenAddTaskWindowMethod();
                }
                    );
            }
        }

        #endregion

        #region Open Project Command

        private LambdaCommand openAddNewProjectWindow;

        public LambdaCommand OpenAddNewProjectWindow
        {
            get
            {
                return openAddNewProjectWindow ?? new LambdaCommand(obj =>
                {
                    OpenAddProjectWindowMethod();
                }
                    );
            }
        }

        #endregion

        #endregion

        #region Edit Commands

        #region Edit Tasks

        private LambdaCommand openEditNewTaskWindow;

        public LambdaCommand OpenEditNewTaskWindow
        {
            get
            {
                return openEditNewTaskWindow ?? new LambdaCommand(obj =>
                {
                    OpenEditTaskWindowMethod();
                }
                    );
            }
        }

        #endregion

        #region Project Edit

        private LambdaCommand openEditNewProjectWindow;

        public LambdaCommand OpenEditNewProjectWindow
        {
            get
            {
                return openEditNewProjectWindow ?? new LambdaCommand(obj =>
                {
                    OpenEditProjectWindowMethod();
                }
                    );
            }
        }

        #endregion

        #endregion

        #region Show Windows

        #region Methods

        #region Add
        //методы открытия окон
        private void OpenAddStaffWindowMethod()
         {
             AddNewStaffWindow newStaffWindow = new AddNewStaffWindow();
             SetCenterPositionAndOpen(newStaffWindow);
          }

        private void OpenAddTaskWindowMethod()
        {
            AddNewTaskWindow newTaskWindow = new AddNewTaskWindow();
            SetCenterPositionAndOpen(newTaskWindow);
        }

        private void OpenAddProjectWindowMethod()
        {
            AddNewProjectWindow newProjectWindow = new AddNewProjectWindow();
            SetCenterPositionAndOpen(newProjectWindow);
        }

        #endregion

        #region Edit

        private void OpenEditStaffWindowMethod()
        {
            EditStaffWindow editStaffWindow = new EditStaffWindow();
            SetCenterPositionAndOpen(editStaffWindow);
        }

        private void OpenEditTaskWindowMethod()
        {
            EditTaskWindow editTaskWindow = new EditTaskWindow();
            SetCenterPositionAndOpen(editTaskWindow);
        }

        private void OpenEditProjectWindowMethod()
        {
            EditProjectWindow editProjectWindow = new EditProjectWindow();
            SetCenterPositionAndOpen(editProjectWindow);
        }

        #endregion

        #region Вспомогательные
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion

        #endregion

        #endregion

        #endregion

        #region Служебные
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}
