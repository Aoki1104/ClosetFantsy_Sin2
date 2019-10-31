using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelButton_pumpkin : MonoBehaviour
{
    public bool pumpkin_move = false;//カボチャが動いてるかどうか判別

    public void OnClick()
    {
        pumpkin_move = !pumpkin_move;
    }

}
