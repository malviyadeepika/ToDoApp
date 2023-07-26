using CoreLogic.Data;
using CoreLogic.Model;
using CoreLogic.Services;

namespace CoreTest;

public class userServiceTest
{
    private MyContext ctx;

    [SetUp]
    public void SetUp()
    {
        this.ctx = new MyContext();
    }

    [Test]
    public void GetUserByNameReturnsName()
    {
        var u = new User { Name = "UserTest2", Email = "ut2@gmail.com", Password = "ut12345" };
        ctx.users.Add(u);
        ctx.SaveChanges();

        var userService = new userService();
        var user = userService.getUserByName("UserTest2");
        u.Id = user.Id;

        Assert.NotNull(user);
        Assert.AreEqual(u.Name, user.Name);
        Assert.AreEqual(u.Email, user.Email);
        Assert.AreEqual(u.Password, user.Password);
    }

    [Test]
    public void CreateUserCreatesUser()
    {
        var userService = new userService();
        var user = new User { Name = "UserTest3", Email = "ut3@gmail.com", Password = "ut12345" };
        userService.createUser(user);


        var newUser = ctx.users.FirstOrDefault(u => u.Name == "UserTest3");
        user.Id = newUser.Id;

        Assert.NotNull(newUser);
        Assert.AreEqual(user.Name, newUser.Name);
        Assert.AreEqual(user.Email, newUser.Email);
        Assert.AreEqual(user.Password, newUser.Password);

    }

    [Test]
    public void UpdateUserUpdatesUser()
    {
        var u = new User { Name = "UserTest4", Email = "ut4@gmail.com", Password = "ut12345" };
        ctx.users.Add(u);
        ctx.SaveChanges();

        u.Name = "UpdatedName";
        u.Email = "utt2@gmail.com";

        var userService = new userService();
        userService.updateUser(u);

        var updatedUser = ctx.users.FirstOrDefault(u => u.Name == "UpdatedName");
        u.Id = updatedUser.Id;

        Assert.NotNull(updatedUser);
        /* Assert.AreEqual(u, updatedUser);*/
        Assert.AreEqual(u.Name, updatedUser.Name);
        Assert.AreEqual(u.Email, updatedUser.Email);
        Assert.AreEqual(u.Password, updatedUser.Password);

    }

    [Test]
    public void DeleteUserDeletesUser()
    {
        var u = new User { Name = "UserTest5", Email = "ut5@gmail.com", Password = "ut12345" };
        ctx.users.Add(u);
        ctx.SaveChanges();

        var user = ctx.users.FirstOrDefault(c => c.Name == "UserTest5");
        int id = user.Id;
        var userService = new userService();
        userService.deleteUser(id);

        var deletedUser = ctx.users.FirstOrDefault(c => c.Name == "UserTest5");
        Assert.Null(deletedUser);

    }

}
