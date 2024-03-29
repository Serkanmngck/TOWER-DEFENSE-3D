using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCameraController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float smoothTime = 0.1f;
    public float maxX = 10f;
    public float minX = -10f;

    private float currentSpeed = 0f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            float delta = touch.deltaPosition.y;

            if (touch.position.x > Screen.width / 2)
            {
                MoveForward(delta);
            }
            else if (touch.position.x < Screen.width / 2)
            {
                MoveBackward(delta);
            }
        }
    }

    void MoveForward(float delta)
    {
        currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed * delta, smoothTime);
        float newPosition = Mathf.Clamp(transform.position.z + currentSpeed * Time.deltaTime, minX, maxX);
        transform.position = new Vector3(transform.position.x, transform.position.y, newPosition);
    }

    void MoveBackward(float delta)
    {
        currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed * delta, smoothTime);
        float newPosition = Mathf.Clamp(transform.position.z - currentSpeed * Time.deltaTime, minX, maxX);
        transform.position = new Vector3(transform.position.x, transform.position.y, newPosition);
    }
}