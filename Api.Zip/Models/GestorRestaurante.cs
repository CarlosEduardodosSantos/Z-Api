using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Zip.Models
{
    public class GestorRestaurante
    {
        public int restauranteId { get; set; }
        public string nome { get;set; }
        public string usuarioMaster { get; set; }
        public string senhaMaster { get; set; }
        public string grupo { get; set; }
        public string imagem { get; set; }
        public Guid token { get; set; }
    }

    public class ProdutosRestaurante
    {
        public int ProdutoId { get; set; }
        public Guid ProdutoGuid { get; set; }
        public int Situacao { get; set; }
        public float AvaliacaoRating { get; set; }
        public int CategoriaId { get; set; }
        public int NumberMeiomeio { get; set; }
        public bool IsPartMeioMeio { get; set; }
        public int TamanhoId { get; set; }
        public bool IsControlstock { get; set; }
        public int Stock { get; set; }
        public int referenciaId { get; set; }
        public int restauranteId { get; set; }
        public string nome { get; set; }
        public decimal valorVenda { get; set; }
        public decimal valorRegular { get; set; }
        public decimal valorPromocao { get; set; }
        public string imagem { get; set; }
        public int tamanho { get; set; }
        public string descricao { get; set; }
    }
}
