

namespace gregslist_csharp.Repositories;
public class CarsRepository
{
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Car GetCarById(int carId)
  {
    string sql = "SELECT * FROM cars WHERE id = @id;";
    // NOTE                           {id: 4}
    Car car = _db.Query<Car>(sql, new { id = carId }).FirstOrDefault();
    return car;
  }

  internal List<Car> GetCars()
  {
    string sql = "SELECT * FROM cars;";

    List<Car> cars = _db.Query<Car>(sql).ToList();
    return cars;
  }
}