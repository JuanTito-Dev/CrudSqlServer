using CrudSqlServer.Data;
using CrudSqlServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudSqlServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext Datos;

        public HomeController(ILogger<HomeController> logger, AppDbContext Datos)
        {
            _logger = logger;
            this.Datos = Datos;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await Datos.Registros.ToListAsync();
            return View(list);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost, ActionName("CrearRegistro")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Registro registro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Datos.Registros.Add(registro);
                    await Datos.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al guardar el registro: " + ex.Message);
                    return View("Crear", registro);
                }
            }

            return View("Crear", registro);
        }

        [HttpGet]
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var registro = await Datos.Registros.FindAsync(id);
            if (registro is null)
            {
                return NotFound();
            }
            return View(registro);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var registro = await Datos.Registros.FindAsync(id);
            if (registro is null)
            {
                return NotFound();
            }
            return View(registro);
        }

        [HttpPost, ActionName("EditarRegistro")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Registro registro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Datos.Registros.Update(registro);
                    await Datos.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error al guardar el registro: " + ex.Message);
                    return View("Editar", registro);
                }

            }
            return View("Editar", registro);
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var registro = await Datos.Registros.FindAsync(id);
            if (registro is null)
            {
                return NotFound();
            }
            return View(registro);
        }

        [HttpPost, ActionName("EliminarRegistro")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if ( id is null)
            {
                return NotFound();
            }
            var registro = await Datos.Registros.FindAsync(id);
            if (registro is null)
            {
                return NotFound();
            }
            Datos.Registros.Remove(registro);
            await Datos.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
