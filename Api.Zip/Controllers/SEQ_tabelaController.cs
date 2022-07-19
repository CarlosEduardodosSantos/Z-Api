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
    public class SEQ_tabelaController
    {
        private readonly SEQ_tabDAL _TABDAL;

        public SEQ_tabelaController(SEQ_tabDAL tabDAL)
        {
            _TABDAL = tabDAL;
        }

        [HttpGet("obterPorCodigo/{codigo}")]
        public SEQ_tabela ObterFornecPorCodigo(string codigo)
        {
            if (Strings.Conexao != null)
            {
                var data = _TABDAL.ObterUserPorTabela(codigo).FirstOrDefault();
                return data;
            }
            else { return null; }
        }

        [HttpGet("obterTodos")]
        public RootResult ObterTodos()
        {

            if (Strings.Conexao != null)
            {
                var data = _TABDAL.ObterTodos().ToList();
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
        public object Adicionar([FromBody] SEQ_tabela seqTAB)
        {

            if (Strings.Conexao != null)
            {
                try
                {
                    _TABDAL.Insert(seqTAB);
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
        public object Alterar([FromBody] SEQ_tabela seqTAB)
        {
            if (Strings.Conexao != null)
            {
                try
                {
                    _TABDAL.Update(seqTAB);
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
                    _TABDAL.Delete(codigo);
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
