using System;

namespace Api.Zip.Models
{
    public class ReceitasPharma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Receita { get; set; }
        public string Receita2 { get; set; }
        public string Receita3 { get; set; }
        public string Receita4 { get; set; }
        public DateTime DataHora { get; set; }
        public int Status { get; set; }
    }
}
