using Api.Zip.DAL;
using Api.Zip.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Api.Zip.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SecaoController
    {
        private readonly SecaoDAL _secaoDAL;

        public SecaoController(SecaoDAL secaoDAL)
        {
            _secaoDAL = secaoDAL;
        }

        [HttpGet("obterPorCodigo/{codigo}")]
        public Secao ObterSecaoPorCodigo(int codigo)
        {
            if (Strings.Conexao != null)
            {
                var data = _secaoDAL.ObterUserPorCodigo(codigo).FirstOrDefault();
                return data;
            }
            else { return null; }
        }

        [HttpGet("obterTodos")]
        public RootResult ObterTodos()
        {

            if (Strings.Conexao != null)
            {
                var data = _secaoDAL.ObterTodos().ToList();
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

        [HttpPost("adicionar")]
        public object Adicionar([FromBody] Secao secao)
        {

            if (Strings.Conexao != null)
            {
                try
                {
                    _secaoDAL.Insert(secao);
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
            else
            {
                return new { errors = true, message = "Connection String não encontrada!" };
            }
        }

        [HttpPut("alterar")]
        public object Alterar([FromBody] Secao secao)
        {
            if (Strings.Conexao != null)
            {
                try
                {
                    _secaoDAL.Update(secao);
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

        [HttpDelete("deletar/{codigo}")]
        public object Delete(int codigo)
        {
            if (Strings.Conexao != null)
            {

                try
                {
                    _secaoDAL.Delete(codigo);
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
            else
            {
                return new { errors = true, message = "Connection String não encontrada!" };
            }

        }
    }
}

