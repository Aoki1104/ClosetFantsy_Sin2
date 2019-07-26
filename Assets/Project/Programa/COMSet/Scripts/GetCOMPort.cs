using System;
using System.IO.Ports;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCOMPort :MonoBehaviour
{

    private void Start()
    {
        Main();
    }
    static void Main()
    {
        // すべてのシリアル・ポート名を取得する
        string[] ports = SerialPort.GetPortNames();

        // 取得したシリアル・ポート名を出力する
        foreach (string port in ports)
        {
            Debug.Log(port);
        }
        Console.ReadLine();
    }
}