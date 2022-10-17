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
    public class UsuariosDAL
    {
        private readonly IConfiguration _configuration;

        public UsuariosDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Usuarios> ObterUserPorSenha(string Nome, string Senha)
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var login = conn
                    .Query<Usuarios>("select * from Usuarios where Nome = @Nome and Senha = @Senha", new { Nome, Senha })
                    .ToList();
                conn.Close();

                return login;
            }

        }

        public List<Usuarios> ObterUserPorCodigo(int Codigo)
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var login = conn
                    .Query<Usuarios>("select * from Usuarios where Codigo = @Codigo", new { Codigo })
                    .ToList();
                conn.Close();

                return login;
            }

        }

        public List<Usuarios> ObterTodos()
        {

            using (var conn = new SqlConnection(
                   Strings.Conexao))
            {
                conn.Open();
                var login = conn
                    .Query<Usuarios>("select * from Usuarios order by nome")
                    .ToList();
                conn.Close();

                return login;
            }

        }

        public void Insert(Usuarios usuario)
        {
            var sql = "Insert Into Usuarios(Nome, Senha, Ativo, Role)" +
                      "Values (@Nome, @Senha, @Ativo, @Role)";
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        Nome = usuario.Nome,
                        Senha = usuario.Senha,
                        Ativo = usuario.Ativo,
                        Role = usuario.Role
                    });
                conn.Close();
            }
        }

        public void Update(Usuarios usuario)
        {
            var sql = "Update Usuarios set Nome = @Nome, Senha =@Senha, Ativo =@Ativo, Role =@Role" +
                      " where Codigo = @Codigo";
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        Codigo = usuario.Codigo,
                        Nome = usuario.Nome,
                        Senha = usuario.Senha,
                        Ativo = usuario.Ativo,
                        Role = usuario.Role
                    });
                conn.Close();
            }
        }

        public void Delete(int codigo)
        {
            using (var conn = new SqlConnection(Strings.Conexao))
            {
                conn.Open();
                conn.Query("Delete from Usuarios where Codigo = @Codigo",
                    new
                    {
                        Codigo = codigo
                    });
                conn.Close();
            }
        }


    }
}
