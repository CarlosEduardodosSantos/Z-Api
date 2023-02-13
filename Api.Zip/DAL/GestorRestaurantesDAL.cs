using Api.Zip.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

        //
        /// Tipos
        //

        public IEnumerable<ProdTiposGestor> ObterTiposPorprodutosOpcaoTipoId(int produtosOpcaoTipoId)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("VipFood")))
            {
                var sqlTp1 = new StringBuilder();
                sqlTp1.AppendLine("Select ProdutosOpcaoTipos.*, ProdutosOpcoes.* From ProdutosOpcaoTipos");
                sqlTp1.AppendLine("Left Join ProdutosOpcoes On ProdutosOpcaoTipos.ProdutosOpcaoTipoId = ProdutosOpcoes.ProdutosOpcaoTipoId");
                sqlTp1.AppendLine("Where ProdutosOpcaoTipos.produtosOpcaoTipoId = @produtosOpcaoTipoId");
                conn.Open();

                var lookup = new Dictionary<int, ProdTiposGestor>();
                conn.Query<ProdTiposGestor, produtoOpcao, ProdTiposGestor>(sqlTp1.ToString(),
                    (p1, p2) =>
                    {
                        ProdTiposGestor shop;
                        if (!lookup.TryGetValue(p1.ProdutosOpcaoTipoId, out shop))
                        {
                            lookup.Add(p1.ProdutosOpcaoTipoId, shop = p1);
                        }


                        if (shop.ProdutoOpcaos == null)
                            shop.ProdutoOpcaos = new List<produtoOpcao>();
                        if (p2 != null)
                            shop.ProdutoOpcaos.Add(p2);

                        return shop;

                    }, new { produtosOpcaoTipoId } , splitOn: "ProdutosOpcaoTipoId, ProdutosOpcaoId").AsQueryable();
                var resultList = lookup.Values;

                conn.Close();

                return resultList;
            }
        }

        public List<produtoOpcao> ObterProdOpcaoPorGuid(string ProdutosOpcaoGuid)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                var login = conn
                    .Query<produtoOpcao>("select * from ProdutosOpcoes where ProdutosOpcaoId = @ProdutosOpcaoGuid", new { ProdutosOpcaoGuid })
                    .ToList();
                conn.Close();

                return login;
            }
        }

        public void DeleteTipos(int ProdutosOpcaoTipoId)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                conn.Query("delete from ProdutosOpcoes where produtosOpcaoTipoId = @produtosOpcaoTipoId " +
                           "delete from ProdutosOpcaoTipos where produtosOpcaoTipoId = @produtosOpcaoTipoId",
                    new
                    {
                        produtosOpcaoTipoId = ProdutosOpcaoTipoId
                    });
                conn.Close();
            }
        }

        public void DeleteRelacao(Guid produtosOpcaoId)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                conn.Query("Delete from ProdutosOpcaoTipoRelacao where ProdutosOpcaoId = @ProdutosOpcaoId",
                    new
                    {
                        ProdutosOpcaoId = produtosOpcaoId
                    });
                conn.Close();
            }
        }


        //
        /// Produtos
        //

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

        public List<ProdutosRestaurante> ObterUserPorIdRestaurante(int idRestaurante)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                var prop = conn
                    .Query<ProdutosRestaurante>("select * from Produtos where Situacao = 1 and restauranteId = @idRestaurante or Situacao = 2 and restauranteId = @idRestaurante order by nome", new { idRestaurante })
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

        //
        /// Categorias
        //

        public List<Categoria> ObterCategorias(int idRestaurante)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                var prop = conn
                    .Query<Categoria>("select * from Categorias where restauranteId = @idRestaurante order by descricao", new { idRestaurante })
                    .ToList();
                conn.Close();
                return prop;
            }

        }

        public List<Categoria> ObterCategPorId(int categoriaId)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                var login = conn
                    .Query<Categoria>("select * from Categorias where categoriaId = @categoriaId", new { categoriaId })
                    .ToList();
                conn.Close();

                return login;
            }
        }

        public void DeleteCategoria(int CategoriaId)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                conn.Query("Delete from Categorias where categoriaId = @categoriaId",
                    new
                    {
                        categoriaId = CategoriaId
                    });
                conn.Close();
            }
        }

        //
        /// Restaurante
        //

        public List<GestorRestaurante> ObterUserPorCnpjSenha(string cnpj, string Senha)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                var prop = conn
                    .Query<GestorRestaurante>("select * from Restaurantes where cnpj = @cnpj and Senha = @Senha", new { cnpj, Senha })
                    .ToList();
                conn.Close();




                return prop;
            }

        }

        public void UpdateRestaurante(GestorRestaurante restaurante)
        {
            var sql = "Update Restaurantes set senha = @senha, email =@email, pedidoMinimo =@pedidoMinimo, abreAs =@abreAs, " +
                      "fechaAs = @fechaAs, fone =@fone, foneCelular =@foneCelular, aceitaRetira =@aceitaRetira, uf = @uf, " +
                      "bairro =@bairro, logradouro =@logradouro, numero =@numero, tempoEntrega =@tempoEntrega" +
                      " where token = @token";
            using (var conn = new SqlConnection(_configuration.GetConnectionString("VipFood")))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        token = restaurante.token,
                        senha = restaurante.senha,
                        email = restaurante.email,
                        pedidoMinimo = restaurante.pedidoMinimo,
                        abreAs = restaurante.abreAs,
                        fechaAs = restaurante.fechaAs,
                        fone = restaurante.fone,
                        foneCelular = restaurante.foneCelular,
                        aceitaRetira = restaurante.aceitaRetira,
                        uf = restaurante.uf,
                        bairro = restaurante.bairro,
                        logradouro = restaurante.logradouro,
                        numero = restaurante.numero,
                        tempoEntrega = restaurante.tempoEntrega
                    });
                conn.Close();
            }
        }
    }
}
