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
    public class ClienteDAL
    {
        private readonly IConfiguration _configuration;

        public ClienteDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Cliente> ObterUserPorCodigo(int Codigo)
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var login = conn
                    .Query<Cliente>("select * from CLIENTE where CODIGO = @Codigo", new { Codigo })
                    .ToList();
                conn.Close();

                return login;
            }

        }

        public List<Cliente> ObterTodos()
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var login = conn
                    .Query<Cliente>("select * from CLIENTE order by NOME")
                    .ToList();
                conn.Close();

                return login;
            }

        }

        public void Insert(Cliente cli)
        {
            var sql = "Insert Into CLIENTE(NOME, RG, FONE, ATIVO, CEP, ENDERECO, COMPLEMENTO, CPF, EMAIL, BAIRRO, UF, CIDADE, NumeroDaCasa, TIPO)" +
                           "Values (@NOME, @RG, @FONE, @ATIVO, @CEP, @ENDERECO, @COMPLEMENTO, @CPF, @EMAIL, @BAIRRO, @UF, @CIDADE, @NumeroDaCasa, @TIPO)";
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        NOME = cli.NOME,
                        RG = cli.RG,
                        FONE = cli.FONE,
                        ATIVO = cli.ATIVO,
                        CEP = cli.CEP,
                        ENDERECO = cli.ENDERECO,
                        COMPLEMENTO = cli.COMPLEMENTO,
                        CPF = cli.CPF,
                        EMAIL = cli.EMAIL,
                        BAIRRO = cli.BAIRRO,
                        UF = cli.UF,
                        CIDADE = cli.CIDADE,
                        NumeroDaCasa = cli.NumeroDaCasa,
                        TIPO = cli.TIPO
                    });
                conn.Close();
            }
        }

        public void Update(Cliente cli)
        {
            var sql = "Update CLIENTE set NOME = @NOME, RG = @RG, FONE = @FONE, ATIVO = @ATIVO, CEP = @CEP, ENDERECO = @ENDERECO, COMPLEMENTO = @COMPLEMENTO, " +
                      "CPF = @CPF, EMAIL = @EMAIL, BAIRRO = @BAIRRO, UF = @UF, CIDADE = @CIDADE, NumeroDaCasa = @NumeroDaCasa, TIPO = @TIPO " +
                      " where CODIGO = @Codigo";
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        CODIGO = cli.CODIGO,
                        NOME = cli.NOME,
                        RG = cli.RG,
                        FONE = cli.FONE,
                        ATIVO = cli.ATIVO,
                        CEP = cli.CEP,
                        ENDERECO = cli.ENDERECO,
                        COMPLEMENTO = cli.COMPLEMENTO,
                        CPF = cli.CPF,
                        EMAIL = cli.EMAIL,
                        BAIRRO = cli.BAIRRO,
                        UF = cli.UF,
                        CIDADE = cli.CIDADE,
                        NumeroDaCasa = cli.NumeroDaCasa,
                        TIPO = cli.TIPO
                    });
                conn.Close();
            }
        }

        public void Delete(int codigo)
        {
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query("Delete from CLIENTE where CODIGO = @Codigo",
                    new
                    {
                        Codigo = codigo
                    });
                conn.Close();
            }
        }
    }
}
