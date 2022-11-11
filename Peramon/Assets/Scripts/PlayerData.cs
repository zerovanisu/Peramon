using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public static int treasureGet = 0;
    [SerializeField]public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        treasureGet = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TreasureTextUpdate()
    {
        scoreText.text = "見つけたお宝：" + treasureGet; 
    }
}
