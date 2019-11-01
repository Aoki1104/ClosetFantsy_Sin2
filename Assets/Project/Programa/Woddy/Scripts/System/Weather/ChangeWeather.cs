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
    private WeatherManager weather_manager;

    private void Start()
    {
        weather_manager = GameObject.Find("WeatherManager").GetComponent<WeatherManager>();
    }

    public void Change()
    {
        weather_manager.UpdateWeather((int)weather);
    }

    

}
