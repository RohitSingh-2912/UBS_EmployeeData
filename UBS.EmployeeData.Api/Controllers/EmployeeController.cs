using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using UBS.EmployeeData.Abstraction;

namespace UBS.EmployeeData.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        public EmployeeController(EmployeeService employeeServices)
        {
            EmployeeService = employeeServices ?? throw new ArgumentNullException(nameof(employeeServices));
        }
        public EmployeeService EmployeeService { get; }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                
                
               return Ok(EmployeeService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getByName")]
        public ActionResult GetById([FromQuery] string Id)
        {
            try
            {
                var employees = EmployeeService.GetById(Id);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Employee> Insert([FromBody]Employee employee)
        {
            try
            {

                return Ok(EmployeeService.Insert(employee));

            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }

        }

        [HttpPut]
        public ActionResult Update([FromBody]Employee employee)
        {
            string id = employee.Id;
            EmployeeService.Update(id, employee);
            return Ok(employee);

        }

        [HttpDelete]
        public DeleteResult Delete([FromQuery]string id)
        {
            return EmployeeService.Delete(id);
        }
    }
}