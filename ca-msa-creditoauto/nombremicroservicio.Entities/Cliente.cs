using System;
using System.Collections.Generic;

#nullable disable

namespace nombremicroservicio.Entities
{
    public partial class Cliente
    {
        public Cliente()
        {
            Asignacions = new HashSet<Asignacion>();
            Creditos = new HashSet<Credito>();
        }

        public int CliIdCliente { get; set; }
        public string CliIdentificacion { get; set; }
        public string CliNombres { get; set; }
        public string CliApellidos { get; set; }
        public int? CliEdad { get; set; }
        public DateTime? CliFechaNacimiento { get; set; }
        public string CliDireccion { get; set; }
        public string CliTelefono { get; set; }
        public string CliEstadoCivil { get; set; }
        public string CliIdentificacionConyugue { get; set; }
        public string CliNombreConyugue { get; set; }
        public bool? CliSujetoCredito { get; set; }

        public virtual ICollection<Asignacion> Asignacions { get; set; }
        public virtual ICollection<Credito> Creditos { get; set; }
    }
}
