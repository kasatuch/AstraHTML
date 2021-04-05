using AstraHTML.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AstraHTML.Data
{
    static class DataWorker
    {
        public static string CreateStaff(string login)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //Проверка на существование сотрудника
                bool checkIsIxist = db.Staff.Any(el => el.Login == login);
                if (!checkIsIxist)
                {
                    Staff newStaff = new Staff { Login = login };
                    db.Staff.Add(newStaff);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        public static string CreateTask(string name)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //Проверка на существование сотрудника
                bool checkIsIxist = db.Tasks.Any(el => el.Name == name);
                if (!checkIsIxist)
                {
                    Tasks newTask = new Tasks { Name = name };
                    db.Tasks.Add(newTask);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
        public static string CreateProject(string name)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //Проверка на существование сотрудника
                bool checkIsIxist = db.Tasks.Any(el => el.Name == name);
                if (!checkIsIxist)
                {
                    Tasks newTask = new Tasks { Name = name };
                    db.Tasks.Add(newTask);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }
    }
}
