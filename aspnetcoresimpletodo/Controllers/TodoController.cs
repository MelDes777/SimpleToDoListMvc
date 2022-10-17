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
            IQueryable<ToDo> items = from i in _context.ToDoes
                                         orderby i.Id
                                         select i;


            List<ToDo> todoList = await items.ToListAsync();

            return View(todoList);

        }

        // GET /todo/create
        [HttpGet]
        public IActionResult Create() => View();

        // Post /todo/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ToDo item)
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
            ToDo item = await _context.ToDoes.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);

        }

        // Post /todo/edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ToDo item)
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
            ToDo item = await _context.ToDoes.FindAsync(id);

            if (item == null)
            {
                TempData["Error"] = "The item does not exist!";
            }
            else
            {
                _context.ToDoes.Remove(item);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The item has been deleted!";
            }

            return RedirectToAction("Index");

        }
    }
}
