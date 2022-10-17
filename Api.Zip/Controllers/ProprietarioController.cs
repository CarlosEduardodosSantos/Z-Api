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
    public class ProprietarioController : Controller
    {
        private readonly ProprietarioDAL _propDAL;

        public ProprietarioController(ProprietarioDAL PROPDAL)
        {
            _propDAL = PROPDAL;
        }

        [HttpGet("obterLogin/{Nome}/{Senha}")]
        public Proprietario ObterLoginPorId(string Nome, string Senha)
        {
                var data = _propDAL.ObterUserPorSenha(Nome, Senha).FirstOrDefault();
                return data;
        }

        [HttpGet("obterPorCodigo/{Nro}")]
        public Proprietario ObterUsuarioPorCodigo(int Nro)
        {
                var data = _propDAL.ObterPropPorId(Nro).FirstOrDefault();
                return data;

        }

        [HttpGet("obterTodos")]
        public RootResult ObterTodos()
        {

                var data = _propDAL.ObterTodos().ToList();
                var totalPage = 1;
                return new RootResult()
                {
                    TotalPage = totalPage,
                    Results = data
                };

        }


        [HttpPost("adicionar")]
        public object Adicionar([FromBody] Proprietario prop)
        {
                try
                {
                    _propDAL.Insert(prop);
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
        public object Alterar([FromBody] Proprietario prop)
        {
                try
                {
                    _propDAL.Update(prop);
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
                    _propDAL.Delete(Nro);
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
