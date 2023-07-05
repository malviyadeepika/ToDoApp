using CoreLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services;
    public class LoginService
    {
       List<Log> GetAllLogins()
    {
        var result=new List<Log>()
        {
<<<<<<< Updated upstream:CoreLogic/Services/LogService.cs
            new Log(){},
=======
            new Login(){username="Abuzar",password="Zar0907"},
>>>>>>> Stashed changes:CoreLogic/Services/LoginService.cs
        };
        return result;
    }
    
}
