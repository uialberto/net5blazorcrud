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
            }

            return View();
        }
    }
}
