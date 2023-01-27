using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerModelSwitcher : MonoBehaviour
{
    [SerializeField]
    private ARObjectManager _arObjManager;

    private int _num = 0;

    public GameObject _arObj { get; set; }


    public void SpawningObject(int imageNum, Vector3 pos, Quaternion rot)
    {
        GameObject monster;
        monster = Instantiate(_arObjManager.GetArObjByNum(RandomMonsterNum(imageNum)), pos, rot);
        //monster.GetComponent<BaseMonster>().isSpecial = RandomMonsterSpecial();
        Debug.Log("Spawn");
    }

    private int RandomMonsterNum(int _num)
    {
        int _id = 0;
        switch (_num)
        {
            case 0:
                _id = Random.Range(0, 3);
                break;
            case 1:
                _id = Random.Range(3, 5);
                break;
            default:
                break;
        }
        Debug.Log(_id);
        return _id;
    }

    private bool RandomMonsterSpecial()
    {
        return Random.Range(0, 2) == 0;
    }
}