using System.Collections.Generic;
using UnityEngine;
 
//ARFoundation���g�p����ۂɒǉ�����l�[���X�y�[�X
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
 
public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject redCube;//��������I�u�W�F�N�g
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();


    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)�@�@//��ʂɎw���G�ꂽ���ɏ�������
            {
                if (arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;�@�@//Ray��ARPlane���Փ˂��Ƃ����Pose
                    Instantiate(redCube, hitPose.position, hitPose.rotation);�@�@//�I�u�W�F�N�g�̐���
                }
            }
        }
    }


}