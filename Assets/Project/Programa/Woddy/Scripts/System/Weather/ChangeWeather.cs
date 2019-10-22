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

    public List<UniStorm.WeatherType> weathertype;
    public UniStorm.UniStormSystem unistrom;
    [SerializeField] private SeasonManagement season_management;
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
        sunny = !sunny;

        UpdateWeather(sunny);
    }

    private void UpdateWeather(bool _sunny)
    {
        if (_sunny != true)
        {
            if (season_management.now_season == SeasonManagement.Season.Winter)
                weather_num = (int)Weather.Snow;
            else
                weather_num = (int)Weather.Rain;
        }
        else
        {
            weather_num = (int)Weather.Sunny;
        }
        Debug.Log("weathertype" + weathertype[weather_num]);
        //unistrom.CurrentWeatherType = weathertype[weather_num];
        //unistrom.InitializeWeather(true);
        UniStorm.UniStormManager.Instance.ChangeWeatherWithTransition(weathertype[weather_num]);
       //UniStorm.UniStormManager.Instance.ChangeWeatherInstantly(weathertype[weather_num]);
    }
}
