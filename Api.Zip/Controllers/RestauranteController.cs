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


        [HttpGet("obterRestauranteGestorByNomeSenha/{nome}/{Senha}")]
        public GestorRestaurante ObterUsuarioPorNomeSenha(string nome, string Senha)
        {
            var data = _ResDAL.ObterUserPorNomeSenha(nome, Senha).FirstOrDefault();
            return data;

        }

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
    }
}
