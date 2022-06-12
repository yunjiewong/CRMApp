using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class ShipperController : Controller
    {
        private readonly IShipperServiceAsync serviceRepository;
        public ShipperController(IShipperServiceAsync _serviceRepository)
        {
            serviceRepository = _serviceRepository;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var model = await serviceRepository.GetAllAsync();
            return View(model);
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ShipperModel model)
        {
            if (ModelState.IsValid)
            {
                await serviceRepository.AddShipperAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var model = await serviceRepository.GetByIdAsync(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ShipperModel model)
        {
            ViewBag.IsEdit = false;
            if (ModelState.IsValid)
            {
                await serviceRepository.UpdateShipperAsync(model);
                ViewBag.IsEdit = true;

            }

            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await serviceRepository.DeleteShipperAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> List(int id)
        {
            var model = await serviceRepository.GetAllAsync();
            return View(model);
        }
    }
}

