using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Zip.Models
{
    public class Categoria
    {
        public int categoriaId { get; set; }
        public int restauranteId { get; set; }
        public int referenciaId { get; set; }
        public string descricao { get; set; }
        public Guid restauranteToken { get; set; }
        public int situacao { get; set; }
        public int sequencia { get; set; }
    }
}
