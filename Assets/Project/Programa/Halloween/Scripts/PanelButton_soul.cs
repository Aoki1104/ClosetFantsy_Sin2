using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PanelButton_soul : MonoBehaviour
    {
    private ParticleSystem particle;
    private bool Button_soul;
    public GameObject FireParticle;
    private PanelButton_soul soul_manager;
    private void Start()
    {
        soul_manager = GameObject.Find("Button_soul").GetComponent<PanelButton_soul>();
        particle = this.GetComponent<ParticleSystem>();
    }
        // Update is called once per frame
        void Update()
        {
      
    }
        public void OnClick()
        {

            Debug.Log("押された!");  // ログを出力
            if (Button_soul == false)
            {
            FireParticle.SetActive(true);
            //ボタンをオンにする
            Button_soul = true;
               // particle.Play(); //パーティクルの再生
        }

            else
            {
            //ボタンをオフにする
            FireParticle.SetActive(false);
            Button_soul = false;
                //particle.Stop();
            }

            print(":soul:" + Button_soul);
        }
    }