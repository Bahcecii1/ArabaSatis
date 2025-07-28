using ArabaSatis.Data;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ArabaSatis.Controllers
{
    public class ResimController : Controller
    {
        private readonly ArabamDbContext? _context;

        public ResimController()
        {
        }

        public ResimController(ArabamDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            var veri = await _context.ArabaResims.ToListAsync();
            return View();
        }

        // GET: ResimController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ResimController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResimController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ResimController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ResimController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ResimController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ResimController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
