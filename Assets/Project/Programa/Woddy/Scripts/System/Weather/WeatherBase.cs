using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*  検討中の仕様
public enum weather {
    Sunny = 0,
    Rain
}

public class WeatherBase : StatefulObjectBase<WeatherBase,weather>
{



    private void Start()
    {
        Initalize();
    }

    private void Initalize()
    {
        statelist.Add(new Sunny(this));
        statelist.Add(new Rain(this));

        statemachine = new ObjStateMachine<WeatherBase>();

        ChangeState(weather.Sunny);
    }


    /// <summary>
    /// 晴れの状態
    /// </summary>
    class Sunny : State<WeatherBase>
    {
        public Sunny(WeatherBase owner) : base(owner) { }


    }

    /// <summary>
    /// 雨の状態
    /// </summary>
    class Rain  : State<WeatherBase>
    {
        public Rain(WeatherBase owner) : base(owner) { }

    }
}
*/

public class WeatherBase :MonoBehaviour
{
    public Text weather_text;
    [SerializeField] private GameObject water_fall;

     public enum weather 
    {
        sun=0,
        rain,
        snow
    }

    weather _weather;

    
   public void ChangeWeather(string tmp_weather)
    {
        if (tmp_weather == "sun")
            _weather = weather.sun;
        if (tmp_weather == "rain")
            _weather = weather.rain;
    }

    //雨のときの初期化
    private void RainInitialize()
    {
        water_fall.SetActive(true);
    }

    public string GetWeather()
    {
        return _weather.ToString();
    }

    private void Update()
    {
        weather_text.text = _weather.ToString();    
    }
}