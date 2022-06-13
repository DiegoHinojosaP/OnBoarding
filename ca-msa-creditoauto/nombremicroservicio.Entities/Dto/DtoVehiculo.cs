namespace nombremicroservicio.Entities.Dto
{
    public class DtoVehiculo
    {
        public DtoVehiculo()
        {
            Marca = new DtoMarca();
        }

        public string VehPlaca { get; set; }
        public int MarIdMarca { get; set; }
        public string VehModelo { get; set; }
        public string VehNumeroChasis { get; set; }
        public string VehTipo { get; set; }
        public string VehCilindraje { get; set; }
        public decimal VehAvaluo { get; set; }
        public DtoMarca Marca { get; set; }
    }
}
