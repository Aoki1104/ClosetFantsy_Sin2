using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 時間の進む速度を管理するクラス
/// </summary>
public class TimeControll : MonoBehaviour
{
    private float time_speed = 1.0f;    //時間の進む速度を保有する変数
    private float accel_speed = 2.0f;
    private float normal_speed = 1.0f;

    /// <summary>
    /// 時間を加速させる
    /// </summary>
    public void TimeSpeedAccel()
    {
        time_speed = accel_speed;
        Time.timeScale = time_speed;
    }

    /// <summary>
    /// 通常の時間速度に設定する
    /// </summary>
    public void TimeSpeedNormal()
    {
        time_speed = normal_speed;
        Time.timeScale = time_speed;
    }

}
