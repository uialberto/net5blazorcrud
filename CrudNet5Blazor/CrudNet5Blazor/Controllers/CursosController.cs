using CrudNet5Blazor.DataAccess;
using CrudNet5Blazor.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNet5Blazor.Controllers
{
    public class CursosController : Controller
    {
        private readonly AppContextDb _context;

        public CursosController(AppContextDb context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Curso> list = _context.Cursos;
            return View(list);
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

            return View();
        }
        public IActionResult Editar(int? id)
        {
            var curso = _context.Cursos.Find(id);
            if (curso == null)
                return NotFound();
            return View(curso);
        }

        [HttpPost]
        public IActionResult Editar(Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Cursos.Update(curso);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

            return View();
        }

        public IActionResult Borrar(int? id)
        {
            var curso = _context.Cursos.Find(id);
            if (curso == null)
                return NotFound();

            _context.Cursos.Remove(curso);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
