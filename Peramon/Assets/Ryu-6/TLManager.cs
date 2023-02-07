using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TLManager : MonoBehaviour
{
    //�E�B���h�E�̊g��E�k���̒�`
    public enum WINDOWTYPE
    {
        Expansion = 0, Shrink = 1, Close = 2
    }

    [Header("�g�傳�ꂽ�E�B���h�E")]
    [SerializeField]
    GameObject Window_B;

    [Header("�k�����ꂽ�E�B���h�E")]
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

    void Start()
    {
        WindowChange(WINDOWTYPE.Expansion);
        M_ID = 0;
        MessageChange(M_ID);
    }


    void Update()
    {
        //�f�o�b�O�p���b�Z�[�W�i�s
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
        //���ʉ�������

        //�Ō�̃��b�Z�[�W��������
        int i = Message.Length - 1;
        if (M_ID == i)
        {
            Debug.Log("�Q�[���X�^�[�g");
            //�Q�[���X�^�[�g
        }
        //�����łȂ��ꍇ
        else
        {
            //���b�Z�[�W�i�s
            M_ID += 1;
            MessageChange(M_ID);
        }
    }
}
