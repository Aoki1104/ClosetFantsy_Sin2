using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControll : MonoBehaviour
{
    private int normal_speed = 1;
    private int accle_speed = 4;
    private bool time_accle = false;
    [SerializeField] private GameObject accel_particle;

    public void TimeChange()
    {
        time_accle = !time_accle;
        
        if (time_accle)
            TimeAccel();
        else
            TimeNormal();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            TimeChange();

    }

    /// <summary>
    /// 時間の流れを普通に戻す
    /// </summary>
    private void TimeNormal()
    {
        Time.timeScale = normal_speed;
        accel_particle.SetActive(false);
    }

    /// <summary>
    /// 時間を加速させる
    /// </summary>
    private void TimeAccel()
    {
        Time.timeScale = accle_speed;
        accel_particle.SetActive(true);
    }
    
}
