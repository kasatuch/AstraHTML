using AstraHTML.Models;
using System.Collections.Generic;
using System.Linq;

namespace AstraHTML.Data
{
    static class DataWorker
    {

        #region Create
        public static string CreateStaff(string name, string surname, string speciality, string post, int salary, string login, string password)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //Проверка на существование сотрудника
                bool checkIsIxist = db.Staff.Any(el => el.Name == name && el.Surname == surname);
                if (!checkIsIxist)
                {
                    Staff newStaff = new Staff { Name = name, Surname = surname, Speciality = speciality, Post = post, Salary = salary, Login = login, Password = password};
                    db.Staff.Add(newStaff);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        public static string CreateTask(string name, string description, Projects project, Staff staff, string priority)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsIxist = db.Tasks.Any(el => el.Name == name && el.Project == project);
                if (!checkIsIxist)
                {
                    Tasks newTask = new Tasks { Name = name, Description = description, Projectid = project.id, Staffid = staff.id, Priority = priority};
                    db.Tasks.Add(newTask);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        public static string CreateProject(string title, string client, string description)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsIxist = db.Projects.Any(el => el.Title == title && el.Client == client);
                if (!checkIsIxist)
                {
                    Projects newProject = new Projects { Title = title, Client = client, Description = description };
                    db.Projects.Add(newProject);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        #endregion

        #region Delete
        public static string DeleteStaff(Staff staff)
        {
            string result = "Такого сотрудника не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Staff.Remove(staff);
                db.SaveChanges();
                result = "Сделано! Сотрудник " + staff.Name + " " + staff.Surname + " удалён";
            }
            return result;
        }

        public static string DeleteTask(Tasks tasks)
        {
            string result = "Такой задачи не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Tasks.Remove(tasks);
                db.SaveChanges();
                result = "Сделано! Задача " + tasks.Name + " удалена";
            }
            return result;
        }
        public static string DeleteProject(Projects project)
        {
            string result = "Такого проекта не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Projects.Remove(project);
                db.SaveChanges();
                result = "Сделано! Проект " + project.Title + " заказчика " + project.Client + " удалён";
            }
            return result;
        }
        #endregion

        #region Edit

        public static string EditStaff(Staff oldStaff, string newName, string newSurname, string newSpeciality, string newPost, int newSalary, string newLogin, string newPassword)
        {
            string result = "Такого сотрудника не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Staff staff = db.Staff.FirstOrDefault(s => s.id == oldStaff.id);
                if (staff != null)
                {
                    staff.Name = newName;
                    staff.Surname = newSurname;
                    staff.Speciality = newSpeciality;
                    staff.Post = newPost;
                    staff.Salary = newSalary;
                    staff.Login = newLogin;
                    staff.Password = newPassword;
                    db.SaveChanges();
                    result = "Сделано! Сотрудник " + staff.Name + " " + staff.Surname + " изменён";
                }
            }
            return result;
        }

        public static string EditTask(Tasks oldTask, string newName, string newDescription, Projects newProject, Staff newStaff, string newPriority)
        {
            string result = "Такой задачи не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Tasks task = db.Tasks.FirstOrDefault(s => s.id == oldTask.id);
                if (task != null)
                {
                    task.Name = newName;
                    task.Description = newDescription;
                    task.Projectid = newProject.id;
                    task.Staffid = newStaff.id;
                    task.Priority = newPriority;
                    db.SaveChanges();
                    result = "Сделано! Задача " + task.Name + " изменёна";
                }
            }
            return result;
        }

        public static string EditProject(Projects oldProject, string newTitle, string newClient, string newDescription)
        {
            string result = "Такой задачи не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Projects project = db.Projects.FirstOrDefault(s => s.id == oldProject.id);
                if (project != null)
                {
                    project.Title = newTitle;
                    project.Client = newClient;
                    project.Description = newDescription;

                    db.SaveChanges();
                    result = "Сделано! Проект " + project.Title + " заказчика " + project.Client + " изменён";
                }
            }
            return result;
        }


        #endregion

        #region GetAll

        public static List<Staff> GetAllStaffs()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                var result = db.Staff.ToList();
                return result;
            }
        }

        public static List<Tasks> GetAllTasks()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Tasks.ToList();
                return result;
            }
        }

        public static List<Projects> GetAllProjects()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Projects.ToList();
                return result;
            }
        }

        #endregion

        #region Get Data For View

        //Получение Title проекта, по id.

        public static Projects GetProjectTitleByid(int id)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                Projects pro = db.Projects.FirstOrDefault(p => p.id == id);
                return pro;
            }
        }

        //Конкатенация Ф.И. для их вывода в одном Item в Combobox
        public static string GetFullNameStaff(string name, string surname)
        {
            return name + " " + surname;
        }

        #endregion
    }
}
