using FiloKiralama_Api.Dtos.FleetOffer;
using FiloKiralama_Api.Repositories.FleetOffer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FleetOfferController : ControllerBase
    {
        private readonly IFleetOfferRepository _fleetOfferRepository;

        public FleetOfferController(IFleetOfferRepository fleetOfferRepository)
        {
            _fleetOfferRepository = fleetOfferRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOffer(CreateSendAnOfferDto createSendAnOfferDto)
        {
            _fleetOfferRepository.CreateOffer(createSendAnOfferDto);
            return Ok("Teklif başarılı bir şekilde eklendi");
        }
        [HttpGet]
        public async Task<IActionResult> OfferList()
        {
            var values = await _fleetOfferRepository.GetAllOffer();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFleetOffer(int id)
        {
            var value = await _fleetOfferRepository.GetFleetOffer(id);
            return Ok(value);
        }
    }
}
