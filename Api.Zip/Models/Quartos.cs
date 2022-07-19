namespace Api.Zip.Models
{
    public class Quartos
    {
        public int Nro { get; set; }
        public int id_prop { get; set; }
        public string Hotel { get; set; }
        public string Quarto { get; set; }
        public decimal Valor_limpeza { get; set; }
        public decimal Valor_condominio { get; set; }
        public string Obs { get; set; }
        public string Status { get; set; }
        public int HotelId { get; set; }
    }
}
