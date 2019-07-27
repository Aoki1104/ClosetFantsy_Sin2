using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    public class PanelButton_fog : MonoBehaviour
    {
        [SerializeField] private GlobalFog script;
        private bool Button_fog;
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            float startfog = script.startDistance;
            Debug.Log("StartDistanceは" + startfog);

        }
        public void OnClick()
        {

            Debug.Log("押された!");  // ログを出力
            if (Button_fog == false)
            {
                //ボタンをオンにする
                Button_fog = true;
                    script.Add1TostartDistance();
            }
                
                else
                {
                    //ボタンをオフにする
                    Button_fog = false;
                }
                
                print(":fog:" + Button_fog);
            }
        }
    }