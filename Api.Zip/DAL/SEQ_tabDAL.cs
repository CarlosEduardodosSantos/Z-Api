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
    public class SEQ_tabDAL
    {
        private readonly IConfiguration _configuration;

        public SEQ_tabDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<SEQ_tabela> ObterUserPorTabela(string codigo)
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var login = conn
                    .Query<SEQ_tabela>("select * from SEQ_TABELA where TABELA = @codigo", new { codigo })
                    .ToList();
                conn.Close();

                return login;
            }

        }

        public List<SEQ_tabela> ObterTodos()
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var login = conn
                    .Query<SEQ_tabela>("select * from SEQ_TABELA order by COD_SEQ_TABELA")
                    .ToList();
                conn.Close();

                return login;
            }

        }

        public void Insert(SEQ_tabela SEQTAB)
        {
            var sql = "Insert Into SEQ_TABELA(TABELA, COLUNA, SEQUENCIA)" +
                      "Values (@TABELA, @COLUNA, @SEQUENCIA)";
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        TABELA = SEQTAB.TABELA,
                        COLUNA = SEQTAB.COLUNA,
                        SEQUENCIA = SEQTAB.SEQUENCIA
                    });
                conn.Close();
            }
        }

        public void Update(SEQ_tabela SEQTAB)
        {
            var sql = "Update SEQ_TABELA set COLUNA = @COLUNA, SEQUENCIA = @SEQUENCIA" +
                      " where TABELA = @TABELA";
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        TABELA = SEQTAB.TABELA,
                        COLUNA = SEQTAB.COLUNA,
                        SEQUENCIA = SEQTAB.SEQUENCIA
                    });
                conn.Close();
            }
        }

        public void Delete(int codigo)
        {
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query("Delete from SEQ_TABELA where COD_SEQ_TABELA = @COD_SEQ_TABELA",
                    new
                    {
                        COD_SEQ_TABELA = codigo
                    });
                conn.Close();
            }
        }
    }
}
