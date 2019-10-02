using Domain.Core.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IInspeccionService : IDomainService
    {
        Inspeccion CreateInspeccion(Inspeccion inspeccion);
        Inspeccion GetInspeccionById(Guid idInspeccion);
        void UpdateInspeccion(Guid idInspeccion, Inspeccion inspeccion);
        InspeccionEstado AddInspeccionEstado(Guid InspeccionId,InspeccionEstado inspeccionEstado);
        InspeccionEstado GetInspeccionEstadoById(Guid idInspeccionEstado, Guid IdInspeccion);
        void UpdateInspeccionEstado(Guid InspeccionId, Guid InspeccionEstadoId, InspeccionEstado inspeccionEstado);
        void AddInspeccionItemControlValores(List<Inspeccion_ItemControl_Valores> inspeccionItemControlValores, Guid InspeccionId);
        Inspeccion_ItemControl_Valores GetInspeccionItemControlValoresById(Guid inspeccionId, int ItemControlId);
        List<Inspeccion_ItemControl_Valores> GetInspeccionItemControlValoresByIdInspeccion(Guid inspeccionId);
        void UpdateInspeccionItemControlValores(Guid inspeccionId, Inspeccion_ItemControl_Valores inspeccionItemControlValores);

    }
}
