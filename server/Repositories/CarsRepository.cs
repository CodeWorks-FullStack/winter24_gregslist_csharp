




namespace gregslist_csharp.Repositories;
public class CarsRepository
{
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Car CreateCar(Car carData)
  {
    string sql = @"
    INSERT INTO
    cars(make, model, year, price, imgUrl, hasSalvagedTitle, engineType, color, creatorId)
    VALUES(@Make, @Model, @Year, @Price, @ImgUrl, @HasSalvagedTitle, @EngineType, @Color, @CreatorId);
    
    SELECT * FROM cars WHERE id = LAST_INSERT_ID();";

    Car car = _db.Query<Car>(sql, carData).FirstOrDefault();
    return car;
  }

  internal void DestroyCar(int carId)
  {
    string sql = "DELETE FROM cars WHERE id = @carId LIMIT 1;";

    _db.Execute(sql, new { carId });
  }

  internal Car GetCarById(int carId)
  {
    // NOTE dapper will look through the object passed to it for a key of id and inject the value into our sql statement
    string sql = "SELECT * FROM cars WHERE id = @id;";

    // NOTE second argument passed to dapper is an anonymous object, with our int id stored inside.
    //                                   {id: 4}
    Car car = _db.Query<Car>(sql, new { id = carId }).FirstOrDefault();
    return car;
  }

  internal List<Car> GetCars()
  {
    string sql = "SELECT * FROM cars;";

    List<Car> cars = _db.Query<Car>(sql).ToList();
    return cars;
  }

  internal Car UpdateCar(Car carToUpdate)
  {
    string sql = @"
      UPDATE cars
      SET
      make = @Make,
      model = @Model,
      price = @Price,
      hasSalvagedTitle = @HasSalvagedTitle
      WHERE id = @Id
      LIMIT 1;
      
      SELECT * FROM cars WHERE id = @Id;";

    Car car = _db.Query<Car>(sql, carToUpdate).FirstOrDefault();
    return car;
  }
}