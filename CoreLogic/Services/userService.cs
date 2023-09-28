using CoreLogic.Data;
using CoreLogic.Model;
using Microsoft.EntityFrameworkCore;
namespace CoreLogic.Services;

public class userService
{
    MyContext ctx;
    public userService() { 
        ctx = new MyContext();
    }

    public void createUser(User u)
    {
        ctx.users.Add(u);
        ctx.SaveChanges();
    }

    public void deleteUser(int uId)
    {
        var userToRemove = ctx.users.FirstOrDefault(u => u.Id == uId);
        if (userToRemove != null)
        {
            throw new ArgumentException("User not found", nameof(uId));
        }
        ctx.users.Remove(userToRemove);
        ctx.SaveChanges();
    }

    public void updateUser(User updatedUser)
    {
        ctx.users.Attach(updatedUser);
        ctx.Entry(updatedUser).State = EntityState.Modified;
        ctx.SaveChanges();
    }

    public User getUserById(int id)
    {
        return ctx.users.Include(t=>t.Tasks).ThenInclude(t => t.Category).FirstOrDefault(u => u.Id == id);
    }

    public User getUserByName(string name)
    {
        return ctx.users.Include(t => t.Tasks).ThenInclude(t => t.Category).FirstOrDefault(u => u.Name == name);
    }
}


