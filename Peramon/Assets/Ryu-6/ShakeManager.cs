using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeManager : MonoBehaviour
{
    private Vector3 Acceleration;
    private Vector3 preAcceleration;
    float DotProduct;
    public static int ShakeCount;

    [Header("何回振ったらギミック解除にするか")]
    [SerializeField]
    int Clear_Count;

    [Header("テクスチャ―の入った子オブジェクト")]
    [SerializeField]
    GameObject Child_Object;//子オブジェクトのテクスチャー処理のスクリプト

    void Start()
    {
        //特殊ペラモンかを判断するスイッチをオンにしておく
        Child_Object.GetComponent<BaseMonster>().isSpecial = true;

        //剥がす処理の書かれたコードを無効化しておく
        Child_Object.GetComponent<Tearing>().enabled = false;
    }

    void Update()
    {
        //振られたのをカウント
        ShakeCheck();

        if(ShakeCount < Clear_Count)
        {
            //剥がす処理のコードが実行できるように、無効化を解除する
            Child_Object.GetComponent<Tearing>().enabled = true;
        }
    }

    //振られた事をカウントするコード
    void ShakeCheck()
    {
        preAcceleration = Acceleration;
        Acceleration = Input.acceleration;
        DotProduct = Vector3.Dot(Acceleration, preAcceleration);
        if (DotProduct < 0)
        {
            ShakeCount++;
        }
    }
}
