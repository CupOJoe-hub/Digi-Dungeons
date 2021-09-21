using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    public Transform camera;
    public Vector3 offset;
    public float smoothTime;

    private void FixedUpdate() {
        Vector3 finalPos = followTarget.position + offset;

        camera.position = Vector3.Lerp(camera.position, finalPos, smoothTime);
    }
}
