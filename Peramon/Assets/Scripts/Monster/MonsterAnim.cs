using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnim : MonoBehaviour
{
    BaseMonster _baseMonster;
    [SerializeField]float _randomRange = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _baseMonster = transform.GetChild(0).gameObject.GetComponent<BaseMonster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_baseMonster.isSpecial == true)
        {
            SpecialAnim();
        }
    }

    void SpecialAnim()
    {
        Vector3 newPos = new Vector3(Random.Range(-_randomRange, _randomRange) * Time.deltaTime, Random.Range(-_randomRange, _randomRange) * Time.deltaTime, Random.Range(-_randomRange, _randomRange) * Time.deltaTime);
        this.gameObject.transform.position += newPos;
    }
}
