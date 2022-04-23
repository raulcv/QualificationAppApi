using QualificationApp.Domain.Dtos;
using QualificationApp.Domain.Entity;
using QualificationApp.Domain.Interfaces.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QualificationApp.Domain.Interfaces.Parametro.Usuario
{
    public interface IUsuarioRepository : IGenericRepository<UsuarioModel, UsuarioDto>
    {
        public Task<UsuarioModel> ObtenerUsuarioPorEmail(string usuario);

    }
}
