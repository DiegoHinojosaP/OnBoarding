using System;
using System.Collections.Generic;
using System.Text;

namespace nombremicroservicio.Entities.Dto
{
    public class DtoCliente
    {
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
    }
}
