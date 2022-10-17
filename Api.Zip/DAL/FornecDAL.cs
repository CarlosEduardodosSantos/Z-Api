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
    public class FornecDAL
    {
        private readonly IConfiguration _configuration;

        public FornecDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Fornec> ObterUserPorCodigo(int Codigo)
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var login = conn
                    .Query<Fornec>("select * from Fornec where CODIGO = @Codigo", new { Codigo })
                    .ToList();
                conn.Close();

                return login;
            }

        }

        public List<Fornec> ObterTodos()
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var login = conn
                    .Query<Fornec>("select * from Fornec order by NOME")
                    .ToList();
                conn.Close();

                return login;
            }

        }

        public void Insert(Fornec fornec)
        {
            var sql = "Insert Into Fornec(NOME, NomeFantasia, CNPJ, ENDERECO, Complemento, CEP, CIDADE, BAIRRO, UF, FONE1, FONE2, RAMAL1, RAMAL2, CGC, IE, OBS, END_NUM, END_COMP, email, Ativo, TIPO)" +
                      "Values (@NOME, @NomeFantasia, @CNPJ, @ENDERECO, @Complemento, @CEP, @CIDADE, @BAIRRO, @UF, @FONE1, @FONE2, @RAMAL1, @RAMAL2, @CGC, @IE, @OBS, @END_NUM, @END_COMP, @email, @Ativo, @TIPO)";
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        NOME = fornec.NOME,
                        NomeFantasia = fornec.NomeFantasia,
                        CNPJ = fornec.CNPJ,
                        ENDERECO = fornec.ENDERECO,
                        Complemento = fornec.Complemento,
                        CEP = fornec.CEP,
                        CIDADE = fornec.CIDADE,
                        BAIRRO = fornec.BAIRRO,
                        UF = fornec.UF,
                        FONE1 = fornec.FONE1,
                        FONE2 = fornec.FONE2,
                        RAMAL1 = fornec.RAMAL1,
                        RAMAL2 = fornec.RAMAL2,
                        CGC = fornec.CGC,
                        IE = fornec.IE,
                        OBS = fornec.OBS,
                        END_NUM = fornec.END_NUM,
                        END_COMP = fornec.END_COMP,
                        email = fornec.email,
                        Ativo = fornec.Ativo,
                        TIPO = fornec.TIPO
                    });
                conn.Close();
            }
        }

        public void Update(Fornec fornec)
        {
            var sql = "Update Fornec set NOME = @NOME, NomeFantasia = @NomeFantasia, CNPJ = @CNPJ, ENDERECO = @ENDERECO, Complemento = @Complemento, CEP = @CEP, CIDADE = @CIDADE, BAIRRO = @BAIRRO, UF = @UF, FONE1 = @FONE1," +
                                       " FONE2 = @FONE2, RAMAL1 = @RAMAL1, RAMAL2 = @RAMAL2, CGC = @CGC, IE = @IE, OBS = @OBS, END_NUM = @END_NUM, END_COMP = @END_COMP, email = @email, Ativo = @Ativo, TIPO = @TIPO" +
                      " where CODIGO = @Codigo";
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        CODIGO = fornec.CODIGO,
                        NOME = fornec.NOME,
                        NomeFantasia = fornec.NomeFantasia,
                        CNPJ = fornec.CNPJ,
                        ENDERECO = fornec.ENDERECO,
                        Complemento = fornec.Complemento,
                        CEP = fornec.CEP,
                        CIDADE = fornec.CIDADE,
                        BAIRRO = fornec.BAIRRO,
                        UF = fornec.UF,
                        FONE1 = fornec.FONE1,
                        FONE2 = fornec.FONE2,
                        RAMAL1 = fornec.RAMAL1,
                        RAMAL2 = fornec.RAMAL2,
                        CGC = fornec.CGC,
                        IE = fornec.IE,
                        OBS = fornec.OBS,
                        END_NUM = fornec.END_NUM,
                        END_COMP = fornec.END_COMP,
                        email = fornec.email,
                        Ativo = fornec.Ativo,
                        TIPO = fornec.TIPO
                    });
                conn.Close();
            }
        }

        public void Delete(int codigo)
        {
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query("Delete from Fornec where CODIGO = @Codigo",
                    new
                    {
                        Codigo = codigo
                    });
                conn.Close();
            }
        }
    }
}
