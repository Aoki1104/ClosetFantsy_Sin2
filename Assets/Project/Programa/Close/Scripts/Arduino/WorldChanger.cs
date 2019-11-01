using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

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

    // Start is called before the first frame update
    void Start()
    {
        now_world = SceneManager.GetActiveScene().name;
        world_name = (WorldName)Enum.ToObject(typeof(WorldName), now_world);
        door_check = true;
    }

    // Update is called once per frame
    void Update()
    {

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

        #region 7月オープンキャンパス時のif分実装
        //今のシーンと設定されたシーンが異なる場合のみシーンを変更する
        if (now_world != world_name.ToString())
            WorldChange(world_name);
        #endregion
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
