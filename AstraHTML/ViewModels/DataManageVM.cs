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
using System.Windows.Input;
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
        public static string StaffName { get; set; }
        public static string StaffSurname { get; set; }
        public static string StaffSpeciality { get; set; }
        public static string StaffPost { get; set; }
        public static int StaffSalary { get; set; }
        public static string StaffLogin { get; set; }
        public static string StaffPassword { get; set; }

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
                        MessageView mes = new MessageView("Вы не задали имя.");
                        mes.Show();
                    }
                    else if (StaffSurname == null || StaffSurname.Replace(" ", "").Length == 0)
                    {
                        MessageView mes = new MessageView("Вы не задали фамилию.");
                        mes.Show();
                    }
                    else if (StaffSpeciality == null || StaffSpeciality.Replace(" ", "").Length == 0)
                    {
                        MessageView mes = new MessageView("Вы не задали специализацию.");
                        mes.Show();
                    }
                    else if (StaffPost == null || StaffPost.Replace(" ", "").Length == 0)
                    {
                        MessageView mes = new MessageView("Вы не задали должность.");
                        mes.Show();
                    }
                    else if (StaffSalary == 0)
                    {
                        MessageView mes = new MessageView("Вы не правильно указали зарплату.");
                        mes.Show();
                    }
                    else if (StaffLogin == null || StaffLogin.Replace(" ", "").Length == 0)
                    {
                        MessageView mes = new MessageView("Вы не задали логин.");
                        mes.Show();
                    }
                    else if (StaffPassword == null || StaffPassword.Replace(" ", "").Length == 0)
                    {
                        MessageView mes = new MessageView("Вы не задали пароль.");
                        mes.Show();
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

        public LambdaCommand AddNewStaffReg
        {
            get
            {
                return addNewStaff ?? new LambdaCommand(obj =>
                {
                    Window wnd = new Window();
                    string resultStr = "";

                    if (StaffName == null || StaffName.Replace(" ", "").Length == 0) 
                    {
                        MessageView mes = new MessageView("Вы не задали имя.");
                        mes.Show();
                    }
                   else if (StaffSurname == null || StaffSurname.Replace(" ", "").Length == 0) 
                    {
                        MessageView mes = new MessageView("Вы не задали фамилию.");
                        mes.Show();
                    }
                    else if (StaffSpeciality == null || StaffSpeciality.Replace(" ", "").Length == 0)
                    {
                        MessageView mes = new MessageView("Вы не задали специализацию.");
                        mes.Show();
                    }
                    else if (StaffPost == null || StaffPost.Replace(" ", "").Length == 0) 
                    {
                        MessageView mes = new MessageView("Вы не задали должность.");
                        mes.Show();
                    }
                   else if (StaffSalary == 0) {
                        MessageView mes = new MessageView("Вы не правильно указали зарплату.");
                        mes.Show();
                    }
                  else  if (StaffLogin == null || StaffLogin.Replace(" ", "").Length == 0) 
                    {
                        MessageView mes = new MessageView("Вы не задали логин.");
                        mes.Show();
                    }
                  else  if (StaffPassword == null || StaffPassword.Replace(" ", "").Length == 0) 
                    {
                        MessageView mes = new MessageView("Вы не задали пароль.");
                        mes.Show();
                    }
                    else
                    {
                        resultStr = DataWorker.CreateStaff(StaffName, StaffSurname, StaffSpeciality, StaffPost, StaffSalary, StaffLogin, StaffPassword);
                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }

                    );
            }
        }

        #endregion

        #region Add Task

        public static string TaskName { get; set; }
        public static string TaskDescription { get; set; }

        public static Staff TaskStaff { get; set; }
        public static Projects TaskProject { get; set; }

        public static string TaskPriority { get; set; }

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
                        MessageView mes = new MessageView("Вы не задали название.");
                        mes.Show();

                    }
                    else if (TaskDescription == null || TaskName.Replace(" ", "").Length == 0)
                    {
                        MessageView mes = new MessageView("Вы не задали описание.");
                        mes.Show();
                    }
                   else  if (TaskProject == null)
                    {
                        MessageView mes = new MessageView("Вы не указали проект.");
                        mes.Show();
                    }
                    else if (TaskStaff == null)
                    {
                        MessageView mes = new MessageView("Вы не указали разработчика.");
                        mes.Show();
                    }
                   else  if (TaskPriority == null)
                    {
                        MessageView mes = new MessageView("Вы не задали приоритетность.");
                        mes.Show();
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

        public static string ProjectTitle { get; set; }
        public static string ProjectClient { get; set; }
        public static string ProjectDescription { get; set; }

        private LambdaCommand addNewProject;
        public LambdaCommand AddNewProject
        {
            get
            {
                return addNewProject ?? new LambdaCommand(obj =>
                {
                    Window wnd = obj as Window;

                    string resultStr = "";

                         if (ProjectTitle == null || ProjectTitle.Replace(" ","").Length == 0)
                    {
                        MessageView mes = new MessageView("Вы не указали название проекта.");
                        mes.Show();
                    }
                    else if (ProjectClient == null || ProjectClient.Replace(" ", "").Length == 0)
                    {
                        MessageView mes = new MessageView("Вы не указали заказчика.");
                        mes.Show();
                    }
                    else if (ProjectDescription == null || ProjectDescription.Replace(" ", "").Length == 0)
                    {
                        MessageView mes = new MessageView("Вы не указали описание проекта.");
                        mes.Show();
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

        //Выделяет красным поля с неправильными введёнными данными.
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

        #region Свойства для выделенных элементов в ListView

        public TabItem SelectedTabItem { get; set; }

        public static Tasks SelectedTask { get; set; }

        public static Staff SelectedStaff { get; set; }

        public static Projects SelectedProject { get; set; }

        #endregion


        #region Delete

        private LambdaCommand deleteItem;
        public LambdaCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new LambdaCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";

                    //If Staff

                    if(SelectedTabItem.Name == "StaffTab" && SelectedStaff != null)
                    {
                        resultStr = DataWorker.DeleteStaff(SelectedStaff);
                        UpdateAllDataView();
                    }

                    

                    //If Task

                    if (SelectedTabItem.Name == "TaskTab" && SelectedTask != null)
                    {
                        resultStr = DataWorker.DeleteTask(SelectedTask);
                        UpdateAllDataView();
                    }

                    if (SelectedTabItem.Name == "UserTaskTab" && SelectedTask != null)
                    {
                        resultStr = DataWorker.DeleteTask(SelectedTask);
                    }

                    //If Project

                    if (SelectedTabItem.Name == "ProjectTab" && SelectedProject != null)
                    {
                        resultStr = DataWorker.DeleteProject(SelectedProject);
                        UpdateAllDataView();
                    }

                    

                    SetNullValuesToProperties();
                    ShowMessageToUser(resultStr);
                }
                );
            }
        }

        #endregion

        #region Commands to show windows

        #region Open Commands

        private LambdaCommand openEditItem;
        public LambdaCommand OpenEditItem
        {
            get
            {
                return openEditItem ?? new LambdaCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";

                    //If Staff

                    if (SelectedTabItem.Name == "StaffTab" && SelectedStaff != null)
                    {
                        OpenEditStaffWindowMethod(SelectedStaff);
                    }


                    //If Task

                    if (SelectedTabItem.Name == "TaskTab" && SelectedTask != null)
                    {
                        OpenEditTaskWindowMethod(SelectedTask);
                    }

                    //If Project

                    if (SelectedTabItem.Name == "ProjectTab" && SelectedProject != null)
                    {
                        OpenEditProjectWindowMethod(SelectedProject);
                    }

                });
            }
        }


        #region Edit

        private LambdaCommand editStaff;
        public LambdaCommand EditStaff
        {
            get
            {
                return editStaff ?? new LambdaCommand(obj =>
                {

                Window wnd = new Window();
                string resultStr = "";

                if (StaffName == null || StaffName.Replace(" ", "").Length == 0)
                {
                    MessageView mes = new MessageView("У сотрудника всегда должно быть имя.");
                    mes.Show();
                }
                else if (StaffSurname == null || StaffSurname.Replace(" ", "").Length == 0)
                {
                    MessageView mes = new MessageView("У сотрудника всегда должна быть фамилия.");
                    mes.Show();
                }
                else if (StaffSpeciality == null || StaffSpeciality.Replace(" ", "").Length == 0)
                {
                    MessageView mes = new MessageView("У сотрудника всегда должна быть специализация.");
                    mes.Show();
                }
                else if (StaffPost == null || StaffPost.Replace(" ", "").Length == 0)
                {
                    MessageView mes = new MessageView("У содрудника должна быть должность.");
                    mes.Show();
                }
                else if (StaffSalary == 0)
                {
                    MessageView mes = new MessageView("Вы не правильно указали зарплату.");
                    mes.Show();
                }
                else if (StaffLogin == null || StaffLogin.Replace(" ", "").Length == 0)
                {
                        if (StaffLogin == "Admin" || StaffLogin.Replace(" ", "") == "Admin" )
                        {
                            MessageView mes = new MessageView("В системе может быть только один администратор.");
                            mes.Show();
                        }
                        else
                        {
                            MessageView mes = new MessageView("Вы не задали логин.");
                            mes.Show();
                        }
                }
                else if (StaffPassword == null || StaffPassword.Replace(" ", "").Length == 0)
                {
                    MessageView mes = new MessageView("Вы не задали пароль.");
                    mes.Show();
                }
                else
                {       
                        resultStr = DataWorker.EditStaff(SelectedStaff, StaffName, StaffSurname, StaffSpeciality, StaffPost, StaffSalary, StaffLogin, StaffPassword);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        ShowMessageToUser(resultStr);
                        wnd.Close();
                }

                });
            }
        }


        private LambdaCommand editTask;
        public LambdaCommand EditTask
        {
            get
            {
                return editStaff ?? new LambdaCommand(obj =>
                {

                    Window wnd = new Window();
                    string resultStr = "";
                    if (TaskName == null || TaskName.Replace(" ", "").Length == 0)
                    {
                        MessageView mes = new MessageView("Поле названия таска не может быть пустым.");
                        mes.Show();

                    }
                    else if (TaskDescription == null || TaskName.Replace(" ", "").Length == 0)
                    {
                        MessageView mes = new MessageView("Поле описания не принято оставлять пустым.");
                        mes.Show();
                    }
                    else if (TaskProject == null)
                    {
                        MessageView mes = new MessageView("Задача без проекта не может существовать.");
                        mes.Show();
                    }
                    else if (TaskStaff == null)
                    {
                        MessageView mes = new MessageView("Вы не назначили сотрудника на таск.");
                        mes.Show();
                    }
                    else if (TaskPriority == null)
                    {
                        MessageView mes = new MessageView("У задачи всегда должен быть приоритет.");
                        mes.Show();
                    }
                    else
                    {
                        resultStr = DataWorker.EditTask(SelectedTask, TaskName, TaskDescription, TaskProject, TaskStaff, TaskPriority);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        ShowMessageToUser(resultStr);
                        wnd.Close();
                    }

                });
            }
        }

        private LambdaCommand editProject;
        public LambdaCommand EditProject
        {
            get
            {
                return editProject ?? new LambdaCommand(obj =>
                {
                    Window wnd = obj as Window;

                    string resultStr = "";

                    if (ProjectTitle == null || ProjectTitle.Replace(" ", "").Length == 0)
                    {
                        MessageView mes = new MessageView("Поле названия проекта не может быть пустым.");
                        mes.Show();
                    }
                    else if (ProjectClient == null || ProjectClient.Replace(" ", "").Length == 0)
                    {
                        MessageView mes = new MessageView("Поле заказчика не может быть пустым.");
                        mes.Show();
                    }
                    else if (ProjectDescription == null || ProjectDescription.Replace(" ", "").Length == 0)
                    {
                        MessageView mes = new MessageView("Этичнее не оставлять поле описания пустым.");
                        mes.Show();
                    }
                    else
                    {
                        resultStr = DataWorker.EditProject(SelectedProject, ProjectTitle, ProjectClient, ProjectDescription);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        ShowMessageToUser(resultStr);
                        wnd.Close();
                    }

                });
            }
        }

        #endregion

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

        public void OpenEditStaffWindowMethod(Staff staff)
        {
            EditStaffWindow editStaffWindow = new EditStaffWindow(staff);
            SetCenterPositionAndOpen(editStaffWindow);
        }

        private void OpenEditTaskWindowMethod(Tasks task)
        {
            EditTaskWindow editTaskWindow = new EditTaskWindow(task);
            SetCenterPositionAndOpen(editTaskWindow);
        }

        private void OpenEditProjectWindowMethod(Projects project)
        {
            EditProjectWindow editProjectWindow = new EditProjectWindow(project);
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
