using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static int treasureGet = 0;
    [SerializeField]public Text scoreText;
    public List<int> gotMonster = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        treasureGet = 0;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if(gotMonster.Count >= 5 && SceneManager.GetActiveScene().name != "ResultTest")
            SceneManager.LoadScene("ResultTest");
    }
    
    public void TreasureTextUpdate()
    {
        scoreText.text = "見つけたお宝：" + gotMonster.Count; 
    }

    public void AddGotMonster(int monsterID)
    {
        gotMonster.Add(monsterID);
        TreasureTextUpdate();
    }
}
