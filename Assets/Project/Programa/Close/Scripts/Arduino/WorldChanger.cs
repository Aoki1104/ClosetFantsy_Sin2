using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;
using System;
using System.IO;

/// <summary>
/// ドアを閉めた時にワールドチェンジするクラス
/// </summary>
public class WorldChanger : MonoBehaviour
{
    private enum WorldName
    {
        woody_world02=0,
        world_Hallo
    }

    WorldName world_name;

    private bool door_check;  //ドアの開閉確認(true:open,false:close)
    private string now_world; //現在のワールド名
    private string text_name = "WorldNumber";
    private TextAsset world_text;
    private string world_num;
    private StreamReader reader;
    private int num;
    private float max_time = 2.0f;
    private float now_time;
    
    // Start is called before the first frame update
    void Start()
    {
        now_world = SceneManager.GetActiveScene().name;
        Debug.Log(now_world);
        world_name = (WorldName)Enum.Parse(typeof(WorldName), now_world,true);
        door_check = true;
        var fs = new FileStream(
    @"C:\Users\1423148_Otsuka\Documents\Encoder\WorldNumber.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        reader = new StreamReader(fs, Encoding.GetEncoding("Shift_JIS"));
        world_num = reader.ReadToEnd();
        Debug.Log("num" + world_num);
    }


    // Update is called once per frame
    void Update()
    {
        now_time += Time.deltaTime;
        #region ドアが実装された時の処理
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            door_check = true;
        }
        
        
        if (door_check == true)
        {
            WorldChange(world_name);
        }
        */
        #endregion

        if (now_time > max_time)
        {
            ReadText();
            now_time = 0;
        }
        #region 7月オープンキャンパス時のif分実装
        //今のシーンと設定されたシーンが異なる場合のみシーンを変更する
        if (now_world != world_name.ToString())
            WorldChange(world_name);
        #endregion
    }

    private void ReadText()
    {
        var fs = new FileStream(
   @"C:\Users\1423148_Otsuka\Documents\Encoder\WorldNumber.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        reader = new StreamReader(fs, Encoding.GetEncoding("Shift_JIS"));
        world_num = reader.ReadToEnd();
        num = int.Parse(world_num);
        world_name = (WorldName)Enum.Parse(typeof(WorldName), world_num, true);
        Debug.Log("num" + world_num);
    }

    //エンコーダーの移動位置を調べる
    public void SerialGetWorldNumber(int num)
    {
        world_name = (WorldName)Enum.ToObject(typeof(WorldName), num);
    }

    //ワールド変更
    private void WorldChange(WorldName world)
    {
        SceneManager.LoadScene(world.ToString());
    }
}
