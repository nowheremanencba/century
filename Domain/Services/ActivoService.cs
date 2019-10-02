using Domain.Core.Services;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Specifications;
using Domain.Interfaces.Services;
using System.Collections.Generic;
using Domain.Core;
using System;
using System.Globalization;
using System.Linq;
using Domain.Entities.Activo_Agreggate_Root.Validator;

namespace Domain.Interfaces.Services
{
    public class ActivoService : DomainService, IActivoService
    {
        public Activo ObtenerActivo(IActivoRepository activoRepository, Guid? id, string dominio = null, int? numeroInterno = null)
        {
            Activo activo = null;
            string clave = "llave ";

            if (id != null)
            {
                activo = activoRepository.GetById(id);
                clave = clave + "(Id) == ( " +id.ToString() + ")";
            }
            else
            {
                if (dominio != null)
                {
                    activo = activoRepository.GetActivoByDominio(dominio);
                    clave = clave + "(Dominio) == (" + dominio.ToString() + ")";
                }
                else
                {
                    if (numeroInterno != null)
                    {
                        activo = activoRepository.GetActivoByNumeroInterno(numeroInterno);
                        clave = clave + "(NumeroInterno) == (" + numeroInterno.ToString() + ")";
                    }
                }
            }
            if (activo is null)
                throw new CenturyException(new CenturyError(CenturyError.TipoError.NoEncontrado, "Activo no encontrado " + clave, "Activo"));

            return activo;
        }

        public Activo CrearActivo(IActivoRepository activoRepository, Activo activo)
        {
            bool esDominioRequerido = activoRepository.GetDominioIsRequired(activo.TipoActivoId);
            var activoValidator = new ActivoValidator(esDominioRequerido);
            if (activoValidator.IsValid(activo))
            {
                activoRepository.Add(activo);
                activoRepository.Commit();
                activoRepository.LoadReference(activo, a => a.TipoModelo);
                activoRepository.LoadReference(activo, a => a.TipoActivo);
                return activo;
            }
            else
            {
                throw new CenturyException(new CenturyError(CenturyError.TipoError.ErrorValidacion, "No se puede crear el activo. No se cumplió una validación de datos.", "Activo", activoValidator.BrokenRules(activo)));
            }
        }

        public IEnumerable<Activo> ObtenerActivos(IActivoRepository activoRepository)
        {
            var activoResult = activoRepository.GetAll();
            if (activoResult == null)
                throw new CenturyException(new CenturyError(CenturyError.TipoError.NoEncontrado, "No se pudo obtener los activos", "Activo"));
            return activoResult;
        }

        public Activo ModificarActivo(IActivoRepository activoRepository, Activo activo)
        {
            bool esDominioRequerido = activoRepository.GetDominioIsRequired(activo.TipoActivoId);
            var activoValidator = new ActivoValidator(esDominioRequerido);
            if (activoValidator.IsValid(activo))
            {
                activoRepository.Update(activo);
                activoRepository.Commit();
                activoRepository.LoadReference(activo, a => a.TipoModelo);
                activoRepository.LoadReference(activo, a => a.TipoActivo);
                return activo;
            }
            else
                throw new CenturyException(new CenturyError(CenturyError.TipoError.ErrorValidacion, "No se puede modificar el activo. No se cumplio una validación de datos.", "Activo", activoValidator.BrokenRules(activo)));
        }

        public DocumentacionActivo AgregarDocumentacion(IActivoRepository activoRepository, DocumentacionActivo doc, Guid IdActivo)
        {
            var docValidator = new DocumentacionActivoValidator();
            if (docValidator.IsValid(doc))
            {
                var activo = ObtenerActivo(activoRepository, IdActivo);
                activo.AgregarDocumento(doc);
                activoRepository.Commit();
                return doc;
            }
            else
                throw new CenturyException(new CenturyError(CenturyError.TipoError.ErrorValidacion, "No se puede agregar la documentacion activo. No se cumplio una validación de datos.", "DocumentacionActivo", docValidator.BrokenRules(doc)));
        }

        public void EliminarDocumentacion(IActivoRepository activoRepository, Guid IdDocumentacion)
        {
            var doc = ObtenerDocumentacionById(activoRepository, IdDocumentacion);
            activoRepository.Remove(doc);
            activoRepository.Commit();
        }

        public DocumentacionActivo ModificarDocumentacion(IActivoRepository activoRepository, DocumentacionActivo doc, Guid IdActivo)
        {
            var docValidator = new DocumentacionActivoValidator();
            if (docValidator.IsValid(doc))
            {
                var activo = ObtenerActivo(activoRepository, IdActivo);
                var docUpdate = ObtenerDocumentacionById(activoRepository, doc.Id);
                docUpdate.CambiarFechaVencimiento(doc.FechaVencimiento);
                docUpdate.CambiarTipoDocumentacionActivoId(doc.TipoDocumentacionActivoId);
                activoRepository.Update(activo);
                activoRepository.Commit();
                return docUpdate;
            }
            else
                throw new CenturyException(new CenturyError(CenturyError.TipoError.ErrorValidacion, "No se puede modificar la documentacion activo. No se cumplio una validación de datos.", "DocumentacionActivo", docValidator.BrokenRules(doc)));
        }

        public DocumentacionActivo ObtenerDocumentacionById(IActivoRepository activoRepository, Guid id)
        {
            var activoResult = activoRepository.GetDocumentacionById(id);
            if (activoResult is null)
                throw new CenturyException(new CenturyError(CenturyError.TipoError.NoEncontrado, "DocumentacionActivo no encontrado con llave (id) == (" + id.ToString() + ")", "DocumentacionActivo"));
            return activoResult;
        }
        
        public IEnumerable<DocumentacionActivo> GetAllDocumentacionDeActivoByFechaVencimiento(IActivoRepository activoRepository, Guid idActivo, DateTime fechaVencimiento)
        {
            IEnumerable<DocumentacionActivo> docs = activoRepository.Filter(d => d.FechaVencimiento <= fechaVencimiento && d.ActivoId == idActivo).ToList(); 
            // Validate if list contains documentations
            if (docs.Count() == 0)
                throw new CenturyException(new CenturyError(CenturyError.TipoError.NoEncontrado, "DocumentacionActivo no encontrado", "DocumentacionActivo"));
            else
                return docs;            
        }

        public IEnumerable<Activo> GetActivosConDocumentacionVencida(IActivoRepository activoRepository, DateTime fechaVencimiento)
        {
            if (fechaVencimiento == DateTime.MinValue)
                fechaVencimiento = DateTime.Now; 
            IEnumerable<Activo> activos = activoRepository.Filter(activo => activo.Documentos.Exists(documento => documento.FechaVencimiento <= fechaVencimiento)).ToList();

            // Validate if list contains activos
            if (activos.Count() == 0)
                throw new CenturyException(new CenturyError(CenturyError.TipoError.NoEncontrado, "Activos no encontrados", "Activo"));

            return activos;
        }        
    }
}
