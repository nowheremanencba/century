using Domain.Core;
using Domain.Core.Services;
using Domain.Entities;
using Domain.Entities.Inspeccion_Agreggate_Root.Validator;
using Domain.Entities.ListadoInspeccion_Agreggate_Root.Validator;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
   
    public class InspeccionService : DomainService, IInspeccionService
    {
        private readonly IInspeccionRepository _inspeccionRepository; 

        public InspeccionService(IInspeccionRepository inspeccionRepository)
        {
            _inspeccionRepository = inspeccionRepository;
        }

        public InspeccionService()
        {
        }

        public Inspeccion CreateInspeccion(Inspeccion inspeccion)
        {
            bool isTipoActivoInListaInspeccion = _inspeccionRepository.GetIsTipoActivoInListaInspeccion(inspeccion);

            var inspeccionValidator = new InspeccionValidator(isTipoActivoInListaInspeccion);

            if (!(inspeccionValidator.IsValid(inspeccion)))
                throw new CenturyException(new CenturyError(CenturyError.TipoError.ErrorValidacion, "No se puede crear la inspeccion. No se cumplió una validación de datos.", "Inspeccion", inspeccionValidator.BrokenRules(inspeccion)));

            _inspeccionRepository.Add(inspeccion);
            _inspeccionRepository.Commit();
            return inspeccion;
        }
        public Inspeccion GetInspeccionById(Guid idInspeccion)
        {
            var inspeccionResult =  _inspeccionRepository.GetById(idInspeccion);
            if (inspeccionResult is null)
                throw new CenturyException(new CenturyError(CenturyError.TipoError.NoEncontrado, "Inspeccion no encontrado con llave (id) == (" + idInspeccion.ToString() + ")", "Inspeccion"));

            _inspeccionRepository.LoadReference(inspeccionResult, a => a.Activo);
            _inspeccionRepository.LoadReference(inspeccionResult, a => a.ListadoInspeccion);
            _inspeccionRepository.LoadReference(inspeccionResult, a => a.TipoInspeccion);
            return inspeccionResult;
        }


        public void UpdateInspeccion(Guid idInspeccion, Inspeccion inspeccion)
        {
            var inspeccionToUpdate = GetInspeccionById(idInspeccion);
            inspeccionToUpdate.SetObservacion(inspeccion.Observacion);
            inspeccionToUpdate.SetActivoId(inspeccion.ActivoId);
            inspeccionToUpdate.SetListadoInspeccionId(inspeccion.ListadoInspeccionId);
            inspeccionToUpdate.SetTipoInspeccionId(inspeccion.TipoInspeccionId);

            bool IsTipoActivoInListaInspeccion = _inspeccionRepository.GetIsTipoActivoInListaInspeccion(inspeccion);

            var inspeccionValidator = new InspeccionValidator(IsTipoActivoInListaInspeccion);

            if (!(inspeccionValidator.IsValid(inspeccionToUpdate)))
                throw new CenturyException(new CenturyError(CenturyError.TipoError.ErrorValidacion, "No se puede actualizar la inspeccion. No se cumplió una validación de datos.", "Inspeccion", inspeccionValidator.BrokenRules(inspeccion)));

            _inspeccionRepository.Update(inspeccionToUpdate);
            _inspeccionRepository.Commit();
        }
        public InspeccionEstado AddInspeccionEstado(Guid InspeccionId, InspeccionEstado inspeccionEstado)
        {
            inspeccionEstado.SetInspeccionId(InspeccionId);

            var inspeccionEstadoValidator = new InspeccionEstadoValidator();

            if (!(inspeccionEstadoValidator.IsValid(inspeccionEstado)))
                throw new CenturyException(new CenturyError(CenturyError.TipoError.ErrorValidacion, "No se puede crear la InspeccionEstado. No se cumplió una validación de datos.", "Inspeccion", inspeccionEstadoValidator.BrokenRules(inspeccionEstado)));

            _inspeccionRepository.AddInspeccionEstado(inspeccionEstado);
            _inspeccionRepository.Commit();
            return inspeccionEstado;
        }

        public InspeccionEstado GetInspeccionEstadoById(Guid InspeccionEstadoId, Guid InspeccionId)
        {
            var inspeccionEstadoResult = _inspeccionRepository.GetInspeccionEstadoById(InspeccionEstadoId, InspeccionId);
            if (inspeccionEstadoResult is null)
                throw new CenturyException(new CenturyError(CenturyError.TipoError.NoEncontrado, "InspeccionEstado no encontrado con llave (id) == (" + InspeccionEstadoId.ToString() + ")", "InspeccionEstado"));

            return inspeccionEstadoResult; 
        }
        public void UpdateInspeccionEstado(Guid InspeccionId, Guid InspeccionEstadoId, InspeccionEstado inspeccionEstado)
        {
            var inspeccionEstadoToUpdate = GetInspeccionEstadoById(InspeccionEstadoId, InspeccionId);
            inspeccionEstadoToUpdate.SetInspeccionId(InspeccionId);
            inspeccionEstadoToUpdate.SetObservacion(inspeccionEstado.Observacion);
            inspeccionEstadoToUpdate.SetFecha(inspeccionEstado.Fecha);
            inspeccionEstadoToUpdate.SetUbicacion(inspeccionEstado.Ubicacion);
            inspeccionEstadoToUpdate.SetTipoEstadoInspeccionId(inspeccionEstado.TipoEstadoInspeccionId); 

            var inspeccionEstadoValidator = new InspeccionEstadoValidator();

            if (!(inspeccionEstadoValidator.IsValid(inspeccionEstadoToUpdate)))
                throw new CenturyException(new CenturyError(CenturyError.TipoError.ErrorValidacion, "No se puede actualizar la InspeccionEstado. No se cumplió una validación de datos.", "InspeccionEstado", inspeccionEstadoValidator.BrokenRules(inspeccionEstado)));

            _inspeccionRepository.UpdateInspeccionEstado(inspeccionEstadoToUpdate);
            _inspeccionRepository.Commit();
        }
        public void AddInspeccionItemControlValores(List<Inspeccion_ItemControl_Valores> inspeccionItemControlValores, Guid InspeccionId)
        {
            foreach (var item in inspeccionItemControlValores)
            {
                item.SetInspeccionId(InspeccionId);

                bool lecturaItemControl = _inspeccionRepository.GetRequireLecturaItemControl(item.ItemControlId);
                var inspeccionItemControlValoresValidator = new InspeccionItemControlValoresValidator(lecturaItemControl);

                if (!(inspeccionItemControlValoresValidator.IsValid(item)))
                    throw new CenturyException(new CenturyError(CenturyError.TipoError.ErrorValidacion, "No se puede crear la InspeccionItemControlValores. No se cumplió una validación de datos.", "InspeccionItemControlValores", inspeccionItemControlValoresValidator.BrokenRules(item)));

                _inspeccionRepository.AddInspeccionItemControlValores(item);
            }
            
            _inspeccionRepository.Commit(); 
        }
        public Inspeccion_ItemControl_Valores GetInspeccionItemControlValoresById(Guid inspeccionId, int ItemControlId)
        {
            var inspeccionICVResult = _inspeccionRepository.GetInspeccionItemControlValoresById(inspeccionId, ItemControlId);
            if (inspeccionICVResult is null)
                throw new CenturyException(new CenturyError(CenturyError.TipoError.NoEncontrado, "InspeccionItemControlValores no encontrado con llave (itemControlId) == (" + ItemControlId.ToString() + ") e (inspeccionId) == (" + inspeccionId.ToString() + ")", "InspeccionItemControlValores"));

            return inspeccionICVResult;
        }
        public List<Inspeccion_ItemControl_Valores> GetInspeccionItemControlValoresByIdInspeccion(Guid inspeccionId)
        {
            var inspeccionICVListResult = _inspeccionRepository.GetInspeccionItemControlValoresByIdInspeccion(inspeccionId);
            if (inspeccionICVListResult.Count == 0)
                throw new CenturyException(new CenturyError(CenturyError.TipoError.NoEncontrado, "InspeccionItemControlValores no encontrado con llave (inspeccionId) == (" + inspeccionId.ToString() + ")", "InspeccionItemControlValores"));

            return inspeccionICVListResult;
        }
        public void UpdateInspeccionItemControlValores(Guid inspeccionId, Inspeccion_ItemControl_Valores inspeccionItemControlValores)
        {
            var inspeccionICVToUpdate = GetInspeccionItemControlValoresById(inspeccionId, inspeccionItemControlValores.ItemControlId);
            inspeccionICVToUpdate.SetInspeccionId(inspeccionId);
            inspeccionICVToUpdate.SetObservacion(inspeccionItemControlValores.Observacion);
            inspeccionICVToUpdate.SetOrden(inspeccionItemControlValores.Orden);
            inspeccionICVToUpdate.SetValorLectura(inspeccionItemControlValores.ValorLectura);
            inspeccionICVToUpdate.SetTipoAccionRecomendadaId(inspeccionItemControlValores.TipoAccionRecomendadaId);
            inspeccionICVToUpdate.SettipoLecturaItemInspeccionId(inspeccionItemControlValores.TipoLecturaItemInspeccionId);

            bool lecturaItemControl = _inspeccionRepository.GetRequireLecturaItemControl(inspeccionItemControlValores.ItemControlId);
            var inspeccionItemControlValoresValidator = new InspeccionItemControlValoresValidator(lecturaItemControl);

            if (!(inspeccionItemControlValoresValidator.IsValid(inspeccionICVToUpdate)))
                throw new CenturyException(new CenturyError(CenturyError.TipoError.ErrorValidacion, "No se puede actualizar la Inspeccion_ItemControl_Valores. No se cumplió una validación de datos.", "Inspeccion_ItemControl_Valores", inspeccionItemControlValoresValidator.BrokenRules(inspeccionICVToUpdate)));

            _inspeccionRepository.UpdateInspeccionItemControlValores(inspeccionICVToUpdate);
            _inspeccionRepository.Commit();
        }
    }
}
