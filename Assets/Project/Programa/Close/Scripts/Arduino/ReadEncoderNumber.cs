using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadEncoderNumber : MonoBehaviour
{
    private int encoder_num = 0;

    private SerialHandler serialHandler;
    private WorldChanger world_changer;

    // Use this for initialization
    void Start()
    {
        serialHandler = this.gameObject.GetComponent<SerialHandler>();
        world_changer = this.gameObject.GetComponent<WorldChanger>();
        //信号を受信したときに、そのメッセージの処理を行う
        serialHandler.OnDataReceived += OnDataReceived;
    }

    /*
	 * シリアルを受け取った時の処理
	 */
    void OnDataReceived(string message)
    {
        try
        {
            encoder_num = int.Parse(message);
            world_changer.CheckEncoderPosition(encoder_num);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }
}
