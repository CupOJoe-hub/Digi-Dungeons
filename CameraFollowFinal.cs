using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This Script References A Target And Lerps Towards The Location Of The Target Plus A Editor Defined Offset
public class CameraFollow : MonoBehaviour
{
    //These Variables Store The Target, Camera Transform, Camera Offset And Smooth Time
    public Transform followTarget;
    public Transform camera;
    public Vector3 offset;
    public float smoothTime;

    //During The Fixed Update Function Is Where The Camera Lerps To The Target
    private void FixedUpdate() {
        Vector3 finalPos = followTarget.position + offset;

        camera.position = Vector3.Lerp(camera.position, finalPos, smoothTime);
    }
}
