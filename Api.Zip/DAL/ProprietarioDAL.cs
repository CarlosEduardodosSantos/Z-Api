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
    public class ProprietarioDAL
    {
        private readonly IConfiguration _configuration;

        public ProprietarioDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Proprietario> ObterTodos()
        {

            using (SqlConnection conn = new SqlConnection(
                _configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                var str = conn
                    .Query<Proprietario>("select * from Proprietario")
                    .ToList();
                conn.Close();

                return str;
            }

        }

        public List<Proprietario> ObterPropPorId(int Nro)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                var prop = conn
                    .Query<Proprietario>("select * from Proprietario where Nro = @Nro", new { Nro })
                    .ToList();
                conn.Close();

                return prop;
            }

        }

        public List<Proprietario> ObterUserPorSenha(string Nome, string Senha)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                var login = conn
                    .Query<Proprietario>("select * from Proprietario where Login = @Nome and Senha = @Senha", new { Nome, Senha })

                    .ToList();
                conn.Close();

                return login;
            }

        }

        public void Insert(Proprietario prop)
        {
            var sql = "Insert Into Proprietario(Nome, Fone, Login, Senha, isAdmin)" +
                      "Values (@Nome, @Fone, @Login, @Senha, @isAdmin)";
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        Nome = prop.Nome,
                        Fone = prop.Fone,
                        Login = prop.Login,
                        Senha = prop.Senha,
                        isAdmin = prop.isAdmin,
                    });
                conn.Close();
            }
        }

        public void Update(Proprietario prop)
        {
            var sql = "Update Proprietario set Nome = @Nome, Fone =@Fone, Login=@Login,Senha =@Senha, isAdmin =@isAdmin " +
                      " where Nro = @Nro";
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        Nro = prop.Nro,
                        Nome = prop.Nome,
                        Fone = prop.Fone,
                        Login = prop.Login,
                        Senha = prop.Senha,
                        isAdmin = prop.isAdmin,
                    });
                conn.Close();
            }
        }

        public void Delete(int Nro)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                conn.Query("Delete from Proprietario where Nro = @Nro",
                    new
                    {
                        Nro = Nro
                    });
                conn.Close();
            }
        }
    }
}

