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
    public class MovimentacaoDAL
    {
        private readonly IConfiguration _configuration;

        public MovimentacaoDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Movimentacao> ObterTodos()
        {

            using (SqlConnection conn = new SqlConnection(
                _configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                var str = conn
                    .Query<Movimentacao>("select * from Movimentacao")
                    .ToList();
                conn.Close();

                return str;
            }

        }

        public List<Movimentacao> ObterMovPorId(int Nro)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                var prop = conn
                    .Query<Movimentacao>("select * from Movimentacao where Nro = @Nro", new { Nro })
                    .ToList();
                conn.Close();

                return prop;
            }

        }

        public List<Movimentacao> ObterMovPorQuarto(string Quarto, int HotelId)
        {

            using (var conn = new SqlConnection(
                   _configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                var prop = conn
                    .Query<Movimentacao>("select * from Movimentacao where Quarto = @Quarto and HotelId = @HotelId", new { Quarto, HotelId })
                    .ToList();
                conn.Close();

                return prop;
            }

        }
        public void Insert(Movimentacao mov)
        {
            var sql = "Insert Into Movimentacao(Data, Quarto, Hospede, Checkin, Checkout, Diarias, Valor, Pgto, Booking, Obs, HotelId, QtdeAdultos, QtdeCriancas)" +
                      "Values (@Data, @Quarto, @Hospede, @Checkin, @Checkout, @Diarias, @Valor, @Pgto, @Booking, @Obs, @HotelId, @QtdeAdultos, @QtdeCriancas)";
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        Data = DateTime.Now,
                        Quarto = mov.Quarto,
                        Hospede = mov.Hospede,
                        Checkin = mov.Checkin,
                        Checkout = mov.Checkout,
                        Diarias = mov.Diarias,
                        Valor = mov.Valor,
                        Pgto = mov.Pgto,
                        Booking = mov.Booking,
                        HotelId = mov.HotelId,
                        Obs = mov.Obs,
                        QtdeAdultos = mov.QtdeAdultos,
                        QtdeCriancas = mov.QtdeCriancas
                    });
                conn.Close();
            }
        }

        public void Update(Movimentacao mov)
        {
            var sql = "Update Movimentacao set Data =@Data, Quarto =@Quarto, Hospede =@Hospede, Checkin =@Checkin, Checkout =@Checkout, Diarias =@Diarias, Valor =@Valor, Pgto =@Pgto, Booking =@Booking, Obs =@Obs, HotelId =@HotelId, QtdeAdultos =@QtdeAdultos, QtdeCriancas =@QtdeCriancas" +
                      " where Nro = @Nro";
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                conn.Query(sql,
                    new
                    {
                        Nro = mov.Nro,
                        Data = DateTime.Now,
                        Quarto = mov.Quarto,
                        Hospede = mov.Hospede,
                        Checkin = mov.Checkin,
                        Checkout = mov.Checkout,
                        Diarias = mov.Diarias,
                        Valor = mov.Valor,
                        Pgto = mov.Pgto,
                        Booking = mov.Pgto,
                        Obs = mov.Obs,
                        HotelId = mov.HotelId,
                        QtdeAdultos = mov.QtdeAdultos,
                        QtdeCriancas = mov.QtdeCriancas
                    });
                conn.Close();
            }
        }

        public void Delete(int Nro)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Z-Hotel")))
            {
                conn.Open();
                conn.Query("Delete from Movimentacao where Nro = @Nro",
                    new
                    {
                        Nro = Nro
                    });
                conn.Close();
            }
        }
    }
}
