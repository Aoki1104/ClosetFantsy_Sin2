using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{

    public void StringArgFunction(string world)
    {
        SceneManager.LoadScene(world);
    }
}