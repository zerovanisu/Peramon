using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static int treasureGet = 0;
    [SerializeField] public Text scoreText;
    public List<int> gotMonster = new List<int>();
    private bool toResult = false;
    // Start is called before the first frame update
    void Start()
    {
        treasureGet = 0;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        ResultCheck();
    }

    public void TreasureTextUpdate()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        scoreText.text = "見つけたお宝：" + gotMonster.Count;
    }

    public void AddGotMonster(int monsterID)
    {
        gotMonster.Add(monsterID);
        TreasureTextUpdate();
    }

    private void ResultCheck(int count = 5)
    {
        if (gotMonster.Count >= count && !toResult)
        {
            toResult = true;
            StartCoroutine(MoveToResult());
        }
    }

    IEnumerator MoveToResult()
    {
        Debug.Log("ToResult");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
        Debug.Log("ToResult2");
    }

    public void ResetData()
    {
        treasureGet = 0;
        gotMonster.Clear();
        toResult = false;
    }

}
