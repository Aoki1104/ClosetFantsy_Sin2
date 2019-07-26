using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeather : MonoBehaviour
{

    public UniStorm.WeatherType[] weathertype;
    public UniStorm.UniStormSystem unistrom;
    private bool rainy = false;


    public void Change()
    {
        rainy = !rainy;

        if (rainy)
            Rain();
        else
            Sunny();
    }


    /// <summary>
    /// 晴れ
    /// </summary>
    private void Sunny()
    {
        unistrom.CurrentWeatherType = weathertype[0];
        unistrom.InitializeWeather(true);
    }
    

    private void Rain()
    {
        unistrom.CurrentWeatherType = weathertype[1];
        unistrom.InitializeWeather(true);
    }
}
