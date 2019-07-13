using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 時間帯を管理するクラス(昼・夜のようなやつ)
/// </summary>
public class TimeZone : MonoBehaviour 
    {
    private float sun_rotate;

    //時間帯を保管している列挙型
    public enum time_zone {
        Daytime = 0,        //朝・昼
        Night               //夜
    };

    public time_zone _time_zone = time_zone.Daytime;
    public GameObject sun;     //太陽を保管する変数


    //デバッグ用変数
   // public Text timezone;

    void Update()
    {
        sun_rotate = sun.transform.eulerAngles.x;
       // Debug.Log("sunrotate:" + sun_rotate);
        //太陽の角度が0より上ならば昼　そうでなければ夜
        if(sun_rotate  >= 0 && sun_rotate <= 80)
        {
            _time_zone = time_zone.Daytime;
        }
        else if(sun_rotate >=270 )
        {
            _time_zone = time_zone.Night;
        }
       // Debug.Log("sun:" + sun_rotate);
      //  timezone.text = _time_zone.ToString();
    }

    /// <summary>
    /// enum型をstring型へ変換して、現在の状態を返すメソッド
    /// </summary>
    public string TimeZoneGet()
    {
        return _time_zone.ToString();
    }

}
