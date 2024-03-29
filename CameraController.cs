using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float minYAngle = 10f;
    [SerializeField] private float maxYAngle = 80f;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float minZoom = 20f;
    [SerializeField] private float maxZoom = 40f;

    [SerializeField] private Transform cameraTransform; // Kamera transformu

    private float targetZoom; // Hedef zoom de�eri
    private float zoomSmoothSpeed = 5f; // Zoom de�erindeki yumu�ak ge�i� h�z�

    // X ve Z eksen s�n�rlar�
    [SerializeField] private float minX = -100f;
    [SerializeField] private float maxX = 100f;
    [SerializeField] private float minZ = -100f;
    [SerializeField] private float maxZ = 100f;

    private void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        targetZoom = cameraTransform.position.y;
    }

    private void Update()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        ZoomCamera(scrollWheel);

        // Kamera hareketi
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        Vector3 moveAmount = moveDirection * moveSpeed * Time.deltaTime;

        // Yeni kamera pozisyonunu hesapla ve s�n�rla
        Vector3 newPosition = transform.position + moveAmount;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        // Kamera pozisyonunu g�ncelle
        transform.position = newPosition;

        // Yumu�ak ge�i� i�in ZoomCamera fonksiyonunu her frame �a��rma
        ZoomCamera(0f);
    }

    private void ZoomCamera(float scrollInput)
    {
        float currentZoom = cameraTransform.position.y;

        targetZoom -= scrollInput * zoomSpeed;
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);

        currentZoom = Mathf.Lerp(currentZoom, targetZoom, zoomSmoothSpeed * Time.deltaTime);

        Camera.main.fieldOfView = currentZoom;

        Vector3 newPosition = new Vector3(cameraTransform.position.x, currentZoom, cameraTransform.position.z);
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        cameraTransform.position = newPosition;
    }
}