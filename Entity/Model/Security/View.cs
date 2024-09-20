using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class View
    {
        public int id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool State { get; set; }

        //Relacion entre tablas
        public String ModuleId { get; set; }
        public Module IdModule { get; set; }
    }
}
