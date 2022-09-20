using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Mapping;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.ExternalServices.OpenWeather.Request;
using ContactKeeper.Application.ExternalServices.OpenWeather.Response;
using ContactKeeper.Domain.Enums;

namespace ContactKeeper.Infrastructure.Services;

public class OpenWeatherService : IOpenWeatherService
{
    private readonly IHttpClientHandler _httpClient;

    private string ClientApi { get; } = "open-weather-api";

    public OpenWeatherService(IHttpClientHandler httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request, CancellationToken cancellationToken)
    {
        return await _httpClient.GenericRequest<OpenWeatherRequest, OpenWeatherResponse>(ClientApi, string.Concat("weather?", StringExtensions
            .ParseObjectToQueryString(request, true)), cancellationToken, MethodType.Get, request);
    }
}