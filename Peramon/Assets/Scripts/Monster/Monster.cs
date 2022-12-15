using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public Text counterText; //Text用変数
    private int counter = 0; //スコア計算用変数
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
        /*************剥がした時の処理*************/
        //Ranの数字以下ならば当たり以上ならはずれ
        if (number < Ran)
        {
            Debug.Log("宝があった");
            //当たりの場合Counterを加算
            counter++;
            counter += 1;
            //クリア条件
            if (counter < 5)
            {

                Debug.Log("Counterが5に達していない");
            }
            else
            {
                //Counterが５に達していたらクリアSceneに移行
                Debug.Log("Counterが5に達している");
                //SceneManager.LoadScene("p");//←クリアScene
            }
        }
        //Ranの数字以上はずれ
        else
        {
            Debug.Log("宝はなかった");
        }
        /***************************************/
    }
}

