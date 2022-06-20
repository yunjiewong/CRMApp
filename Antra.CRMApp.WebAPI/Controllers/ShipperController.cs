using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Antra.CRMApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ShipperController : Controller
    {
        private readonly IShipperServiceAsync serviceAsync;
        public ShipperController(IShipperServiceAsync serviceAsync)
        {
            this.serviceAsync = serviceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await serviceAsync.GetAllAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await serviceAsync.GetByIdAsync(id);
            if (result == null)
                return NotFound($"Region With ID = {id} is not available");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ShipperModel model)
        {
            var result = await serviceAsync.AddShipperAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(ShipperModel model)
        {
            var result = await serviceAsync.UpdateShipperAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await serviceAsync.DeleteShipperAsync(id);
            if (result > 0)
                return Ok("Region Delete Successfully!");
            return BadRequest();
        }

    }
}

