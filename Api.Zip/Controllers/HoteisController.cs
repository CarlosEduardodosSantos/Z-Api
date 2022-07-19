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
    public class HoteisController : Controller
    {
        private readonly HoteisDAL _hotDAL;

        public HoteisController(HoteisDAL HOTDAL)
        {
            _hotDAL = HOTDAL;
        }

        [HttpGet("obterPorCodigo/{Nro}")]
        public Hoteis ObterUsuarioPorCodigo(int Nro)
        {
            var data = _hotDAL.ObterHotelPorId(Nro).FirstOrDefault();
            return data;

        }

        [HttpGet("obterTodos")]
        public RootResult ObterTodos()
        {

            var data = _hotDAL.ObterTodos().ToList();
            var totalPage = 1;
            return new RootResult()
            {
                TotalPage = totalPage,
                Results = data
            };

        }


        [HttpPost("adicionar")]
        public object Adicionar([FromBody] Hoteis hot)
        {
            try
            {
                _hotDAL.Insert(hot);
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
        public object Alterar([FromBody] Hoteis hot)
        {
            try
            {
                _hotDAL.Update(hot);
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
                _hotDAL.Delete(Nro);
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
