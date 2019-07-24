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

    private int encoder_num;
    private int now_encoder_position;
    private int old_encoder_position;
    private int rotate_max = 68;
    private int rotate_min = -27;
    private bool door_check;  //ドアの開閉確認(true:open,false:close)
    private string now_world; //現在のワールド名

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("StartEncoder:" + PlayerPrefs.GetInt("EncoderNum", encoder_num));
        encoder_num = PlayerPrefs.GetInt("EncoderNum", encoder_num); 
        now_world = SceneManager.GetActiveScene().name;
        world_name = (WorldName)Enum.Parse(typeof(WorldName), now_world,true);
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
    public void CheckEncoderPosition(int position)
    {
        now_encoder_position = position;
        Debug.Log("nowEncoder:" + now_encoder_position);
        //エンコーダーの位置が以前より大きいなら＋、小さいなら－
        if(now_encoder_position > old_encoder_position)
        {
            SetEncoderNum(1);
            old_encoder_position = now_encoder_position;
        }
        else if(now_encoder_position < old_encoder_position)
        {
            SetEncoderNum(-1);
            old_encoder_position = now_encoder_position;
        }
        Debug.Log("oldEncoder:" + old_encoder_position);

        SetWorld();
    }

    private void SetEncoderNum(int add_num)
    {
        encoder_num += add_num;

        if (encoder_num > rotate_max)
            encoder_num = rotate_min;

        if (encoder_num < rotate_min)
            encoder_num = rotate_max;
    }

    //ロータリーエンコーダーの数値によって世界をセットする
    public void SetWorld()
    {
        //大樹ステージをセット
        if (-27 <= encoder_num && encoder_num <= 24)
            world_name = WorldName.woody_world02;

        //ハロウィンステージをセット
        if (25 <= encoder_num && encoder_num <= 68)
            world_name = WorldName.world_Hallo;
        Debug.Log("encode_num:" + encoder_num);
    }

    //ワールド変更
    private void WorldChange(WorldName world)
    {
        PlayerPrefs.SetInt("EncoderNum", encoder_num);
        Debug.Log("EndEncoder:" + PlayerPrefs.GetInt("EncoderNum", encoder_num));
        PlayerPrefs.Save();
        SceneManager.LoadScene(world.ToString());
    }
}
