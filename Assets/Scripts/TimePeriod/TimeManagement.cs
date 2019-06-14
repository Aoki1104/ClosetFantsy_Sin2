using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class TimeManagement : MonoBehaviour
{
    private float _filed_time;          //フィールドの時間を保管する変数
    private float max_time = 300.0f;    //進む時間の最大数値
    private float accel_time = 1.2f;    //時間の進み具合

    #region デバッグ用変数
          
    public Text timetext;
    public Text debugtimetext;

    private float debug_filed_time; //通常の時間の進みを持つ変数
    #endregion

    //フィールドの時間を保存するプロパティ
    private float filed_time {
        get { return _filed_time; }
        set { _filed_time = Mathf.Clamp(value,0.0f, max_time);}
    }



    private void Update()
    {
        TimeAdd();
        TimeReset();
        DebugTimeAdd();


      
        timetext.text = filed_time.ToString();
        debugtimetext.text = debug_filed_time.ToString();
    }



    /// <summary>
    /// 加速度の数値によって進む時間の速さを変更する
    /// </summary>
    private void TimeAdd()
    {
        filed_time += Time.deltaTime*accel_time;
    }

    /// <summary>
    /// 最大時間を超えたら0にリセットする
    /// </summary>
    private void TimeReset()
    {
        if (filed_time >= max_time)
            filed_time = 0;
    }

    /// <summary>
    /// 現在の時刻を返す
    /// </summary>
    public float TimeReturn()
    {
        return accel_time;
    }

    //デバッグ用の
    private void DebugTimeAdd()
    {
        debug_filed_time += Time.deltaTime;
    }
}
