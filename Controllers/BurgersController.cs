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
  public class BurgersController : ControllerBase
  {
    private readonly BurgerRepository _burgerRepo;
    public BurgersController(BurgerRepository repo)
    {
      _burgerRepo = repo;
    }

    // GET api/Burgers
    [HttpGet]
    public IEnumerable<Burger> Get()
    {
      return _burgerRepo.GetAll();
    }

    // GET api/Burgers/5
    [HttpGet("{id}")]
    public ActionResult<Burger> Get(int id)
    {
      Burger burger = _burgerRepo.GetBurgerById(id);
      if (burger != null)
      {
        return Ok(burger);
      }
      else
      {
        return NotFound();
      }
    }

    // POST api/Burgers
    [HttpPost]
    public ActionResult<List<Burger>> Post([FromBody] Burger burger)
    {
      return Ok(_burgerRepo.AddBurger(burger));
    }

    // PUT api/Burgers/5
    [HttpPut("{id}")]
    public ActionResult<Burger> Put(int id, [FromBody] Burger burger)
    {
      return Ok(_burgerRepo.UpdateBurger(id, burger));
    }

    // // DELETE api/Burgers/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_burgerRepo.DeleteBurger(id)) { return Ok("Successfully Deleted"); }
      return BadRequest();
    }

  }
}