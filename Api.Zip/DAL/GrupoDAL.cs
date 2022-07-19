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
    public class GrupoDAL
    {
        private readonly IConfiguration _configuration;

        public GrupoDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Grupo> ObterUserPorCodigo(int GRUPO)
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var login = conn
                    .Query<Grupo>("select * from GRUPO where GRUPO = @GRUPO", new { GRUPO })
                    .ToList();
                conn.Close();

                return login;
            }

        }

        public List<Grupo> ObterTodos()
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var login = conn
                    .Query<Grupo>("select * from GRUPO order by DES_")
                    .ToList();
                conn.Close();

                return login;
            }

        }

        public void Insert(Grupo grupo)
        {
            var sql = "Insert Into GRUPO(DES_)" +
                      "Values (@DES_)";
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        DES_ = grupo.DES_
                    });
                conn.Close();
            }
        }

        public void Update(Grupo grupo)
        {
            var sql = "Update GRUPO set DES_ = @DES_ " +
                      " where GRUPO = @GRUPO";
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        GRUPO = grupo.GRUPO,
                        DES_ = grupo.DES_
                    });
                conn.Close();
            }
        }

        public void Delete(int grupo)
        {
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query("Delete from GRUPO where GRUPO = @GRUPO",
                    new
                    {
                        GRUPO = grupo
                    });
                conn.Close();
            }
        }
    }
}
