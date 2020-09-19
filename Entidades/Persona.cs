using System;
using System.ComponentModel.DataAnnotations;

namespace Registro_Completo.Entidades{

    public class Persona{
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public double Telefono { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }

    }
}