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
    public class ClienteController
    {
        private readonly ClienteDAL _CliDAL;

        public ClienteController(ClienteDAL fornecDAL)
        {
            _CliDAL = fornecDAL;
        }

        [HttpGet("obterPorCodigo/{codigo}")]
        public Cliente ObterFornecPorCodigo(int codigo)
        {
            if (Strings.Conexao != null)
            {
                var data = _CliDAL.ObterUserPorCodigo(codigo).FirstOrDefault();
                return data;
            }
            else { return null; }
        }

        [HttpGet("obterTodos")]
        public RootResult ObterTodos()
        {

            if (Strings.Conexao != null)
            {
                var data = _CliDAL.ObterTodos().ToList();
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
        public object Adicionar([FromBody] Cliente fornec)
        {

            if (Strings.Conexao != null)
            {
                try
                {
                    _CliDAL.Insert(fornec);
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
        public object Alterar([FromBody] Cliente fornec)
        {
            if (Strings.Conexao != null)
            {
                try
                {
                    _CliDAL.Update(fornec);
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
                    _CliDAL.Delete(codigo);
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
