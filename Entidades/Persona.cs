using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RegistroPersona.Entidades
{
    public class Personas
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha_nacimiento { get; set; }

        public Personas()
        {
            ID = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            Fecha_nacimiento = DateTime.Now;
        }
    }
}