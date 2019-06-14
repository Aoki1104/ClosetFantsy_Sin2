using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 天候ボタンの変化クラス
/// </summary>
public class WeatherButton : MonoBehaviour
{
    public WeatherBase weather_base;

    //晴れに変更
    public void ChangeSun()
    {
        weather_base.ChangeWeather("sun");
    }

    //雨に変更
    public void ChangeRain()
    {
        weather_base.ChangeWeather("rain");
    }
}
