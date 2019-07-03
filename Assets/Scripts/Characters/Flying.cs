using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 飛行するクラス
/// </summary>
public class Flying : MonoBehaviour,iWalk
{
    private Vector3 character_position;
    private float max_position = 10;
    private float min_position = -10;

    private Vector3 ground_position;
    private float max_y;
    private float min_y;

    private void Start()
    {
        ground_position = GameObject.FindGameObjectWithTag("Ground").transform.position;
        max_y = ground_position.y +this.transform.position.y+ max_position;
        min_y = ground_position.y + Mathf.Abs(this.transform.position.y);
    }

    public void GetCharaPosition(Vector3 chara_position)
    {
        character_position = chara_position;
    }

    public Vector3 SetDestination()
    {
        character_position.x += Random.Range(min_position, max_position);
        character_position.z += Random.Range(min_position, max_position);
        character_position.y = Random.Range(min_y, max_y);

        return character_position;
    }

    public void WalkEnd()
    {

    }
}
