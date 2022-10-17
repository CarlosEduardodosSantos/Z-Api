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
    public class StringsController : Controller
    {
        private readonly StringsDAL _stringsDAL;

        public StringsController(StringsDAL stringsDAL)
        {
            _stringsDAL = stringsDAL;
        }

        [HttpGet("obterString/{Cnpj}")]
        public Strings ObterStringPorId(string Cnpj)
        {
            var data = _stringsDAL.ObterPorId(Cnpj).FirstOrDefault();
            if (data != null)
            {
                Strings.Conexao = data.ConString;
            }
            return data;

        }

        [HttpPut("alterarTema")]
        public object Alterar([FromBody] Strings stringa)
        {
                try
                {
                    _stringsDAL.Update(stringa);
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

    }
}
