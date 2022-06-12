using Microsoft.AspNetCore.Mvc;
using Antra.CRMApp.WebMVC.Models;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Antra.CRMApp.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServiceAsync productServiceAsync;
        private readonly ICategoryServiceAsync categoryServiceAsync;
        public ProductController(IProductServiceAsync _productServiceAsync, ICategoryServiceAsync _categoryServiceAsync)
        {

            productServiceAsync = _productServiceAsync;
            categoryServiceAsync = _categoryServiceAsync;
        }

        public async Task<IActionResult> Index()
        {
            var empCollection = await productServiceAsync.GetAllAsync();
            if (empCollection != null)
                return View(empCollection);

            List<ProductResponseModel> model = new List<ProductResponseModel>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var collection = await categoryServiceAsync.GetAllAsync();
            ViewBag.Category = new SelectList(collection, "Id","Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await productServiceAsync.AddProductAsync(model);
                return RedirectToAction("Index");
            }
            var collection = await categoryServiceAsync.GetAllAsync();
            ViewBag.Category = new SelectList(collection, "Id","Name");
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await productServiceAsync.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var empModel = await productServiceAsync.GetProductForEditAsync(id);
            var collection = await categoryServiceAsync.GetAllAsync();
            ViewBag.Category = new SelectList(collection, "Id", "Name");
            return View(empModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductRequestModel model)
        {
            ViewBag.IsEdit = false;
            var collection = await categoryServiceAsync.GetAllAsync();
            ViewBag.Category = new SelectList(collection, "Id", "Name");
            if (ModelState.IsValid)
            {
                await productServiceAsync.UpdateProductAsync(model);
                ViewBag.IsEdit = true;

            }

            return View(model);
        }


        public async Task<IActionResult> List()
        {
            var model = await productServiceAsync.GetAllAsync();
            return View(model);
        }
    }
}
