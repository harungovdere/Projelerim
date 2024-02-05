using FiloKiralama_Api.Dtos.CarDtos;
using FiloKiralama_Api.Models.DapperContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace FiloKiralama_Api.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly Context _context;

        public CarRepository(Context context)
        {
            _context = context;
            
        }
        
        public async void CreateCar(CreateCarDto createCarDto)
        {
            
            string query = "INSERT INTO ARACLAR (Plaka,MarkaKodu,TipKodu,ModelYili,KM,Renk,Sanziman,YakitTipi,Durum) VALUES (@Plaka,@MarkaKodu,@TipKodu,@ModelYili,@KM,@Renk,@Sanziman,@YakitTipi,@Durum)";
            var parameters = new DynamicParameters();
            parameters.Add("@Plaka", createCarDto.Plaka);
            parameters.Add("@MarkaKodu", createCarDto.MarkaKodu);
            parameters.Add("@TipKodu", createCarDto.TipKodu);
            parameters.Add("@ModelYili", createCarDto.ModelYili);
            parameters.Add("@KM", createCarDto.KM);
            parameters.Add("@Renk", createCarDto.Renk);
            parameters.Add("@Sanziman", createCarDto.Sanziman);
            parameters.Add("@YakitTipi", createCarDto.YakitTipi);
            parameters.Add("@Durum", createCarDto.Durum);

            using (var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async void DeleteCar(int id)
        {
            string query = "DELETE FROM ARACLAR WHERE AracID=@AracID";
            var parameters = new DynamicParameters();
            parameters.Add("@AracID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCarDto>> GetAllCarAsync()
        {
            string query = "SELECT A.AracID,A.Plaka,A.MarkaKodu,M.MarkaAdi,A.TipKodu,N.TipAdi,N.ModelTipID,A.ModelYili,A.KM,A.Renk,A.Sanziman,A.YakitTipi,D.Durum,D.DurumID,R.DosyaAdi FROM  ARACLAR A INNER JOIN MARKALAR M ON M.MarkaKodu = A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu = A.TipKodu AND M.MarkaKodu = N.MarkaKodu INNER JOIN ARAC_DURUM D ON D.DurumID=A.Durum LEFT OUTER JOIN MODELLER_RESIM R ON R.MarkaKodu=A.MarkaKodu AND R.TipKodu=A.TipKodu ORDER BY A.Plaka";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCarDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDCarDto> GetCar(int id)
        {
            string query= "SELECT A.AracID,A.Plaka,A.MarkaKodu,M.MarkaAdi,A.TipKodu,N.TipAdi,A.ModelYili,A.KM,A.Renk,A.Sanziman,A.YakitTipi, A.Durum FROM  ARACLAR A INNER JOIN MARKALAR M ON M.MarkaKodu = A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu = A.TipKodu AND M.MarkaKodu = N.MarkaKodu  WHERE A.AracID=@AracID";
            var parameters = new DynamicParameters();
            parameters.Add("@AracID",id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDCarDto>(query,parameters);
                return values;
            }
        }

        public async void UpdateCar(UpdateCarDto updateCarDto)
        {
            string query = "UPDATE ARACLAR SET Plaka=@Plaka,MarkaKodu=@MarkaKodu,TipKodu=@TipKodu,ModelYili=@ModelYili,KM=@KM,Renk=@Renk,Sanziman=@Sanziman,YakitTipi=@YakitTipi,Durum=@Durum WHERE AracID=@AracID";
            var parameters = new DynamicParameters();
            
            parameters.Add("@Plaka", updateCarDto.Plaka);
            parameters.Add("@MarkaKodu", updateCarDto.MarkaKodu);
            parameters.Add("@TipKodu", updateCarDto.TipKodu);
            parameters.Add("@ModelYili", updateCarDto.ModelYili);
            parameters.Add("@KM", updateCarDto.KM);
            parameters.Add("@Renk", updateCarDto.Renk);
            parameters.Add("@Sanziman", updateCarDto.Sanziman);
            parameters.Add("@YakitTipi", updateCarDto.YakitTipi);
            parameters.Add("@AracID", updateCarDto.AracID);
            parameters.Add("@Durum", updateCarDto.Durum);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        
    }
}
