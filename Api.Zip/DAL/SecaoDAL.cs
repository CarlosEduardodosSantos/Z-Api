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
    public class SecaoDAL
    {
        private readonly IConfiguration _configuration;

        public SecaoDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Secao> ObterUserPorCodigo(int Codigo)
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var secao = conn
                    .Query<Secao>("select * from Secao where Codigo = @Codigo", new { Codigo})
                    .ToList();
                conn.Close();

                return secao;
            }

        }

        public List<Secao> ObterTodos()
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var secao = conn
                    .Query<Secao>("select * from Secao order by DES_")
                    .ToList();
                conn.Close();

                return secao;
            }

        }

        public void Insert(Secao secao)
        {
            var sql = "Insert Into Secao(CODIGO, DES_)" +
                      "Values (@CODIGO, @DES_)";
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        CODIGO = secao.Codigo,
                        DES_ = secao.DES_
                    });
                conn.Close();
            }
        }

        public void Update(Secao secao)
        {
            var sql = "Update Secao set DES_ = @DES_ " +
                      " where Codigo = @Codigo";
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        Codigo = secao.Codigo,
                        DES_ = secao.DES_
                    });
                conn.Close();
            }
        }

        public void Delete(int codigo)
        {
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query("Delete from Secao where Codigo = @Codigo",
                    new
                    {
                        Codigo = codigo
                    });
                conn.Close();
            }
        }
    }
}
