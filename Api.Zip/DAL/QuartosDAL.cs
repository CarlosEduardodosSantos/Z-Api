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
    public class QuartosDAL
    {
        private readonly IConfiguration _configuration;

        public QuartosDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Quartos> ObterTodos()
        {

            using (SqlConnection conn = new SqlConnection(
                _configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                var str = conn
                    .Query<Quartos>("select * from Quartos")
                    .ToList();
                conn.Close();

                return str;
            }

        }

        public List<Quartos> ObterQuartoPorId(int Nro)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                var prop = conn
                    .Query<Quartos>("select * from Quartos where Nro = @Nro", new { Nro })
                    .ToList();
                conn.Close();

                return prop;
            }

        }

        public List<Quartos> ObterPorProp(int id_prop)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                var quartos = conn
                    .Query<Quartos>("select * from Quartos where id_prop = @id_prop", new { id_prop })
                    .ToList();
                conn.Close();

                return quartos;
            }

        }

        public void Insert(Quartos quarto)
        {
            var sql = "Insert Into Quartos(id_prop, Hotel, Quarto, Valor_limpeza, Valor_condominio, obs, status, HotelId)" +
                      "Values (@id_prop, @Hotel, @Quarto, @Valor_limpeza, @Valor_condominio, @Obs, @Status, @HotelId)";
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        id_prop = quarto.id_prop,
                        Hotel = quarto.Hotel,
                        Quarto = quarto.Quarto,
                        Valor_limpeza = quarto.Valor_limpeza,
                        Valor_condominio = quarto.Valor_condominio,
                        Obs = quarto.Obs,
                        Status = quarto.Status,
                        HotelId = quarto.HotelId,
                    });
                conn.Close();
            }
        }

        public void Update(Quartos quarto)
        {
            var sql = "Update Quartos set Hotel =@Hotel, Quarto =@Quarto, Valor_limpeza =@Valor_limpeza, Valor_condominio =@Valor_condominio, Obs =@Obs, Status =@Status, HotelId =@HotelId " +
                      " where Nro = @Nro";
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        Nro = quarto.Nro,
                        Hotel = quarto.Hotel,
                        Quarto = quarto.Quarto,
                        Valor_limpeza = quarto.Valor_limpeza,
                        Valor_condominio = quarto.Valor_condominio,
                        Obs = quarto.Obs,
                        Status = quarto.Status,
                        HotelId = quarto.HotelId,
                    });
                conn.Close();
            }
        }

        public void UpdateStatus(Quartos quarto)
        {
            var sql = "Update Quartos set Status =@Status " +
                      " where Quarto = @Quarto";
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        Quarto = quarto.Quarto,
                        Status = quarto.Status
                    });
                conn.Close();
            }
        }

        public void Delete(int Nro)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                conn.Query("Delete from Quartos where Nro = @Nro",
                    new
                    {
                        Nro = Nro
                    });
                conn.Close();
            }
        }

    }
}
