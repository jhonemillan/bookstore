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
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CoverTypeController(IUnitOfWork unit)
        {
            this.unitOfWork = unit;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAll()
        {
            var all = await unitOfWork.CoverType.GetAll();
            return Json(new { data = all });
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            CoverType ct = new CoverType();

            if (id == null)
            {
                return View(ct);
            }

            ct = await unitOfWork.CoverType.Get(id.GetValueOrDefault());

            if (ct == null)
            {
                return NotFound();
            }

            return View(ct);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType ct)
        {
            if (ModelState.IsValid)
            {
                if (ct.Id==0)
                {
                    unitOfWork.CoverType.Add(ct);
                }
                else
                {
                    unitOfWork.CoverType.Update(ct);
                }
                
                unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(ct);
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                unitOfWork.CoverType.Delete(id.GetValueOrDefault());                
                unitOfWork.Save();
                return Json(new { success = true, message = "delete completed" });
            }


            return Json(new { success = false, message = "error deleting" });
        }
    }
}