using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using QualificationApp.Domain.Dtos;
using QualificationApp.Domain.Entity;
using QualificationApp.Domain.Interfaces.Parametro.Ocupacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QualificationApp.Api.Controllers
{
    [Route("api/ocupaciones")]
    [ApiController]
    [Authorize]
    //[ExceptionFilter]
    public class OcupacionController : ControllerBase
    {
        private readonly IOcupacionRepository _ocupacionRepository;
        public OcupacionController(IOcupacionRepository ocupacionRepository)
        {
            _ocupacionRepository = ocupacionRepository;
        }
        // GET: api/ocupaciones/1
        [HttpGet]
        public async Task<ActionResult> ListarOcupaciones()
        {
            var OcupacionItems = await _ocupacionRepository.ObtenerTodos();
            throw new InvalidOperationException();
            return Ok(OcupacionItems);
        }
        // GET: api/ocupaciones
        [HttpGet("{idOcupacion}")]
        public async Task<ActionResult> ListarOcupacion(int idOcupacion)
        {
            //var ocupacionItem = await _unitOfWork.Ocupaciones.AsyncObtenerPorId(idOcupacion);
            var ocupacionItem = await _ocupacionRepository.ObtenerPorId(idOcupacion);
            if (ocupacionItem != null)
            {
                return Ok(ocupacionItem);
            }
            return NotFound();
        }
        //POST api/ocupaciones/
        [HttpPost]
        public async Task<ActionResult> CrearOcupacion(OcupacionModel ocupacionModel)
        {
            var respuesta = await _ocupacionRepository.Agregar(ocupacionModel);
            int id = Int32.Parse(respuesta.Retorno1);
            if (respuesta.Resultado == 1)
            {
                //respuesta.StatusCode = this.StatusCode(StatusCodeResult);
                var ocupacionRead = await _ocupacionRepository.ObtenerPorId(id);
                respuesta.Data.Add(ocupacionRead);
            }
            return Ok(respuesta);
        }
        //POST api/ocupaciones/1
        [HttpPut("{idOcupacion}")]
        public async Task<ActionResult> Modificarcupacion(int idOcupacion, OcupacionModel ocupacionModel)
        {
            ocupacionModel.IdOcupacion = idOcupacion;
            var respuesta = await _ocupacionRepository.Modificar(ocupacionModel);
            if (respuesta.Resultado == 1)
            {
                var ocupacionRead = await _ocupacionRepository.ObtenerPorId(ocupacionModel.IdOcupacion);
                respuesta.Data.Add(ocupacionRead);
            }
            return Ok(respuesta);
        }
        //POST api/ocupaciones/1
        [HttpDelete("{idOcupacion}")]
        public async Task<ActionResult> EliminarOcupacion(int idOcupacion)
        {
            var respuesta = await _ocupacionRepository.Eliminar(idOcupacion);
            return Ok(respuesta);
        }
    }
}
