using Api.Zip.DAL;
using Api.Zip.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Zip.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RestauranteController : Controller
    {
        private readonly GestorRestaurantesDAL _ResDAL;
        public RestauranteController(GestorRestaurantesDAL ResDAL)
        {
            _ResDAL = ResDAL;
        }

        //
        /// Tipos
        //

        [HttpGet("obteTiposByTipoId/{produtosOpcaoTipoId}")]
        public RootResult ObterTiposByGestor(int produtosOpcaoTipoId)
        {
            var data = _ResDAL.ObterTiposPorprodutosOpcaoTipoId(produtosOpcaoTipoId).ToList();
            return new RootResult()
            {
                TotalPage = 1,
                Results = data
            };
        }

        [HttpGet("ObterProdutosOpcaoGuid/{ProdutosOpcaoGuid}")]
        public produtoOpcao ObterProdutosOpcaoGuid(string ProdutosOpcaoGuid)
        {
            var data = _ResDAL.ObterProdOpcaoPorGuid(ProdutosOpcaoGuid).FirstOrDefault();
            return data;
        }

        [HttpDelete("DeletarTipos/{ProdutosOpcaoTipoId}")]
        public object DeleteTipos(int ProdutosOpcaoTipoId)
        {

            try
            {
                _ResDAL.DeleteTipos(ProdutosOpcaoTipoId);
                return new
                {
                    errors = false,
                    message = "Exclusão efetuada com sucesso."
                };
            }
            catch (Exception e)
            {
                return new
                {
                    errors = true,
                    message = e.Message
                };
            }
        }

        [HttpDelete("DeletarRelacao/{produtosOpcaoId}")]
        public object DeleteRelacao(Guid produtosOpcaoId)
        {

            try
            {
                _ResDAL.DeleteRelacao(produtosOpcaoId);
                return new
                {
                    errors = false,
                    message = "Exclusão efetuada com sucesso."
                };
            }
            catch (Exception e)
            {
                return new
                {
                    errors = true,
                    message = e.Message
                };
            }


        }

        //
        /// Produtos
        //

        [HttpGet("obterProdPorGuid/{Guid}")]
        public ProdutosRestaurante ObterProdPorGuid(string Guid)
        {
            if (Strings.Conexao != null)
            {
                var data = _ResDAL.ObterProdPorGuid(Guid).FirstOrDefault();
                return data;
            }
            else { return null; }
        }

        [HttpGet("obterPrdutos/{restauranteid}")]
        public RootResult ObterTodos(int restauranteid)
        {

            if (Strings.Conexao != null)
            {
                var data = _ResDAL.ObterUserPorIdRestaurante(restauranteid).ToList();
                var totalPage = 1;
                return new RootResult()
                {
                    TotalPage = totalPage,
                    Results = data
                };
            }
            else
            {
                return new RootResult()
                {
                    TotalPage = 0,
                    Results = null
                };
            }

        }

        [HttpDelete("deletar/{ProdutoID}")]
        public object Delete(int ProdutoID)
        {

            try
            {
                _ResDAL.Delete(ProdutoID);
                return new
                {
                    errors = false,
                    message = "Exclusão efetuada com sucesso."
                };
            }
            catch (Exception e)
            {
                return new
                {
                    errors = true,
                    message = e.Message
                };
            }


        }

        //
        /// Categorias
        //

        [HttpGet("ObterCategoriasByRestauranteID/{RestauranteID}")]
        public RootResult ObterCategoriasPorRestauranteID(int RestauranteID)
        {
            if (Strings.Conexao != null)
            {
                var data = _ResDAL.ObterCategorias(RestauranteID).ToList();
                var totalPage = 1;
                return new RootResult()
                {
                    TotalPage = totalPage,
                    Results = data
                };
            }
            else
            {
                return new RootResult()
                {
                    TotalPage = 0,
                    Results = null
                };
            }

        }

        [HttpGet("ObterCategoriaPorcategoriaId/{CategID}")]
        public Categoria ObterCategPorCategID(int CategID)
        {
            if (Strings.Conexao != null)
            {
                var data = _ResDAL.ObterCategPorId(CategID).FirstOrDefault();
                return data;
            }
            else { return null; }
        }

        [HttpGet("ObterCategorias/{restauranteid}")]
        public RootResult ObterCategorias(int restauranteid)
        {

            if (Strings.Conexao != null)
            {
                var data = _ResDAL.ObterCategorias(restauranteid).ToList();
                var totalPage = 1;
                return new RootResult()
                {
                    TotalPage = totalPage,
                    Results = data
                };
            }
            else
            {
                return new RootResult()
                {
                    TotalPage = 0,
                    Results = null
                };
            }

        }

        [HttpDelete("deletarCategoria/{CategoriaId}")]
        public object deletarCategoria(int CategoriaId)
        {

            try
            {
                _ResDAL.DeleteCategoria(CategoriaId);
                return new
                {
                    errors = false,
                    message = "Exclusão efetuada com sucesso."
                };
            }
            catch (Exception e)
            {
                return new
                {
                    errors = true,
                    message = e.Message
                };
            }


        }

        //
        /// Restaurante
        //

        [HttpGet("obterRestauranteGestorByCnpjSenha/{cnpj}/{Senha}")]
        public GestorRestaurante ObterUsuarioPorNomeSenha(string cnpj, string Senha)
        {
            var data = _ResDAL.ObterUserPorCnpjSenha(cnpj, Senha).FirstOrDefault();
            return data;

        }

        [HttpPut("alterarRestaurante")]
        public object Alterar([FromBody] GestorRestaurante Restaurante)
        {
            if (Strings.Conexao != null)
            {
                try
                {
                    _ResDAL.UpdateRestaurante(Restaurante);
                    return new
                    {
                        errors = false,
                        message = "Cadastro atualizado com sucesso."
                    };
                }

                catch (Exception e)
                {
                    return new
                    {
                        errors = true,
                        message = e.Message
                    };
                }
            }

            else
            {
                return new { errors = true, message = "Connection String não encontrada!" };
            }
        }
    }
}
