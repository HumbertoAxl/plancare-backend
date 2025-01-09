using System.Text.Json;

namespace CarRegistrationStatus.API.Services
{
    public class MockDataProvider
    {
        public List<Car> GetCars()
        {
            var data = File.ReadAllText("./Data/mockCarsData.json");
            var cars = JsonSerializer.Deserialize<List<Car>>(data);
            
            return cars;
        }
    }
}