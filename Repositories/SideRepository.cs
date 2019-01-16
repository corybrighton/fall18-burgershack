using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class SideRepository
  {
    private readonly IDbConnection _db;
    public SideRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Side> GetAll()
    {
      return _db.Query<Side>("SELECT * FROM Sides;");
    }

    public Side GetSideById(int id)
    {
      return _db.QueryFirstOrDefault<Side>($"SELECT * FROM Sides WHERE id = @id", new { id });
    }

    // Create
    public Side AddSide(Side side)
    {
      int id = _db.ExecuteScalar<int>(@"
 	INSERT INTO Sides (name, description, price) VALUES (@Name, @Description, @Price); 
 	SELECT LAST_INSERT_ID()", new
      {
        side.Name,
        side.Description,
        side.Price
      });
      side.id = id;
      return side;
    }

    // Update
    public Side UpdateSide(int id, Side side)
    {
      _db.ExecuteScalar<int>(@"
 	UPDATE Sides SET 
   Name = @Name,
   Description = @Description,
   Price = @Price
   WHERE id = @id; 
 	SELECT LAST_INSERT_ID()", new
      {
        side.Name,
        side.Description,
        side.Price,
        id
      });
      side.id = id;
      return side;
    }

    public bool DeleteSide(int id)
    {
      _db.Query<Side>($"DELETE FROM Sides WHERE id = @id", new { id });
      return true;
    }
  }
}