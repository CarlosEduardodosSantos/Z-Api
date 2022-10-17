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
    public class GrupoController
    {
        private readonly GrupoDAL _grupoDAL;
        private readonly SEQ_tabDAL _SEQtabDAL;

        public GrupoController(GrupoDAL grupoDAL, SEQ_tabDAL seqdal)
        {
            _grupoDAL = grupoDAL;
            _SEQtabDAL = seqdal;
        }

        [HttpGet("obterPorGRUPO/{GRUPO}")]
        public Grupo ObterFornecPorCodigo(int GRUPO)
        {
            if (Strings.Conexao != null)
            {
                var data = _grupoDAL.ObterUserPorCodigo(GRUPO).FirstOrDefault();
                return data;
            }
            else { return null; }
        }

        [HttpGet("obterTodos")]
        public RootResult ObterTodos()
        {

            if (Strings.Conexao != null)
            {
                var data = _grupoDAL.ObterTodos().ToList();
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
        public object Adicionar([FromBody] Grupo grupo)
        {

            if (Strings.Conexao != null)
            {
                try
                {
                    var seq = _SEQtabDAL.ObterUserPorTabela("GRUPO").FirstOrDefault();
                    grupo.GRUPO = Convert.ToInt16(seq.SEQUENCIA) + 1;
                    _grupoDAL.Insert(grupo);
                    SEQ_tabela datau = new SEQ_tabela();

                    datau.TABELA = "GRUPO";
                    datau.SEQUENCIA = grupo.GRUPO;
                    datau.COLUNA = "GRUPO";
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
        public object Alterar([FromBody] Grupo grupo)
        {
            if (Strings.Conexao != null)
            {
                try
                {
                    _grupoDAL.Update(grupo);
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

        [HttpDelete("deletar/{GRUPO}")]
        public object Delete(int grupo)
        {
            if (Strings.Conexao != null)
            {

                try
                {
                    _grupoDAL.Delete(grupo);
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
