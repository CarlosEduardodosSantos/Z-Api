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
    public class TAB_tipoController
    {
        private readonly TAB_tipoDAL _TipoDAL;

        public TAB_tipoController(TAB_tipoDAL tipoDAL)
        {
            _TipoDAL = tipoDAL;
        }

        [HttpGet("obterPorCodigo/{codigo}")]
        public TAB_TIPO ObterFornecPorCodigo(string codigo)
        {
            if (Strings.Conexao != null)
            {
                var data = _TipoDAL.ObterUserPorCodigo(codigo).FirstOrDefault();
                return data;
            }
            else { return null; }
        }

        [HttpGet("obterTodos")]
        public RootResult ObterTodos()
        {

            if (Strings.Conexao != null)
            {
                var data = _TipoDAL.ObterTodos().ToList();
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
        public object Adicionar([FromBody] TAB_TIPO TIPO)
        {

            if (Strings.Conexao != null)
            {
                try
                {
                    _TipoDAL.Insert(TIPO);
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

        [HttpDelete("deletar/{codigo}")]
        public object Delete(string codigo)
        {
            if (Strings.Conexao != null)
            {

                try
                {
                    _TipoDAL.Delete(codigo);
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
