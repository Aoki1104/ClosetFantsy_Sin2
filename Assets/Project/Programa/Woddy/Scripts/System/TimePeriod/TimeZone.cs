using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 時間帯を管理するクラス(昼・夜のようなやつ)
/// </summary>
public class TimeZone : MonoBehaviour 
    {
    
    //時間帯を保管している列挙型
    public enum time_zone {
        Daytime = 0,        //朝・昼
        Night               //夜
    };
    private time_zone _time_zone = time_zone.Daytime;

    private int now_minute;
    private int old_minute;
    public UniStorm.UniStormSystem unistrom;
    public Text time_zone_check;

    private void Start()
    {
        now_minute = unistrom.Minute;
        TimeZoneSet(unistrom.Hour, now_minute);
        time_zone_check.text = _time_zone.ToString();
    }

    void Update()
    {
        now_minute = unistrom.Minute;

        if (now_minute != old_minute)
            TimeZoneSet(unistrom.Hour,now_minute);

        time_zone_check.text = _time_zone.ToString();
    }

    /// <summary>
    /// 時間帯を設定する
    /// </summary>
    private void TimeZoneSet(int hour,int minute)
    {
        old_minute = minute;

        if (hour >= 7 && hour < 18)
            _time_zone = time_zone.Daytime;
        else if (hour >= 18)
            _time_zone = time_zone.Night;
        else if(hour >= 0 && hour < 7)
            _time_zone = time_zone.Night;
    }

    /// <summary>
    /// enum型をstring型へ変換して、現在の状態を返すメソッド
    /// </summary>
    public string TimeZoneGet()
    {
        return _time_zone.ToString();
    }

}
