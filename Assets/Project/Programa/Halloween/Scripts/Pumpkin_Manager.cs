﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin_Manager : MonoBehaviour
{
    public bool pumpkin_move = false;//カボチャが動いてるかどうか判別

    public void PumpkinChangeState()
    {
        pumpkin_move = !pumpkin_move;
    }
  
}