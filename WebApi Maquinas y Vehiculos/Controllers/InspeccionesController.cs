using Application.ModelsDto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApi.Shared;

namespace WebApi_Maquinas_y_Vehiculos.Controllers
{
    /// <summary>
    /// InspeccionesController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InspeccionesController : ControllerBase
    {
        private readonly IInspeccionService _inspeccionService;
        private readonly IMapper _mapper;

        /// <summary>
        /// ListadosInspeccionController
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="inspeccionService"></param>
        public InspeccionesController(IMapper mapper, IInspeccionService inspeccionService)
        {
            _mapper = mapper;
            _inspeccionService = inspeccionService;
        }

        /// <summary>
        /// Crea un Inspeccion
        /// </summary>
        /// <param name="inspeccion">Entidad Inspeccion</param> 
        /// <response code="201">Crea el Inspeccion con exito</response> 
        /// <response code="400">Bad request</response>
        /// <response code="500">Error interno del servidor</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost()]
        public IActionResult CreateInspeccion([FromBody] InspeccionDTO inspeccion)
        {
            Inspeccion _inspeccion= _mapper.Map<InspeccionDTO, Inspeccion>(inspeccion);
             
            var result = _inspeccionService.CreateInspeccion(_inspeccion);

            return CreatedAtRoute("GetInspeccionById", new { IdInspeccion = result.Id }, null);
        }

        /// <summary>
        /// Retorna un Inspeccion por Id
        /// </summary>
        /// <param name="IdInspeccion">Inspeccion ID</param>
        /// <returns>Retorna un Inspeccion</returns>
        /// <response code="200">Retorna una Inspeccion por Id con exito</response>
        /// <response code="404">No se encuentra el Inspeccion con el Id Inspeccion enviado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet("{IdInspeccion}", Name = "GetInspeccionById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetInspeccionById(Guid IdInspeccion)
        {
            var inspeccion = _inspeccionService.GetInspeccionById(IdInspeccion);

            return Ok(inspeccion);
        }
        /// <summary>
        /// Actualiza una Inspeccion existente
        /// </summary>
        /// <param name="IdInspeccion">Inspeccion ID</param>
        /// <param name="inspeccion">Entidad Inspeccion</param> 
        /// <response code="200">El Inspeccion es actualizado con exito</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">El Inspeccion con el id ingresado no es encontrado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPut()]
        [Route("{IdInspeccion}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Put(Guid IdInspeccion, [FromBody] InspeccionDTO inspeccion)
        {
            Inspeccion _inspeccion = _mapper.Map<InspeccionDTO, Inspeccion>(inspeccion);

            _inspeccionService.UpdateInspeccion(IdInspeccion,_inspeccion);

            return Ok();
        }

        /// <summary>
        /// Crea un InspeccionEstado
        /// </summary>
        /// <param name="InspeccionId">Inspeccion ID</param>
        /// <param name="inspeccionEstado">InspeccionEstado</param> 
        /// <response code="201">Crea el InspeccionEstado con exito</response> 
        /// <response code="400">Bad request</response>
        /// <response code="500">Error interno del servidor</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("{InspeccionId}/Estados")]
        [HttpPost()]
        public IActionResult AddInspeccionEstado(Guid InspeccionId, [FromBody] InspeccionEstadoDTO inspeccionEstado)
        {
            InspeccionEstado _inspeccionEstado = _mapper.Map<InspeccionEstadoDTO, InspeccionEstado>(inspeccionEstado);

            var result = _inspeccionService.AddInspeccionEstado(InspeccionId, _inspeccionEstado);

            return CreatedAtRoute("GetInspeccionesEstadoByIdInspeccion", new { result.InspeccionId, InspeccionEstadoId = result.Id }, null);

        }

        /// <summary>
        /// Retorna un InspeccionEstado por IdInspeccion
        /// </summary>
        /// <param name="InspeccionId">Inspeccion ID</param>
        /// <param name="InspeccionEstadoId">Inspeccion Estado ID</param>
        /// <returns>Retorna un InspeccionEstado de la inspeccion ingresada</returns>
        /// <response code="200">Retorna un InspeccionEstado por Id con exito</response>
        /// <response code="404">No se encuentra los InspeccionEstado con el Id Inspeccion enviado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet("{InspeccionId}/Estados/{InspeccionEstadoId}", Name = "GetInspeccionesEstadoByIdInspeccion")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetInspeccionesEstadoByIdInspeccion(Guid InspeccionId, Guid InspeccionEstadoId)
        {
            var listadoInspeccion = _inspeccionService.GetInspeccionEstadoById(InspeccionEstadoId, InspeccionId);

            return Ok(listadoInspeccion);
        }

        /// <summary>
        /// Actualiza una InspeccionEstado existente
        /// </summary>
        /// <param name="InspeccionId">Inspeccion ID</param>
        /// <param name="InspeccionEstadoId">Inspeccion Estado ID</param>
        /// <param name="inspeccionEstado">Entidad InspeccionEstado</param> 
        /// <response code="200">El InspeccionEstado es actualizado con exito</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">El InspeccionEstado con el id ingresado no es encontrado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPut()]
        [Route("{InspeccionId}/Estados/{InspeccionEstadoId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateInspeccionEstado(Guid InspeccionId, Guid InspeccionEstadoId, [FromBody] InspeccionEstadoDTO inspeccionEstado)
        {
            InspeccionEstado _inspeccionEstado = _mapper.Map<InspeccionEstadoDTO, InspeccionEstado>(inspeccionEstado);

            _inspeccionService.UpdateInspeccionEstado(InspeccionId, InspeccionEstadoId, _inspeccionEstado);

            return Ok();
        }

        /// <summary>
        /// Crea un InspeccionItemControlValores
        /// </summary>
        /// <param name="InspeccionId">Inspeccion ID</param> 
        /// <param name="inspeccionItemControlValores">InspeccionItemControlValores</param> 
        /// <response code="201">Crea el InspeccionItemControlValores con exito</response> 
        /// <response code="400">Bad request</response>
        /// <response code="500">Error interno del servidor</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("{InspeccionId}/ItemsControl")]
        [HttpPost()]
        public IActionResult AddInspeccionItemControlValores(Guid InspeccionId, [FromBody] List<Inspeccion_ItemControl_ValoresDTO> inspeccionItemControlValores)
        {
            List<Inspeccion_ItemControl_Valores> _inspeccionItemControlValores = _mapper.Map<List<Inspeccion_ItemControl_ValoresDTO>, List<Inspeccion_ItemControl_Valores>>(inspeccionItemControlValores);

             _inspeccionService.AddInspeccionItemControlValores(_inspeccionItemControlValores, InspeccionId);

            return CreatedAtRoute("GetInspeccionItemControlValoresById", new { InspeccionId }, null);
        }

        /// <summary>
        /// Retorna una lista InspeccionItemControlValores por InspeccionId
        /// </summary> 
        /// <param name="InspeccionId">Inspeccion ID</param>
        /// <returns>Retorna una lista InspeccionItemControlValores</returns>
        /// <response code="200">Retorna una lista InspeccionItemControlValores por InspeccionId con exito</response>
        /// <response code="404">No se encuentra el InspeccionItemControlValores con el Id Inspeccion enviado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet("{InspeccionId}/ItemsControl", Name = "GetInspeccionItemControlValoresById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetInspeccionItemControlValoresById(Guid InspeccionId)
        {
            var listadoInspeccion = _inspeccionService.GetInspeccionItemControlValoresByIdInspeccion(InspeccionId);

            return Ok(listadoInspeccion);
        }

        /// <summary>
        /// Actualiza una InspeccionItemControlValores existente
        /// </summary>
        /// <param name="InspeccionId">Inspeccion ID</param>
        /// <param name="inspeccionItemControlValores">Entidad inspeccionItemControlValores</param>  
        /// <response code="200">El InspeccionEstado es actualizado con exito</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">El InspeccionEstado con el id ingresado no es encontrado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPut()]
        [Route("{InspeccionId}/ItemsControl")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateInspeccionItemControlValores(Guid InspeccionId, [FromBody] Inspeccion_ItemControl_ValoresDTO inspeccionItemControlValores)
        {
            Inspeccion_ItemControl_Valores _inspeccionItemControlValores = _mapper.Map<Inspeccion_ItemControl_ValoresDTO, Inspeccion_ItemControl_Valores>(inspeccionItemControlValores);

            _inspeccionService.UpdateInspeccionItemControlValores(InspeccionId,   _inspeccionItemControlValores);

            return Ok();
        }
    }
}