using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApi.DbOperations;
using WebApi.Models;
using System.Linq;
using Utilities;
using WebApi.Application.OrderOperations.Commands;
using AutoMapper;
using WebApi.Application.OrderOperations.Validators;
using FluentValidation;
using WebApi.Models.WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class MigrationController : ControllerBase
    {

        private readonly OrdersDbContext _context;
        private readonly IMapper _mapper;

        public MigrationController(OrdersDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("migrating")]
        public IActionResult Migrating([FromQuery] string value)
        {
            if (value.Equals("migrate"))
            {
                var migrator = _context.Database.GetService<IMigrator>();

                migrator.Migrate();

                return Ok("Successful");
            }
            else
            {
                return BadRequest("Invalid value");
            }
        }

        [HttpPost("fakedata")]
        public IActionResult FakeData([FromQuery] string value)
        {
            if (value.Equals("fakedata"))
            {
                CreateFakeData command = new CreateFakeData(_context);

                int n = 10;

                for (int i = 0; i < n; i++)
                {
                    var newOrder = Order.FakeData.Generate(1).First();
                    command.Model = newOrder;
                    var result = command.Handle();
                    if (result.Success == false)
                    {
                        return BadRequest(result);
                    }
                }
                return Ok("success");
            }
            else
            {
                return BadRequest("Invalid value");
            }
        }
    }
}