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
  }
}
