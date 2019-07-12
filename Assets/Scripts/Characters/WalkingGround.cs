using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 地上を歩くキャラクターの処理
/// </summary>
public class WalkingGround : MonoBehaviour,iWalk
{
    private Vector3 character_position; //キャラクターの現在の位置
    private float max_x_position = 10.0f;       //目的地のx軸の最大値
    private float min_x_position = -10.0f;
    private float max_z_position = 10.0f;       //目的地のz軸の最大値
    private float min_z_position = -10.0f;

    public void GetCharaPosition(Vector3 chara_position)
    {
        character_position = chara_position;
    }

    public Vector3 SetDestination()
    {
        character_position.x += Random.Range(min_x_position, max_x_position);
        character_position.z += Random.Range(min_z_position, max_z_position);

        return character_position;
    }

    public void WalkEnd()
    {

    }

}
