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
    public class QuartosController : Controller
    {
        private readonly QuartosDAL _quartosDAL;

        public QuartosController(QuartosDAL QUARTOSDAL)
        {
            _quartosDAL = QUARTOSDAL;
        }

        [HttpGet("obterPorUser/{id_prop}")]
        public RootResult ObterPorUser(int id_prop)
        {
            var data = _quartosDAL.ObterPorProp(id_prop).ToList();
            var totalPage = 1;
            return new RootResult()
            {
                TotalPage = totalPage,
                Results = data
            };
        }

        [HttpGet("obterPorCodigo/{id}")]
        public Quartos ObterUsuarioPorCodigo(int id)
        {
            var data = _quartosDAL.ObterQuartoPorId(id).FirstOrDefault();
            return data;

        }

        [HttpGet("obterTodos")]
        public RootResult ObterTodos()
        {

            var data = _quartosDAL.ObterTodos().ToList();
            var totalPage = 1;
            return new RootResult()
            {
                TotalPage = totalPage,
                Results = data
            };

        }


        [HttpPost("adicionar")]
        public object Adicionar([FromBody] Quartos quart)
        {
            try
            {
                _quartosDAL.Insert(quart);
                return new
                {
                    errors = false,
                    message = "Cadastro efetuado com sucesso."
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

        [HttpPut("alterar")]
        public object Alterar([FromBody] Quartos quart)
        {
            try
            {
                _quartosDAL.Update(quart);
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

        [HttpDelete("deletar/{Nro}")]
        public object Delete(int Nro)
        {

            try
            {
                _quartosDAL.Delete(Nro);
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
