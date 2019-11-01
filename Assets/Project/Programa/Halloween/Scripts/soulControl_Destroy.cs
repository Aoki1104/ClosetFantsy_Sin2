using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soulControl_Destroy : MonoBehaviour
{
    [SerializeField] private soulControlScript soulcount;
    private ParticleSystem particle;
    private bool Button_soul;
    public GameObject FireParticle;

    private bool Button_soul_Destroy;
    public List<ParticleSystem> DestroyPartcle;

    void Start()
    {
        Button_soul_Destroy = false;
        FireParticle.SetActive(false);
    }

    public void OnClick()
    {
        Debug.Log("押された!");  // ログを出力
        if (soulcount.Button_soul == true && Button_soul_Destroy==false)
        {
            FireParticle.SetActive(false);
            for(int num=0;num<DestroyPartcle.Count;num++)
            DestroyPartcle[num].Play();
      
            soulcount.Button_soul = !soulcount.Button_soul;
        }

        Button_soul_Destroy = !Button_soul_Destroy;
    }
}