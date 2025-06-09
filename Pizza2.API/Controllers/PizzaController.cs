using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza.CORE.DTOs;
using Pizza.CORE.Iterfaces;
using Pizza.CORE.Models;

namespace Pizza2.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaRepository _repository;

        public PizzaController(IPizzaRepository repository)
        {
            _repository = repository;
        }

        [Authorize(Roles = "Customer,Admin")]
        [HttpGet("GetAllPizza")]

        public async Task<IActionResult> GetAllPizza()
        {
            var allpizza = await _repository.GetAllAsync();
            if (allpizza == null)
                return NotFound(null);
            var sizes = new List<string>();
            sizes = ["L" , "M" , "S"];
            foreach (var p in allpizza)
                p.AvailableSizes = sizes;
            return Ok(allpizza);
        }
        [Authorize(Roles = "Customer,Admin")]
        [HttpPost("GetPizzaByName")]
        public async Task<IActionResult> GetPizza([FromBody]PizzaSummaryDto dto)
        {
            var p = await _repository.GetPizzaAsync(dto);
            if(p == null)
                return NotFound("pizaa not found !");
            return Ok(p);

        }
        [Authorize(Roles = "Customer,Admin")]

        [HttpPost("filterByPrice{x}")]
        public async Task<IActionResult> FilterPrice(int x)
        {
            var p = await _repository.FilterPrice(x);
            if (p == null)
                return NotFound("pizaa not found !");
            return Ok(p);

        }

        [Authorize(Roles = "Admin")]

        [HttpPost("AddPizza")]
        public async Task<IActionResult> AddPizza(PizzaDto p)
        {
            pizza new_pizza = new pizza();
            new_pizza.Name = p.Name;
            new_pizza.size = p.size;
            new_pizza.Description = p.Description;
            new_pizza.Price = p.Price;
            new_pizza.ImageUrl = p.ImageUrl;
            await _repository.AddAsync(new_pizza);
            return Ok(new_pizza);
        }
        [Authorize(Roles = "Admin")]

        [HttpPut("Update{id}")]
        public async Task<IActionResult> UpdatePizza(int id , PizzaDto p)
        {

            pizza new_pizza = await _repository.GetById(id);
            if (new_pizza == null)
                return NotFound($"no pizza with id : {id}");
            new_pizza.Name = p.Name;
            new_pizza.size = p.size;
            new_pizza.Description = p.Description;
            new_pizza.Price = p.Price;
            new_pizza.ImageUrl = p.ImageUrl;
            _repository.Update(id , new_pizza);
            return Ok(new_pizza);
        }

        [Authorize(Roles = "Admin")]

        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> DeletePiza(int id)
        {
            var del = await _repository.GetById(id);
            if (del == null)
                return NotFound("Pizza not found!");
            _repository.Delete(del);
            return Ok("Deleted successfully");
        }

    }
}
