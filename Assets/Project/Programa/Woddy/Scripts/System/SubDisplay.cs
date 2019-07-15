using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubDisplay : MonoBehaviour
{
    void Awake()
    {

      
        // 横画面で開発している場合は以下の用に切り替えます
        float developAspect = 1024.0f / 600.0f;

        // 実機のサイズを取得して、縦横比取得
        float deviceAspect = (float)Screen.width / (float)Screen.height;

        // 実機と開発画面との対比
        float scale = deviceAspect / developAspect;

        GameObject cam = this.gameObject;
        Camera subCamera = cam.GetComponent<Camera>();

        // カメラに設定していたorthographicSizeを実機との対比でスケール
        float deviceSize = subCamera.orthographicSize;
        // scaleの逆数
        float deviceScale = 1.0f / scale;
        // orthographicSizeを計算し直す
        subCamera.orthographicSize = deviceSize * deviceScale;

        Screen.SetResolution(1024, 768, false, 60);
    }
}
