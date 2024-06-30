using BE;
using BLL.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using UI.Models;
using UI.Models.ViewModels;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPeliculaService _peliculaService;

        public HomeController(IPeliculaService peliculaService)
        {
            _peliculaService = peliculaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            IQueryable<Pelicula> queryPeliculaSQL = await _peliculaService.ObtenerTodos();
        
            List<VMPelicula> lista = queryPeliculaSQL
                .Select(p => new VMPelicula()
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Fecha = p.Fecha.Value.ToString("dd/MM/yyyy")
                }).ToList();
            return StatusCode(StatusCodes.Status200OK,lista);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMPelicula modelo)
        {
            Pelicula NuevaPelicula = new Pelicula()
            {  
                Nombre = modelo.Nombre,
                Descripcion = modelo.Descripcion,
                Fecha = DateTime.ParseExact(modelo.Fecha, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-PE"))
            };
            bool respuesta = await _peliculaService.Insertar(NuevaPelicula);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpPut] 
        public async Task<IActionResult> Actualizar([FromBody] VMPelicula modelo)
        {
            Pelicula NuevaPelicula = new Pelicula()
            {
                Id = modelo.Id,
                Nombre = modelo.Nombre,
                Descripcion = modelo.Descripcion,
                Fecha = DateTime.ParseExact(modelo.Fecha, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-PE"))
            };
            bool respuesta = await _peliculaService.Actualizar(NuevaPelicula);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool respuesta = await _peliculaService.Eliminar(id);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
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