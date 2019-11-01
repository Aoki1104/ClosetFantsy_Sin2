using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeatherManager : MonoBehaviour
{
    public enum Weather
    {
        Sunny = 0,
        Rain = 1,
        Snow = 2
    }
    private Weather now_weather = Weather.Sunny;
    private Weather old_weather = Weather.Sunny;
    [SerializeField] private ParticleSystem water_fall;

    public List<UniStorm.WeatherType> weathertype;
    public UniStorm.UniStormSystem unistrom;
    private int weather_num = 0;
    private String weather_name;
    private void Start()
    {
        weathertype = unistrom.AllWeatherTypes;

        foreach (UniStorm.WeatherType allweather in weathertype)
            Debug.Log(allweather);

        weather_name = UniStorm.UniStormSystem.Instance.CurrentWeatherType.WeatherTypeName;

    }

    private void Update()
    {
        if (weather_name != UniStorm.UniStormSystem.Instance.CurrentWeatherType.WeatherTypeName)
            NatureWeatherChange();
    }

    public void UpdateWeather(int weather_type)
    {
        weather_num = weather_type;
        now_weather = (Weather)Enum.ToObject(typeof(Weather), weather_num);
        UniStorm.UniStormManager.Instance.ChangeWeatherWithTransition(weathertype[weather_num]);
        
        WeatherEnd(old_weather);
        WeatherInitialize(now_weather);
        old_weather = now_weather;

        weather_name = UniStorm.UniStormSystem.Instance.CurrentWeatherType.WeatherTypeName;
        Debug.Log("name:" + weather_name);
    }

    private void NatureWeatherChange()
    {
        weather_name = UniStorm.UniStormSystem.Instance.CurrentWeatherType.WeatherTypeName;
        switch (weather_name)
        {
            case "Clear":
                UpdateWeather((int)Weather.Sunny);
                break;
            case "Rain":
                UpdateWeather((int)Weather.Rain);
                break;
            case "Snow":
                UpdateWeather((int)Weather.Snow);
                break;
        }
        Debug.Log("name:" + weather_name);
    }


    public void WeatherInitialize(Weather weather_type)
    {
        switch(weather_type)
        {
            case Weather.Sunny:
                break;

            case Weather.Rain:
                water_fall.Play();
                break;

            case Weather.Snow:
                break;
        }
    }

    private void WeatherEnd(Weather weather_type)
    {
        switch (weather_type)
        {
            case Weather.Sunny:
                break;

            case Weather.Rain:
                water_fall.Stop();
                break;

            case Weather.Snow:
                break;
        }
    }

}
