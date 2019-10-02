using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Application.ModelsDto.ActivoDto_Agreggate_Root;
using AutoMapper;
using Domain.Core;
using Domain.Entities;
using Domain.Interfaces.Services;
using Infraestructure.Persistance.PostgresSQL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Shared;

namespace WebApi_Maquinas_y_Vehiculos.Controllers
{
    /// <summary>
    /// Controller Activo
    /// </summary>
    [Route("api/[controller]")]
    [ApiController] 
    public class ActivosController : ControllerBase
    {
        private ActivoRepository _activoRepository = new ActivoRepository();
        private ActivoService _activoService = new ActivoService();
        // Creacion de un campo para almacenar el objeto de Automapper
        private readonly IMapper _mapper;

        /// <summary>
        /// Asigna el objeto de automapper en el constructor por dependency injection
        /// </summary>
        /// <param name="mapper"></param>
        public ActivosController(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        /// <summary>
        /// Retorna un activo por Id
        /// </summary>
        /// <param name="id">Activo id</param>
        /// <returns>Retorna un activo</returns>
        /// <response code="200">Retorna un activo por Id con exito</response>
        /// <response code="404">No se encuentra el activo con el Id Activo enviado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet("{id}", Name = "GetActivoById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetActivoById(Guid id)
        {
            try
            {
                // Get activo by id
                var activo = _activoService.ObtenerActivo(_activoRepository,id);

                return Ok(new ApiOkResponse(activo));
            }
            catch (CenturyException ex)
            {
                ObjectResult o = new ObjectResult(new ApiResponse(ex.CenturyError, ex.StackTrace));
                if (ex.CenturyError.Codigo  == CenturyError.TipoError.NoEncontrado) {  o.StatusCode = 404; }
                else { o.StatusCode = 500; }
                return o;
            }
            catch (Exception ex)
            {
                ObjectResult o = new ObjectResult(ex.Message);
                o.StatusCode = 500;
                return o;
            }
        }
        
        /// <summary>
        /// Obtiene un activo por dominio y numero interno
        /// </summary> 
        /// <param name="dominio">dominio</param>
        /// <param name="numeroInterno">numeroInterno</param>
        /// <returns>Restorna un activo</returns>
        /// <response code="200">Retorna el activo buscado con exito</response>
        /// <response code="404">No se encuentra el activo con el dominio y numero interno enviado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Search(string dominio = null, string numeroInterno = null)
        {
            try
            {
                var activo = (Activo)null; 

                // Get activo by dominio
                if (!string.IsNullOrEmpty(dominio))
                    activo = _activoService.ObtenerActivo(_activoRepository,null,dominio,null);
                // Get activo by numeroInterno
                if (!string.IsNullOrEmpty(numeroInterno))
                    activo = _activoService.ObtenerActivo(_activoRepository,null,null,int.Parse(numeroInterno));
  
                return Ok(new ApiOkResponse(activo));
            }
            catch (CenturyException ex)
            {
                ObjectResult o = new ObjectResult(new ApiResponse(ex.CenturyError, ex.StackTrace));
                if (ex.CenturyError.Codigo == CenturyError.TipoError.NoEncontrado) { o.StatusCode = 404; }
                else { o.StatusCode = 500; }
                return o;
            }
            catch (Exception ex)
            {
                ObjectResult o = new ObjectResult(ex.Message);
                o.StatusCode = 500;
                return o;
            }
        }

        /// <summary>
        /// Crea un Activo.
        /// </summary>
        /// <param name="request">Activo</param>
        /// <returns>Devuelve un activo</returns>
        /// <response code="201">Crea el activo con exito</response> 
        /// <response code="400">Bad request</response>
        /// <response code="500">Error interno del servidor</response>
        [ProducesResponseType(201)] 
        [ProducesResponseType(500)]
        [HttpPost]
        public IActionResult Post([FromBody] ActivoDto request)
        {
            try
            {
                Activo activo = _mapper.Map<ActivoDto, Activo>(request);

                var result = _activoService.CrearActivo(_activoRepository, activo);

                return CreatedAtRoute("GetActivoById", new { id = result.Id }, result);
            }
            catch (CenturyException ex)
            {
                ObjectResult o = new ObjectResult(new ApiResponse(ex.CenturyError, ex.StackTrace));
                o.StatusCode = 500;
                return o;
            }
            catch (Exception ex)
            {
                ObjectResult o = new ObjectResult(ex.Message);
                o.StatusCode = 500;
                return o;
            }
        }
         
        /// <summary>
        /// Actualiza un activo existente
        /// </summary>
        /// <param name="id">activo ID</param>
        /// <param name="request">Activo</param>
        /// <returns>Retorna activo actualizado</returns>
        /// <response code="200">El activo es actualizado con  exito</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPut()]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put(Guid id, [FromBody] ActivoDto request)
        {
            try
            {
                // Get activo by id
                var activoToUpdate = _activoService.ObtenerActivo(_activoRepository,id);

                // Set id 
                request.Id = id;

                //Map DTO to entity to update
                Activo activo = _mapper.Map<ActivoDto, Activo>(request);

                var result = _activoService.ModificarActivo(_activoRepository, activo);

                return Ok(new ApiOkResponse(result));
            }
            catch (CenturyException ex)
            {
                ObjectResult o = new ObjectResult(new ApiResponse(ex.CenturyError, ex.StackTrace));
                if (ex.CenturyError.Codigo == CenturyError.TipoError.NoEncontrado) { o.StatusCode = 404; }
                else { o.StatusCode = 500; }
                return o;
            }
            catch (Exception ex)
            {
                ObjectResult o = new ObjectResult(ex.Message);
                o.StatusCode = 500;
                return o;
            }
        }

        #region DocumentacionActivo
        /// <summary>
        /// Obtiene un documento
        /// </summary>
        /// <param name="id">Guid</param> 
        /// <returns>Retorna un documento</returns>
        /// <response code="200">Obtiene el documento por Id con exito </response>
        /// <response code="404">No se encuentra ningun activo con el id enviado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet("DocumentacionActivo/{id}", Name = "GetDocumentacionById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult ObtenerDocumentacionById(Guid id)
        {
            try
            {
                var result = _activoService.ObtenerDocumentacionById(_activoRepository, id); 

                return Ok(new ApiOkResponse(result));
            }
            catch (CenturyException ex)
            {
                ObjectResult o = new ObjectResult(new ApiResponse(ex.CenturyError, ex.StackTrace));
                if (ex.CenturyError.Codigo == CenturyError.TipoError.NoEncontrado) { o.StatusCode = 404; }
                else { o.StatusCode = 500; }
                return o;
            }
            catch (Exception ex)
            {
                ObjectResult o = new ObjectResult(ex.Message);
                o.StatusCode = 500;
                return o;
            }
        }
        /// <summary>
        /// Crea una Documentacion Activo 
        /// </summary>
        /// <param name="IdActivo">DocumentacionActivo</param>
        /// <param name="DocumentacionActivo">DocumentacionActivo</param>
        /// <returns>Retorna una documentacion activo</returns>
        /// <response code="201">El documento es agregado con exito</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">El activo  al que se quiere crear la documentacion  no es encontrado</response>
        /// <response code="500">Error interno del servidor</response>
        // POST: api/DocumentacionActivo
        [HttpPost]
        [Route("{IdActivo}/DocumentacionActivo")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult AgregarDocumentacion(Guid IdActivo, [FromBody] DocumentacionActivoDTO DocumentacionActivo)
        {
            try
            {
                if (DocumentacionActivo == null)
                    return BadRequest();
                 
                DocumentacionActivo doc = _mapper.Map<DocumentacionActivoDTO, DocumentacionActivo>(DocumentacionActivo);
                 
                var result = _activoService.AgregarDocumentacion(_activoRepository, doc, IdActivo ); 

                return CreatedAtRoute("GetDocumentacionById", new { id = result.Id }, doc);
            }
            catch (CenturyException ex)
            {
                ObjectResult o = new ObjectResult(new ApiResponse(ex.CenturyError, ex.StackTrace));
                if (ex.CenturyError.Codigo == CenturyError.TipoError.NoEncontrado) { o.StatusCode = 404; }
                else { o.StatusCode = 500; }
                return o;
            }
            catch (Exception ex)
            {
                ObjectResult o = new ObjectResult(ex.Message);
                o.StatusCode = 500;
                return o;
            }
        }

        /// <summary>
        /// Elimina DocumentacionActivo
        /// </summary>
        /// <param name="IdDocumentacion">IdDocumentacion</param>  
        /// <response code="200">El documento es eliminado con exito</response>
        /// <response code="404">El documento con el Id enviado no es encontrado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpDelete("DocumentacionActivo/{IdDocumentacion}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult EliminarDocumentacion(Guid IdDocumentacion)
        {
            try
            {  
                _activoService.EliminarDocumentacion(_activoRepository, IdDocumentacion);

                return Ok();
            }
            catch (CenturyException ex)
            {
                ObjectResult o = new ObjectResult(new ApiResponse(ex.CenturyError, ex.StackTrace));
                if (ex.CenturyError.Codigo == CenturyError.TipoError.NoEncontrado) { o.StatusCode = 404; }
                else { o.StatusCode = 500; }
                return o;
            }
            catch (Exception ex)
            {
                ObjectResult o = new ObjectResult(ex.Message);
                o.StatusCode = 500;
                return o;
            }
        }

        /// <summary>
        /// Actualiza un documento  
        /// </summary>
        /// <param name="IdActivo">DocumentacionActivo </param>
        /// <param name="request">DocumentacionActivo </param>
        /// <returns>Retorna un documento actualizado</returns>
        /// <response code="200">El documento es actualizado con exito</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPut()]
        [Route("{IdActivo}/DocumentacionActivo")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult ActualizarDocumentacion(Guid IdActivo,[FromBody] DocumentacionActivoDTO request)
        {
            try
            {  
                DocumentacionActivo docActivo = _mapper.Map<DocumentacionActivoDTO, DocumentacionActivo>(request);
                var result = _activoService.ModificarDocumentacion(_activoRepository, docActivo, IdActivo);

                return Ok(new ApiOkResponse(result));
            }
            catch (CenturyException ex)
            {
                ObjectResult o = new ObjectResult(new ApiResponse(ex.CenturyError, ex.StackTrace));
                if (ex.CenturyError.Codigo == CenturyError.TipoError.NoEncontrado) { o.StatusCode = 404; }
                else { o.StatusCode = 500; }
                return o;
            }
            catch (Exception ex)
            {
                ObjectResult o = new ObjectResult(ex.Message);
                o.StatusCode = 500;
                return o;
            }
        }
        /// <summary>
        /// Obtiene una DocumentacionActivo
        /// </summary>
        /// <param name="idActivo">idActivo</param> 
        /// <param name="FechaVencimiento">FechaVencimiento</param>
        /// <returns>Retorna una lista de DocumentacionActivo</returns>
        /// <response code="200">Obtiene una DocumentacionActivo por idActivo y FechaVencimiento con exito</response>
        /// <response code="404">No se puede encontrar el activo con el Id enviado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet()]
        [Route("{idActivo}/Documentos")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetDocumentacionVencida(Guid idActivo, DateTime FechaVencimiento)
        {
            try
            {
                // Get All DocumentacionActivo by id 
                IEnumerable<DocumentacionActivo> docs = _activoService.GetAllDocumentacionDeActivoByFechaVencimiento(_activoRepository,idActivo, FechaVencimiento);
 
                return Ok(new ApiOkResponse(docs));
            }
            catch (CenturyException ex)
            {
                ObjectResult o = new ObjectResult(new ApiResponse(ex.CenturyError, ex.StackTrace));
                if (ex.CenturyError.Codigo == CenturyError.TipoError.NoEncontrado) { o.StatusCode = 404; }
                else { o.StatusCode = 500; }
                return o;
            }
            catch (Exception ex)
            {
                ObjectResult o = new ObjectResult(ex.Message);
                o.StatusCode = 500;
                return o;
            }
        }
        
        /// <summary>
        /// Obtiene una lista de Activos con documentacion vencida
        /// </summary> 
        /// <param name="FechaVencimiento">FechaVencimiento</param>
        /// <returns>Retorna una lista de Activos</returns>
        /// <response code="200">Returna una lista de Activos por fecha de vencimiento de su documentacion</response>
        /// <response code="404">Si la consulta no obtiene un resultado</response>
        /// <response code="500">Si hay internal server error</response>
        [HttpGet()]
        [Route("*/Documentos")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetActivosConDocumentacionVencida(DateTime FechaVencimiento)
        {
            try
            {
                // Get All activos by fecha vencimiento
                IEnumerable<Activo> activos = _activoService.GetActivosConDocumentacionVencida(_activoRepository,FechaVencimiento);

                return Ok(new ApiOkResponse(activos));
            }
            catch (CenturyException ex)
            {
                ObjectResult o = new ObjectResult(new ApiResponse(ex.CenturyError, ex.StackTrace));
                if (ex.CenturyError.Codigo == CenturyError.TipoError.NoEncontrado) { o.StatusCode = 404; }
                else { o.StatusCode = 500; }
                return o;
            }
            catch (Exception ex)
            {
                ObjectResult o = new ObjectResult(ex.Message);
                o.StatusCode = 500;
                return o;
            }
        }
        #endregion
    }

}