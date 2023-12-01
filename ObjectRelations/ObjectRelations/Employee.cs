using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectRelations
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public string Email { get; set; }

        public Department dept {  get; set; }

        public List<Address> AddressList { get; set; } = new List<Address>();
    }
}
