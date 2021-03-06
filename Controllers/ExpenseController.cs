using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenseTracker.Controllers
{
    public class ExpenseController : Controller
    {

        private readonly ApplicationDbContext _db;

        // adds a DB context with dependency injection
        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }


        // allows for expense type to linked with expense for create abd update
       
        public IActionResult Index()
        {

            // uses the dependency injection to set the obj list for use with expenses in the view
            // passes the data to the view using this
            IEnumerable<Expense> objList = _db.Expenses;

            // expense type lambda is used for the drop down or null ref will come up

            foreach (var obj in objList)
            {
                obj.ExpenseType = _db.ExpenseTypes.FirstOrDefault(u => u.Id == obj.ExpenseTypeId);
            }

            return View(objList);
           
        }

        public IActionResult Create()
        {

            // expense type lambda is used for the drop down 

            IEnumerable<SelectListItem> TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            ViewBag.TypeDropDown = TypeDropDown;

            return View();
        }

        // post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense obj)
        {

            // valdation check 
            if (ModelState.IsValid)
            {
                // obj.ExpenseTypeId = 1;
                _db.Expenses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        // get delete (displays the item in the delete view )
     
        public IActionResult Delete(int? id)
        {

            
            if (id == null || id == 0 )
            {
                return NotFound();

            }

            var obj = _db.Expenses.Find(id);

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

            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();

            }
            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


        // get Update 
        public IActionResult Update(int? id)
        {
            IEnumerable<SelectListItem> TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            ViewBag.TypeDropDown = TypeDropDown;

            if (id == null || id == 0)
            {
                return NotFound();

            }

            var obj = _db.Expenses.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }


        // Post update
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public IActionResult Update(Expense obj)
        {


            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }


    }
}
