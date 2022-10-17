using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Zip.Models
{
    public class Fornec
    {
        public int CODIGO { get; set; }
        public string NOME { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string IE { get; set; }
        public string FONE1 { get; set; }
        public string FONE2 { get; set; }
        public string email { get; set; }
        public string CEP { get; set; }
        public string ENDERECO { get; set; }
        public string Complemento { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string UF { get; set; }
        public string RAMAL1 { get; set; }
        public string RAMAL2 { get; set; }
        public string CGC { get; set; }
        public string OBS { get; set; }
        public int END_NUM { get; set; }
        public string END_COMP { get; set; }
        public string Ativo { get; set; }
        public string TIPO { get; set; }
    }
}
