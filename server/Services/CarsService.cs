namespace gregslist_csharp.Services;

public class CarsService
{
  private readonly CarsRepository _repository;

  public CarsService(CarsRepository repository)
  {
    _repository = repository;
  }

  internal Car CreateCar(Car carData)
  {
    Car car = _repository.CreateCar(carData);
    return car;
  }

  internal string DestroyCar(int carId, string userId)
  {
    Car carToDestroy = GetCarById(carId);

    if (carToDestroy.CreatorId != userId)
    {
      throw new Exception("NOT YOUR CAR");
    }

    _repository.DestroyCar(carId);


    return $"{carToDestroy.Make} {carToDestroy.Model} has been destroyed.";
  }

  internal Car GetCarById(int carId)
  {
    Car car = _repository.GetCarById(carId);

    if (car == null)
    {
      throw new Exception($"Invalid id: {carId}");
    }

    return car;
  }

  internal List<Car> GetCars()
  {
    List<Car> cars = _repository.GetCars();
    return cars;
  }
}