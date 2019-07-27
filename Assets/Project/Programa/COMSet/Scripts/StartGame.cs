using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public COMSetter comsetter;
    public void SceneChnge()
    {
        comsetter.SetCOM();
        SceneManager.LoadScene("woody_world02");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            SceneChnge();
    }
}
