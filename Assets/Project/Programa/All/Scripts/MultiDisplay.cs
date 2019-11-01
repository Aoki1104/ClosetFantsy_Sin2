using UnityEngine;

public class MultiDisplay : SingletonMonoBehaviour<MultiDisplay>
{
    private float subdisplay_aspect = 1024.0f / 600.0f;
    private float subcamera_aspect = 1920.0f /1080.0f;

    void Awake()
    {
        if(this != Instance)
        {
            Destroy(gameObject);
            return;
        }
             int maxDisplayCount = 2;
        for (int i = 0; i < maxDisplayCount && i < Display.displays.Length; i++)
        {
            if (i != 1)
                Display.displays[i].Activate();
            else if (i == 1)
                Display.displays[i].Activate();

        }

        DontDestroyOnLoad(gameObject);
    }

} // class GameController