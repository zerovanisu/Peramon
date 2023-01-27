using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    [SerializeField] public Vector3[] _imagePos;
    [SerializeField] public GameObject[] _monsterImage;
    [SerializeField] public Transform _transform;
    PlayerData _playerData;
    private bool resultEnd = false;

    List<int> gotMonster;
    // Start is called before the first frame update
    void Start()
    {
        resultEnd = false;
        gotMonster = new List<int>();
        _playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        StartCoroutine("ResultImage", 0.5f);
    }

    void Update()
    {
        ToTitle();
    }

    /// <summary>
    /// 剥がしたモンスターの画像生成
    /// </summary>
    /// <returns></returns>
    IEnumerator ResultImage()
    {
        gotMonster.AddRange(_playerData.gotMonster);
        for (int i = 0; i < gotMonster.Count; i++)
        {
            Instantiate(_monsterImage[gotMonster[i]], _imagePos[i], Quaternion.identity, _transform);
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
        resultEnd = true;
    }

    /// <summary>
    /// タイトルへ移動
    /// </summary>
    private void ToTitle()
    {
        if (!resultEnd)
            return;

        if (Input.touchCount > 0)
        {
            SceneManager.LoadScene(0);
            _playerData.ResetData();
        }
    }
}
