using Domain.Core.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IListadoInspeccionRepository : IRepositoryBase<ListadoInspeccion>
    {  
        ItemControl AddItemControlToListadoInspeccion(ItemControl itemControl, ListadoInspeccion listadoInspeccion, int orden);
        ItemControl UpdateItemControlInListadoInspeccion(ItemControl itemControl, ListadoInspeccion listadoInspeccion, int orden);
        ItemControl GetItemControlById(int id);
        ItemControl GetItemControlInListadoInspeccion(int id, Guid idListadoInspeccion);
        void LoadCollection(ListadoInspeccion listadoInspeccion, Expression<Func<ListadoInspeccion, IEnumerable<ItemControl>>> col);
        bool ValidateOrderItemControlInListadoInspeccion(int itemControlId, Guid idListadoInspeccion, int orden);
        void LoadCollection(ListadoInspeccion listadoInspeccion, Expression<Func<ListadoInspeccion, IEnumerable<TipoActivo>>> col);
        ListadoInspeccion UpdateListadoInspeccion(ListadoInspeccion listadoInspeccion, TipoActivo tipoActivo);
        TipoActivo GetTipoActivoById(int id);
        ListadoInspeccion AddListadoInspeccion(ListadoInspeccion listadoInspeccion, TipoActivo tipoActivo);
        void DeleteListadoInspeccion_TipoActivo(Guid id);
        void UpdateListadoInspeccion(ListadoInspeccion listadoInspeccionUpdate);
    }
}
