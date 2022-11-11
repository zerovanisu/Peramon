using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TLManager : MonoBehaviour
{
    //�E�B���h�E�̊g��E�k���̒�`
    public enum WINDOWTYPE
    {
        Expansion = 0, Shrink = 1//Close = 2
    }

    [Header("�g��E�B���h�E")]
    [SerializeField]
    GameObject Window_B;

    [Header("�k���E�B���h�E")]
    [SerializeField]
    GameObject Window_S;

    [Header("���b�Z�[�WID")]
    [SerializeField]
    int M_ID;

    [Header("���b�Z�[�W")]
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

    //�E�B���h�E��؂�ւ��鏈��
    void WindowChange(WINDOWTYPE type)
    {
        switch(type)
        {
            case WINDOWTYPE.Expansion://�g��
                Window_B.SetActive(true);
                Window_S.SetActive(false);
                break;

            case WINDOWTYPE.Shrink://�k��
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
