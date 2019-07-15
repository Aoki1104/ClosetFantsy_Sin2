using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCamera : MonoBehaviour {

    //デフォルトの画面比率
    [Range(4, 16)]
    public int BaseAspectWidth = 16;
    [Range(3, 16)]
    public int BaseAspectHeight = 9;


    void Awake()
    {

        Camera camera = gameObject.GetComponent<Camera>();
        float fov = camera.fieldOfView;

        float baseAspect = (float)BaseAspectHeight / (float)BaseAspectWidth;
        float nowAspect = (float)Screen.height / (float)Screen.width;
        float changeAspect;

        if (baseAspect > nowAspect)
        {

            changeAspect = baseAspect / nowAspect;
            camera.fieldOfView = fov * changeAspect;
        }
        else if (nowAspect > baseAspect)
        {

            changeAspect = nowAspect / baseAspect;
            camera.fieldOfView = fov * changeAspect;
        }

    }



}

