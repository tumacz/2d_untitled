using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Camera _mainCam;
    [SerializeField] private Transform _target;

    void Start()
    {
        _mainCam = FindObjectOfType<Camera>();
    }

    void Update()
    {
        float camPosZ = _mainCam.transform.position.z;
        _mainCam.transform.position = new Vector3(_target.position.x, _target.position.y, camPosZ);
    }
}
