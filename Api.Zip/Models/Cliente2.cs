using System;

namespace Api.Zip.Models
{
    public class Cliente2
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public DateTime dtnasc { get; set; }
        public string convenio { get; set; }
        public string atacado { get; set; }
        public string ativo { get; set; }
        public string razao { get; set; }
        public string endereco { get; set; }
        public int end_num { get; set; }
        public string end_comp { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string cep { get; set; }
        public string rg { get; set; }
        public string cic { get; set; }
        public string ie { get; set; }
        public string fone1 { get; set; }
        public string codconv { get; set; }
        //Empresa = CODCONV* Este você pega as informações da tabela TAB_CONV - É um cadastro de convenio*
        public string email { get; set; }
        public float vlmax { get; set; }
        public float desconto { get; set; }
        public string senha_prazo { get; set; }
        public int diavenc { get; set; }
        public string id { get; set; }
        public int cod_fidelidade { get; set; }
        public string inscmunicipal { get; set; }
        public int regime_trib { get; set; }
        public bool consfinal { get; set; }
        public DateTime dtcad = DateTime.Now;
        public DateTime dtcompra { get; set; }
        public int qtde_ref_diaria { get; set; }


    }
}
