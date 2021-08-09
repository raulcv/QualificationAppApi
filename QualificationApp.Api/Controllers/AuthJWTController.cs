using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QualificationApp.Domain.Base;
using QualificationApp.Domain.Entity;
using QualificationApp.Domain.Interfaces.Parametro.Usuario;
using QualificationApp.Domain.Interfaces.Shared;
using QualificationApp.Infrastructure.BDContext;
using QualificationApp.Utilities.Helper;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace QualificationApp.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthJWTController : ControllerBase
    {
        private readonly ILogger<AuthJWTController> _logger;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IJwtAuthenticationService _authService;
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        public AuthJWTController(ILogger<AuthJWTController> logger, IJwtAuthenticationService authService, IUsuarioRepository usuarioRepository, AppDbContext appDbContext, IConfiguration configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authService = authService;
            _usuarioRepository = usuarioRepository;
            _appDbContext = appDbContext;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpGet]
        public object Get()
        {
            var responseObject = new { Status = "Running" };
            _logger.LogInformation($"Status: {responseObject.Status}");

            return responseObject;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthModel authModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorHelper.GetModelStateErrors(ModelState));
            }
            
             //UsuarioModel usuarioModel = await _appDbContext.Usuarios.Where(x => x.Email == authModel.Username).FirstOrDefaultAsync();
            UsuarioModel usuarioModel = await _usuarioRepository.ObtenerUsuarioPorEmail(authModel.Usuario);

            if (usuarioModel == null)
            {
                return NotFound(ErrorHelper.Response(404, "Usuario no encotrado"));
            }

            //if (HashHelper.CheckHash(authModel.Password, usuarioModel.Password, usuarioModel.Salt))
            //{
            //    var secretKey = _configuration.GetValue<string>("SecretKey");
            //    var key = Encoding.ASCII.GetBytes(secretKey);

            //    var claims = new ClaimsIdentity();
            //    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, authModel.Usuario));

            //    var tokenDescriptor = new SecurityTokenDescriptor
            //    {
            //        Subject = claims,
            //        Expires = DateTime.UtcNow.AddHours(4),
            //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //    };

            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            //    string bearerToken = tokenHandler.WriteToken(createdToken);
            //    return Ok(bearerToken);
            //}
            //else
            //{
            //    return Forbid();
            //}

            var token = _authService.Authentication(authModel.Usuario, authModel.Password, usuarioModel.Password, usuarioModel.Salt);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

    }
}
