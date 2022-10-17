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
    public class DeptoDAL
    {
        private readonly IConfiguration _configuration;

        public DeptoDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Depto> ObterUserPorCodigo(int Codigo)
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var depto = conn
                    .Query<Depto>("select * from Depto where CODIGO = @Codigo", new { Codigo })
                    .ToList();
                conn.Close();

                return depto;
            }

        }

        public List<Depto> ObterTodos()
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var depto = conn
                    .Query<Depto>("select * from Depto order by des_")
                    .ToList();
                conn.Close();

                return depto;
            }

        }

        public void Insert(Depto depto)
        {
            var sql = "Insert Into Depto(Codigo, Des_)" +
                           "Values (@Codigo, @Des_)";
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        Codigo = depto.Codigo,
                        Des_ = depto.Des_

                    });
                conn.Close();
            }
        }

        public void Update(Depto depto)
        {
            var sql = "Update Depto set Des_ = @Des_" +
                      " where CODIGO = @Codigo";
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        Codigo = depto.Codigo,
                        Des_ = depto.Des_,
                    });
                conn.Close();
            }
        }

        public void Delete(int codigo)
        {
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query("Delete from Depto where CODIGO = @Codigo",
                    new
                    {
                        Codigo = codigo
                    });
                conn.Close();
            }
        }
    }
}
