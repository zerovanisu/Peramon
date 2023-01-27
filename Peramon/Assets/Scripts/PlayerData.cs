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
   [SerializeField] private int _resultMonsterNum = 5;
    // Start is called before the first frame update
    void Start()
    {
        treasureGet = 0;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
    }

    private void TreasureTextUpdate()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        scoreText.text = "見つけたお宝：" + gotMonster.Count;
    }

    public void AddGotMonster(int monsterID)
    {
        //タイトル画面の画像が剥がした場合
        if (monsterID == -1)
        {
            StartCoroutine(MoveToMainScene());
            return;
        }

        gotMonster.Add(monsterID);
        TreasureTextUpdate();
        ResultCheck();
    }

    private void ResultCheck()
    {
        if (gotMonster.Count >= _resultMonsterNum)
        {
            StartCoroutine(MoveToResult());
        }
    }

    IEnumerator MoveToResult()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }

    IEnumerator MoveToMainScene()
    {
        yield return new WaitForSeconds(1f);
        ResetData();
        SceneManager.LoadScene(1);
    }
    public void ResetData()
    {
        treasureGet = 0;
        gotMonster.Clear();
    }

}
