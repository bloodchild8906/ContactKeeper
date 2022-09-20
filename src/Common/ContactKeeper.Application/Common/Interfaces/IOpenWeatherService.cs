using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.ExternalServices.OpenWeather.Request;
using ContactKeeper.Application.ExternalServices.OpenWeather.Response;

namespace ContactKeeper.Application.Common.Interfaces;

public interface IOpenWeatherService
{
    Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request,
        CancellationToken cancellationToken);
}