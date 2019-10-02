using Domain.Core.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IInspeccionRepository : IRepositoryBase<Inspeccion>
    {
        InspeccionEstado AddInspeccionEstado(InspeccionEstado inspeccionEstado);
        InspeccionEstado GetInspeccionEstadoById(Guid idInspeccionEstado, Guid IdInspeccion); 
        void UpdateInspeccionEstado(InspeccionEstado inspeccionEstado);
        Inspeccion_ItemControl_Valores AddInspeccionItemControlValores(Inspeccion_ItemControl_Valores inspeccionItemControlValores);
        Inspeccion_ItemControl_Valores GetInspeccionItemControlValoresById(Guid inspeccionId, int itemControlId);
        void UpdateInspeccionItemControlValores(Inspeccion_ItemControl_Valores inspeccionICVToUpdate);
        bool GetIsTipoActivoInListaInspeccion(Inspeccion inspeccion);
        bool GetRequireLecturaItemControl(int itemControlId);
        List<Inspeccion_ItemControl_Valores> GetInspeccionItemControlValoresByIdInspeccion(Guid inspeccionId); 
    }
}
