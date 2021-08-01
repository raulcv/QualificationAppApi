using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QualificationApp.Domain.Dtos;
using QualificationApp.Domain.Entity;
using QualificationApp.Domain.Interfaces.Parametro.Pais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QualificationApp.Api.Controllers
{
    [Route("api/paises")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly IPaisRepository _paisRepository;
        //private readonly IMapper _mapper;
        public PaisController(IPaisRepository paisRepo/*, IMapper mapper*/)
        {
            _paisRepository = paisRepo;
            //_mapper = mapper;
        }
        // GET: api/paises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisDto>>> ListarPaises()
        {
            var PaisItems = await _paisRepository.ListarPaises();
            return Ok(PaisItems);
        }
        // GET: api/paises/2
        [HttpGet("{idPais}", Name = "ObtenerPaisPorId")]
        public async Task<ActionResult<IEnumerable<PaisDto>>> ObtenerPaisPorId(int idPais)
        {
            var PaisItem = await _paisRepository.ObtenerPaisPorId(idPais);
            if (PaisItem != null)
            {
                return Ok(PaisItem);
            }
            return NotFound();
        }
        //POST api/paises/
        [HttpPost]
        public async Task<ActionResult<PaisDto>> CreaarPais(PaisModel paisModel)
        {
            PaisRespuesta paisRespuesta = new PaisRespuesta();
            var respuesta = await _paisRepository.CrearPais(paisModel);
            int idPais = Int32.Parse(respuesta.Retorno1);
            if (respuesta.Resultado == 1)
            {
                var paisRead = _paisRepository.ObtenerPaisPorId(idPais);
                paisRespuesta.paisData.Add(paisRead.Result);
            }
            paisRespuesta.Resultado = respuesta.Resultado;
            paisRespuesta.Mensaje = respuesta.Mensaje;
            return Ok(paisRespuesta);
        }

        //PuT api/paises/1
        [HttpPut("{idPais}")]
        public async Task<ActionResult> ModificarPais(int idPais, PaisModel paisCrearDto)
        {
            PaisRespuesta paisRespuesta = new PaisRespuesta();
            paisCrearDto.IdPais = idPais;
            var respuesta = await _paisRepository.ModificarPais(paisCrearDto);
            if (respuesta.Resultado == 1)
            {
                var paisRead = _paisRepository.ObtenerPaisPorId(idPais);
                paisRespuesta.paisData.Add(paisRead.Result);
            }
            paisRespuesta.Resultado = respuesta.Resultado;
            paisRespuesta.Mensaje = respuesta.Mensaje;
            return Ok(paisRespuesta);
        }
        //DELETE api/paises/1
        [HttpDelete("{idPais}")]
        public async Task<ActionResult> EliminarPais(int idPais)
        {
            var respuesta = await _paisRepository.EliminarPais(idPais);
            return Ok(respuesta);
        }
    }
}
