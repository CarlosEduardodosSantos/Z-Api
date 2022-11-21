using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Zip.Models
{
    public class Cliente
    {
        public int CODIGO { get; set; }
        public string NOME { get; set; }
        public string RG { get; set; }
        public string FONE1 { get; set; }
        public string ATIVO { get; set; }
        public string UF { get; set; }
        public string CIDADE { get; set; }
        public string CEP { get; set; }
        public string ENDERECO { get; set; }
        public string BAIRRO { get; set; }
        public string COMPLEMENTO { get; set; }
        public string CPF { get; set; }
        public string EMAIL { get; set; }
        public string NumeroDaCasa { get; set; }
        public string TIPO { get; set; }

    }
}
