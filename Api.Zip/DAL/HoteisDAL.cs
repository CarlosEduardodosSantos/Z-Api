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
    public class HoteisDAL
    {
        private readonly IConfiguration _configuration;

        public HoteisDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Hoteis> ObterTodos()
        {

            using (SqlConnection conn = new SqlConnection(
                _configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                var str = conn
                    .Query<Hoteis>("select * from Hotel")
                    .ToList();
                conn.Close();

                return str;
            }

        }

        public List<Hoteis> ObterHotelPorId(int Nro)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                var prop = conn
                    .Query<Hoteis>("select * from Hotel where HotelId = @HotelId", new { Nro })
                    .ToList();
                conn.Close();

                return prop;
            }

        }


        public void Insert(Hoteis hot)
        {
            var sql = "Insert Into Hotel(Nome)" +
                      "Values (@Nome)";
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {

                        Nome = hot.Nome,
                    });
                conn.Close();
            }
        }

        public void Update(Hoteis hot)
        {
            var sql = "Update Hotel set Nome = @Nome" +
                      " where HotelId = @HotelId";
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        HotelId = hot.HotelId,
                        Nome = hot.Nome,
                    });
                conn.Close();
            }
        }

        public void Delete(int Nro)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                conn.Query("Delete from Hotel where HotelId = @HotelId",
                    new
                    {
                        Nro = Nro
                    });
                conn.Close();
            }
        }
    }
}
