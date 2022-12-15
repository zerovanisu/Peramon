using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class SpeciaMonster : MonoBehaviour
{
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.ID)
        {
            #region 剥がす方向が決まっているモンスター
            case 1:


                break;
            #endregion

            #region 逃げ回るモンスター
            case 2:
                //スマホを降ったら
                //
                break;
            #endregion

            #region 動き回っているモンスター
            case 3:


                break;
            #endregion

            #region 隠れているモンスター
            case 4:


                break;
            #endregion
        }
    }
}
