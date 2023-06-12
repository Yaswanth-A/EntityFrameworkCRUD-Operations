
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Practice.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly APIDbContext _context;

        public EmployeesController(APIDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Employee> CreateEmployee(EmployeeReq EmployeeCreateReq)
        {
            var employee = new Employee()
            {
                //EmployeeId = Guid.NewGuid(),
                EmployeeName = EmployeeCreateReq.EmployeeName,
                Age = EmployeeCreateReq.Age,
                Salary = EmployeeCreateReq.Salary,
                DepartmentId = EmployeeCreateReq.DepartmentId,
                Department = _context.Departments.Find(EmployeeCreateReq.DepartmentId)
            };
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmployeeId }, employee);
        }

        

        [HttpGet("department/departmentId")]
        public ActionResult<IQueryable<Employee>> GetEmployeesByDepartment(int departmentId)
        {
            //var employees = _context.Employees.Where(e => e.EmployeeDepartmentId == departmentId);

            //if (!employees.Any())
            //    return NotFound();

            //return employees;
            var departmentEmployees = _context.Employees.Where(e => e.DepartmentId == departmentId);
            if (!departmentEmployees.Any())
                return NotFound("Department not found");

            return Ok(departmentEmployees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
                return NotFound("Employee not found");

            return Ok(employee.EmployeeName);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, EmployeeReq updatedEmployee)
        {
            var employee = _context.Employees.Find(id);
            if(employee == null)
            {
                return NotFound("Employee not found");
            }

            //_context.Entry(updatedEmployee).State = EntityState.Modified;
            employee.EmployeeName = updatedEmployee.EmployeeName;
            employee.Age = updatedEmployee.Age;
            employee.Salary = updatedEmployee.Salary;
            employee.DepartmentId = updatedEmployee.DepartmentId;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
                return NotFound("Employee not found");

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return Ok();
        }

       
    }
}
