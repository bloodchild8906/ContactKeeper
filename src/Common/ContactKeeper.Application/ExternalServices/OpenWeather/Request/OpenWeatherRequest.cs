namespace ContactKeeper.Application.ExternalServices.OpenWeather.Request;

public class OpenWeatherRequest
{
    public string Q { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
    public Guid Id { get; set; }
}