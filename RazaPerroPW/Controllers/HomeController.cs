using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazaPerroPW.Models.entities;
using RazaPerroPW.Models.misentitades;
using RazaPerroPW.Models.viewmodels;

namespace RazaPerroPW.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index(string letra)
        {
            PerrosContext context = new();
            IndexViewModel vm = new();
            if(letra == null) 
            {
            var dato = context.Razas.Select(x => 
            new Perros 
            {
                Id = (int)x.Id,
                Nombre = x.Nombre ?? " " 
            }).OrderBy(x => x.Nombre).ToList();
            vm.perro = dato;    
            return View(vm);

            }
            else 
            {
                var dato = context.Razas.Where(x=> x.Nombre.Substring(0,1) == letra).Select(x =>
            new Perros
            {
                Id = (int)x.Id,
                Nombre = x.Nombre ?? " "
            }).OrderBy(x => x.Nombre).ToList();
                vm.perro = dato;
                return View(vm);

            }

        }
        [Route("/razas/{nombre}")] 
        public IActionResult Razas(string nombre) 
        {

            PerrosContext context = new(); 
            List<Perro> perros = new();
            List<int> ListaNPerros = context.Razas.Select(x=> (int)x.Id).ToList(); 
            Random Prandom = new();
            for (int i = 0; i <= 3; i++)
            {
                int num = Prandom.Next(0 ,ListaNPerros.Count());
                Perro perro = context.Razas.Where(x => x.Id == ListaNPerros[num])
                    .Select(x => new Perro
                    { IdRaza = ListaNPerros[num],
                    Nombre = x.Nombre }).First();
               perros.Add(perro);
            }
            
            nombre = nombre.Replace("_", " ");
            var datoraza = context.Razas.Include(x => x.Caracteristicasfisicas).Where(x => x.Nombre == nombre).Select(x => 
            new RazaViewModel 
            {
                Nombre0 = x.Nombre,
                Nombre2 = x.OtrosNombres ?? " ",
                AlturaMax = x.AlturaMax,
                AlturaMin = x.AlturaMin,
                PesoMax = x.PesoMax,
                PesoMin = x.PesoMin,
                Descripcion = x.Descripcion,
                Hosico = x.Caracteristicasfisicas.Hocico ?? " ",
                Patas = x.Caracteristicasfisicas.Patas ?? " ",
                Cola = x.Caracteristicasfisicas.Cola ?? " ",
                Color = x.Caracteristicasfisicas.Color ?? " ",
                EsperanzaVida = (int)x.EsperanzaVida,
                Pelo = x.Caracteristicasfisicas.Pelo ?? " ",
                Pais = x.IdPaisNavigation.Nombre ?? " ",
                Id = (int)x.Id,
                AmistadDes =(int) x.Estadisticasraza.AmistadDesconocidos,
                AmistadPerros = (int)x.Estadisticasraza.AmistadPerros,
                Cepillado = (int)x.Estadisticasraza.NecesidadCepillado,
                Ejercicio = (int) x.Estadisticasraza.EjercicioObligatorio,
                NEnergia = (int) x.Estadisticasraza.NivelEnergia,
                Felicidad = (int) x.Estadisticasraza.FacilidadEntrenamiento
                
                
            }).First();
            datoraza.Perros = perros;

            return View(datoraza);
        }

        [Route ("/pais")]
        public IActionResult Pais() 
        {
            PerrosContext context = new();
            PaisViewModel vm = new();
            var datopais = context.Paises.Select(x => 
            new Pais 
            { 
                IdRaza= x.Id,
                NombrePais = x.Nombre ?? " ",
                perros = x.Razas.Select(x => 
                new Perro 
                { Nombre = x.Nombre,
                IdRaza = (int)x.Id
                }) ,
            }).OrderBy(x => x.NombrePais).ToList();
            vm.pais = datopais;
            return View(vm);
        }
    }
}
