using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Antra.CRMApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
 
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServiceAsync employeeServiceAsync;

        public EmployeeController(IEmployeeServiceAsync _employeeServiceAsync)
        {
            employeeServiceAsync = _employeeServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await employeeServiceAsync.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await employeeServiceAsync.GetByIdAsync(id);
            if (result == null)
                return NotFound($"Employee With ID = {id} is not available");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EmployeeRequestModel model)
        {
            var result = await employeeServiceAsync.AddEmployeeAsync(model);
            if (result > 0)
            {
                var response = new { msg = model };
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EmployeeRequestModel model)
        {
            var result = await employeeServiceAsync.UpdateEmployeeAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await employeeServiceAsync.DeleteEmployeeAsync(id);
            if (result > 0)
                return Ok("Region Delete Successfully!");
            return BadRequest();
        }
    }
    /*

     public class EmployeeController : Controller
     {
         [HttpGet]
         //https://localhost:portnumber/api/employee
         public IActionResult Get()
         {
             string result = "WElcome";
             return Ok(result);
         }

         [HttpGet]
         [Route("{id:int}/{age:int}")]
         public IActionResult Get(int id, int age)
         {
             string result = "WElcome back " + id+ " age "+age;
             return Ok(result);
         }
         [HttpGet]
         [Route("{name}")]
         public IActionResult Get(string name)
         {
             string result = "WElcome back " + name;
             return Ok(result);
         }


         [HttpGet]
         [Route("city/{city}")]
         //https://localhost:portnumber/api/employee/city/chicago
         public IActionResult GetByCity(string city)
         {
             string result = "WElcome back " + city;
             return Ok(result);
         }

         [HttpPost]
         //https://localhost:portnumber/api/employee
         public IActionResult Post(Employee emp)
         {
             string result = "Employee has been inserted";
             return Ok(result);
         }
    }
    */


}

