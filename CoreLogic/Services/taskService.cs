using CoreLogic.Data;
using CoreLogic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services;
public class taskService
{
    MyContext ctx;
    public taskService()
    {
        ctx = new MyContext();
    }
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
    public void updateTask(Model.Task updatedTask)
    {
        ctx.tasks.Attach(updatedTask);
        ctx.Entry(updatedTask).State = EntityState.Modified;
        ctx.SaveChanges();
    }

    public Model.Task getTaskById(int id)
    {
        return ctx.tasks.Include(c=>c.Category).Single(t => t.Id == id);
    }

    public void deleteTask(int tId)
    {
        var taskToRemove = ctx.tasks.Find(tId);
        if (taskToRemove == null)
        {
            throw new ArgumentException("Task not found", nameof(tId));
        }
        ctx.tasks.Remove(taskToRemove);
        ctx.SaveChanges();
    }

    public List<Category> getAllCategories()
    {
        return ctx.categories.ToList();
    }
}
