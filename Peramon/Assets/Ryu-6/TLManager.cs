using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TLManager : MonoBehaviour
{
    //ウィンドウの拡大・縮小の定義
    public enum WINDOWTYPE
    {
        Expansion = 0, Shrink = 1, Close = 2
    }

    [Header("拡大されたウィンドウ")]
    [SerializeField]
    GameObject Window_B;

    [Header("縮小されたウィンドウ")]
    [SerializeField]
    GameObject Window_S;

    [Header("メッセージID")]
    [SerializeField]
    int M_ID;

    [Header("メッセージ")]
    [SerializeField]
    string[] Message;

    [SerializeField]
    Text TextBox;

    [Header("テキスト切り替えの速度")]
    [SerializeField]
    float TextCount;

    void Start()
    {
        WindowChange(WINDOWTYPE.Expansion);
        M_ID = 0;
        MessageChange(M_ID);
    }


    void Update()
    {
        //デバッグ用メッセージ進行
        if(Input.GetKeyDown(KeyCode.Z))
        {
            NextMessage();
        }
    }

    public void WindowOpen()
    {
        WindowChange(WINDOWTYPE.Expansion);
        MessageChange(M_ID);
    }

    public void WindowClose()
    {
        WindowChange(WINDOWTYPE.Shrink);
    }

    //ウィンドウを切り替える処理
    void WindowChange(WINDOWTYPE type)
    {
        switch(type)
        {
            case WINDOWTYPE.Expansion://拡大
                Window_B.SetActive(true);
                Window_S.SetActive(false);
                break;

            case WINDOWTYPE.Shrink://縮小
                Window_B.SetActive(false);
                Window_S.SetActive(true);
                break;

            case WINDOWTYPE.Close:
                Window_B.SetActive(false);
                Window_S.SetActive(false);
                break;
        }
    }

    void MessageChange(int x)
    {
        TextBox.text = Message[x];
    }

    public void NextMessage()
    {
        //効果音を入れる

        //最後のメッセージだったら
        int i = Message.Length - 1;
        if (M_ID == i)
        {
            Debug.Log("ゲームスタート");
            //ゲームスタート
        }
        //そうでない場合
        else
        {
            //メッセージ進行
            M_ID += 1;
            MessageChange(M_ID);
        }
    }
}
