using Domain.Core.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IListadoInspeccionService : IDomainService
    {
        ListadoInspeccion CreateListadoInspeccion(ListadoInspeccion listadoInspeccion);
        ListadoInspeccion GetListadoInspeccionById(Guid id);
        void AddItemControlToListadoInspeccion(Guid IdListadoInspeccion, List<int> listItemControl);
        ListadoInspeccion UpdateListadoInspeccion(ListadoInspeccion listadoInspeccion, Guid id);
        ItemControl GetItemControlById(int id);
        void UpdateItemControlInListadoInspeccion(int itemControlId, Guid id, int orden);
    }
}
