using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soul_manager : MonoBehaviour
{
    public bool soul_move = false;
    public void PumpkinChangeState()
    {
        soul_move = !soul_move;
    }
}
