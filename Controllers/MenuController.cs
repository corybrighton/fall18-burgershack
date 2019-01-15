using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgerShack.Models;
using BurgerShack.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MenuController : ControllerBase
  {

    private readonly MenuRepository _menuRepo;
    public MenuController(MenuRepository repo)
    {
      _menuRepo = repo;
    }
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<MenuItem>> Get()
    {
      return Ok(_menuRepo.GetAll());
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<MenuItem> Get(int id)
    {
      MenuItem mItem = _menuRepo.GetItem(id);
      if (mItem != null) { return Ok(mItem); }
      return NotFound();
    }

    // POST api/values
    [HttpPost]
    public ActionResult<MenuItem> Post([FromBody] MenuItem item)
    {
      return Created("/api/cats/", _menuRepo.AddItem(item));
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<MenuItem> Put(int id, [FromBody] MenuItem item)
    {
      MenuItem result = _menuRepo.EditMenu(id, item);
      if (result != null) { return Ok(item); }
      return NotFound();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_menuRepo.DeleteMenuItem(id)) { return Ok("Success"); }
      return NotFound();
    }
  }
}
