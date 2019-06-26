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

    public Camera main_camera;

    [SerializeField] private float walk_speed;
    private Vector3 destination_point;    //目的地
    private Vector3 previous_position;    //前回の目的地データ
    private Vector3 diff;                //現在地と目的地の差
    private Rigidbody rigid;    
    private iWalk iwalk;
    private float wait_time;             //Idleの時間
    private float max_wait_time = 2.5f;  //Idle状態の最大時間
    private float idle_time;
    private Animator chracter_animator;
    
    void Start()
    {
        iwalk = this.gameObject.GetComponent<iWalk>();
        rigid = this.gameObject.GetComponent<Rigidbody>();
        chracter_animator = GetComponent<Animator>();
        chracter_animator.SetInteger("State",(int)basic_state);
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
        chracter_animator.SetInteger("State", (int)basic_state);

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
                break;

            default:
                SetState(BasicState.Idle);
                break;
        }
    }

}
