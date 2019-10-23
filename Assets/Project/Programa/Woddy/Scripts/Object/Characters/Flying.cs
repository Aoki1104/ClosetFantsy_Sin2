using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 飛行するクラス
/// </summary>
public class Flying : MonoBehaviour,iWalk
{
    private Vector3 character_position;
    private float max_move_amount = 10;
    private float min_move_amount = -10;

    private Vector3 ground_position;
    private Vector3 display_range_max;
    private Vector3 display_range_min;

    private void Start()
    {
        ground_position = GameObject.FindGameObjectWithTag("Ground").transform.position;
        Camera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        display_range_max = new Vector3(85,103,-46);
        display_range_min = new Vector3(67,0,-81);
        display_range_min.y = ground_position.y + max_move_amount;
    }

    public void GetCharaPosition(Vector3 chara_position)
    {
        character_position = chara_position;
    }

    public Vector3 SetDestination()
    {
        character_position.x = Random.Range(display_range_min.x, display_range_max.x);
        character_position.z = Random.Range(display_range_min.z, display_range_max.z);
       character_position.y = Random.Range(display_range_min.y, display_range_max.y);

        return character_position;
    }

    public void WalkEnd()
    {

    }
}
