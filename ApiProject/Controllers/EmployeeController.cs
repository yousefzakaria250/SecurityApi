using ApiProject.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    { 
        private readonly ITIContext context;
        public EmployeeController(ITIContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult EmployeeWithDept(int id)
        {
            var emp = context.Employee.Include(d=>d.Department).FirstOrDefault(f=> f.DeptId == id);
            EmployeeWithDept emps = new EmployeeWithDept()
            {
                Id = id,
                EmpName = emp.Name,
                DeptName = emp.Department.Name
            };

            return Ok(emps);
        }
    }
}
