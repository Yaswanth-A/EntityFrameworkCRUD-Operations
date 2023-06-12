
using Microsoft.AspNetCore.Mvc;
using WebAPI_Practice.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly APIDbContext _context;

        public DepartmentsController(APIDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Department> CreateDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return Ok(department);
            //return CreatedAtAction(nameof(GetDepartmentById), new { id = department.DepartmentID }, department);
        }

        //[HttpGet("{id}")]
        //public ActionResult<Department> GetDepartmentById(int id)
        //{
        //    var department = _context.Departments.Find(id);

        //    if (department == null)
        //        return NotFound();

        //    return department;
        //}
    }
}
