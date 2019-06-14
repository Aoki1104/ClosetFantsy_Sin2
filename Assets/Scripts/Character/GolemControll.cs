using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemControll : MonoBehaviour
{
    private Vector3 golem_position;
    private Vector3 destination_point;  //歩く先の目的地 

    private void Start()
    {
        golem_position = this.transform.position;
    }

    private void Update()
    {
            
    }

    /// <summary>
    /// ランダムで目的地を決める
    /// </summary>
    private void SetDestination()
    {
        destination_point.x = golem_position.x + RandomSet();
        destination_point.z = golem_position.z + RandomSet();
    }

    
    private float RandomSet()
    {
        return Random.Range(-10.0f, 10.0f);
    }

}
