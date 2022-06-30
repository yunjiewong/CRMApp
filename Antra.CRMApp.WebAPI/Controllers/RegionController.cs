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
    [Authorize]
    public class RegionController : Controller
    {
        private readonly IRegionServiceAsync regionServiceAsync;
        public RegionController(IRegionServiceAsync regionServiceAsync)
        {
            this.regionServiceAsync = regionServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //throw new NotImplementedException("This method is not Implemented! ");
            //throw new Exception("custom exception");
            return Ok(await regionServiceAsync.GetAllAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await regionServiceAsync.GetByIdAsync(id);
            if (result == null)
                return NotFound($"Region With ID = {id} is not available");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegionModel model)
        {
            var result = await regionServiceAsync.AddRegionAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RegionModel model)
        {
            int result = await regionServiceAsync.UpdateRegionAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await regionServiceAsync.DeleteRegionAsync(id);
            if (result > 0)
            {
                var response = new { Message = "Region Delete Successfully!" };
                return Ok(response);
            }
                
            return BadRequest();
        }


    }
}

