using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIコンポーネントの使用

public class menubeta : MonoBehaviour
{
    public SerialHandler serialHandler;
    Button World01;
    Button World02;
    Button World03;
    Button World04;

    void Start()
    {
        serialHandler.OnDataReceived += OnDataReceived;

    }
    void OnDataReceived(string message)
    {
        try
        {
            float sum = float.Parse(message); // string型をfloat型に変換
            // ボタンコンポーネントの取得
            World01 = GameObject.Find("/Canvas/Button1").GetComponent<Button>();
            World02 = GameObject.Find("/Canvas/Button2").GetComponent<Button>();
            World03 = GameObject.Find("/Canvas/Button3").GetComponent<Button>();
            World04 = GameObject.Find("/Canvas/Button4").GetComponent<Button>();

            #region Plus
            // 最初に選択状態にしたいボタンの設定
            if (sum < 0.25)
            {
                World01.Select();
            }
            else if ((sum > 0.25) && (sum < 0.50))
            {
                World02.Select();
            }
            else if ((sum > 0.50) && (sum < 0.75))
            {
                World03.Select();
            }
            else if ((sum > 0.75) && (sum < 1.00))
            {
                World04.Select();
            }
            #endregion

            #region minus
            if ((sum < 0)&&(sum>-0.25))
            {
                World01.Select();
            }
            else if ((sum < -0.25) && (sum > -0.50))
            {
                World02.Select();
            }
            else if ((sum < -0.50) && (sum > -0.75))
            {
                World03.Select();
            }
            else if ((sum < -0.75) && (sum > -1.00))
            {
                World04.Select();
            }
            #endregion
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }
}