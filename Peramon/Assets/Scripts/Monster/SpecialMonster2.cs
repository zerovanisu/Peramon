using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMonster2 : MonoBehaviour
{
    [SerializeField]
    private int clickCount = 0;
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
    public int Sec = 0;

    void Start()
    {
        movePosition = moveRandomPosition();  //�A���s���A�I�u�W�F�N�g�̖ړI�n��ݒ�
    }

    private void Update()
    {
        this.player.transform.position = Vector3.MoveTowards
        (player.transform.position, movePosition, speed * Time.deltaTime);  //�@�Aplayer�I�u�W�F�N�g��, �ړI�n�Ɉړ�, �ړ����x
        if (movePosition == player.transform.position)
        {
            movePosition = moveRandomPosition();//�A�ړI�n���Đݒ�
        }
        seconds += Time.deltaTime;
        if (seconds >= Sec)
        {
            speed = 0;
            seconds = 0;
            Debug.Log("5�b��ɒ�~");
        }

    }



    private Vector3 moveRandomPosition()  // �ړI�n�𐶐��Ax��y�̃|�W�V�����������_���ɒl���擾 
    {
        Vector3 randomPosi = new Vector3(Random.Range(-11, 10), Random.Range(-8, 6), 4);
        return randomPosi;
    }
}