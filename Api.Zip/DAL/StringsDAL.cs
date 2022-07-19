using Api.Zip.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Zip.DAL
{
    public class StringsDAL
    {
        private readonly IConfiguration _configuration;

        public StringsDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Strings> ObterPorId(string Cnpj)
        {

            using (SqlConnection conn = new SqlConnection(
                _configuration.GetConnectionString("ConString")))
            {
                conn.Open();
                var str = conn
                    .Query<Strings>("select * from Conexoes where Cnpj = @Cnpj", new { Cnpj })
                    .ToList();
                conn.Close();

                return str;
            }

        }
    }
}
