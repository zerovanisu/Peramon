using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private ARObjectManager _arObjManager;
    public GameObject _arObj { get; set; }


    public void SpawningObject(int imageNum, Vector3 pos, Quaternion rot)
    {
        GameObject monster;
        monster = Instantiate(_arObjManager.GetArObjByNum(RandomMonsterNum(imageNum)), pos, rot);
        BaseMonster _baseMonster = monster.transform.GetChild(0).gameObject.GetComponent<BaseMonster>();
        _baseMonster.isSpecial = RandomMonsterSpecial(30);
        _baseMonster.isSpecial = true ? 
                                        _baseMonster.haveTreasure = RandomMonsterSpecial(80) : 
                                        _baseMonster.haveTreasure = RandomMonsterSpecial(50) ;
        Debug.Log("Spawn");
    }

    private int RandomMonsterNum(int _num)
    {
        int _id = 0;
        switch (_num)
        {
            case 0:
                _id = Random.Range(0, 4);
                break;
            case 1:
                _id = Random.Range(5, 8);
                break;
            default:
                break;
        }
        Debug.Log(_id);
        return _id;
    }

    private bool RandomMonsterSpecial(int _prob)
    {
        return Random.Range(0, 100) < _prob;
    }
}