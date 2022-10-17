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
    public class TAB_tipoDAL
    {
        private readonly IConfiguration _configuration;

        public TAB_tipoDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<TAB_TIPO> ObterUserPorCodigo(string Codigo)
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var login = conn
                    .Query<TAB_TIPO>("select * from TAB_TIPO where TIPO = @Codigo", new { Codigo })
                    .ToList();
                conn.Close();

                return login;
            }

        }

        public List<TAB_TIPO> ObterTodos()
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var login = conn
                    .Query<TAB_TIPO>("select * from TAB_TIPO order by TIPO")
                    .ToList();
                conn.Close();

                return login;
            }

        }

        public void Insert(TAB_TIPO TABTIPO)
        {
            var sql = "Insert Into TAB_TIPO(TIPO, DES_)" +
                           "Values (@TIPO, @DES_)";
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        TIPO = TABTIPO.TIPO,
                        DES_ = TABTIPO.DES_
                    });
                conn.Close();
            }
        }

        public void Delete(string codigo)
        {
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query("Delete from TAB_TIPO where TIPO = @Codigo",
                    new
                    {
                        Codigo = codigo
                    });
                conn.Close();
            }
        }
    }
}
