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
    public class UsuariosGestorController : Controller
    {
        private readonly UsuariosGestorDAL _UsuDAL;
        public UsuariosGestorController(UsuariosGestorDAL UsuDAL)
        {
            _UsuDAL = UsuDAL;
        }

        [HttpGet("obterTodosRec")]
        public RootResult ObterTodos()
        {

                var data = _UsuDAL.ObterTodos().ToList();
                var totalPage = 1;
                return new RootResult()
                {
                    TotalPage = totalPage,
                    Results = data
                };

        }

        [HttpGet("obterUsuGestotByNomeSenha/{nome}/{Senha}")]
        public UsuariosGestor ObterUsuarioPorNomeSenha(string nome, string Senha)
        {
            var data = _UsuDAL.ObterUserPorNomeSenha(nome, Senha).FirstOrDefault();
            return data;

        }

        [HttpGet("obterRecByNome/{UserID}")]
        public UsuariosGestor ObterPharmaPorNome(Guid UserID)
        {
                var data = _UsuDAL.ObterUsuPorID(UserID).FirstOrDefault();
                return data;
        }

        [HttpPost("adicionar")]
        public object Adicionar([FromBody] UsuariosGestor Usu)
        {
                try
                {
                    _UsuDAL.Insert(Usu);
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
        public object Alterar([FromBody] UsuariosGestor usu)
        {
            try
            {
                _UsuDAL.Update(usu);
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

        [HttpDelete("deletar/{UserID}")]
        public object Delete(Guid UserID)
        {

            try
            {
                _UsuDAL.Delete(UserID);
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
