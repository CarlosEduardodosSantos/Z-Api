using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Zip.Models
{
    public class PROD
    {
        public int CODIGO { get; set; }
        public string DES_ { get; set; }
        public string GRUPO { get; set; }
        public float VLCUSTO { get; set; }
        public float VLVENDA { get; set; }
        public string TIPO { get; set; }
        public DateTime D_ATUAL { get; set; }
        public float VLCOMPRA { get; set; }
        public DateTime DTCAD { get; set; }
        public float VL_MEDIO { get; set; }
        public string prod_img { get; set; }
        public float QTDE1 { get; set; }
        public float Falta1 { get; set; }
        public float vlvenda_old { get; set; }
        public DateTime vlvenda_alt { get; set; }
        public bool Continuo { get; set; }
        public float Qtde_div1 { get; set; }
        public bool Bonificado { get; set; }
        public bool ImprimirCozinha { get; set; }
        public decimal vlentrega { get; set; }
        public float VLMESA { get; set; }
        public string ATIVO { get; set; }
        public bool USABALANCA { get; set; }
        public bool APLICA_SERVICO { get; set; }
        public int CLASSFISCAL_INC { get; set; }
        public int CSTPIS_ID { get; set; }
        public int CSTCOFINS_ID { get; set; }
        public string CSOSN { get; set; }
        public int DEPTO { get; set; }
        public int SECAO { get; set; }
        public float VLVENDA2 { get; set; }
        public int QtdeP { get; set; }
    }
}
