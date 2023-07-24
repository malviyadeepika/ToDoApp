using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Model
{
    public class Category
    {
       public Category()
        {
           Tasks = new HashSet<Task>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        ICollection<Task> Tasks { get; set; }

    }
}
