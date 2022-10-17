using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Zip.Models
{
    public class Strings
    {
        public string Cnpj { get; set; }
        public string ConString { get; set; }
        public int Tema { get; set; }

        private static string _ConString = "";
        public static string Conexao
        {
            get { return _ConString; }
            set { _ConString = value; }
        }
    }
}
