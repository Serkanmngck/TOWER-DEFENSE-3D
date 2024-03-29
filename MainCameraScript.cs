using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    private bool isRotating;
    private bool isPanning;
    private float velocity;
    private float zoomVelocity;

    private float deltaX = 0f;
    private float deltaY = 0f;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            isRotating = true;
            velocity = 0f;
        }
        else
        {
            isRotating = false;
        }

        if (Input.GetMouseButton(2))
        {
            isPanning = true;
            deltaX = 0f;
            deltaY = 0f;
        }
        else
        {
            isPanning = false;
        }

        if (isRotating == true)
        {
            RotateCameraTarget();
        }
        else if (isPanning == true)
        {
            PanCameraTarget();
        }

        CalculateRotation();
        CalculateZoom();
        CalculatePan();
    }

    void CalculateRotation()
    {
        Vector3 rot = Camera.main.transform.parent.eulerAngles;
        rot.y += velocity;
        Camera.main.transform.parent.eulerAngles = rot;
        velocity = Mathf.Lerp(velocity, 0f, Time.deltaTime * 5f);
    }

    void CalculateZoom()
    {
        if (Camera.main.orthographicSize < 15f)
        {
            Camera.main.orthographicSize = 15f;
            zoomVelocity = 0f;
            return;
        }

        if (Camera.main.orthographicSize > 80f)
        {
            Camera.main.orthographicSize = 80f;
            zoomVelocity = 0f;
            return;
        }

        if (
            Camera.main.orthographicSize + zoomVelocity >= 15f &&
            Camera.main.orthographicSize + zoomVelocity <= 80f
        )
        {
            Camera.main.orthographicSize += zoomVelocity;
        }

        zoomVelocity -= Input.GetAxis("Mouse ScrollWheel") * 2f;
        zoomVelocity = Mathf.Lerp(zoomVelocity, 0f, Time.deltaTime * 5f);
    }

    void CalculatePan()
    {
        if (deltaX < 0)
        {
            Camera.main.transform.parent.Translate(-deltaX, 0, deltaX);
        }

        if (deltaX > 0)
        {
            Camera.main.transform.parent.Translate(-deltaX, 0, deltaX);
        }

        if (deltaY < 0)
        {
            Camera.main.transform.parent.Translate(-deltaY, 0, -deltaY);
        }

        if (deltaY > 0)
        {
            Camera.main.transform.parent.Translate(-deltaY, 0, -deltaY);
        }

        deltaY = Mathf.Lerp(deltaY, 0f, Time.deltaTime * 5f);
        deltaX = Mathf.Lerp(deltaX, 0f, Time.deltaTime * 5f);
    }

    void RotateCameraTarget()
    {
        velocity += Input.GetAxis("Mouse X") * 3f;
    }

    void PanCameraTarget()
    {
        deltaX = Input.GetAxisRaw("Mouse X") * 3f;
        deltaY = Input.GetAxisRaw("Mouse Y") * 3f;
    }
}
