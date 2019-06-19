using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャラクターの基底クラス
/// </summary>
public class CharacterBase : MonoBehaviour
{
    //基本動作
    private enum BasicState {
        Idle,
        Walk
    }

    BasicState basic_state =BasicState.Idle;

    private Vector3 destination_point;    //目的地
    private Vector3 diff;
    private Rigidbody rigid;
    private iWalk iwalk;
    private float wait_time;      //Idleの時間
    private float max_wait_time = 2.5f;
    private float idle_time;
    [SerializeField] private float walk_speed;

    // Start is called before the first frame update
    void Start()
    {
        iwalk = this.gameObject.GetComponent<iWalk>();
        rigid = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        StateControll();
    }

    //ステート(状態)を管理する関数
    void StateControll()
    {


        switch (basic_state)
        {
            //待機
            case BasicState.Idle:

                    idle_time += Time.deltaTime;
                if (idle_time > wait_time)
                {
                    idle_time = 0.0f;
                    SetState(BasicState.Walk);
                }

                break;

            //歩く
            case BasicState.Walk:
                //進行方向へ向く
               
                if (diff.magnitude > 0.01f)
                    transform.rotation = Quaternion.LookRotation(diff);
                                                                      

                

                transform.Translate(Vector3.forward * walk_speed * Time.deltaTime);

                if ((this.transform.position - destination_point).sqrMagnitude < 1)
                    SetState(BasicState.Idle);
                break;

            default:
                SetState(BasicState.Idle);
                break;
         }
    }

    //ステート(状態)の初期処理
    void SetState(BasicState _state)
    {
        basic_state = _state;

        switch (basic_state)
        {
            //待機
            case BasicState.Idle:

                idle_time = 0.0f;
                wait_time = Random.Range(0.0f, max_wait_time);
                rigid.velocity = Vector3.zero;
                break;

            //歩く
            case BasicState.Walk:
                iwalk.GetCharaPosition(this.transform.position);
                destination_point = iwalk.SetDestination();
                diff = destination_point - this.transform.position ;
                Debug.Log("destination:" + destination_point);
               // this.transform.LookAt(destination_point);
                break;

            default:
                SetState(BasicState.Idle);
                break;
        }
    }

}
