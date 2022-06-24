using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] Transform _rotateTarget;

    Vector3 _previousCameraPosition;

    void Update()
    {
        bool middleMouseButtonPressed = Input.GetMouseButtonDown(2);
        if (middleMouseButtonPressed)
        {
            SetCameraPreviousPosition();
        }

        bool holdingMiddleMouseButton = Input.GetMouseButton(2);
        if (holdingMiddleMouseButton)
        {
            Vector3 cameraDirection = _previousCameraPosition - _camera.ScreenToViewportPoint(Input.mousePosition);

            _camera.transform.position = _rotateTarget.position;

            // viewport coordinates need to be multiplied by 180 to calculate angle

            _camera.transform.Rotate(Vector3.right, cameraDirection.y * 180);
            _camera.transform.Rotate(Vector3.up, -cameraDirection.x * 180, Space.World);

            _camera.transform.Translate(new Vector3(0, 0, -10));

            SetCameraPreviousPosition();
        }


    }
    void SetCameraPreviousPosition()
    {
        _previousCameraPosition = _camera.ScreenToViewportPoint(Input.mousePosition);
    }
}
