using Application.OrderOperations.Commands;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
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

        [HttpPost("migrating")]
        public IActionResult Migrating([FromBody] string value)
        {
            if(value == "migrate")
            {
                var migrator = _context.Database.GetService<IMigrator>();

                migrator.Migrate();

                return Ok("Successful");
            }
            else {
                return BadRequest("Invalid value");
            }

        }

         [HttpGet]
        public IActionResult Index()
        {

            GetOrdersQuery query = new(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(_context, _mapper);
            GetOrderDetailQueryValidator validator = new GetOrderDetailQueryValidator();

            query.OrderId = id;

            validator.ValidateAndThrow(query);

            var result = query.Handle();

            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Store([FromBody] CreateOrderModel newOrder)
        {
            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();

            command.Model = newOrder;

            validator.ValidateAndThrow(command);

            var result = command.Handle();
            
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] UpdateOrderModel updatedOrder)
        {
            UpdateOrderCommand command = new UpdateOrderCommand(_context, _mapper);
            UpdateOrderCommandValidator validator = new UpdateOrderCommandValidator();

            command.OrderId = id;
            command.Model = updatedOrder;

            validator.ValidateAndThrow(command);

            var result = command.Handle();

            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Destroy(int id)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(_context);
            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();

            command.OrderId = id;

            validator.ValidateAndThrow(command);

            var result = command.Handle();

            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}