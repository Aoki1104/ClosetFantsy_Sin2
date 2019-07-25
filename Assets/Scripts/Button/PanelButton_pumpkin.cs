using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelButton_pumpkin : MonoBehaviour
{

    [SerializeField] private GameObject light1;

    private bool Button_pumpkin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnClick()
    {
//        Debug.Log("押された!");  // ログを出力
        if (Button_pumpkin == false)
        {
            //ボタンをオンにする
            Button_pumpkin = true;

            light1.SetActive(true);
        }
        else
        {
            //ボタンをオフにする
            Button_pumpkin = false;

            light1.SetActive(false);

        }
        print(":pumpkin:" + Button_pumpkin);
    }

}
