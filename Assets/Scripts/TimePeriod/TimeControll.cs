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


    #region デバッグ用変数
    public Text debugtimetext;      
    private float debug_filed_time; //通常の時間の進みを持つ変数
    #endregion


    private void Update()
    {
        DebugTimeAdd(); 
    }

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

    //時間の移動変化を確認するためのデバック用関数
    private void DebugTimeAdd()
    {
        debug_filed_time += Time.deltaTime;
        debugtimetext.text = debug_filed_time.ToString();
    }
}
