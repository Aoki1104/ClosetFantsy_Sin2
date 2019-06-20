using UnityEngine;

public class MultiDisplay : MonoBehaviour
{
    void Start()
    {
        int maxDisplayCount = 2;
        for (int i = 0; i < maxDisplayCount && i < Display.displays.Length; i++)
        {
            if(i != 1) 
            Display.displays[i].Activate();
            else if(i == 1)
             Display.displays[i].Activate(1024,600,60);
        }
    }

    void OnGUI()
    {
        var mousePos = Display.RelativeMouseAt(Input.mousePosition);
        GUILayout.Label("mouse position:" + ((Vector2)mousePos).ToString());
        GUILayout.Label("display id:" + mousePos.z);
    }

} // class GameController