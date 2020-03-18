using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryController(IUnitOfWork unit)
        {
            this.unitOfWork = unit;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAll()
        {
            var all = await unitOfWork.Category.GetAll();
            return Json(new { data = all });
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Category category = new Category();

            if (id == null)
            {
                return View(category);
            }

            category = await unitOfWork.Category.Get(id.GetValueOrDefault());

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id==0)
                {
                    unitOfWork.Category.Add(category);
                }
                else
                {
                    unitOfWork.Category.Update(category);
                }
                
                unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                unitOfWork.Category.Delete(id.GetValueOrDefault());                
                unitOfWork.Save();
                return Json(new { success = true, message = "delete completed" });
            }


            return Json(new { success = false, message = "error deleting" });
        }
    }
}