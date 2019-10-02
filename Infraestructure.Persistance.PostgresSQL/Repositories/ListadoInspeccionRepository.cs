using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infraestructure.Persistance.PostgresSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infraestructure.Persistance.PostgresSQL.Repositories
{
    public class ListadoInspeccionRepository : BaseRepository<ListadoInspeccion>, IListadoInspeccionRepository
    {
        public ListadoInspeccion AddListadoInspeccion(ListadoInspeccion listadoInspeccion, TipoActivo tipoActivo)
        {
            listadoInspeccion.SetTipoActivo(null);
            db.Set<ListadoInspeccion>().Add(listadoInspeccion);
            db.Set<ListadoInspeccion_TipoActivo>().Add(new ListadoInspeccion_TipoActivo()
            {
                ListadoInspeccionId = listadoInspeccion.Id,
                TipoActivoId = tipoActivo.Id
            });
            return listadoInspeccion;
        }
        public ListadoInspeccion UpdateListadoInspeccion(ListadoInspeccion listadoInspeccion, TipoActivo tipoActivo)
        {
            listadoInspeccion.SetTipoActivo(null); 

            db.Set<ListadoInspeccion_TipoActivo>().Add(new ListadoInspeccion_TipoActivo()
            {
                ListadoInspeccionId = listadoInspeccion.Id,
                TipoActivoId = tipoActivo.Id
            });

            db.Set<ListadoInspeccion>().Update(listadoInspeccion);
            return listadoInspeccion;
        }
        public void UpdateListadoInspeccion(ListadoInspeccion listadoInspeccionUpdate)
        {
            db.Set<ListadoInspeccion>().Update(listadoInspeccionUpdate); 
        }

        public void DeleteListadoInspeccion_TipoActivo(Guid id)
        {
            var listInspeccion = db.ListadoInspeccion_TipoActivo
                                 .Where(ic => ic.ListadoInspeccionId == id)
                                 .ToList();
            foreach (var item in listInspeccion)
            {
                db.Set<ListadoInspeccion_TipoActivo>().Remove(item);
            }
        }
        public void LoadCollection(ListadoInspeccion listadoInspeccion, Expression<Func<ListadoInspeccion, IEnumerable<ItemControl>>> col)
        {
            var itemsControl = (from li in db.ListadoInspeccion_ItemControl
                                join i in db.ItemControl on li.ItemControlId equals i.Id
                                where li.ListadoInspeccionId == listadoInspeccion.Id
                                select i)
                                .ToList<ItemControl>();

            //var itemsControl = db.ListadoInspeccion_ItemControl
            //                   .Where(lic => lic.ListadoInspeccionId == listadoInspeccion.Id)
            //                   .OrderBy(lic => lic.Orden)
            //                   .Select(lic => lic.ItemControl)
            //                   .ToList();
            listadoInspeccion.SetItemsControl(itemsControl); 
        }
        public void LoadCollection(ListadoInspeccion listadoInspeccion, Expression<Func<ListadoInspeccion, IEnumerable<TipoActivo>>> col)
        {
            var tipoActivo = (from li in db.ListadoInspeccion_TipoActivo
                              join ta in db.TipoActivo on li.TipoActivoId equals ta.Id
                              where li.ListadoInspeccionId == listadoInspeccion.Id
                              select ta)
                              .ToList<TipoActivo>();
            //var tipoActivo = db.ListadoInspeccion_TipoActivo
            //                                   .Where(lic => lic.ListadoInspeccionId == listadoInspeccion.Id) 
            //                                   .Select(lic => lic.TipoActivo)
            //                                   .ToList(); 

          listadoInspeccion.SetTipoActivo(tipoActivo);
        }
        public ItemControl AddItemControlToListadoInspeccion(ItemControl itemControl, ListadoInspeccion listadoInspeccion, int orden)
        {
            db.Set<ListadoInspeccion_ItemControl>().Add(new ListadoInspeccion_ItemControl()
            {
                ItemControlId = itemControl.Id,
                Orden = orden,
                ListadoInspeccionId = listadoInspeccion.Id
            });
            return itemControl;
        }
        public ItemControl UpdateItemControlInListadoInspeccion(ItemControl itemControl, ListadoInspeccion listadoInspeccion, int orden)
        {
            ListadoInspeccion_ItemControl listItemControl = db.Set<ListadoInspeccion_ItemControl>()
                                                            .Where(x => x.ListadoInspeccionId == listadoInspeccion.Id && x.ItemControlId == itemControl.Id)
                                                            .FirstOrDefault();
            listItemControl.ItemControlId = itemControl.Id;
            listItemControl.Orden = orden;
            listItemControl.ListadoInspeccionId = listadoInspeccion.Id;
            db.Update(listItemControl);
            return itemControl; 
        }
        public TipoActivo GetTipoActivoById(int id)
        {
            TipoActivo tipoActivo = db.TipoActivo
                                    .Where(ic => ic.Id == id)
                                    .FirstOrDefault();
            return tipoActivo; 
        }
        public ItemControl GetItemControlById(int id)
        {
            ItemControl itemControl = db.ItemControl
                                        .Where(ic => ic.Id == id)
                                       .FirstOrDefault();
            return itemControl;
        }

        public ItemControl GetItemControlInListadoInspeccion(int id, Guid IdListadoInspeccion)
        {
            ItemControl itemControl = (from li in db.ListadoInspeccion_ItemControl
                                join i in db.ItemControl on li.ItemControlId equals i.Id
                                where li.ListadoInspeccionId == IdListadoInspeccion && li.ItemControlId == i.Id
                                select i)
                                .FirstOrDefault<ItemControl>();
            //ItemControl itemControl = db.ListadoInspeccion_ItemControl
            //                            .Where(lic => lic.ItemControlId == id && lic.ListadoInspeccionId == IdListadoInspeccion)
            //                            .Select(lic => lic.ItemControl)
            //                           .FirstOrDefault();
            return itemControl;
        }

        public bool ValidateOrderItemControlInListadoInspeccion(int itemControlId, Guid idListadoInspeccion, int orden)
        { 
            var existe = db.ListadoInspeccion_ItemControl
                                 .Where(lic => lic.ListadoInspeccionId == idListadoInspeccion)
                                 .ToList()
                                 .Any(item => item.Orden == orden); 
            return existe;
        }
    }
}
