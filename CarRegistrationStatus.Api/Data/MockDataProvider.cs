using CarRegistrationStatus.API.Services;

public class CarService
{
    private readonly MockDataProvider _mockDataProvider;
    private List<Car> _cars;

    public CarService()
    {
        _mockDataProvider = new MockDataProvider();
        _cars = _mockDataProvider.GetCars();
    }

    public List<Car> GetCars(string? make = null)
    {
        if (string.IsNullOrEmpty(make))
        {
            return _cars;
        }
        else
        {
            return _cars.Where(car => car.Make.Equals(make, StringComparison.OrdinalIgnoreCase)).ToList();
        }

    }
}
