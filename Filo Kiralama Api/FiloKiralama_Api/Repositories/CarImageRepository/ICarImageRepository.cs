using FiloKiralama_Api.Dtos.CarImageDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.CarImageRepository
{
    public interface ICarImageRepository
    {
       public  Task<List<ResultCarImageDto>> AllCarImage();
        //void UploadFile(CreateImageDto createImageDto);
        public Tuple<int, string> SaveCarImage(IFormFile imagefile);
        //public Tuple<int, string> SaveCarImage(CreateImageDto createImageDto);
        public bool DeleteCarImage(string imageFileName);
        void DeleteImage(int id);
        void CreateImage(CreateImageDto createImageDto);
        void UpdateImage(UpdateImageDto updateImageDto);
        Task<ResultCarImageDto> GetImage(int id);
    }
}
