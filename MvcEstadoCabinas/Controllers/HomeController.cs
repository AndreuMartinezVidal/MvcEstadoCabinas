using MvcPlanificacionCabinas.Data;
using MvcPlanificacionCabinas.Models;
using System;
using System.Collections.Generic;
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
        public async Task<ActionResult> Index(int days = 3, string sortOrder = "", string currentSort = "")
        {
            ViewBag.CurrentSort = GetCurrentSort(sortOrder, currentSort);

            var max_date = DateTime.Today.AddDays(days);

            var planificaciones = GetPlanificacionesDL(max_date);

            var result = await SortEntitiesByColumnName(planificaciones).ToListAsync();

            return View(result);
        }

        private string GetCurrentSort(string sortOrder, string currentSort)
        {
            if (!string.IsNullOrWhiteSpace(sortOrder) && currentSort == sortOrder)
            {
                sortOrder = sortOrder.EndsWith("_desc") ? sortOrder.Replace("_desc", "") : sortOrder + "_desc";
            }
            else if (sortOrder == "")
            {
                sortOrder = "prioridad";
            }

            return sortOrder;
        }

        private IQueryable<PlanificacionCabinasViewModel> GetPlanificacionesDL(DateTime max_date)
        {
            var planificaciones = from p in db.Planificaciones
                                      //LEFT JOIN:
                                  join e in db.PlanificacionEstados//.Include(i=>i.PlanificacionEstadoTipo)
                                    on p.Order_cod equals e.Order_cod into gje
                                  from estado in gje.DefaultIfEmpty()
                                      //LEFT JOIN:
                                  join t in db.PlanificacionEstadoTipos
                                    on estado.PlanificacionEstadoTipoId equals t.PlanificacionEstadoTipoId into gjt
                                  from tipo in gjt.DefaultIfEmpty()
                                      //
                                  where estado != null
                                  || DbFunctions.TruncateTime(p.fecha_inicio_Programada) <= DbFunctions.TruncateTime(max_date)
                                  //
                                  select new PlanificacionCabinasViewModel
                                  {
                                      Prioridad = estado.Prioridad,
                                      Tubo = p.Tubo,
                                      recurso = p.recurso,
                                      des_subseccion = p.des_subseccion,
                                      Order_cod = p.Order_cod,
                                      material_cod = p.material_cod,
                                      descart = p.descart,
                                      Lote = p.Lote,
                                      fecha_inicio_Programada = p.fecha_inicio_Programada,
                                      PlanificacionEstadoId = estado.PlanificacionEstadoId,
                                      Estado = tipo.Description,
                                      UsuarioModificacion = estado.UsuarioModificacion,
                                      FechaModificacion = estado.FechaModificacion,
                                  };
            return planificaciones;
        }

        IQueryable<PlanificacionCabinasViewModel> SortEntitiesByColumnName(IQueryable<PlanificacionCabinasViewModel> entities)
        {
            string sortOrder = ViewBag.CurrentSort;
            if (sortOrder.EndsWith("_desc"))
                switch (sortOrder.Replace("_desc", ""))
                {
                    case nameof(PlanificacionCabinasViewModel.Prioridad): return entities.OrderByDescending(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.Tubo): return entities.OrderByDescending(e => e.Tubo).ThenBy(e => e.Prioridad).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.recurso): return entities.OrderByDescending(e => e.recurso).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.des_subseccion): return entities.OrderByDescending(e => e.des_subseccion).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.Order_cod): return entities.OrderByDescending(e => e.Order_cod).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.material_cod): return entities.OrderByDescending(e => e.material_cod).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.descart): return entities.OrderByDescending(e => e.descart).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.Lote): return entities.OrderByDescending(e => e.Lote).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.fecha_inicio_Programada): return entities.OrderByDescending(e => e.fecha_inicio_Programada).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.Estado): return entities.OrderByDescending(e => e.Estado).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.UsuarioModificacion): return entities.OrderByDescending(e => e.UsuarioModificacion).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.FechaModificacion): return entities.OrderByDescending(e => e.FechaModificacion).ThenBy(e => e.Prioridad);
                    default: return entities;
                }
            else
                switch (sortOrder)
                {
                    case nameof(PlanificacionCabinasViewModel.Prioridad): return entities.OrderBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.Tubo): return entities.OrderBy(e => e.Tubo).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.recurso): return entities.OrderBy(e => e.recurso).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.des_subseccion): return entities.OrderBy(e => e.des_subseccion).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.Order_cod): return entities.OrderBy(e => e.Order_cod).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.material_cod): return entities.OrderBy(e => e.material_cod).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.descart): return entities.OrderBy(e => e.descart).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.Lote): return entities.OrderBy(e => e.Lote).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.fecha_inicio_Programada): return entities.OrderBy(e => e.fecha_inicio_Programada).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.Estado): return entities.OrderBy(e => e.Estado).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.UsuarioModificacion): return entities.OrderBy(e => e.UsuarioModificacion).ThenBy(e => e.Prioridad);
                    case nameof(PlanificacionCabinasViewModel.FechaModificacion): return entities.OrderBy(e => e.FechaModificacion).ThenBy(e => e.Prioridad);
                    default: return entities;
                };
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