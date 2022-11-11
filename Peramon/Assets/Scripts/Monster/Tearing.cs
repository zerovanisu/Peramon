using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class Tearing : MonoBehaviour
{


    Material m_material;
    float nowAngle = 0;
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
        TearMonster();
    }
    private void TearRight()
    {
        m_material.SetFloat("_AngleX2", 0);
        m_material.DOFloat(180, "_AngleX2", 1f);
        TearMonster();
    }
    private void TearUp()
    {
        m_material.SetFloat("_AngleY", 0);
        m_material.DOFloat(180, "_AngleY", 1f);
        TearMonster();
    }

    private void TearDown()
    {
        m_material.SetFloat("_AngleY2", 0);
        m_material.DOFloat(180, "_AngleY2", 1f);
        TearMonster();
    }
    private void TearMonster()
    {
        isTeared = true;
        Destroy(this.gameObject, 1.5f);
        PlayerData.treasureGet++;
        GameObject.Find("PlayerData").GetComponent<PlayerData>().TreasureTextUpdate();
    }
}
