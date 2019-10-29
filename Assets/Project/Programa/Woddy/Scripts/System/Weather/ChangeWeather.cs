using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeather : MonoBehaviour
{
    private enum Weather {
        Sunny = 0,
        Rain = 1,
        Snow= 2
    }

    [SerializeField] private Weather weather;
    public List<UniStorm.WeatherType> weathertype;
    public UniStorm.UniStormSystem unistrom;
    private bool sunny = true;
    private int weather_num = 0;

    private void Start()
    {
        weathertype = unistrom.AllWeatherTypes;

        foreach(UniStorm.WeatherType allweather in weathertype )
        Debug.Log(allweather);
    }

    public void Change()
    { 
        UpdateWeather();
    }

    private void UpdateWeather()
    {
        weather_num = (int)weather;
 
        UniStorm.UniStormManager.Instance.ChangeWeatherWithTransition(weathertype[weather_num]);
    }
}
