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
    public class UsuariosGestorDAL
    {
        private readonly IConfiguration _configuration;

        public UsuariosGestorDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<UsuariosGestor> ObterTodos()
        {

            using (SqlConnection conn = new SqlConnection(
                _configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                var str = conn
                    .Query<UsuariosGestor>("select * from Users")
                    .ToList();
                conn.Close();

                return str;
            }

        }

        public List<UsuariosGestor> ObterUserPorNomeSenha(string nome, string Senha)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                var prop = conn
                    .Query<UsuariosGestor>("select * from Users where nome = @nome and Senha = @Senha", new { nome, Senha })
                    .ToList();
                conn.Close();

                return prop;
            }

        }

        public List<UsuariosGestor> ObterUsuPorID(Guid UserID)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                var prop = conn
                    .Query<UsuariosGestor>("select * from Users where UserID = @UserID", new { UserID })
                    .ToList();
                conn.Close();

                return prop;
            }

        }
        public void Insert(UsuariosGestor users)
        {

            var sql = "Insert Into Users(UserID, AccessKey, nome, Senha, email, fone)" +
                      "Values (@UserID, @AcessKey, @nome, @Senha, @email, @fone)";
            using (var conn = new SqlConnection(_configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        UserID = Guid.NewGuid(),
                        AcessKey = " ",
                        nome = users.nome,
                        Senha = users.Senha,
                        email = users.email,
                        fone = users.fone
                    });
                conn.Close();
            }
        }

        public void Update(UsuariosGestor users)
        {
            var sql = "Update Users set nome =@nome, Senha =@Senha, email =@email" +
                      " where UserID = @UserID";
            using (var conn = new SqlConnection(_configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        UserID = users.UserID,
                        nome = users.nome,
                        Senha = users.Senha,
                        email = users.email
                    });
                conn.Close();
            }
        }

        public void Delete(Guid UserID)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                conn.Query("Delete from Users where UserID = @UserID",
                    new
                    {
                        UserID = UserID
                    });
                conn.Close();
            }
        }
    }
}
