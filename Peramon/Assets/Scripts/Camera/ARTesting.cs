using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTesting : MonoBehaviour
{
    [SerializeField] Text text, score;
    [SerializeField] Camera arCamera;
    int m_score = 0;



    void Start()
    {
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    text.text = hitObject.transform.gameObject.name;
                    Destroy(hitObject.transform.gameObject);
                    m_score++;
                    score.text = m_score + "/5";
                }
            }
        }
    }
}
