using CoreLogic.Data;
using CoreLogic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services;
    public class taskService
    {
        MyContext ctx=new MyContext();
        public IEnumerable<Model.Task> GetAllTasks()
        {
           var result = ctx.tasks.Include(c => c.Category).ToList();
           return result;  
        }

        public void createTask(Model.Task t)
        {
            if (t != null)
            {
                ctx.tasks.Add(t);
                ctx.SaveChanges();
            }
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

        public void updateTask(Model.Task updatedTask)
        {
        var existingTask = ctx.tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
        if (existingTask != null)
        {
            existingTask.taskName = updatedTask.taskName;
            existingTask.TaskDate = updatedTask.TaskDate;
            existingTask.CategoryId = updatedTask.CategoryId;
            ctx.SaveChanges();
        }
    }

        public Model.Task getTaskById(int id)
        {
            return ctx.tasks.FirstOrDefault(t => t.Id == id);
        }

        public void deleteTaskById(int id)
        {
            var taskToRemove = ctx.tasks.FirstOrDefault(Ta => Ta.Id == id);
            if (taskToRemove != null)
            {
                ctx.tasks.Remove(taskToRemove);
                ctx.SaveChanges();
            }
        }

    public List<Category> getAllCategories()
    {
        return ctx.categories.ToList();
    }
}
