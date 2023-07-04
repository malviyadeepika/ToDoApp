using CoreLogic.Data;
using CoreLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services;
    public class UserServices
    {
    MyContext ctx;
       public List<Users> GetAll()
    {
        ctx= new MyContext();
        var result=ctx.users.ToList();
        return result;
        
    }
    }
