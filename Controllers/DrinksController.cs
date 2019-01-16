using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BurgerShack.Models;
using BurgerShack.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DrinksController : ControllerBase
  {
    private readonly DrinkRepository _drinkRepo;
    public DrinksController(DrinkRepository repo)
    {
      _drinkRepo = repo;
    }

    // GET api/Drinks
    [HttpGet]
    public IEnumerable<Drink> Get()
    {
      return _drinkRepo.GetAll();
    }

    // GET api/Drinks/5
    [HttpGet("{id}")]
    public ActionResult<Drink> Get(int id)
    {
      Drink drink = _drinkRepo.GetDrinkById(id);
      if (drink != null)
      {
        return Ok(drink);
      }
      else
      {
        return NotFound();
      }
    }

    // POST api/Drinks
    [HttpPost]
    public ActionResult<List<Drink>> Post([FromBody] Drink drink)
    {
      return Ok(_drinkRepo.AddDrink(drink));
    }

    // PUT api/Drinks/5
    [HttpPut("{id}")]
    public ActionResult<Drink> Put(int id, [FromBody] Drink drink)
    {
      return Ok(_drinkRepo.UpdateDrink(id, drink));
    }

    // // DELETE api/Drinks/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_drinkRepo.DeleteDrink(id)) { return Ok("Successfully Deleted"); }
      return BadRequest();
    }

  }
}