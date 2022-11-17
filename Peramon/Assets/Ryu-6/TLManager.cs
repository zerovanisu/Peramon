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

    [Header("�e�L�X�g�؂�ւ��̑��x")]
    [SerializeField]
    float TextCount;

    private float Count2;

    void Start()
    {
        WindowChange(WINDOWTYPE.Expansion);

        Count2 = TextCount;
    }


    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Z))
        {
            M_ID += 1;
            MessageChange(M_ID);
        }*/

        Count2 -= Time.deltaTime;

        if (Count2 <= 0)
        {
            if(M_ID != Message.Length - 1)
            {
                M_ID += 1;
                MessageChange(M_ID);
                Count2 = TextCount;
            }
        }
        
    }

    public void WindowOpen()
    {
        WindowChange(WINDOWTYPE.Expansion);
        M_ID = 1;
        MessageChange(M_ID);
        Count2 = TextCount;
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
