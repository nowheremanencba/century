using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Infraestructure.Persistance.PostgresSQL.Repositories
{
    public class InspeccionRepository : BaseRepository<Inspeccion>, IInspeccionRepository
    {
        public InspeccionEstado AddInspeccionEstado(InspeccionEstado inspeccionEstado)
        { 
            db.Set<InspeccionEstado>().Add(inspeccionEstado);
            return inspeccionEstado;
        }
        public InspeccionEstado GetInspeccionEstadoById(Guid idInspeccionEstado, Guid IdInspeccion)
        {
            var inspeccionEstado = db.InspeccionEstado
                                   .Where(ic => ic.InspeccionId == IdInspeccion && ic.Id==idInspeccionEstado)
                                   .FirstOrDefault();
            return inspeccionEstado;
        } 
        
        public void UpdateInspeccionEstado(InspeccionEstado inspeccionEstado)
        {
            db.Set<InspeccionEstado>().Update(inspeccionEstado);
        }
        public Inspeccion_ItemControl_Valores AddInspeccionItemControlValores(Inspeccion_ItemControl_Valores inspeccionItemControlValores)
        {
            db.Set<Inspeccion_ItemControl_Valores>().Add(inspeccionItemControlValores);
            return inspeccionItemControlValores;
        }
        public Inspeccion_ItemControl_Valores GetInspeccionItemControlValoresById(Guid inspeccionId, int itemControlId)
        {
            Inspeccion_ItemControl_Valores inspeccionICV = (from ins in db.InspeccionItemControlValores
                                                            where ins.ItemControlId==itemControlId && ins.InspeccionId ==inspeccionId
                                                            select ins
                                                          ).FirstOrDefault();
            return inspeccionICV; 
        }
        public List<Inspeccion_ItemControl_Valores> GetInspeccionItemControlValoresByIdInspeccion(Guid inspeccionId)
        {
            List<Inspeccion_ItemControl_Valores> listInspeccionICV = (from ins in db.InspeccionItemControlValores
                                                                        where ins.InspeccionId == inspeccionId
                                                                        select ins
                                                                      ).ToList();
            return listInspeccionICV;
        }
        public  void UpdateInspeccionItemControlValores(Inspeccion_ItemControl_Valores inspeccionICVToUpdate)
       {
          db.Set<Inspeccion_ItemControl_Valores>().Update(inspeccionICVToUpdate);
       }
        public bool GetIsTipoActivoInListaInspeccion(Inspeccion inspeccion)
        { 
            var queryListadoInspeccion = from u in db.ListadoInspeccion_TipoActivo
                                         let ces = from ce in db.Activos
                                                   where ce.Id == inspeccion.ActivoId
                                                   select ce.TipoActivoId
                                         where ces.Contains(u.TipoActivoId) && u.ListadoInspeccionId == inspeccion.ListadoInspeccionId
                                         select u;
            
            return queryListadoInspeccion.Count() > 0 ? true : false;
        }
        public bool GetRequireLecturaItemControl(int itemControlId)
        {
            var requireLectura = (from ic in db.ItemControl
                                 where ic.Id == itemControlId
                                 select ic.RealizarLectura).FirstOrDefault(); ;

            return requireLectura;
        }
    }
}
