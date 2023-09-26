using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { set; get;  }
        public string City { set; get; }
        [ForeignKey("Department")]
        public int DeptId {  set ; get; }   
        public Department Department { set; get;  }
    }
}
