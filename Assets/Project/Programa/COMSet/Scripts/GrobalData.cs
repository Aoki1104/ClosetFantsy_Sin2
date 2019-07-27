using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Post
{
    社長,
    CEO,
    部長,
    平社員,
    学生,
}

public class Character
{
    public string Name { get;}
    public int Age { get; }
    public Post Post { get; }
    public Character(string name,int age,Post post)
    {
        Name = name;
        Age = age;
        Post = post;
    }

    /// <summary>
    /// 役職をポイント化するときに振り分ける
    /// </summary>
    public static void PostToPoint(Post post)
    {

    }
}

public class Evaluation
{
    const float PerfectRate = 2;
    const float GreateRate = 1;
    const float MissRate = 0f;
    const float ThroughRate = 0f;
    const float ComboRate = 0.05f;
    const int AdjusteNum = 100;

    public int GetAdjustedScore()
    {
        return Score/* / AdjusteNum*/;
    }

    /// <summary>
    /// ～Countはインクリメントでのみアクセス
    /// </summary>
    public int PerfectCount
    {
        get { return perfectCount; }
        set
        {
            perfectCount = value;
            combo++;
            int addScore = 0;
            addScore+= (int)(PerfectRate);
            addScore += Comboreturn();
            score += addScore;
        }
    }
    public int GreateCount
    {
        get { return greateCount; }
        set
        {
            greateCount = value;
            combo++;
            int addScore = 0;
            addScore += (int)(GreateRate);
            addScore += Comboreturn();
            score += addScore;
        }
    }
    public int MissCount
    {
        get { return missCount; }
        set
        {
            missCount = value;
            combo = 0;
        }
    }
    public int ThroughCount
    {
        get { return throughCount; }
        set
        {
            throughCount = value;
            combo = 0;
        }
    }
    public int Comboreturn()
    {
        if (combo > 10)
        {
            return 1;
        }
        if (combo > 50)
        {
            return 2;
        }
        if (combo > 100)
        {
            return 3;
        }
        return 0;
    }
    public int Score { get { return score; } }
    public int Combo { get { return combo; } }
    int comboplus = 0;
    int perfectCount = 0;
    int greateCount = 0;
    int missCount = 0;
    int throughCount = 0;
    int combo;
    int score;
    public Evaluation()
    {
        perfectCount = 0;
        greateCount = 0;
        missCount = 0;
        throughCount = 0;
        combo = 0;
        score = 0;
    }

    public int GetScore(int combo = 1)
    {
        score += (int)(PerfectCount);
        score += (int)(GreateCount);
        //score += (int)(ThroughCount * ThroughRate);
        return score;
    }
    public void Reset()//タイトルで呼ぼうと思う
    {
        perfectCount = 0;
        greateCount = 0;
        missCount = 0;
        throughCount = 0;
        combo = 0;
        score = 0;
    }
}

/// <summary>
/// ゲーム全体の共有データ
/// </summary>
public static class GrobalData{
    //リザルトで表示する.キャラクターのデータ
    public static List<Character> characters = new List<Character>();

    //LEDをコントロールするArduinoのCOMの値,未初期化を検知するため-1
    public static int LEDComNumber = -1;

    public static Evaluation Evaluation= new Evaluation();

    
}