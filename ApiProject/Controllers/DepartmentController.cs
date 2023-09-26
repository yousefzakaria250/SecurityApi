using ApiProject.Models;
using ApiProject.Repositories;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDeptRepo deptRepo;

        public DepartmentController(IDeptRepo deptRepo)
        {
            this.deptRepo = deptRepo;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            IEnumerable<Department> departments = deptRepo.GetAll();
            return Ok(departments);
        }

        [HttpGet("{id}")]
      // [Route("/{id :int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var department = deptRepo.GetById(id);
            return Ok(department);
        }

        [HttpGet("{name:alpha}")]
        //[Route("{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            var department = deptRepo.GetByName(name);
            return Ok(department);
        }

        [HttpPost("AddDepartment")]
        public IActionResult Add(Department department)
        {
            if(ModelState.IsValid)
            {
                var res = deptRepo.Add(department);
                return Ok(res);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var res = deptRepo.Delete(id);
            return StatusCode(200, res);
        }
    }
}
