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
    public class PRODController
    {
        private readonly prodDAL _prodDAL;
        private readonly SEQ_tabDAL _SEQtabDAL;

        public PRODController(prodDAL PRODDAL, SEQ_tabDAL seqdal)
        {
            _prodDAL = PRODDAL;
            _SEQtabDAL = seqdal;
        }

        [HttpGet("obterPorCodigo/{codigo}")]
        public PROD ObterFornecPorCodigo(int codigo)
        {
            if (Strings.Conexao != null)
            {
                var data = _prodDAL.ObterUserPorCodigo(codigo).FirstOrDefault();
                return data;
            }
            else { return null; }
        }

        [HttpGet("obterPorGrupo/{grupo}")]
        public RootResult ObterGrupoPorCodigo(int grupo)
        {
            if (Strings.Conexao != null)
            {
                var data = _prodDAL.ObterProdPorGrupo(grupo).ToList();
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

        [HttpGet("obterTodos")]
        public RootResult ObterTodos()
        {

            if (Strings.Conexao != null)
            {
                var data = _prodDAL.ObterTodos().ToList();
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
        public object Adicionar([FromBody] PROD prod)
        {

            if (Strings.Conexao != null)
            {
                try
                {
                    var seq = _SEQtabDAL.ObterUserPorTabela("PROD").FirstOrDefault();

                    prod.CODIGO = Convert.ToInt16(seq.SEQUENCIA) + 1;
                    _prodDAL.Insert(prod);

                    SEQ_tabela datau = new SEQ_tabela();

                    datau.TABELA = "PROD";
                    datau.SEQUENCIA = prod.CODIGO;
                    _SEQtabDAL.Update(datau);
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
        public object Alterar([FromBody] PROD prod)
        {
            if (Strings.Conexao != null)
            {
                try
                {
                    _prodDAL.Update(prod);
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
                    _prodDAL.Delete(codigo);
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