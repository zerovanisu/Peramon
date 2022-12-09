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
    public GameObject player;  //①動かしたいオブジェクトをインスペクターから入れる。
    [SerializeField]
    public int speed = 0;  //オブジェクトが自動で動くスピード調整
    [SerializeField]
    private float clickInterval = 0.75f;
    [SerializeField]
    public int slowspeed = 0;
    Vector3 movePosition;  //②オブジェクトの目的地を保存
    float seconds;
    [SerializeField]
    public int Sec = 5;

    public float timeOut;
    private float timeElapsed;

    private bool _isDoAction = false;

    void Start()
    {
        Debug.Log("コルーチンを実施中です");
        movePosition = moveRandomPosition();  //②実行時、オブジェクトの目的地を設定
    }

    private void Update()
    {
        this.player.transform.position = Vector3.MoveTowards
        //①②playerオブジェクトが, 目的地に移動, 移動速度
        (player.transform.position, movePosition, speed * Time.deltaTime);
        if (movePosition == player.transform.position)
        {
            movePosition = moveRandomPosition();//②目的地を再設定
        }
        seconds += Time.deltaTime;
        timeElapsed += Time.deltaTime;
    }
    //関数：オブジェクトをクリックした場合の動作
    public void onClickAct()
    {

        if (clickCount < 3) clickCount++;

        if (true == _isDoAction) return;

        _isDoAction = true;

        if (clickCount == 1)
        {
            speed = 13;
            StartCoroutine(Corou4());
            Debug.Log("クリック1回");

        }
        if (clickCount == 2)
        {
            speed = 13;
            StartCoroutine(Corou4());
            Debug.Log("クリック2回");
        }
        if (clickCount == 3)
        {
            speed = 0;
            Debug.Log("クリック3回");
            Debug.Log("object停止");
        }
    }
    //コルーチン関数の名前
    private IEnumerator Corou4()
    {
        //コルーチンの内容
        for (int i = 1; i < 4; i++)
        {
            Debug.Log("今" + i + "秒です");
            speed = 18;
            yield return new WaitForSeconds(1.0f);

            if (clickCount == 3)
            {
                Debug.Log("コルーチンを終了しました");

                _isDoAction = false;
                yield break;
            }
            if (i == 3)
            {
                speed = 13;
                Debug.Log("コルーチンを終了しました");

                _isDoAction = false;
                yield break;
            }
        }
    }
    // 目的地を生成、xとyのポジションをランダムに値を取得
    private Vector3 moveRandomPosition()
    {
        Vector3 randomPosi = new Vector3(Random.Range(-11, 10), Random.Range(-8, 6), 4);
        return randomPosi;
    }
}