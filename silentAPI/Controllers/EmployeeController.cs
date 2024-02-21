using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using silentAPI.Models;

namespace silentAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        AppDbContext _db;
        public EmployeeController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _db.Employees.ToList();
            return Ok(employees);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Please enter correct Employee id");

            Employee emp = _db.Employees.Find(id);
            if (emp != null)
            {
                return Ok(emp);
            }

            return NotFound($"{id} Employee does not exist");
        }


        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Employees.Add(employee);
                    _db.SaveChanges();

                    return Created("Create" , employee);
                }
                catch (Exception ex)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError , ex.Message);
                }

            }
            return BadRequest("Please Check Input Data");
            
        }

        [HttpPut]
        public IActionResult Update(int id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest("Please correct Category Id");

            if (ModelState.IsValid)
            {
                try
                {
                 
                    _db.Employees.Update(employee);
                    _db.SaveChanges();

                    return Ok(employee);
                }
                catch (Exception ex)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }

            }
            return BadRequest("Please Check Input Data");

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Please enter correct Employee Id");

                try
                {
                   Employee emp =  _db.Employees.Find(id);
                    _db.Employees.Remove(emp);
                    _db.SaveChanges();

                    return Ok(emp);
                }
                catch (Exception ex)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }

            return BadRequest("Please Check Input Data");

        }

    }
}
