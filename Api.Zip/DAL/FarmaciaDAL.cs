using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using Api.Zip.Models;

namespace Api.Zip.DAL
{
    public class FarmaciaDAL
    {
        private readonly IConfiguration _configuration;

        public FarmaciaDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Farmacias> ObterPorId(string Cnpj)
        {

            using (SqlConnection conn = new SqlConnection(
                _configuration.GetConnectionString("ConString")))
            {
                conn.Open();
                var farmacia = conn
                    .Query<Farmacias>("select * from Conexoes where Cnpj = @Cnpj", new { Cnpj })
                    .ToList();
                conn.Close();

                return farmacia;
            }

        }

        public List<ReceitasPharma> ObterTodosRec()
        {
            using (var conn = new SqlConnection(Farmacias.Conexao))
            {
                conn.Open();
                var receitas = conn
                    .Query<ReceitasPharma>("select Id, Nome, Cpf, DataHora, Telefone, Status from ReceitasPharma order by DataHora DESC")
                    .ToList();
                conn.Close();

                return receitas;
            }

        }
        public List<ReceitasPharma> ObterRecPorId(int id)
        {

            using (var conn = new SqlConnection(Farmacias.Conexao))
            {
                conn.Open();
                var receita = conn
                    .Query<ReceitasPharma>("select * from ReceitasPharma where id = @id order by Nome DESC", new { id })
                    .ToList();
                conn.Close();

                return receita;
            }

        }

        public List<ReceitasPharma> ObterRecPorNome(string nome)
        {

            using (var conn = new SqlConnection(Farmacias.Conexao))
            {
                conn.Open();
                var receita = conn
                    .Query<ReceitasPharma>("select Id, Nome, Cpf, DataHora, Telefone, Status from ReceitasPharma where nome like '%'+@nome+'%' order by DataHora DESC", new { nome })
                    .ToList();
                conn.Close();

                return receita;
            }


        }


        public void Insert(ReceitasPharma receita)
        {
            var sql = "Insert Into ReceitasPharma(Nome, Cpf, Telefone, Receita, Receita2, Receita3, Receita4, DataHora, Status)" +
                      "Values (@Nome, @Cpf, @Telefone, @Receita, @Receita2, @Receita3, @Receita4, @DataHora, @Status)";
            using (var conn = new SqlConnection(Farmacias.Conexao))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        Nome = receita.Nome,
                        Cpf = receita.Cpf,
                        Telefone = receita.Telefone,
                        Receita = receita.Receita,
                        Receita2 = receita.Receita2,
                        Receita3 = receita.Receita3,
                        Receita4 = receita.Receita4,
                        DataHora = DateTime.Now,
                        Status = 1
                    });
                conn.Close();
            }
        }
    }
}
