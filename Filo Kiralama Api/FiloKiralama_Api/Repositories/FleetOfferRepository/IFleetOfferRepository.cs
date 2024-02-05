using FiloKiralama_Api.Dtos.FleetOffer;
using FiloKiralama_Api.Dtos.FleetOfferDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.FleetOffer
{
    public interface IFleetOfferRepository
    {
        void CreateOffer(CreateSendAnOfferDto createSendAnOfferDto);
        Task<List<ResultFleetOfferDto>> GetAllOffer();

        Task<ResultFleetOfferDto> GetFleetOffer(int id);
    }
}
