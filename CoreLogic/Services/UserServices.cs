using CoreLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services;
    public class UserServices
    {
         
       public List<Users> GetAll()
    {
        var users = new List<Users>()
        {
            new Users() {Id=1,Name="Abuzar",City="Ranchi"},
            new Users() {Id=2,Name="Nikhat",City="Up"},
            new Users() {Id=3,Name="Sehaja",City="Ap"},
            new Users() {Id=2,Name="Deepika",City="Mp"}
        };
        return users;
    }
    }
