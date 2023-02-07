using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeManager : MonoBehaviour
{
    private Vector3 Acceleration;
    private Vector3 preAcceleration;
    float DotProduct;
    public static int ShakeCount;

    [Header("����U������M�~�b�N�����ɂ��邩")]
    [SerializeField]
    int Clear_Count;

    [Header("�e�N�X�`���\�̓������q�I�u�W�F�N�g")]
    [SerializeField]
    GameObject Child_Object;//�q�I�u�W�F�N�g�̃e�N�X�`���[�����̃X�N���v�g

    void Start()
    {
        //����y���������𔻒f����X�C�b�`���I���ɂ��Ă���
        Child_Object.GetComponent<BaseMonster>().isSpecial = true;

        //�����������̏����ꂽ�R�[�h�𖳌������Ă���
        Child_Object.GetComponent<Tearing>().enabled = false;
    }

    void Update()
    {
        //�U��ꂽ�̂��J�E���g
        ShakeCheck();

        if(ShakeCount < Clear_Count)
        {
            //�����������̃R�[�h�����s�ł���悤�ɁA����������������
            Child_Object.GetComponent<Tearing>().enabled = true;
        }
    }

    //�U��ꂽ�����J�E���g����R�[�h
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
