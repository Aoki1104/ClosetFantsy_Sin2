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
    private time_zone _time_zone = time_zone.Daytime;

    private int now_minute;
    private int old_minute;
    private float minute_forward_max_sec = 5.0f;  //夕方の間の時間を進める秒数
    private float minute_forward_sec;
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
        if (_time_zone != time_zone.Evening)
            TimeUpdate();
        else
            EveningSlow();
        time_zone_check.text = _time_zone.ToString();
    }

    private void TimeUpdate()
    {
        now_minute = unistrom.Minute;

        if (now_minute != old_minute)
            TimeZoneSet(unistrom.Hour, now_minute);
    }

    /// <summary>
    /// 時間帯を設定する
    /// </summary>
    private void TimeZoneSet(int hour,int minute)
    {
        old_minute = minute;
        if (hour >= 7 && hour < 17)
            _time_zone = time_zone.Daytime;
        else if (hour >= 17 || hour < 19)
            _time_zone = time_zone.Evening;
        else if(hour >= 19)
            _time_zone = time_zone.Night;
        else if(hour >= 0 && hour < 7)
            _time_zone = time_zone.Night;
    }



    /// <summary>
    /// 夕方の間だけ時間の進め方を遅くする
    /// </summary>
    private void EveningSlow()
    {
            minute_forward_sec += Time.deltaTime;
            unistrom.Minute = now_minute;

            if (minute_forward_sec > minute_forward_max_sec)
            {
                Debug.Log("Complete");
                minute_forward_sec = 0;
                TimeUpdate();
            }
    }

    /// <summary>
    /// enum型をstring型へ変換して、現在の状態を返すメソッド
    /// </summary>
    public string TimeZoneGet()
    {
        return _time_zone.ToString();
    }

}
