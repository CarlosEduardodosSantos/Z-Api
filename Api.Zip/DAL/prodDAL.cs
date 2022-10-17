using Api.Zip.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Zip.DAL
{
    public class prodDAL
    {
        private readonly IConfiguration _configuration;

        public prodDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<PROD> ObterUserPorCodigo(int Codigo)
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var login = conn
                    .Query<PROD>("select * from PROD where CODIGO = @Codigo", new { Codigo })
                    .ToList();
                conn.Close();

                return login;
            }

        }

        public List<PROD> ObterTodos()
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var login = conn
                    .Query<PROD>("select * from PROD order by DES_")
                    .ToList();
                conn.Close();

                return login;
            }

        }

        public void Insert(PROD prod)
        {
            var sql = "Insert Into PROD(CODIGO, DES_, GRUPO, VLCUSTO, VLVENDA, VLVENDA2,TIPO, D_ATUAL, DEPTO, SECAO, VLCOMPRA, DTCAD, VL_MEDIO, prod_img, " +
                                       "QTDE1, Falta1, vlvenda_old, vlvenda_alt, " +
                                       "Continuo, Qtde_div1, " +
                                       "Bonificado, ImprimirCozinha, vlentrega, VLMESA, ATIVO, USABALANCA, APLICA_SERVICO, CLASSFISCAL_INC, " +
                                       "CSTPIS_ID, CSTCOFINS_ID, CSOSN)" +
                      "Values (@CODIGO, @DES_, @GRUPO, @VLCUSTO, @VLVENDA, @VLVENDA2,@TIPO, @D_ATUAL, @DEPTO, @SECAO, @VLCOMPRA, @DTCAD, @VL_MEDIO, @prod_img, " +
                              "@QTDE1, @Falta1, @vlvenda_old, @vlvenda_alt, " +
                              "@Continuo, @Qtde_div1, " +
                              "@Bonificado, @ImprimirCozinha, @vlentrega, @VLMESA, @ATIVO, @USABALANCA, @APLICA_SERVICO, @CLASSFISCAL_INC, " +
                              "@CSTPIS_ID, @CSTCOFINS_ID, @CSOSN)";
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        CODIGO = prod.CODIGO,
                        DES_ = prod.DES_,
                        GRUPO = prod.GRUPO,
                        VLCUSTO = prod.VLCUSTO,
                        VLVENDA = prod.VLVENDA,
                        VLVENDA2 = prod.VLVENDA2,
                        TIPO = prod.TIPO,
                        D_ATUAL = DateTime.Now,
                        DEPTO = prod.DEPTO,
                        SECAO = prod.SECAO,
                        VLCOMPRA = prod.VLCOMPRA,
                        DTCAD = DateTime.Now,
                        VL_MEDIO = prod.VL_MEDIO,
                        prod_img = prod.prod_img,
                        QTDE1 = prod.QTDE1,
                        Falta1 = prod.Falta1,
                        vlvenda_old = prod.vlvenda_old,
                        vlvenda_alt = DateTime.Now,
                        Continuo = true,
                        Qtde_div1 = prod.Qtde_div1,
                        Bonificado = true,
                        ImprimirCozinha = true,
                        vlentrega = prod.vlentrega,
                        VLMESA = prod.VLMESA,
                        ATIVO = prod.ATIVO,
                        USABALANCA = true,
                        APLICA_SERVICO = true,
                        CLASSFISCAL_INC = prod.CLASSFISCAL_INC,
                        CSTPIS_ID = prod.CSTPIS_ID,
                        CSTCOFINS_ID = prod.CSTCOFINS_ID,
                        CSOSN = prod.CSOSN
                    });
                conn.Close();
            }
        }

        public void Update(PROD prod)
        {
            var sql = "Update PROD set DES_ = @DES_, GRUPO = @GRUPO, VLCUSTO = @VLCUSTO, VLVENDA = @VLVENDA, VLVENDA2 = @VLVENDA2, TIPO = @TIPO, D_ATUAL = @D_ATUAL, DEPTO = @DEPTO, SECAO = @SECAO, " +
                                       "VLCOMPRA = @VLCOMPRA, DTCAD = @DTCAD, VL_MEDIO = @VL_MEDIO, prod_img = @prod_img, " +
                                       "QTDE1 = @QTDE1, Falta1 = @Falta1, vlvenda_old = @vlvenda_old, " +
                                       "vlvenda_alt = @vlvenda_alt, " +
                                       "Continuo = @Continuo, Qtde_div1 = @Qtde_div1, " +
                                       "Bonificado = @Bonificado, ImprimirCozinha = @ImprimirCozinha, vlentrega = @vlentrega, VLMESA = @VLMESA, ATIVO = @ATIVO, USABALANCA = @USABALANCA, " +
                                       "APLICA_SERVICO = @APLICA_SERVICO, CLASSFISCAL_INC = @CLASSFISCAL_INC, " +
                                       "CSTPIS_ID = @CSTPIS_ID, CSTCOFINS_ID = @CSTCOFINS_ID, CSOSN = @CSOSN " +
                      " where CODIGO = @Codigo";
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        CODIGO = prod.CODIGO,
                        DES_ = prod.DES_,
                        GRUPO = prod.GRUPO,
                        VLCUSTO = prod.VLCUSTO,
                        VLVENDA = prod.VLVENDA,
                        VLVENDA2 = prod.VLVENDA2,
                        TIPO = prod.TIPO,
                        D_ATUAL = DateTime.Now,
                        DEPTO = prod.DEPTO,
                        SECAO = prod.SECAO,
                        VLCOMPRA = prod.VLCOMPRA,
                        DTCAD = DateTime.Now,
                        VL_MEDIO = prod.VL_MEDIO,
                        prod_img = prod.prod_img,
                        QTDE1 = prod.QTDE1,
                        Falta1 = prod.Falta1,
                        vlvenda_old = prod.vlvenda_old,
                        vlvenda_alt = DateTime.Now,
                        Continuo = true,
                        Qtde_div1 = prod.Qtde_div1,
                        Bonificado = true,
                        ImprimirCozinha = true,
                        vlentrega = prod.vlentrega,
                        VLMESA = prod.VLMESA,
                        ATIVO = prod.ATIVO,
                        USABALANCA = true,
                        APLICA_SERVICO = true,
                        CLASSFISCAL_INC = prod.CLASSFISCAL_INC,
                        CSTPIS_ID = prod.CSTPIS_ID,
                        CSTCOFINS_ID = prod.CSTCOFINS_ID,
                        CSOSN = prod.CSOSN
                    });
                conn.Close();
            }
        }

        public void Delete(int codigo)
        {
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query("Delete from PROD where CODIGO = @Codigo",
                    new
                    {
                        Codigo = codigo
                    });
                conn.Close();
            }
        }
    }
}