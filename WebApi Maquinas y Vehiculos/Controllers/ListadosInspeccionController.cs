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
    /// Controller ListadosInspeccion
    /// </summary>
    [Route("api/[controller]")] 
    [ApiController] 
    public class ListadosInspeccionController : ControllerBase
    { 
        private readonly IListadoInspeccionService _listadoInspeccionService; 
        private readonly IMapper _mapper;

        /// <summary>
        /// ListadosInspeccionController
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="listadoInspeccionService"></param>
        public ListadosInspeccionController(IMapper mapper, IListadoInspeccionService listadoInspeccionService)
        {
            _mapper = mapper;
            _listadoInspeccionService = listadoInspeccionService;
        }
        /// <summary>
        /// Crea un ListadoInspeccion.
        /// </summary>
        /// <param name="listadoInspeccion">ListadoInspeccion</param>
        /// <returns>Devuelve un ListadoInspeccion</returns>
        /// <response code="201">Crea el ListadoInspeccion con exito</response> 
        /// <response code="400">Bad request</response>
        /// <response code="500">Error interno del servidor</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost()]
        public IActionResult CreateListadoInspeccion([FromBody] ListadoInspeccionDTO listadoInspeccion)
        {   
            ListadoInspeccion _listadoInspeccion = _mapper.Map<ListadoInspeccionDTO, ListadoInspeccion>(listadoInspeccion);
                 
            var result = _listadoInspeccionService.CreateListadoInspeccion(_listadoInspeccion);

            return CreatedAtRoute("GetListadoInspeccionById", new { IdListadoInspeccion = result.Id },null);            
        }

        /// <summary>
        /// Actualiza un ListadoInspeccion existente
        /// </summary>
        /// <param name="IdListadoInspeccion">ListadoInspeccion ID</param>
        /// <param name="listadoInspeccion">ListadoInspeccion</param>
        /// <returns>Retorna ListadosInspeccion actualizado</returns>
        /// <response code="200">El ListadoInspeccion es actualizado con  exito</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">El ListadoInspeccion con el id ingresado no es encontrado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPut()]
        [Route("{IdListadoInspeccion}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Put(Guid IdListadoInspeccion, [FromBody] ListadoInspeccionDTO listadoInspeccion)
        { 
            ListadoInspeccion _listadoInspeccion = _mapper.Map<ListadoInspeccionDTO, ListadoInspeccion>(listadoInspeccion); 
            _listadoInspeccionService.UpdateListadoInspeccion(_listadoInspeccion, IdListadoInspeccion);

            return Ok(); 
        }
        /// <summary>
        /// Retorna un Listado Inspeccion por Id
        /// </summary>
        /// <param name="IdListadoInspeccion">ListadoInspeccion id</param>
        /// <returns>Retorna un Listado Inspeccion</returns>
        /// <response code="200">Retorna un Listado Inspeccion por Id con exito</response>
        /// <response code="404">No se encuentra el ListadoInspeccion con el Id ListadoInspeccion enviado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet("{IdListadoInspeccion}", Name = "GetListadoInspeccionById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetListadoInspeccionById(Guid IdListadoInspeccion)
        {  
            var listadoInspeccion = _listadoInspeccionService.GetListadoInspeccionById(IdListadoInspeccion);

            return Ok(listadoInspeccion); 
        }
        /// <summary>
        /// Crea un ItemControl.
        /// </summary>
        /// <param name="IdListadoInspeccion"></param>
        /// <param name="IdListItemControl">List ItemControl Id</param> 
        /// <returns>Devuelve un ItemControl</returns>
        /// <response code="201">Crea el ItemControl con exito</response> 
        /// <response code="400">Bad request</response>
        /// <response code="404">El ListadoInspeccion al que se quiere agregar el ItemControl  no es encontrado</response>
        /// <response code="500">Error interno del servidor</response> 
        [HttpPost]
        [Route("{IdListadoInspeccion}/ItemsControl")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult AddItemsControl(Guid IdListadoInspeccion, [FromBody] List<int> IdListItemControl)
        { 
             _listadoInspeccionService.AddItemControlToListadoInspeccion(IdListadoInspeccion, IdListItemControl);
 
            return CreatedAtRoute("GetListadoInspeccionById", new { id = IdListadoInspeccion }, null);
        }

        /// <summary>
        /// Actualiza un ItemControl existente
        /// </summary>
        /// <param name="IdListadoInspeccion">ListadoInspeccion ID</param>
        /// <param name="request">ItemControl</param>
        /// <returns>Retorna ItemControl actualizado</returns>
        /// <response code="200">El ItemControl es actualizado con  exito</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">El ListadoInspeccion al que se quiere actualizar el ItemControl no es encontrado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPut()]
        [Route("{IdListadoInspeccion}/ItemsControl")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateItemControl(Guid IdListadoInspeccion, [FromBody] ItemControlDTO request)
        { 
            _listadoInspeccionService.UpdateItemControlInListadoInspeccion(request.Id , IdListadoInspeccion, request.orden); 

            return Ok();
        }     

    }
}