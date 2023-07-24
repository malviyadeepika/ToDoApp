using CoreLogic.Data;
using CoreLogic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services;
    public class userService
    {
        MyContext ctx;
        User u;
        taskService ts=new taskService();
        
        public userService() { 
            ctx = new MyContext();
            u= new User();
        }
        public List<Model.User> GetAllUsers()
        { 
            return ctx.users.Include(t=>t.Tasks).ToList();
        }

        public void createUser(User u)
        {
            ctx.users.Add(u);
            ctx.SaveChanges();
        }

        public void deleteUser(User u)
        {
            var userToRemove = ctx.users.FirstOrDefault(Ta => Ta.Id == u.Id);
            if (userToRemove != null)
            {
                ctx.users.Remove(userToRemove);
                ctx.SaveChanges();
            }
        }

        public void UpdateUser(User updatedUser)
        {
            var existingUser = ctx.users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (existingUser != null)
            {
                existingUser.Name = updatedUser.Name;
                ctx.SaveChanges();
            }
        }

        public User getUserById(int id)
        {
             return ctx.users.Include(t=>t.Tasks).FirstOrDefault(u => u.Id == id);
        }

        public User getUserByName(string name)
        {
            return ctx.users.Include(t => t.Tasks).FirstOrDefault(u => u.Name == name);
       
        }
        
        public User getUserBySearch(string search,string name)
    {
        if(string.IsNullOrEmpty(search))
        {
            return ctx.users.Include(t => t.Tasks).FirstOrDefault(u => u.Name == name);
        }
        var result = ctx.tasks.ToList();
        var searchelement = result.Where(t => t.taskName.Contains(search)); 
        u.Tasks = searchelement;
        return ctx.users.Include(t => t.Tasks).FirstOrDefault(u => u.Name == name);
    }
}


