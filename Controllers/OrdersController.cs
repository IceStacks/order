using Application.OrderOperations.Commands;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.OrderOperations.Commands;
using WebApi.Application.OrderOperations.Validators;
using WebApi.DbOperations;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class OrderController : ControllerBase
    {
        private readonly OrdersDbContext _context;
        private readonly IMapper _mapper;

        public OrderController(OrdersDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // asagida yazdigim db baglantilari duzeltilecek. 
        // DI ile yapmaya calisacagim,  simdilik gecici olarak bu sekilde kullandim.

       
        [HttpGet]
        public IActionResult Index()
        {

            GetOrdersQuery query = new(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult Show(int id) // model ile olmali

        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(_context, _mapper);
            GetOrderDetailQueryValidator validator = new GetOrderDetailQueryValidator();
            return Ok();
        }

        [HttpPost]
        public IActionResult Store([FromBody] CreateOrderModel newOrder) // model ile olmali
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Order updatedSupplier) // model ile olmali
        {

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Destroy(int id)
        {
            return Ok();
        }
    }
}
