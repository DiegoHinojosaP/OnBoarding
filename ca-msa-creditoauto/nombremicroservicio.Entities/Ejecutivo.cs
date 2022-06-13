using System;
using System.Collections.Generic;

#nullable disable

namespace nombremicroservicio.Entities
{
    public partial class Ejecutivo
    {
        public Ejecutivo()
        {
            Creditos = new HashSet<Credito>();
        }

        public int EjeIdEjecutivo { get; set; }
        public int PatIdPatio { get; set; }
        public string EjeIdentificacion { get; set; }
        public string EjeNombres { get; set; }
        public string EjeApellidos { get; set; }
        public string EjeDireccion { get; set; }
        public string EjeTelefonoConvencional { get; set; }
        public string EjeCelular { get; set; }
        public int EjeEdad { get; set; }

        public virtual Patio PatIdPatioNavigation { get; set; }
        public virtual ICollection<Credito> Creditos { get; set; }
    }
}
