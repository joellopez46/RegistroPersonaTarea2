using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RegistroPersona.Entidades
{
    public class Persona
    {
        [Key]

        public int ID { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string cedula { get; set; }
        public string direccion { get; set; }
        public DateTime fecha_nacimiento { get; set; }

        public Persona()
        {
            ID = 0;
            nombre = string.Empty;
            telefono = string.Empty;
            cedula = string.Empty;
            direccion = string.Empty;
            fecha_nacimiento = DateTime.Now;
        }
    }
}
