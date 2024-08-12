using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService CargoOperationService)
        {
            _cargoOperationService = CargoOperationService;
        }

        [HttpGet]

        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationService.TGetAll();

            return Ok(values);
        }

        [HttpPost]

        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate,
            };
            _cargoOperationService.TInsert(cargoOperation);

            return Ok("Cargo işlemi Başarıyla oluşturuldu");
        }



        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo şirketi başarıyla silindi");

        }

        [HttpGet("id")]

        public IActionResult GetCargoOperationById(int id)
        {
            var values = _cargoOperationService.TGetById(id);
            return Ok(values);

        }


        [HttpPut]

        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {

            CargoOperation CargoOperation = new CargoOperation()
            {
                Barcode = updateCargoOperationDto.Barcode,
                CargoOperationId=updateCargoOperationDto.CargoOperationId,
                Description=updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate,
               
            };

            _cargoOperationService.TUpdate(CargoOperation);

            return Ok("Kargo şirketi başarıyla güncellendi");
        }
    }
}
