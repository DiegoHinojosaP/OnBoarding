using System;
using System.Collections.Generic;

#nullable disable

namespace nombremicroservicio.Entities
{
    public partial class Patio
    {
        public Patio()
        {
            Asignacions = new HashSet<Asignacion>();
            Creditos = new HashSet<Credito>();
            Ejecutivos = new HashSet<Ejecutivo>();
        }

        public int PatIdPatio { get; set; }
        public string PatNombre { get; set; }
        public string PatDireccion { get; set; }
        public string PatTelefono { get; set; }
        public int PatPuntoVente { get; set; }

        public virtual ICollection<Asignacion> Asignacions { get; set; }
        public virtual ICollection<Credito> Creditos { get; set; }
        public virtual ICollection<Ejecutivo> Ejecutivos { get; set; }
    }
}
