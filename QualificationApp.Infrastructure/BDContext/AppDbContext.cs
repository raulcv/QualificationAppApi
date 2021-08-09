using Microsoft.EntityFrameworkCore;
using QualificationApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualificationApp.Infrastructure.BDContext
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }

    }
}
