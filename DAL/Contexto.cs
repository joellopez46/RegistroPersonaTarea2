using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RegistroPersona.Entidades;

namespace Registro.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Persona> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         //   optionsBuilder.UseSqlServer(@"server = DESKTOP-1234567/SQLEXPRESS; database = personaDB; trusted_connection = true; ");
        }
    }
}
