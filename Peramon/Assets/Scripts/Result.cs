using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField]public Vector3[] imagePos;
    [SerializeField]public GameObject[] monsterImage;
    [SerializeField] public Transform transform;
    PlayerData playerData;

    List<int> gotMonster;
    // Start is called before the first frame update
    void Start()
    {
        gotMonster = new List<int>();
        playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        StartCoroutine("ResultImage",0.5f);
    }

    IEnumerator ResultImage()
    {
        gotMonster.AddRange(playerData.gotMonster);
        for(int i = 0; i < gotMonster.Count; i++)
        {
            Instantiate(monsterImage[gotMonster[i]], imagePos[i], Quaternion.identity, transform);
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }
}
