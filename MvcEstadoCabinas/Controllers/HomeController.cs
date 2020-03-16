using MvcPlanificacionCabinas.Data;
using MvcPlanificacionCabinas.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcEstadoCabinas.Controllers
{
    public class HomeController : Controller
    {
        private PlanificacionCabinasContext db = new PlanificacionCabinasContext();

        // GET: PlanificacionCabinas
        public async Task<ActionResult> Index(int days = 3, string sortOrder = "prioridad")
        {
            var max_date = DateTime.Today.AddDays(days);
            var planificaciones = from p in db.Planificaciones
                                  join e in db.PlanificacionEstados on p.Order_cod equals e.Order_cod into gj
                                  from estado in gj.DefaultIfEmpty()
                                  where estado != null
                                  || DbFunctions.TruncateTime(p.fecha_inicio_Programada) <= DbFunctions.TruncateTime(max_date)
                                  select new PlanificacionCabinasViewModel
                                  {
                                      //Prioridad = estado == null?null:estado.Prioridad,
                                      Tubo = p.Tubo,
                                      recurso = p.recurso,
                                      des_subseccion = p.des_subseccion,
                                      Order_cod = p.Order_cod,
                                      material_cod = p.material_cod,
                                      descart = p.descart,
                                      Lote = p.Lote,
                                      fecha_inicio_Programada = p.fecha_inicio_Programada,
                                      //PlanificacionEstadoId = estado == null ? null : estado.PlanificacionEstadoId as int?,
                                      //PlanificacionEstadoTipoId = estado == null ? null : estado.PlanificacionEstadoTipoId as PlanificacionEstadoTipoEnum?,
                                  };

            return View(planificaciones.ToList());
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}