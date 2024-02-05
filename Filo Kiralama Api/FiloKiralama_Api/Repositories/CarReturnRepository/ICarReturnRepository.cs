using FiloKiralama_Api.Dtos.CarReturnDtos;

namespace FiloKiralama_Api.Repositories.CarReturnRepository
{
    public interface ICarReturnRepository
    {
        void CreateCarReturn(CreateCarReturnDto createCarReturnDto);
    }
}
