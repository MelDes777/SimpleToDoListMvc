using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleTodoMvc.Infrustructure;
using SimpleTodoMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTodoMvc.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext _context;

        public ToDoController(ToDoContext context)
        {
            _context = context;
        }

        // GET /
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IQueryable<ToDoList> items = from i in _context.ToDoList
                                         orderby i.Id
                                         select i;


            List<ToDoList> todoList = await items.ToListAsync();

            return View(todoList);

        }

        // GET /todo/create
        [HttpGet]
        public IActionResult Create() => View();

        // Post /todo/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ToDoList item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The item has been added!";

                return RedirectToAction("Index");

            }

            return View(item);

        }

        // GET /todo/edit/{id}
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            ToDoList item = await _context.ToDoList.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);

        }

        // Post /todo/edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ToDoList item)
        {
            if (ModelState.IsValid)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The item has been updated!";

                return RedirectToAction("Index");

            }

            return View(item);

        }

        // GET /todo/delete/{id}
        public async Task<ActionResult> Delete(int id)
        {
            ToDoList item = await _context.ToDoList.FindAsync(id);

            if (item == null)
            {
                TempData["Error"] = "The item does not exist!";
            }
            else
            {
                _context.ToDoList.Remove(item);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The item has been deleted!";
            }

            return RedirectToAction("Index");

        }
    }
}
