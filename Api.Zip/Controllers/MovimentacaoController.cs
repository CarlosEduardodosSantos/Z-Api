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

    public class MovimentacaoController : Controller
    {
        private readonly MovimentacaoDAL _movimentacaoDAL;
        private readonly QuartosDAL _quartosDAL;

        public MovimentacaoController(MovimentacaoDAL MOVIMENTACAODAL, QuartosDAL QUARTOSDAL)
        {
            _movimentacaoDAL = MOVIMENTACAODAL;
            _quartosDAL = QUARTOSDAL;

        }

        [HttpGet("obterPorQuarto/{HotelID}/{Quarto}")]
        public RootResult ObterPorQuarto(int HotelID, string Quarto)
        {
            var data = _movimentacaoDAL.ObterMovPorQuarto(Quarto, HotelID).ToList();
            var totalPage = 1;
            return new RootResult()
            {
                TotalPage = totalPage,
                Results = data
            };
        }

        [HttpGet("obterPorCodigo/{id}")]
        public Movimentacao ObterUsuarioPorCodigo(int id)
        {
            var data = _movimentacaoDAL.ObterMovPorId(id).FirstOrDefault();
            return data;

        }

        [HttpGet("obterTodos")]
        public RootResult ObterTodos()
        {

            var data = _movimentacaoDAL.ObterTodos().ToList();
            var totalPage = 1;
            return new RootResult()
            {
                TotalPage = totalPage,
                Results = data
            };

        }


        [HttpPost("adicionar")]
        public object Adicionar([FromBody] Movimentacao mov)
        {
            try
            {
                _movimentacaoDAL.Insert(mov);

                    var quart = new Quartos();
                    quart.Quarto = mov.Quarto;
                    quart.Status = "o";
                    _quartosDAL.UpdateStatus(quart);

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
        public object Alterar([FromBody] Movimentacao mov)
        {
            try
            {
                _movimentacaoDAL.Update(mov);

                var quart = new Quartos();
                quart.Quarto = mov.Quarto;
                quart.Status = "O";
                _quartosDAL.UpdateStatus(quart);

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
                _movimentacaoDAL.Delete(Nro);
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
