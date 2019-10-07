using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// 季節が移らないために月日を制限するクラス
/// </summary>
public class SeasonManagement : MonoBehaviour
{
    public enum Season {
        Summer =7,
        Winter = 12
    }

    public Season now_season;

    private int first_date = 1;
    private int rewind_month = 7;

    public UniStorm.UniStormSystem unistrom;
    [SerializeField]private Text month;
    [SerializeField]private Text day;

    // Start is called before the first frame update
    void Start()
    {
        now_season = Season.Summer;
    }

    // Update is called once per frame
    void Update()
    {
        RevertMonth();
        month.text = unistrom.Month.ToString();
        day.text = unistrom.Day.ToString();
    }

    /// <summary>
    /// 現在の季節の初めの月に戻す
    /// </summary>
    private void RevertMonth()
    {
        if (rewind_month != unistrom.Month)
        {
            unistrom.Month = rewind_month;
            unistrom.Day = first_date;
        }
    }

    public void ChangeMonth(int month)
    {
        now_season = (Season)Enum.ToObject(typeof(Season), month);
        rewind_month = (int)now_season;
    }
    
}