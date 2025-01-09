using CarRegistrationStatus.API.Services;
using Microsoft.AspNetCore.SignalR;

public class RegistrationHub : Hub
{
    private static PeriodicTimer _timer;
    private static CancellationTokenSource _cancellationTokenSource;
    private static Car _car;
    public async Task CheckCarRegistration(Guid? carId)
    {

    var mockDataProvider = new MockDataProvider();

        if (_timer == null)
        {
            _timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
            _cancellationTokenSource = new CancellationTokenSource();
        }

        _car = mockDataProvider.GetCars().FirstOrDefault(c => c.Id == carId);

        while (await _timer.WaitForNextTickAsync(_cancellationTokenSource.Token))
        {

            await Clients.All.SendAsync("CarRegistration", new
            {
                isRegistrationValid = _car?.RegistrationExpiryDate > DateTime.Now,
                currentTime = DateTime.Now
            });
        }
    }
}
