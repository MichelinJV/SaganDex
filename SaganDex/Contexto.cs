using Microsoft.EntityFrameworkCore;
using SaganDex.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaganDex
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Usuarios> USUARIOS { get; set; }
        public DbSet<Estrelas> ESTRELAS { get; set; }
        public DbSet<ExoPlanetas> EXOPLANETAS { get; set; }
    }
}
