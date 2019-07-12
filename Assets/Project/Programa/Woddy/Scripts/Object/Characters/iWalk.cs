using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 歩きの処理インターフェイス
/// </summary>
public interface iWalk
{
    //キャラクターの位置を取得する
    void GetCharaPosition(Vector3 chara_position);

    //目的地の設定
    Vector3 SetDestination();

    //歩き終わったときの処理
    void WalkEnd();

}
