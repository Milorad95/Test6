using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test6.Data;
using Test6.Models;

namespace Test6.Controllers
{
    public class StudentController : Controller
    {
        readonly DataContext _context;

        public StudentController(DataContext productContext)
        {
            _context = productContext;
        }

        // GET: StudentController
        public IActionResult Index([FromQuery] string filter)
        {
            IEnumerable<Student> studenti = _context.Studenti.Where(s => s.Aktivan == true).ToList();

            ViewData["filter"] = filter;

            if (string.IsNullOrEmpty(filter))
            {
                return View(studenti);
            }
            else
            {
                var st = _context.Studenti.Where(s => s.Ime.ToLower().Contains(filter.ToLower()) || s.Prezime.ToLower().Contains(filter.ToLower())).ToList();
                return View(st.Where(s => s.Aktivan == true));
            }
            //return View(_context.Studenti.Where(s => s.Aktivan == true).ToList());
        }


        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.Studenti.SingleOrDefault(s => s.StudentID == id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View("Edit", new Student());
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
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

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.Studenti.SingleOrDefault(s => s.StudentID == id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                if (student.StudentID == 0)
                {
                    _context.Studenti.Add(student);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Studenti.Add(student);
                    _context.Studenti.Update(student);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var st = _context.Studenti.SingleOrDefault(s => s.StudentID == id);
            if(st != null)
            {
                _context.Studenti.Remove(st);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: StudentController/Delete/5
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
