using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Contract.Service;
using Microsoft.AspNetCore.Mvc;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRegionServiceAsync regionServiceAsync;
        private readonly ICustomerServiceAsync customerServiceAsync;
        public CustomerController(ICustomerServiceAsync _customerServiceAsync, IRegionServiceAsync _regionServiceAsync)
        {
            regionServiceAsync = _regionServiceAsync;
            customerServiceAsync = _customerServiceAsync;
        }

        public async Task<IActionResult> Index()
        {
            var empCollection = await customerServiceAsync.GetAllAsync();
            if (empCollection != null)
                return View(empCollection);

            List<CustomerResponseModel> model = new List<CustomerResponseModel>();
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await customerServiceAsync.AddCustomerAsync(model);
                return RedirectToAction("Index");
            }
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await customerServiceAsync.DeleteCustomerAsync(id);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> List()
        {
            var model = await customerServiceAsync.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var empModel = await customerServiceAsync.GetCustomerForEditAsync(id);
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Region = new SelectList(collection, "Id", "Name");
            return View(empModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CustomerRequestModel model)
        {
            ViewBag.IsEdit = false;
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Region = new SelectList(collection, "Id", "Name");

            if (ModelState.IsValid)
            {
                await customerServiceAsync.UpdateCustomersync(model);
                ViewBag.IsEdit = true;

            }

            return View(model);
        }

    }
}

