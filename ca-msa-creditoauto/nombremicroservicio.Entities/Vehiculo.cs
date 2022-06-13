using System;
using System.Collections.Generic;

#nullable disable

namespace nombremicroservicio.Entities
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Creditos = new HashSet<Credito>();
        }

        public int VehIdVehiculo { get; set; }
        public string VehPlaca { get; set; }
        public int MarIdMarca { get; set; }
        public string VehModelo { get; set; }
        public string VehNumeroChasis { get; set; }
        public string VehTipo { get; set; }
        public string VehCilindraje { get; set; }
        public decimal VehAvaluo { get; set; }

        public virtual Marca MarIdMarcaNavigation { get; set; }
        public virtual ICollection<Credito> Creditos { get; set; }
    }
}
