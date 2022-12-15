using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    [SerializeField] public Vector3[] imagePos;
    [SerializeField] public GameObject[] monsterImage;
    [SerializeField] public Transform transform;
    PlayerData playerData;
    private bool resultEnd = false;

    List<int> gotMonster;
    // Start is called before the first frame update
    void Start()
    {
        resultEnd = false;
        gotMonster = new List<int>();
        playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        StartCoroutine("ResultImage", 0.5f);
    }

    void Update()
    {
        ToTitle();
    }

    IEnumerator ResultImage()
    {
        gotMonster.AddRange(playerData.gotMonster);
        for (int i = 0; i < gotMonster.Count; i++)
        {
            Instantiate(monsterImage[gotMonster[i]], imagePos[i], Quaternion.identity, transform);
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
        resultEnd = true;
    }

    private void ToTitle()
    {
        if (!resultEnd)
            return;

        if (Input.touchCount > 0)
        {
            SceneManager.LoadScene(0);
            playerData.ResetData();
        }
    }
}
