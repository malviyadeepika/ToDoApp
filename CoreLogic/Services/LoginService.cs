using CoreLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services;
    public class LogService
    {
       List<Login> GetAllLogins()
    {
        var result=new List<Login>()
        {
            new Login(){},
        };
        return result;
    }
    
}
