using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test6.Data;
using Test6.Models;

namespace Test6.Controllers
{
    public class SmerController : Controller
    {
        readonly DataContext _context;

        public SmerController(DataContext context)
        {
            _context = context;
        }
        // GET: SmerController
        public ActionResult Index()
        {
            return View(_context.Smerovi.ToList());
        }

        // GET: SmerController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.Smerovi.SingleOrDefault(s => s.SmerID == id));
        }

        // GET: SmerController/Create
        public ActionResult Create()
        {
            return View("Edit", new Smer());
        }

        // POST: SmerController/Create
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

        // GET: SmerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.Smerovi.SingleOrDefault(p => p.SmerID == id));
        }

        // POST: SmerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Smer smer)
        {
            if(smer.SmerID < 1)
            {
                _context.Smerovi.Add(smer);
                _context.SaveChanges();
            }
            else
            {
                _context.Smerovi.Add(smer);
                _context.Smerovi.Update(smer);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: SmerController/Delete/5
        public ActionResult Delete(int id)
        {
            var cat = _context.Smerovi.SingleOrDefault(p => p.SmerID == id);
            if (cat != null)
            {
                _context.Smerovi.Remove(cat);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // POST: SmerController/Delete/5
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
