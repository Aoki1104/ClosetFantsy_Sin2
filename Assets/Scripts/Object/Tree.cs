using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private Vector3 tree_size = new Vector3(1, 1, 1);
    private Vector3 growspeed = new Vector3(0.1f, 0.1f, 0.1f);
    private Vector3 maxsize = new Vector3(5, 5, 5);

    public WeatherBase weather_base;
    public TimeManagement time_management;
    public TimeZone time_zone;


    private void Update()
    {
        if(time_zone.TimeZoneGet() == "Daytime" && weather_base.GetWeather() == "rain")
        //木の大きさが最大サイズ以下だったら成長し続ける
        if (tree_size.x <= maxsize.x && tree_size.y <= maxsize.y && tree_size.z <= maxsize.z)
        {
            tree_size += growspeed * Time.deltaTime * time_management.TimeReturn() ;
            transform.localScale = tree_size;
        }
    }
}
