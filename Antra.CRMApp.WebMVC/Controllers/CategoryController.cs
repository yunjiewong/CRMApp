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
    public class CategoryController : Controller
    {
        private readonly ICategoryServiceAsync categoryServiceAsync;
        public CategoryController(ICategoryServiceAsync _cat)
        {
            categoryServiceAsync = _cat;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var model = await categoryServiceAsync.GetAllAsync();
            return View(model);
        }

  
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                await categoryServiceAsync.AddCatogoryAsync(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await categoryServiceAsync.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await categoryServiceAsync.GetByIdAsync(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryModel model)
        {
            ViewBag.IsEdit = false;
            if (ModelState.IsValid)
            {
                await categoryServiceAsync.UpdateAsync(model);
                ViewBag.IsEdit = true;

            }

            return View(model);
        }

        public async Task<IActionResult> List()
        {
            var  model = await categoryServiceAsync.GetAllAsync();
            return View(model);
        }

    }
}

