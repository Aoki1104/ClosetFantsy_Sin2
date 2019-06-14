using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIコンポーネントの使用

public class menu : MonoBehaviour
{

    Button World01;
    Button World02;
    Button World03;

    void Start()
    {
        // ボタンコンポーネントの取得
        World01 = GameObject.Find("/Canvas/Button1").GetComponent<Button>();
        World02 = GameObject.Find("/Canvas/Button2").GetComponent<Button>();
        World03 = GameObject.Find("/Canvas/Button3").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        World01.Select();
    }
}