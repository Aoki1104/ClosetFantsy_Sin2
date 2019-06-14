using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSun : MonoBehaviour
{
    public TimeManagement time_management;
    
    //1秒間の回転角度
    private float rotate_speed = 2f;
    //0時の角度
    private Vector3 rot = new Vector3(0f, 330f, 0f);

    // Update is called once per frame
    void Update()
    {
        //太陽が正の方向に(時計回り)に回転する
        this.transform.Rotate(Vector3.right * rotate_speed * time_management.TimeReturn() * Time.deltaTime);   
    }
}
