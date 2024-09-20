using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Person
    {
        public int id { get; set; }
        public String First_name { get; set; }
        public String Last_name { get; set; }
        public String Email { get; set; }
        public String Addres { get; set; }
        public String TypeDocument { get; set; }
        public int Document { get; set; }
        public DateTime Birth_of_date { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public int Phone { get; set; }
        public bool State { get; set; }
    }
}
