using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PumpkinControll : MonoBehaviour
{
    [SerializeField]
    float jumpPower = 300.0f;       //ジャンプ力ぅ
    [SerializeField]
    float waittime = 500.0f;
    
    private Rigidbody _rigit;
    private Vector3 pos;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    void FixedUpdate()
    {

            Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
            Vector3 force = new Vector3(0.0f, jumpPower, 0.0f);    // 力を設定
            rb.AddForce(force);  // 力を加える
        StartCoroutine(waiter());

    }

    IEnumerator waiter()
    {
        Debug.Log("ウェイト"); 
        yield return new WaitForSeconds(waittime);
    }
}
