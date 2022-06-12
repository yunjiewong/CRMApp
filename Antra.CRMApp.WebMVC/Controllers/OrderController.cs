using System;
using Microsoft.AspNetCore.Mvc;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductServiceAsync productServiceAsync;
        private readonly IOrderServiceAsync orderServiceAsync;

        public OrderController(IProductServiceAsync _productServiceAsync, IOrderServiceAsync _orderServiceAsync)
        {
            productServiceAsync = _productServiceAsync;
            orderServiceAsync = _orderServiceAsync;
        }

        public async Task<IActionResult> Index()
        {
            var empCollection = await orderServiceAsync.GetAllAsync();
            if (empCollection != null)
                return View(empCollection);

            List<OrderResponseModel> model = new List<OrderResponseModel>();
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var collection = await productServiceAsync.GetAllAsync();
            ViewBag.Product = new SelectList(collection, "Id", "Name") ;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await orderServiceAsync.AddOrderAsync(model);
                return RedirectToAction("Index");
            }
            var collection = await productServiceAsync.GetAllAsync();
            ViewBag.Product = new SelectList(collection, "Id", "Name");
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await orderServiceAsync.DeleteOrderAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> List()
        {
            var model = await orderServiceAsync.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var empModel = await orderServiceAsync.GetOrderForEditAsync(id);
            var collection = await productServiceAsync.GetAllAsync();
            ViewBag.Product = new SelectList(collection, "Id", "Name");
            return View(empModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(OrderRequestModel model)
        {
            ViewBag.IsEdit = false;
            var collection = await productServiceAsync.GetAllAsync();
            ViewBag.Product = new SelectList(collection, "Id", "Name");
            if (ModelState.IsValid)
            {
                await orderServiceAsync.UpdateOrderAsync(model);
                ViewBag.IsEdit = true;

            }

            return View(model);
        }

    }
}

