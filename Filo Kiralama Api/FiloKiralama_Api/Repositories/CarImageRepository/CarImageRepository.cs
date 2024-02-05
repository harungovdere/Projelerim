using Dapper;
using FiloKiralama_Api.Dtos.CarDtos;
using FiloKiralama_Api.Dtos.CarImageDtos;
using FiloKiralama_Api.Models.DapperContext;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.CarImageRepository
{
    public class CarImageRepository : ICarImageRepository
    {
        private readonly Context _context;
        //public CarImageRepository(Context context)
        //{
        //    _context = context;

        //}

        private IWebHostEnvironment environment;

        public CarImageRepository(IWebHostEnvironment env, Context context)
        {
            this.environment = env;
            _context = context;
        }
        // Api ye resim yüklenirse ve bu resim silinmek istenirse DeleteCarImage çalışacak
        public bool DeleteCarImage(string imageFileName)
        {
            try
            {
                var wwwPath = this.environment.WebRootPath;
                var path = Path.Combine(wwwPath, "Uploads\\", imageFileName);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async void DeleteImage(int id)
        {
            string query = "DELETE FROM MODELLER_RESIM WHERE ResimID=@ResimID";
            var parameters = new DynamicParameters();
            parameters.Add("@ResimID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public Tuple<int, string> SaveCarImage(IFormFile imageFile)
        //public Tuple<int, string> SaveCarImage(CreateImageDto createImageDto)
        {
            try
            {
                var contentPath = this.environment.ContentRootPath;
                // path = "c://projects/productminiapi/uploads" ,not exactly something like that
                var path = Path.Combine(contentPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Check the allowed extenstions
                //var ext = Path.GetExtension(imageFile.FileName);
                var ext = Path.GetExtension(imageFile.FileName);
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
                if (!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("Yalnızca {0} uzantıya izin veriliyor", string.Join(",", allowedExtensions));
                    return new Tuple<int, string>(0, msg);
                }

                string uniqueString = Guid.NewGuid().ToString();
                // we are trying to create a unique filename here
                var newFileName = uniqueString + ext;
                var fileWithPath = Path.Combine(path, newFileName);
                var stream = new FileStream(fileWithPath, FileMode.Create);
                imageFile.CopyTo(stream);
                //createImageDto.File.CopyTo(stream);
                stream.Close();

                return new Tuple<int, string>(1, newFileName);
            }
            catch (Exception ex)
            {
                return new Tuple<int, string>(0, "Hata oluştu");
            }
        }


        public async void CreateImage(CreateImageDto createImageDto)
        {

            string query = "INSERT INTO MODELLER_RESIM (TipKodu,MarkaKodu,DosyaAdi) VALUES  (@TipKodu,@MarkaKodu,@DosyaAdi)";
            var parameters = new DynamicParameters();

            parameters.Add("@TipKodu", createImageDto.TipKodu);
            parameters.Add("@MarkaKodu", createImageDto.MarkaKodu);
            parameters.Add("@DosyaAdi", createImageDto.DosyaAdi);
            //parameters.Add("@File", createImageDto.File);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task<List<ResultCarImageDto>> AllCarImage()
        {
            string query = "SELECT A.ResimID,A.MarkaKodu,M.MarkaAdi,A.TipKodu,N.TipAdi,A.DosyaAdi FROM MODELLER_RESIM A INNER JOIN MARKALAR M ON M.MarkaKodu = A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu = A.TipKodu AND M.MarkaKodu = N.MarkaKodu ORDER BY M.MarkaAdi ";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCarImageDto>(query);
                return values.ToList();
            }
        }

        public async void UpdateImage(UpdateImageDto updateImageDto)
        {
            string query = "UPDATE MODELLER_RESIM SET MarkaKodu=@MarkaKodu,TipKodu=@TipKodu,DosyaAdi=@DosyaAdi WHERE ResimID=@ResimID";
            var parameters = new DynamicParameters();

            parameters.Add("@ResimID", updateImageDto.ResimID);
            parameters.Add("@MarkaKodu", updateImageDto.MarkaKodu);
            parameters.Add("@TipKodu", updateImageDto.TipKodu);
            parameters.Add("@DosyaAdi", updateImageDto.DosyaAdi);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task<ResultCarImageDto> GetImage(int id)
        {
            string query = "SELECT A.ResimID,A.MarkaKodu,M.MarkaAdi,A.TipKodu,N.TipAdi,A.DosyaAdi,A.Dosya FROM MODELLER_RESIM A INNER JOIN MARKALAR M ON M.MarkaKodu = A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu = A.TipKodu AND M.MarkaKodu = N.MarkaKodu WHERE ResimID=@ResimID";
            var parameters = new DynamicParameters();
            parameters.Add("@ResimID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultCarImageDto>(query, parameters);
                return values;
            }
        }
    }
}



