using System;
using System.Collections.Generic;

public abstract class WeatherProvider
{
    public abstract string GetWeather();
}

public class LocalWeatherProvider : WeatherProvider
{
    public override string GetWeather()
    {
        // Logic for fetching weather information from a local source
        return "Sunny";
    }
}

public class RemoteWeatherProvider : WeatherProvider
{
    public override string GetWeather()
    {
        // Logic for fetching weather information from a remote API
        return "Cloudy";
    }
}

public class WeatherApp
{
    private WeatherProvider _weatherProvider;

    public WeatherApp(WeatherProvider weatherProvider)
    {
        _weatherProvider = weatherProvider;
    }

    public void DisplayWeather()
    {
        string weather = _weatherProvider.GetWeather();
        Console.WriteLine($"Current weather: {weather}");
    }
}
