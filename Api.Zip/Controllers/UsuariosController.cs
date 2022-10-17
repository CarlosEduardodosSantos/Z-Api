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
    public class UsuariosController : Controller
    {
        private readonly UsuariosDAL _usuariosDAL;

        public UsuariosController(UsuariosDAL usuariosDAL)
        {
            _usuariosDAL = usuariosDAL;
        }

        [HttpGet("obterLogin/{Nome}/{Senha}")]
        public Usuarios ObterLoginPorId(string Nome, string Senha)
        {
            if (Strings.Conexao != null)
            {
                var data = _usuariosDAL.ObterUserPorSenha(Nome, Senha).FirstOrDefault();
                return data;
            }
            else { return null; }
        }

        [HttpGet("obterPorCodigo/{codigo}")]
        public Usuarios ObterUsuarioPorCodigo(int codigo)
        {
            if (Strings.Conexao != null)
            {
                var data = _usuariosDAL.ObterUserPorCodigo(codigo).FirstOrDefault();
                return data;
            }
            else { return null; }
        }

        [HttpGet("obterTodos")]
        public RootResult ObterTodos()
        {

            if (Strings.Conexao != null)
            {
                var data = _usuariosDAL.ObterTodos().ToList();
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
        public object Adicionar([FromBody] Usuarios usuario)
        {

            if (Strings.Conexao != null)
            {
                try
                {
                    _usuariosDAL.Insert(usuario);
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
        public object Alterar([FromBody] Usuarios usuario)
        {
            if (Strings.Conexao != null)
            {
                try
                {
                    _usuariosDAL.Update(usuario);
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
                    _usuariosDAL.Delete(codigo);
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
