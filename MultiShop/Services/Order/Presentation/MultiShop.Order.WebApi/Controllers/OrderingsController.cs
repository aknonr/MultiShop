using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {

        //Cqrs deki gibi tek tek handler için nesne örneği oluşturmayacaz . Asagıdaki yapmamız yeterlidir. 
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> OrderingList()
        {
            //Send metodu bizim handler ulaşmamızı sağlayacak . Irequesti miras alan sınıfı cagıracaz.
            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            var values = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(values);
        }


        [HttpPost]

        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            //Bu sefer send parametre aldı commandı aldı command nerden geldi  CreateOrderingCommand sınfına bakınca Irequestden miras almıs. Yani dolaylı yoldan olmus oldu.
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla eklendi");
        }


        [HttpDelete]

        public async Task<IActionResult> RemoveOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Siparis basarıyla silindi");
        }


        [HttpPut]

        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Siparis basarıyla güncellendi");
        }
    }
}
