using Domain.Core.Services;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IActivoService : IDomainService
    {
        Activo CrearActivo(IActivoRepository activoRepository, Activo activo);
        IEnumerable<Activo> ObtenerActivos(IActivoRepository activoRepository);
        Activo ModificarActivo(IActivoRepository activoRepository, Activo activo);
        DocumentacionActivo AgregarDocumentacion(IActivoRepository activoRepository, DocumentacionActivo doc, Guid IdActivo);
        void EliminarDocumentacion(IActivoRepository activoRepository, Guid IdDoc);
        DocumentacionActivo ModificarDocumentacion(IActivoRepository activoRepository, DocumentacionActivo doc, Guid IdActivo);
        DocumentacionActivo ObtenerDocumentacionById(IActivoRepository activoRepository, Guid id);

    }
}
