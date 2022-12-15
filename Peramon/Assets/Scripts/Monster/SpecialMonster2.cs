using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMonster2 : MonoBehaviour
{
    [SerializeField]
    private int clickCount = 0;
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
    public int Sec = 0;

    void Start()
    {
        movePosition = moveRandomPosition();  //②実行時、オブジェクトの目的地を設定
    }

    private void Update()
    {
        this.player.transform.position = Vector3.MoveTowards
        (player.transform.position, movePosition, speed * Time.deltaTime);  //①②playerオブジェクトが, 目的地に移動, 移動速度
        if (movePosition == player.transform.position)
        {
            movePosition = moveRandomPosition();//②目的地を再設定
        }
        seconds += Time.deltaTime;
        if (seconds >= Sec)
        {
            speed = 0;
            seconds = 0;
            Debug.Log("5秒後に停止");
        }

    }



    private Vector3 moveRandomPosition()  // 目的地を生成、xとyのポジションをランダムに値を取得 
    {
        Vector3 randomPosi = new Vector3(Random.Range(-11, 10), Random.Range(-8, 6), 4);
        return randomPosi;
    }
}