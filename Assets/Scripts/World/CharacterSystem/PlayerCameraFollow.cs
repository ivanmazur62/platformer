using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour
{
    public float smoothSpeed = 0.125f;

    private Camera _mainCamera;
    private const float FixedZPosition = -10f;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = transform.position;
        desiredPosition.z = FixedZPosition;
        desiredPosition.y = Mathf.Max(desiredPosition.y, 0f);
        
        Vector3 smoothedPosition = Vector3.Lerp(_mainCamera.transform.position, desiredPosition, smoothSpeed);
        
        _mainCamera.transform.position = smoothedPosition;
    }
}