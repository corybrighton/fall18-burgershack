using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BurgerShack.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SidesController : ControllerBase
  {
    public List<Side> Sides = new List<Side>()
    {
      new Side("Mark Fries", "A delicious Fries with bacon and stuff", 7.56f),
      new Side("Jake Fries", "Now with fries!", 8.54f),
      new Side("D$ Fries", "It's Mostly Foraged", 6.24f)
    };



    // GET api/Sides
    [HttpGet]
    public IEnumerable<Side> Get()
    {
      return Sides;
    }

    // GET api/Fries/5
    [HttpGet("{id}")]
    public ActionResult<Side> Get(int id)
    {
      try
      {
        return Sides[id];
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"NO SUCH Fries\"}");
      }
    }

    // POST api/Fries
    [HttpPost]
    public ActionResult<List<Side>> Post([FromBody] Side side)
    {
      Sides.Add(side);
      return Sides;
    }

    // PUT api/Fries/5
    [HttpPut("{id}")]
    public ActionResult<List<Side>> Put(int id, [FromBody] Side fries)
    {
      try
      {
        Sides[id] = fries;
        return Sides;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"NO SUCH BURGER\"}");
      }
    }

    // DELETE api/Fries/5
    [HttpDelete("{id}")]
    public ActionResult<List<Side>> Delete(int id)
    {
      try
      {
        Sides.Remove(Sides[id]);
        return Sides;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"NO SUCH BURGER\"}");
      }
    }

  }
}