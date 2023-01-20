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
        Instantiate(_arObjManager.GetArObjByNum(RandomMonsterNum(imageNum)), pos, rot);
        Debug.Log("Spawn");
    }

    private int RandomMonsterNum(int _num)
    {
        int _id = 0;
        switch (_num)
        {
            case 1:
                _id = Random.Range(0, 3);
                break;
            case 2:
                _id = Random.Range(3, 5);
                break;
            default:
                break;
        }
        return _id;
    }
}