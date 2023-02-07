using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using Random = UnityEngine.Random;
public class SpecialMonster : MonoBehaviour
{
    [SerializeField]
    private int clickCount;
    [SerializeField]
    private int count;
    public GameObject player;  //�@�����������I�u�W�F�N�g���C���X�y�N�^�[��������B
    [SerializeField]
    public int speed = 0;  //�I�u�W�F�N�g�������œ����X�s�[�h����
    [SerializeField]
    private float clickInterval = 0.75f;
    [SerializeField]
    public int slowspeed = 0;
    Vector3 movePosition;  //�A�I�u�W�F�N�g�̖ړI�n��ۑ�
    float seconds;
    [SerializeField]
    public int Sec = 5;

    public float timeOut;
    private float timeElapsed;

    private bool _isDoAction = false;

    void Start()
    {
        Debug.Log("�R���[�`�������{���ł�");
        movePosition = moveRandomPosition();  //�A���s���A�I�u�W�F�N�g�̖ړI�n��ݒ�
    }

    private void Update()
    {
        this.player.transform.position = Vector3.MoveTowards
        //�@�Aplayer�I�u�W�F�N�g��, �ړI�n�Ɉړ�, �ړ����x
        (player.transform.position, movePosition, speed * Time.deltaTime);
        if (movePosition == player.transform.position)
        {
            movePosition = moveRandomPosition();//�A�ړI�n���Đݒ�
        }
        seconds += Time.deltaTime;
        timeElapsed += Time.deltaTime;
    }
    //�֐��F�I�u�W�F�N�g���N���b�N�����ꍇ�̓���
    public void onClickAct()
    {

        if (clickCount < 3) clickCount++;

        if (true == _isDoAction) return;

        _isDoAction = true;

        if (clickCount == 1)
        {
            speed = 13;
            StartCoroutine(Corou4());
            Debug.Log("�N���b�N1��");

        }
        if (clickCount == 2)
        {
            speed = 13;
            StartCoroutine(Corou4());
            Debug.Log("�N���b�N2��");
        }
        if (clickCount == 3)
        {
            speed = 0;
            Debug.Log("�N���b�N3��");
            Debug.Log("object��~");
        }
    }
    //�R���[�`���֐��̖��O
    private IEnumerator Corou4()
    {
        //�R���[�`���̓��e
        for (int i = 1; i < 4; i++)
        {
            Debug.Log("��" + i + "�b�ł�");
            speed = 18;
            yield return new WaitForSeconds(1.0f);

            if (clickCount == 3)
            {
                Debug.Log("�R���[�`�����I�����܂���");

                _isDoAction = false;
                yield break;
            }
            if (i == 3)
            {
                speed = 13;
                Debug.Log("�R���[�`�����I�����܂���");

                _isDoAction = false;
                yield break;
            }
        }
    }
    // �ړI�n�𐶐��Ax��y�̃|�W�V�����������_���ɒl���擾
    private Vector3 moveRandomPosition()
    {
        Vector3 randomPosi = new Vector3(Random.Range(-11, 10), Random.Range(-8, 6), 4);
        return randomPosi;
    }
}