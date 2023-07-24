using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Model;
    public class Task
    { 
        public int ? Id { get; set; }
        public string? taskName { get; set;}

        public string ?Description { get; set;}
        public int ?UserId { get; set; }
        public User ?User { get; set; }

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
}
