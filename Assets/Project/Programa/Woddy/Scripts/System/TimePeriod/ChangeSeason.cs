using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSeason : MonoBehaviour
{
    [SerializeField] private SeasonManagement season_management;
    private int[] month = { 12,7 };
    private int sequence_month = 0;
    [SerializeField] private ButtonImageChange weather_button_image;

    public void SeasonChange()
    {
            season_management.ChangeMonth(month[sequence_month]);
            sequence_month++;
        if (sequence_month >= month.Length)
            sequence_month = 0;

        weather_button_image.ChangeImage();
    }


}
