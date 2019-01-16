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
  public class SidesController : ControllerBase
  {
    private readonly SideRepository _sideRepo;
    public SidesController(SideRepository repo)
    {
      _sideRepo = repo;
    }

    // GET api/Sides
    [HttpGet]
    public IEnumerable<Side> Get()
    {
      return _sideRepo.GetAll();
    }

    // GET api/Sides/5
    [HttpGet("{id}")]
    public ActionResult<Side> Get(int id)
    {
      Side side = _sideRepo.GetSideById(id);
      if (side != null)
      {
        return Ok(side);
      }
      else
      {
        return NotFound();
      }
    }

    // POST api/Sides
    [HttpPost]
    public ActionResult<List<Side>> Post([FromBody] Side side)
    {
      return Ok(_sideRepo.AddSide(side));
    }

    // PUT api/Sides/5
    [HttpPut("{id}")]
    public ActionResult<Side> Put(int id, [FromBody] Side side)
    {
      return Ok(_sideRepo.UpdateSide(id, side));
    }

    // // DELETE api/Sides/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_sideRepo.DeleteSide(id)) { return Ok("Successfully Deleted"); }
      return BadRequest();
    }

  }
}