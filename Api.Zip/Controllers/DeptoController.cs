using Api.Zip.DAL;
using Api.Zip.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Api.Zip.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
        public class DeptoController
        {
            private readonly DeptoDAL _deptoDAL;

            public DeptoController(DeptoDAL deptoDAL)
            {
                _deptoDAL = deptoDAL;
            }

            [HttpGet("obterPorCodigo/{codigo}")]
            public Depto ObterSecaoPorCodigo(int codigo)
            {
                if (Strings.Conexao != null)
                {
                    var data = _deptoDAL.ObterUserPorCodigo(codigo).FirstOrDefault();
                    return data;
                }
                else { return null; }
            }

            [HttpGet("obterTodos")]
            public RootResult ObterTodos()
            {

                if (Strings.Conexao != null)
                {
                    var data = _deptoDAL.ObterTodos().ToList();
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
            public object Adicionar([FromBody] Depto depto)
            {

                if (Strings.Conexao != null)
                {
                    try
                    {
                        _deptoDAL.Insert(depto);
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
            public object Alterar([FromBody] Depto depto)
            {
                if (Strings.Conexao != null)
                {
                    try
                    {
                        _deptoDAL.Update(depto);
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
                        _deptoDAL.Delete(codigo);
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

