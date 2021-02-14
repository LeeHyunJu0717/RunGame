using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform lookAt;
    public Transform camTransform;

    private void Start()
    {
        camTransform = transform;
    }

    private void LateUpdate()
    {
        camTransform.LookAt(lookAt.position);
    }
}
