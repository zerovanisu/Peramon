using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerModelSwitcher : MonoBehaviour
{
    [SerializeField]
    private ARObjectManager _arObjManager;

    private int _pageNum = 0;

    public GameObject _arObj { get; set; }


    public void SpawningObject(Vector3 pos, Quaternion rot)
    {
        Instantiate(_arObjManager.GetArObjByNum(Random.Range(0, 5)), pos, rot);
        Debug.Log("Spawning");
        //if (_arObj != null) _arObj.SetActive(false);
        //this._pageNum = pageNum;
        //_arObj = _arObjManager.GetArObjByNum(Random.Range(0,5));
        //_arObj.SetActive(true);
        //_arObj.transform.position = pos;
        //_arObj.transform.rotation = rot;
    }
}