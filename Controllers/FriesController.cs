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
  public class FriesController : ControllerBase
  {
    public List<Fries> Frys = new List<Fries>()
    {
      new Fries("Mark Fries", "A delicious Fries with bacon and stuff", 7.56f),
      new Fries("Jake Fries", "Now with fries!", 8.54f),
      new Fries("D$ Fries", "It's Mostly Foraged", 6.24f)
    };



    // GET api/Fries
    [HttpGet]
    public IEnumerable<Fries> Get()
    {
      return Frys;
    }

    // GET api/Fries/5
    [HttpGet("{id}")]
    public ActionResult<Fries> Get(int id)
    {
      try
      {
        return Frys[id];
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"NO SUCH Fries\"}");
      }
    }

    // POST api/Fries
    [HttpPost]
    public ActionResult<List<Fries>> Post([FromBody] Fries fries)
    {
      Frys.Add(fries);
      return Frys;
    }

    // PUT api/Fries/5
    [HttpPut("{id}")]
    public ActionResult<List<Fries>> Put(int id, [FromBody] Fries fries)
    {
      try
      {
        Frys[id] = fries;
        return Frys;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"NO SUCH BURGER\"}");
      }
    }

    // DELETE api/Fries/5
    [HttpDelete("{id}")]
    public ActionResult<List<Fries>> Delete(int id)
    {
      try
      {
        Frys.Remove(Frys[id]);
        return Frys;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"NO SUCH BURGER\"}");
      }
    }

  }
}