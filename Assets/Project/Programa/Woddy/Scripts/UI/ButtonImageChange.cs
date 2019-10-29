using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonImageChange : MonoBehaviour
{
    [SerializeField] private Image button_image;
    [SerializeField] private Sprite snow;
    [SerializeField] private Sprite rain;

    [SerializeField] private SeasonManagement season;

   public void ChangeImage()
    {
        if (season.now_season == SeasonManagement.Season.Summer)
            button_image.sprite = rain;
        else if (season.now_season == SeasonManagement.Season.Winter)
            button_image.sprite = snow;
    }
}
