using AstraHTML.Data;
using AstraHTML.Infrastructure.Commands;
using AstraHTML.Models;
using AstraHTML.Views.OthWindows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

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
