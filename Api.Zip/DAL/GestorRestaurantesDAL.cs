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
    public class GestorRestaurantesDAL
    {
        private readonly IConfiguration _configuration;

        public GestorRestaurantesDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<GestorRestaurante> ObterUserPorNomeSenha(string nome, string Senha)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                var prop = conn
                    .Query<GestorRestaurante>("select * from Restaurantes where usuarioMaster = @nome and senhaMaster = @Senha", new { nome, Senha })
                    .ToList();
                conn.Close();




                return prop;
            }

        }

        public List<ProdutosRestaurante> ObterProdPorGuid(string produtoGuid)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                var login = conn
                    .Query<ProdutosRestaurante>("select * from produtos where ProdutoGuid = @produtoGuid", new { produtoGuid })
                    .ToList();
                conn.Close();

                return login;
            }
        }


            public List<Categoria> ObterCategorias(int idRestaurante)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                var prop = conn
                    .Query<Categoria>("select * from Categorias where restauranteId = @idRestaurante", new { idRestaurante })
                    .ToList();
                conn.Close();




                return prop;
            }

        }

        public List<ProdutosRestaurante> ObterUserPorIdRestaurante(int idRestaurante)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                var prop = conn
                    .Query<ProdutosRestaurante>("select * from Produtos where restauranteId = @idRestaurante order by nome", new { idRestaurante })
                    .ToList();
                conn.Close();




                return prop;
            }

        }

        public void Delete(int produtoid)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                conn.Query("Delete from Produtos where produtoid = @Produtoid",
                    new
                    {
                        Produtoid = produtoid
                    });
                conn.Close();
            }
        }
    }
}
