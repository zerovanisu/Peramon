using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TLManager : MonoBehaviour
{
    //ウィンドウの拡大・縮小の定義
    public enum WINDOWTYPE
    {
        Expansion = 0, Shrink = 1//Close = 2
    }

    [Header("拡大ウィンドウ")]
    [SerializeField]
    GameObject Window_B;

    [Header("縮小ウィンドウ")]
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

    void Start()
    {
        WindowChange(WINDOWTYPE.Expansion);
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            M_ID += 1;
            MessageChange(M_ID);
        }
    }

    public void WindowOpen()
    {
        WindowChange(WINDOWTYPE.Expansion);
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

            /*case WINDOWTYPE.Close:
                break;*/
        }
    }

    void MessageChange(int x)
    {
        TextBox.text = Message[x];
    }
}
