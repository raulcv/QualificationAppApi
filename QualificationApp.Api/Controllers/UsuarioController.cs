using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QualificationApp.Domain.Entity;
using QualificationApp.Domain.Interfaces.Parametro.Usuario;
using QualificationApp.Utilities.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QualificationApp.Api.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        // GET: api/usuarios/1
        [HttpGet]
        public async Task<ActionResult> ListarUsuarios()
        {
            var OcupacionItems = await _usuarioRepository.ObtenerTodos();
            return Ok(OcupacionItems);
        }
        // GET: api/usuarios
        [HttpGet("{idUsuario}")]
        public async Task<ActionResult> ListarUsuario(int idUsuario)
        {
            var result = await _usuarioRepository.ObtenerPorId(idUsuario);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        //POST api/usuarios/
        [HttpPost]
        public async Task<ActionResult> CrearUsuario(UsuarioModel usuarioModel)
        {
            HashedPassword Password = HashHelper.Hash(usuarioModel.Password);
            usuarioModel.Password = Password.Password;
            usuarioModel.Salt = Password.Salt;
            var respuesta = await _usuarioRepository.Agregar(usuarioModel);
            int id = Int32.Parse(respuesta.Retorno1);
            if (respuesta.Resultado == 1)
            {
                var dataRead = await _usuarioRepository.ObtenerPorId(id);
                respuesta.Data.Add(dataRead);
            }
            return Ok(respuesta);
        }
        //POST api/usuarios/1
        [HttpPut("{idUsuario}")]
        public async Task<ActionResult> ModificarUsuario(int idUsuario, UsuarioModel usuarioModel)
        {
            usuarioModel.IdUsuario = idUsuario;
            var respuesta = await _usuarioRepository.Modificar(usuarioModel);
            if (respuesta.Resultado == 1)
            {
                var dataRead = await _usuarioRepository.ObtenerPorId(usuarioModel.IdUsuario);
                respuesta.Data.Add(dataRead);
            }
            return Ok(respuesta);
        }
        //POST api/usuarios/1
        [HttpDelete("{idUsuario}")]
        public async Task<ActionResult> EliminarUsuario(int idUsuario)
        {
            var respuesta = await _usuarioRepository.Eliminar(idUsuario);
            return Ok(respuesta);
        }
    }
}
