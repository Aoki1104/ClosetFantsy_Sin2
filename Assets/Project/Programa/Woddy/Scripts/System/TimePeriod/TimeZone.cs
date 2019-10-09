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
        Evening,
        Night               //夜
    };
    private time_zone now_time_zone = time_zone.Daytime;
    private time_zone old_time_zone = time_zone.Daytime;

    private int now_minute;
    private int old_minute;
    private int tmp_hour; 
    private float minute_forward_max_sec = 2.0f;  //夕方の間の時間を進める秒数
    private float minute_forward_sec;
    public UniStorm.UniStormSystem unistrom;
    public Text time_zone_check;

    private void Start()
    {
        TimeUpdate();
    }

    void Update()
    {
        TimeUpdate();

        if (old_time_zone != now_time_zone)
            AdjustTimeVelocity();
    }

    private void TimeUpdate()
    {
        now_minute = unistrom.Minute;

        if (now_minute != old_minute)
            TimeZoneSet(unistrom.Hour, now_minute);

        time_zone_check.text = now_time_zone.ToString();
    }

    /// <summary>
    /// 時間帯を設定する
    /// </summary>
    private void TimeZoneSet(int hour,int minute)
    {
        old_minute = minute;
        if (hour >= 7 && hour < 17)
            now_time_zone = time_zone.Daytime;
        else if (hour >= 17 && hour < 19)
            now_time_zone = time_zone.Evening;
        else if(hour >= 19)
            now_time_zone = time_zone.Night;
        else if(hour >= 0 && hour < 7)
            now_time_zone = time_zone.Night;
    }

    /// <summary>
    /// 時間帯によって時間の進む速さを調整する
    /// </summary>
    private void AdjustTimeVelocity()
    {
        if (now_time_zone == time_zone.Evening)
            unistrom.DayLength = 3;
        else
            unistrom.DayLength = 1;

        old_time_zone = now_time_zone;
    }

    /// <summary>
    /// enum型をstring型へ変換して、現在の状態を返すメソッド
    /// </summary>
    public string TimeZoneGet()
    {
        return now_time_zone.ToString();
    }

}
