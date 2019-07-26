using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PumpkinControll : MonoBehaviour
{
    [SerializeField]
    private float jumpPower = 100.0f;       //ジャンプ力ぅ
    [SerializeField]
    private float waittime = 5.0f;
    [SerializeField]
    private Gameobject pumpkin_light;

    private bool now_state = false;
    private bool old_state = false;
    private PanelButton_pumpkin pumpkin_manager;
    private Rigidbody _rigit;
    private Vector3 pos;
    private CharacterController characterController;

    // Update is called once per frame
    private void Update()
    {
        now_state = pumpkin_manager.pumpkin_move;
        if(now_state != old_state)
        {
            old_state = now_state;

            if (now_state == true)
            {
                pumpkin_light.SetActive(true);
                StartCoroutine(waiter());
            }
            else
            {
                pumpkin_light.SetActive(false);
                StopCoroutine(waiter());
            }

        }
    }

    void FixedUpdate()
    {

            

    }

    IEnumerator waiter()
    {
        Debug.Log("ウェイト");
        Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
        Vector3 force = new Vector3(0.0f, jumpPower, 0.0f);    // 力を設定
        rb.AddForce(force);  // 力を加える
        yield return new WaitForSeconds(waittime);
        StartCoroutine(waiter());
    }
}
