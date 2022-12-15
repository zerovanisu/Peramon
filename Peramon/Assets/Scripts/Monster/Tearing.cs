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

    private void TearLeft()
    {
        m_material.SetFloat("_AngleX", 0);
        m_material.DOFloat(180, "_AngleX", 1f);
        Invoke("DisappearLeft", 0.8f);
        TearMonster();
    }
    private void TearRight()
    {
        m_material.SetFloat("_AngleX2", 0);
        m_material.DOFloat(180, "_AngleX2", 1f);
        Invoke("DisappearRight", 0.8f);
        TearMonster();
    }
    private void TearUp()
    {
        m_material.SetFloat("_AngleY", 0);
        m_material.DOFloat(180, "_AngleY", 1f);
        Invoke("DisappearUp", 0.8f);
        TearMonster();
    }

    private void TearDown()
    {
        m_material.SetFloat("_AngleY2", 0);
        m_material.DOFloat(180, "_AngleY2", 1f);
        Invoke("DisappearDown", 0.8f);
        TearMonster();
    }
    private void TearMonster()
    {
        isTeared = true;
        if (GetComponent<BaseMonster>().monsterID == -1)
        {
            StartCoroutine(MoveToMainScene());
            return;
        }

        Destroy(this.gameObject, 2f);
        PlayerData playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        int monsterID = GetComponent<BaseMonster>().monsterID;
        playerData.AddGotMonster(monsterID);
    }

    private void DisappearLeft()
    {
        m_material.SetFloat("_DisappearOffsetX", disappearPointStartLeft);
        m_material.DOFloat(disappearPointEndLeft, "_DisappearOffsetX", 1f);
    }
    private void DisappearRight()
    {
        m_material.SetFloat("_DisappearOffsetX2", disappearPointStartRight);
        m_material.DOFloat(disappearPointEndRight, "_DisappearOffsetX2", 1f);
    }
    private void DisappearUp()
    {
        m_material.SetFloat("_DisappearOffsetY", disappearPointStartUp);
        m_material.DOFloat(disappearPointEndUp, "_DisappearOffsetY", 1f);
    }
    private void DisappearDown()
    {
        m_material.SetFloat("_DisappearOffsetY2", disappearPointStartDown);
        m_material.DOFloat(disappearPointEndDown, "_DisappearOffsetY2", 1f);
    }

    IEnumerator MoveToMainScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }

}
