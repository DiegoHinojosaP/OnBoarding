using System;
using System.Collections.Generic;

#nullable disable

namespace nombremicroservicio.Entities
{
    public partial class Marca
    {
        public Marca()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int MarIdMarca { get; set; }
        public string MarNombre { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
