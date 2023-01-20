using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialMonsterTest : MonoBehaviour
{
    private float rayDistance;
    [SerializeField] Camera arCamera;
    private float directionX, directionY;
    private Vector2 startPos, endPos;
    Tearing tearing;
    // Start is called before the first frame update
    void Start()
    {
        rayDistance = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void TouchDetect()
    {
        //ƒ^ƒbƒ`‚ðŽæ“¾
        Touch touch = Input.touches[0];
        Ray ray = arCamera.ScreenPointToRay(touch.position);
        RaycastHit hitObject;
        if (Input.touchCount > 0)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:


                    break;
            }
        }

    }
}
