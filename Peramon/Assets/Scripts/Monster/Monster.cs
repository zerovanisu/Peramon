using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public Text counterText; //Text�p�ϐ�
    private int counter = 0; //�X�R�A�v�Z�p�ϐ�
    private int number;
    [SerializeField]
    int Ran = 0;
    private void Start()
    {
        number = Random.Range(1, 100);
        counter = 0;
    }
    private void Update()
    {
        //
        /*************�����������̏���*************/
        //Ran�̐����ȉ��Ȃ�Γ�����ȏ�Ȃ�͂���
        if (number < Ran)
        {
            Debug.Log("�󂪂�����");
            //������̏ꍇCounter�����Z
            counter++;
            counter += 1;
            //�N���A����
            if (counter < 5)
            {

                Debug.Log("Counter��5�ɒB���Ă��Ȃ�");
            }
            else
            {
                //Counter���T�ɒB���Ă�����N���AScene�Ɉڍs
                Debug.Log("Counter��5�ɒB���Ă���");
                //SceneManager.LoadScene("p");//���N���AScene
            }
        }
        //Ran�̐����ȏ�͂���
        else
        {
            Debug.Log("��͂Ȃ�����");
        }
        /***************************************/
    }
}

