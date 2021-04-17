using System.Collections.Generic;
using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class ExpenseTypeController : Controller
    {

        private readonly ApplicationDbContext _db;

        // DI for expense type
        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;
        }


        // constructor that uses the _db

        public IActionResult Index()
        {


            IEnumerable<ExpenseType> objList = _db.ExpenseTypes;

            return View(objList);
           
        }

        public IActionResult Create()
        {

            return View();
        }

        // post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseType obj)
        {

            // validation checker
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        // get delete (displays the item in the delete view )
     
        public IActionResult Delete(int? id)
        {

            // validation checker
            if (id == null || id == 0 )
            {
                return NotFound();

            }

            // finds each expense type from the ID

            var obj = _db.ExpenseTypes.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }



        // post delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost (int? id)
        {
            // finds each expense type from the ID
            var obj = _db.ExpenseTypes.Find(id);
            if (obj == null)
            {
                return NotFound();

            }
            _db.ExpenseTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


        // get Update 
        public IActionResult Update(int? id)
        {


            if (id == null || id == 0)
            {
                return NotFound();

            }

            var obj = _db.ExpenseTypes.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }


        // Post update
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public IActionResult Update(ExpenseType obj)
        {

            // validation checker
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }


    }
}
