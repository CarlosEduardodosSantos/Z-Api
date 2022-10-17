using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Zip.Models
{
    public class Movimentacao
    {
        public int Nro { get; set; }
        public DateTime Data { get; set; }
        public string Quarto { get; set; }
        public string Hospede { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public int Diarias { get; set; }
        public float Valor { get; set; }
        public string Pgto { get; set; }
        public string Booking { get; set; }
        public string Obs { get; set; }
        public int HotelId { get; set; }
        public int QtdeAdultos { get; set; }
        public int QtdeCriancas { get; set; }
    }
}
