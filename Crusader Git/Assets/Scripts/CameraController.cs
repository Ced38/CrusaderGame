using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;
    Vector3 velocity = Vector3.zero;
    [Range(0,1)]
    public float smoothTime;

    public Vector3 positionOffset;

    [Header("Axis Limitation")]
    public Vector2 xLimit; // x axis limit
    public Vector2 yLimit; // y axis limit

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position + positionOffset;
        //targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y), Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y) - 10);       // if want to set limits
        transform.position = Vector3.SmoothDamp(transform.position,targetPosition, ref velocity, smoothTime);
    }
}
