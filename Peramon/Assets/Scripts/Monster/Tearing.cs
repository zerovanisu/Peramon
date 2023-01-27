using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Tearing : MonoBehaviour
{
    Material m_material;
    [SerializeField, Range(-15, 15)] public float disappearPointStartLeft, disappearPointEndLeft;
    [SerializeField, Range(-15, 15)] public float disappearPointStartRight, disappearPointEndRight;
    [SerializeField, Range(-15, 15)] public float disappearPointStartUp, disappearPointEndUp;
    [SerializeField, Range(-15, 15)] public float disappearPointStartDown, disappearPointEndDown;
    bool isTeared = false;
    // Start is called before the first frame update
    void Start()
    {
        m_material = GetComponent<MeshRenderer>().material;
    }

    public void TearDirection(TouchCheck.Direction direction)
    {
        //剥がす処理
        if (!isTeared)
        {
            switch (direction)
            {
                case TouchCheck.Direction.Up:
                    TearUp();
                    break;
                case TouchCheck.Direction.Down:
                    TearDown();
                    break;
                case TouchCheck.Direction.Left:
                    TearLeft();
                    break;
                case TouchCheck.Direction.Right:
                    TearRight();
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// 左方向に剥がす
    /// </summary>
    private void TearLeft()
    {
        m_material.SetFloat("_AngleX", 0);
        m_material.DOFloat(180, "_AngleX", 1f);
        Invoke("DisappearLeft", 0.8f);
        TearMonster();
    }
    /// <summary>
    /// 右方向に剥がす
    /// </summary>
    private void TearRight()
    {
        m_material.SetFloat("_AngleX2", 0);
        m_material.DOFloat(180, "_AngleX2", 1f);
        Invoke("DisappearRight", 0.8f);
        TearMonster();
    }
    /// <summary>
    /// 上方向に剥がす
    /// </summary>
    private void TearUp()
    {
        m_material.SetFloat("_AngleY", 0);
        m_material.DOFloat(180, "_AngleY", 1f);
        Invoke("DisappearUp", 0.8f);
        TearMonster();
    }

    /// <summary>
    /// 下方向に剥がす
    /// </summary>
    private void TearDown()
    {
        m_material.SetFloat("_AngleY2", 0);
        m_material.DOFloat(180, "_AngleY2", 1f);
        Invoke("DisappearDown", 0.8f);
        TearMonster();
    }
    /// <summary>
    /// 剥がしたモンスターのデータを取得
    /// </summary>
    private void TearMonster()
    {
        isTeared = true;

        //モンスターを破壊する
        Destroy(this.gameObject, 2f);
        AddTearMonster();
    }

    /// <summary>
    /// 剥がしたモンスターをセーフする
    /// </summary>
    private void AddTearMonster()
    {
        //PlayerDataを検索
        PlayerData playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        //モンスターIDを取得
        int monsterID = GetComponent<BaseMonster>().monsterID;
        //PlayerDataへ剥がしたモンスターのIDを送る
        playerData.AddGotMonster(monsterID);
    }

    /// <summary>
    /// モンスターが消える方向
    /// 左方向へ消える
    /// </summary>
    private void DisappearLeft()
    {
        m_material.SetFloat("_DisappearOffsetX", disappearPointStartLeft);
        m_material.DOFloat(disappearPointEndLeft, "_DisappearOffsetX", 1f);
    }
    /// <summary>
    /// モンスターが消える方向
    /// 右方向へ消える
    /// </summary>
    private void DisappearRight()
    {
        m_material.SetFloat("_DisappearOffsetX2", disappearPointStartRight);
        m_material.DOFloat(disappearPointEndRight, "_DisappearOffsetX2", 1f);
    }
    /// <summary>
    /// モンスターが消える方向
    /// 上方向へ消える
    /// </summary>
    private void DisappearUp()
    {
        m_material.SetFloat("_DisappearOffsetY", disappearPointStartUp);
        m_material.DOFloat(disappearPointEndUp, "_DisappearOffsetY", 1f);
    }
    /// <summary>
    /// モンスターが消える方向
    /// 下方向へ消える
    /// </summary>
    private void DisappearDown()
    {
        m_material.SetFloat("_DisappearOffsetY2", disappearPointStartDown);
        m_material.DOFloat(disappearPointEndDown, "_DisappearOffsetY2", 1f);
    }


}
