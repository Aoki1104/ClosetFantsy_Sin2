using UnityEngine;

public class MultiDisplay : MonoBehaviour
{
    public Camera subcamera;
    private float subdisplay_aspect = 1024.0f / 600.0f;
    private float subcamera_aspect = 1920.0f /1080.0f;

    void Awake()
    {
             int maxDisplayCount = 2;
        for (int i = 0; i < maxDisplayCount && i < Display.displays.Length; i++)
        {
            if (i != 1)
                Display.displays[i].Activate();
            else if (i == 1)
               //Display.displays[i].Activate(1024, 768, 60);
                Display.displays[i].Activate();

        }

    }
    /*
    private void Start()
    {
       // Screen.SetResolution(1024, 768, true, 60);
    
        float scale = subdisplay_aspect / subcamera_aspect;
        float device_size = subcamera.orthographicSize;
        Debug.Log("device_size" + subcamera.orthographicSize);
        float device_scale = 1.0f / scale;
        subcamera.orthographicSize = device_size * device_scale;

    }*/

    void OnGUI()
    {
        var mousePos = Display.RelativeMouseAt(Input.mousePosition);
        GUILayout.Label("mouse position:" + ((Vector2)mousePos).ToString());
        GUILayout.Label("display id:" + mousePos.z);
    }

} // class GameController