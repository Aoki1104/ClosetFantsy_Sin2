using UnityEngine;

public class SceneReset : MonoBehaviour
{

    void OnGUI()
    {

        if (GUILayout.Button("Reload"))
        {

            Application.LoadLevel("Main"); // シーンの名前かインデックスを指定
        }
    }
}