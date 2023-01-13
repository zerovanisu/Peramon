using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeManager : MonoBehaviour
{
    private Vector3 Acceleration;
    private Vector3 preAcceleration;
    float DotProduct;
    public static int ShakeCount;

    void Start()
    {
        
    }

    void Update()
    {
        ShakeCheck();
    }

    void ShakeCheck()
    {
        preAcceleration = Acceleration;
        Acceleration = Input.acceleration;
        DotProduct = Vector3.Dot(Acceleration, preAcceleration);
        if (DotProduct < 0)
        {
            ShakeCount++;
        }
    }
}
