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
    public class FarmaciasController
    {
        private readonly FarmaciaDAL _pharmaDAL;

        public FarmaciasController(FarmaciaDAL pharmaDAL)
        {
            _pharmaDAL = pharmaDAL;
        }

        [HttpGet("obterByFarmaId/{Cnpj}")]
        public Farmacias ObterConnPharma(string Cnpj)
        {
            var data = _pharmaDAL.ObterPorId(Cnpj).FirstOrDefault();
            if (data != null)
            {
                Farmacias.Conexao = data.ConString;
            }
            return data;
        }

        [HttpGet("obterTodosRec")]
        public RootResult ObterTodos()
        {

            if (Farmacias.Conexao != null)
            {
                var data = _pharmaDAL.ObterTodosRec().ToList();
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

        [HttpGet("obterRecById/{ID}")]
        public ReceitasPharma ObterPharmaPorID(int ID)
        {
            if (Farmacias.Conexao != null)
            {
                var data = _pharmaDAL.ObterRecPorId(ID).FirstOrDefault();
                return data;
            }
            else { return null; }
        }

        [HttpGet("obterRecByNome/{Nome}")]
        public ReceitasPharma ObterPharmaPorNome(string Nome)
        {
            if (Farmacias.Conexao != null)
            {
                var data = _pharmaDAL.ObterRecPorNome(Nome).FirstOrDefault();
                return data;
            }
            else { return null; }
        }

        [HttpPost("adicionar")]
        public object Adicionar([FromBody] ReceitasPharma PharmaReceitas)
        {

            if (Farmacias.Conexao != null)
            {
                try
                {
                    _pharmaDAL.Insert(PharmaReceitas);
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
    }
}
