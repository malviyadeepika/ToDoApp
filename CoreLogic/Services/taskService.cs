using CoreLogic.Data;
using CoreLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services;
    public class TaskService
    {
        MyContext ctx=new MyContext();
        public List<Model.Task> GetAllTasks()
        {
            
           return ctx.tasks.ToList();
        }

        public void createTask(Model.Task t)
        {
            ctx.tasks.Add(t);
            ctx.SaveChanges();
        }

        public void deleteTask(Model.Task t)
        {
            var taskToRemove = ctx.tasks.FirstOrDefault(Ta => Ta.Id == t.Id);
            if (taskToRemove != null)
            {
                ctx.tasks.Remove(taskToRemove);
                ctx.SaveChanges();
            }
        }

        public void UpdateTask(Model.Task updatedTask)
        {
            var existingTask = ctx.tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
            if (existingTask != null)
            {
                existingTask.taskName = updatedTask.taskName;
                ctx.SaveChanges();
            }
        }
}
