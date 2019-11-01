using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 季節が移らないために月日を制限するクラス
/// </summary>
public class RestrictionDays : MonoBehaviour
{
    
    private int initialize_day = 1;
    public int initialize_month;
    public int limit_month;

    public UniStorm.UniStormSystem unistrom;
    public Text month;
    public Text day;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(limit_month < unistrom.Month)
        {
            unistrom.Month = initialize_month;
            unistrom.Day = initialize_day;
        }
        month.text = unistrom.Month.ToString();
        day.text = unistrom.Day.ToString();
    }
}
