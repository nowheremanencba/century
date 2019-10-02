using Domain.Core;
using Domain.Core.Services;
using Domain.Entities;
using Domain.Entities.ListadoInspeccion_Agreggate_Root.Validator;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{

    public class ListadoInspeccionService : DomainService, IListadoInspeccionService
    {
        private readonly IListadoInspeccionRepository _listadoInspeccionRepository;
        public ListadoInspeccionService(IListadoInspeccionRepository listadoInspeccionRepository)
        {
            _listadoInspeccionRepository = listadoInspeccionRepository;
        }

        public ListadoInspeccionService()
        {
        }

        public ListadoInspeccion CreateListadoInspeccion(ListadoInspeccion listadoInspeccion)
        {
            var listadoInspeccionValidator = new ListadoInspeccionValidator();

            if (listadoInspeccionValidator.IsValid(listadoInspeccion))
            {
                foreach (var item in listadoInspeccion.TipoActivo)
                {
                    var tipoActivo = GetTipoActivoById(item);
                   
                    _listadoInspeccionRepository.AddListadoInspeccion(listadoInspeccion, tipoActivo);
                    
                }
                _listadoInspeccionRepository.Commit();
            }
            else
            {
                throw new CenturyException(new CenturyError(CenturyError.TipoError.ErrorValidacion, "No se puede crear el ListadoInspeccion. No se cumplió una validación de datos.", "ListadoInspeccion", listadoInspeccionValidator.BrokenRules(listadoInspeccion)));
            }
            
            return listadoInspeccion;
        }
         
        public ListadoInspeccion UpdateListadoInspeccion(ListadoInspeccion listadoInspeccion, Guid id)
        {
            var listadoInspeccionValidator = new ListadoInspeccionValidator();

            if (listadoInspeccionValidator.IsValid(listadoInspeccion))
            { 
                var listadoInspeccionUpdate = GetListadoInspeccionById(id);
             
                listadoInspeccionUpdate.SetDescripcion(listadoInspeccion.Descripcion);
                listadoInspeccionUpdate.SetUnidadPeriodicidad(listadoInspeccion.UnidadPeriodicidad);
                listadoInspeccionUpdate.SetTipoMedidaPeriodicidadId(listadoInspeccion.TipoMedidaPeriodicidadId);
                listadoInspeccionUpdate.SetTipoActivo(listadoInspeccion.TipoActivo);

                _listadoInspeccionRepository.DeleteListadoInspeccion_TipoActivo(id);  
                foreach (var item in listadoInspeccion.TipoActivo)
                {
                    var tipoActivo = GetTipoActivoById(item);

                    _listadoInspeccionRepository.UpdateListadoInspeccion(listadoInspeccionUpdate, tipoActivo);
                }

                _listadoInspeccionRepository.Commit();
            }
            else
            {
                throw new CenturyException(new CenturyError(CenturyError.TipoError.ErrorValidacion, "No se puede crear el ListadoInspeccion. No se cumplió una validación de datos.", "ListadoInspeccion", listadoInspeccionValidator.BrokenRules(listadoInspeccion)));
            }

            return listadoInspeccion; 
        }
        public ListadoInspeccion GetListadoInspeccionById(Guid id)
        {
            ListadoInspeccion listadoInspeccion = null;

            if (id != null)
            {
                listadoInspeccion = _listadoInspeccionRepository.GetById(id);
                
                if (listadoInspeccion is null)
                    throw new CenturyException(new CenturyError(CenturyError.TipoError.NoEncontrado, "ListadoInspeccion no encontrado", "ListadoInspeccion"));
                _listadoInspeccionRepository.LoadCollection(listadoInspeccion, l => l.ItemControl);
                _listadoInspeccionRepository.LoadReference(listadoInspeccion, a => a.TipoMedidaPeriodicidad);
                _listadoInspeccionRepository.LoadCollection(listadoInspeccion, a => a.TipoActivo);
            }
            return listadoInspeccion;
        }
        public void AddItemControlToListadoInspeccion(Guid IdListadoInspeccion, List<int> listItemControl)
        {
            var orden = 1;
            var ListadoInspeccion = GetListadoInspeccionById(IdListadoInspeccion);
            foreach (var item in listItemControl)
            { 
                var itemControl = GetItemControlById(item);
                _listadoInspeccionRepository.AddItemControlToListadoInspeccion(itemControl, ListadoInspeccion, orden);
                orden++;
            }

            _listadoInspeccionRepository.Commit();
        }
        public void UpdateItemControlInListadoInspeccion(int itemControlId, Guid IdListadoInspeccion, int orden)
        {
            var itemControlUpdate = ValidateItemControlInListadoInspeccion(itemControlId, IdListadoInspeccion, orden);
            var listadoInspeccion = GetListadoInspeccionById(IdListadoInspeccion); 
            _listadoInspeccionRepository.UpdateItemControlInListadoInspeccion(itemControlUpdate, listadoInspeccion, orden);
            _listadoInspeccionRepository.Commit(); 
        }
        private ItemControl ValidateItemControlInListadoInspeccion(int itemControlId, Guid IdListadoInspeccion, int orden)
        {
            var itemControlResult = _listadoInspeccionRepository.GetItemControlInListadoInspeccion(itemControlId, IdListadoInspeccion);
            if (itemControlResult is null)
                throw new CenturyException(new CenturyError(CenturyError.TipoError.NoEncontrado, "ItemControl no encontrado con llave (id) == (" + itemControlId.ToString() + ") en ListadoInspeccion con llave (id) == (" + IdListadoInspeccion.ToString() + ")", "ItemControl"));
           
            bool existeOrden = _listadoInspeccionRepository.ValidateOrderItemControlInListadoInspeccion(itemControlId, IdListadoInspeccion, orden);
            if (existeOrden)
                throw new CenturyException(new CenturyError(CenturyError.TipoError.NoPermitido, "ItemControl con orden nro. " + orden + " ya existe en ListadoInspeccion con llave (id) == (" + IdListadoInspeccion.ToString() + ")", "ItemControl"));

            return itemControlResult;
        }

        public ItemControl GetItemControlById(int id)
        {
            var itemControlResult = _listadoInspeccionRepository.GetItemControlById(id);
            if (itemControlResult is null)
                throw new CenturyException(new CenturyError(CenturyError.TipoError.NoEncontrado, "ItemControl no encontrado con llave (id) == (" + id.ToString() + ")", "ItemControl"));
            return itemControlResult;
        }
        private TipoActivo GetTipoActivoById(TipoActivo item)
        {
            var tipoActivoResult = _listadoInspeccionRepository.GetTipoActivoById(item.Id);
            if (tipoActivoResult is null)
                throw new CenturyException(new CenturyError(CenturyError.TipoError.NoEncontrado, "TipoActivo no encontrado con llave (id) == (" + item.Id.ToString() + ")", "TipoActivo"));
            return tipoActivoResult;
        }

    }
}
