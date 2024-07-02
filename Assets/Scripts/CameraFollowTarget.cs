using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void LateUpdate()
    {
        float lastZ = transform.position.z;
        transform.position = new Vector3(target.position.x, target.position.y, lastZ);
    }
}
