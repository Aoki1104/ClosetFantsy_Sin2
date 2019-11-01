using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soulControlScript : MonoBehaviour
{
    private ParticleSystem particle;
    public bool Button_soul;
    public GameObject FireParticle;
    public AudioClip FireSE;//サウンド
    AudioSource audioSource;

    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
        Button_soul = false;  
        FireParticle.SetActive(false);
    }

    public void OnClick()
    {
        Debug.Log("押された!");  // ログを出力
        if (Button_soul == false)
        {
           
            FireParticle.SetActive(true);
            audioSource.PlayOneShot(FireSE);
        }
        Button_soul = !Button_soul;
    }
}