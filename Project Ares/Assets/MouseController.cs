using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : Singleton<MouseController>
{
    public float zoomSpeed = 3f;
    public float minOrthSize = 1f;
    public float maxOrthSize = 20f;
    public bool invertScroll = false;

    public Vector3 MousePosition { get; protected set; }
    public Tile TileUnderMouse { get; protected set; }

    private void Update()
    {
        if (lastMousePosition == Vector3.zero)
            lastMousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        HandleTileUnderMouse();

    }

    private void LateUpdate()
    {
        HandleMouseCameraMovement();
        lastMousePosition = Input.mousePosition;

    }

    private Vector3 lastMousePosition;

    private void HandleMouseCameraMovement()
    {
        Transform cam = Camera.main.transform;
        if (Input.GetMouseButton(0))
        {
            cam.Translate(Camera.main.ScreenToWorldPoint(lastMousePosition) - MousePosition);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (invertScroll)
            Camera.main.orthographicSize *= 1 + scroll * zoomSpeed;
        else
            Camera.main.orthographicSize *= 1 - scroll * zoomSpeed;

        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minOrthSize, maxOrthSize);
    }

    private void HandleTileUnderMouse()
    {
        int i = Mathf.RoundToInt(MousePosition.x);
        int j = Mathf.RoundToInt(MousePosition.y);
        TileUnderMouse = WorldController.Instance.GetTileAt(i, j);
    }
}
